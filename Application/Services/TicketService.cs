﻿using Application.Interfaces;
using Application.MediatR.Tickets.Commands.Requests;
using Application.MediatR.Tickets.Queries.Requests;
using AutoMapper;
using Domain.BaseResponse;
using Domain.DTOS;
using Domain.Entities;
using Domain.Enums;
using Domain.Pagination;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.Services;

public class TicketService : ITicketService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TicketService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }



    public async Task<GenericBaseResponse<PaginationResult<TicketDto>>> GetTicketsAsync(GetTicketsQuery query)
    {
        var tickets = await _unitOfWork.Tickets.GetPagedTicketsAsync(query.PageNumber, query.PageSize);
        var totalTickets = await _unitOfWork.Tickets.GetAll().CountAsync();
        var ticketDtos = _mapper.Map<List<TicketDto>>(tickets);

        var paginationResult = PaginationResult<TicketDto>.Success(ticketDtos, totalTickets, query.PageNumber, query.PageSize);

        return new(true, StatusCodes.Status200OK, "Data Loading successfully", paginationResult);

    }

    public async Task<GenericBaseResponse<int>> CreateTicketAsync(CreateTicketCommand command)
    {
        var ticket = _mapper.Map<Ticket>(command);
        ticket.CreationDate = DateTime.UtcNow;
        ticket.Status = TicketStatus.New;

        using var transaction = _unitOfWork.BeginTransaction();
        try
        {
            await _unitOfWork.Tickets.AddAsync(ticket);
            await _unitOfWork.SaveChangesAsync();
            transaction.Commit();
            return new(true, StatusCodes.Status200OK, "created successfully");
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            return new(false, StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    public async Task<GenericBaseResponse<string>> HandleTicketAsync(int ticketId)
    {
        var ticket = await _unitOfWork.Tickets.GetByIdAsync(ticketId);
        if (ticket == null)
        {
            return new(false, StatusCodes.Status404NotFound, "Ticket not found");
        }

        ticket.Status = TicketStatus.Handled;

        using var transaction = _unitOfWork.BeginTransaction();
        try
        {
            await _unitOfWork.Tickets.UpdateAsync(ticket);
            await _unitOfWork.SaveChangesAsync();
            transaction.Commit();
            return new(true, StatusCodes.Status200OK, "Ticket handled successfully");
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            return new(false, StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    public async Task UpdateTicketStatusesAsync()
    {
        var tickets = await _unitOfWork.Tickets.GetAll().ToListAsync();
        var currentTime = DateTime.UtcNow;
        var tasks = new List<Task>();

        foreach (var ticket in tickets)
        {
            var timeElapsed = currentTime - ticket.CreationDate;

            if (timeElapsed.TotalMinutes >= 30 && ticket.Status == TicketStatus.New)
            {
                ticket.Status = TicketStatus.InProgress;
                tasks.Add(UpdateTicketAsync(ticket));

            }
            if (timeElapsed.TotalMinutes >= 60 && ticket.Status != TicketStatus.Handled)
            {
                ticket.Status = TicketStatus.Handled;
                tasks.Add(UpdateTicketAsync(ticket));
            }
            else if (timeElapsed.TotalDays >= 7 && ticket.Status == TicketStatus.Handled)
            {
                ticket.Status = TicketStatus.Closed;
                tasks.Add(UpdateTicketAsync(ticket));
            }
        }

        await Task.WhenAll(tasks);

    }

    public async Task<GenericBaseResponse<string>> UpdateTicketAsync(Ticket ticket)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        try
        {
            await _unitOfWork.Tickets.UpdateAsync(ticket);
            await _unitOfWork.SaveChangesAsync();
            transaction.Commit();
            return new(true, StatusCodes.Status200OK, "updated successfully");
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            return new(false, StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

}
