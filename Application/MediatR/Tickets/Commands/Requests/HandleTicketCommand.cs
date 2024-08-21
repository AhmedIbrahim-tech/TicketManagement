using Domain.BaseResponse;
using MediatR;

namespace Application.MediatR.Tickets.Commands.Requests
{
    public class HandleTicketCommand : IRequest<GenericBaseResponse<string>>
    {
        public int TicketId { get; set; }
    }

}
