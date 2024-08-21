using API.AppMetaData;
using Application.Interfaces;
using Application.MediatR.Tickets.Commands.Requests;
using Application.MediatR.Tickets.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TicketManagement.Controllers;

[ApiController]
public class TicketController : ControllerBase
{
    private readonly IMediator _mediator;

    public TicketController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Router.Ticket.Search)]
    public async Task<IActionResult> GetTickets([FromQuery] GetTicketsQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost(Router.Ticket.Create)]
    public async Task<IActionResult> CreateTicket([FromBody] CreateTicketCommand command)
    {
        var result = await _mediator.Send(command);
        return StatusCode(result.StatusCode , result);
    }


    [HttpPost(Router.Ticket.HandleTicket)]
    public async Task<IActionResult> HandleTicket([FromBody] HandleTicketCommand command)
    {
        var result = await _mediator.Send(command);
        return StatusCode(result.StatusCode, result);
    }


}
