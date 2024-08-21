using Domain.BaseResponse;
using MediatR;

namespace Application.MediatR.Tickets.Commands.Requests
{
    public class CreateTicketCommand : IRequest<GenericBaseResponse<int>>
    {
        public string PhoneNumber { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string District { get; set; }
    }

}
