using Application.MediatR.Tickets.Commands.Requests;
using FluentValidation;

namespace Application.MediatR.Tickets.Commands.Validations
{
    public class HandleTicketCommandValidator : AbstractValidator<HandleTicketCommand>
    {
        public HandleTicketCommandValidator()
        {
            RuleFor(x => x.TicketId)
                .GreaterThan(0).WithMessage("Ticket ID must be greater than 0");
        }
    }

}
