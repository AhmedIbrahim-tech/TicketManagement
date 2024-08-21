using Application.Interfaces;
using Application.MediatR.Tickets.Queries.Requests;
using Domain.DTOS;
using Domain.Entities;
using Domain.Pagination;
using MediatR;

namespace Application.MediatR.Tickets.Queries.Handlers
{
    public class GetTicketsQueryHandler : IRequestHandler<GetTicketsQuery, PaginationResult<TicketDto>>
    {
        private readonly ITicketService _ticketService;

        public GetTicketsQueryHandler(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public async Task<PaginationResult<TicketDto>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
        {
            var ticketsResponse = await _ticketService.GetTicketsAsync(request);
            return ticketsResponse.Data;
        }

    }

}
