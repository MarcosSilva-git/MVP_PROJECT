using MVP.Infra.Entities;
using MVP.Infra.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace MVP.Shared.DTOs.Tickets;

public class TicketDTO
{
    public TicketDTO() { }

    public TicketDTO(Ticket ticket)
    {
        Id = ticket.Id;
        Title = ticket.Title;
        Description = ticket.Description;
        StatusId = ticket.StatusId;
    }

    public int Id { get; set; }

    [MaxLength(250, ErrorMessage = "O título não pode ultrapassar 250 caracteres.")]
    public string Title { get; set; }

    [MaxLength(250, ErrorMessage = "A Descrição não pode ultrapassar 250 caracteres.")]
    public string Description { get; set; }

    public int StatusId { get; set; }
}
