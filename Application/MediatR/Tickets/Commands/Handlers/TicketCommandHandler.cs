using Application.Interfaces;
using Application.MediatR.Tickets.Commands.Requests;
using AutoMapper;
using Domain.BaseResponse;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.Tickets.Commands.Handlers;

public class TicketCommandHandler : IRequestHandler<CreateTicketCommand, GenericBaseResponse<int>>,
                                    IRequestHandler<HandleTicketCommand, GenericBaseResponse<string>>
{
    private readonly ITicketService _ticketService;
    private readonly IMapper _mapper;

    public TicketCommandHandler(ITicketService ticketService, IMapper mapper)
    {
        _ticketService = ticketService;
        _mapper = mapper;
    }

    public async Task<GenericBaseResponse<int>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = _mapper.Map<Ticket>(request);
        return await _ticketService.CreateTicketAsync(request);
    }


    public async Task<GenericBaseResponse<string>> Handle(HandleTicketCommand request, CancellationToken cancellationToken)
    {
        return await _ticketService.HandleTicketAsync(request.TicketId);
    }

}
