using Microsoft.AspNetCore.Mvc;
using MVP.Infra.Context;
using MVP.Infra.Entities;
using MVP.Server.Controllers.Generics;
using MVP.Shared.DTOs.Tickets;
using MVP.Shared.Services;

namespace MVP.Server.Controllers;

public class TicketsController : HelpDeskControllerBase
{
    TicketService TicketService;
    ILogger<TicketsController> _logger;

    public TicketsController(HelpDeskContext helpDeskContext, 
        TicketService ticketService,
        ILogger<TicketsController> logger) : base(helpDeskContext)
    {
        TicketService = ticketService;
        _logger = logger;
    }

    [HttpPost]
    public ActionResult<TicketDTO> Create(TicketDTO ticket)
    {
        var newTicket = TicketService.CreateNewTicket(ticket);
        return Ok(new TicketDTO(newTicket));
    }

    [HttpGet("GetAllTickets")]
    public async Task<ActionResult<TicketDTO>> GetAllTickets() 
    { 
        var tickets = await TicketService.GetAllTickets();
        return Ok(tickets.Select(t => new TicketDTO(t)));
    }

    [HttpDelete]
    public ActionResult<TicketDTO> Delete(int id)
    {
        try
        {
            var deletedTicket = TicketService.DeleteTicket(id);
            return Ok(new TicketDTO(deletedTicket));
        }
        catch (KeyNotFoundException e)
        {
            _logger.LogInformation(e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpGet("TicketStatus")]
    public OkObjectResult TicketStatus()
    {
        var ticketStatus = HelpDeskContext.TicketStatus
            .Select(ts => new { ts.Id, Name = ts.Name.ToString() })
            .ToArray();

        return Ok(ticketStatus);
    }
}
