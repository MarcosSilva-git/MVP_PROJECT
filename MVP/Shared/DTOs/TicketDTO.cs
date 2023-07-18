using MVP.Infra.Entities;
using MVP.Infra.Enums;
using System.ComponentModel.DataAnnotations;

namespace MVP.Shared.DTOs;

public class TicketDTO
{
    public TicketDTO() { }

    public TicketDTO(Ticket ticket)
    {
        Id = ticket.Id;
        Title = ticket.Title ?? "";
        Description = ticket.Description ?? "";
        StatusId = ticket.StatusId;
        OpeningDate = ticket.OpeningDate;
    }

    public int Id { get; set; }

    [Required(ErrorMessage = "*Campo obrigatório.")]
    [StringLength(250, ErrorMessage = "O título não pode ultrapassar 250 caracteres.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "*Campo obrigatório.")]
    [StringLength(250, ErrorMessage = "A Descrição não pode ultrapassar 250 caracteres.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "*Campo obrigatório")]
    public int StatusId { get; set; }
    public string StatusName { get => ((TicketStatusEnum)StatusId).ToString(); }
    public DateTime OpeningDate { get; set; }
}
