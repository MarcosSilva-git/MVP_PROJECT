using Microsoft.EntityFrameworkCore;
using MVP.Infra.Context;
using MVP.Infra.Entities;
using MVP.Shared.DTOs.Tickets;
using MVP.Shared.Services.Generics;
using System.Reflection.Metadata.Ecma335;

namespace MVP.Shared.Services;

public class TicketService : IHelpDeskService
{
    HelpDeskContext HelpDeskContext;

    public TicketService(HelpDeskContext helpDeskContext)
    {
        HelpDeskContext = helpDeskContext;
    }

    public async Task<IEnumerable<Ticket>> GetAllTickets()
    {
        var tickets = await HelpDeskContext.Tickets.ToListAsync();

        return tickets;
    }

    public Ticket CreateNewTicket(TicketDTO ticket)
    {
        var newTicket = new Ticket()
        {
            Title = ticket.Title,
            StatusId = ticket.StatusId,
            Description = ticket.Description,
        };

        HelpDeskContext.Tickets.Add(newTicket);
        HelpDeskContext.SaveChanges();

        return newTicket;
    }

    public Ticket DeleteTicket(int id)
    {
        var ticket = HelpDeskContext.Tickets.Where(t  => t.Id == id).FirstOrDefault();

        if (ticket == null)
            throw new KeyNotFoundException("Nenhum ticket foi encontrado.");

        var deletedTicket = HelpDeskContext.Tickets.Remove(ticket).Entity;
        HelpDeskContext.SaveChanges();

        return deletedTicket;
    }
}
