using Domain.DTOS;
using Domain.Entities;
using Domain.Pagination;
using MediatR;

namespace Application.MediatR.Tickets.Queries.Requests
{
    public class GetTicketsQuery : BasePaginationDto, IRequest<PaginationResult<TicketDto>>
    {
    }
}
