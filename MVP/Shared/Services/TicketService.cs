using Microsoft.EntityFrameworkCore;
using MVP.Infra.Context;
using MVP.Infra.Entities;
using MVP.Shared.DTOs.Tickets;
using MVP.Shared.Services.Generics;
using System.Runtime.InteropServices;

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

    private Ticket GetTicketById(int id)
    {
        var ticket = HelpDeskContext.Tickets.Where(t => t.Id == id).FirstOrDefault();

        if (ticket == null)
            throw new KeyNotFoundException("Nenhum ticket foi encontrado.");

        return ticket;
    }

    public Ticket CreateNewTicket(TicketDTO ticket)
    {
        var newTicket = new Ticket()
        {
            Title = ticket.Title,
            StatusId = ticket.StatusId,
            Description = ticket.Description,
        };

        var addedTicket = HelpDeskContext.Tickets.Add(newTicket).Entity;
        HelpDeskContext.SaveChanges();

        return addedTicket;
    }

    public Ticket DeleteTicket(int id)
    {
        var ticket = GetTicketById(id);

        HelpDeskContext.Tickets.Remove(ticket);
        HelpDeskContext.SaveChanges();

        return ticket;
    }

    public async Task<Ticket> UpdateTicket(TicketDTO ticket)
    {
        var findedTicket = GetTicketById(ticket.Id);

        findedTicket.Title = ticket.Title;
        findedTicket.Description = ticket.Description;
        findedTicket.StatusId = ticket.StatusId;

        HelpDeskContext.SaveChanges();

        return findedTicket;
    }
}
