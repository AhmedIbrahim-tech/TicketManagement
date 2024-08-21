using Application.MediatR.Tickets.Commands.Requests;
using Application.MediatR.Tickets.Queries.Requests;
using Domain.BaseResponse;
using Domain.DTOS;
using Domain.Entities;
using Domain.Pagination;

namespace Application.Interfaces;

public interface ITicketService
{
    Task<GenericBaseResponse<PaginationResult<TicketDto>>> GetTicketsAsync(GetTicketsQuery query);
    Task<GenericBaseResponse<int>> CreateTicketAsync(CreateTicketCommand command);
    Task<GenericBaseResponse<string>> HandleTicketAsync(int ticketId);
    Task<GenericBaseResponse<string>> UpdateTicketAsync(Ticket ticket);
    Task UpdateTicketStatusesAsync();

}
