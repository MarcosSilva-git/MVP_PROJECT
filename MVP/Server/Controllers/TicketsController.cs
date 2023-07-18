using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using MVP.Infra.Context;
using MVP.Infra.Entities;
using MVP.Server.Controllers.Generics;
using MVP.Shared.DTOs;
using MVP.Shared.Services;
using System.IO;

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

    [HttpGet("GetAllTickets")]
    public async Task<ActionResult<List<TicketDTO>>> GetAllTickets()
    {
        var tickets = await TicketService.GetAllTickets();
        return Ok(tickets.Select(t => new TicketDTO(t)));
    }

    [HttpGet("TicketStatus")]
    public OkObjectResult TicketStatus()
    {
        var ticketStatus = HelpDeskContext.TicketStatus.ToArray();

        return Ok(ticketStatus);
    }

    [HttpPost("Create")]
    public ActionResult<TicketDTO> Create(TicketDTO ticket)
    {
        var newTicket = TicketService.CreateNewTicket(ticket);
        return Ok(new TicketDTO(newTicket));
    }

    [HttpPut("Update")]
    public async Task<ActionResult<TicketDTO>> Update(TicketDTO ticket)
    {
        try
        {
            var updatedTicket = await TicketService.UpdateTicket(ticket);
            return Ok(new TicketDTO(updatedTicket));
        }
        catch (KeyNotFoundException e)
        {
            _logger.LogInformation(e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
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

    [HttpPost("ExportToExcel")]
    public FileResult ExportToExcel(List<TicketDTO> tickets)
    {
        var excelWorkBook = new XLWorkbook();
        var sheet = excelWorkBook.Worksheets.Add("Data");

        var row = 1;
        foreach (var ticket in tickets)
        {
            if (ticket == tickets[0])
            {
                sheet.Cell(row, 1).Value = "Id";
                sheet.Cell(row, 2).Value = "Title";
                sheet.Cell(row, 3).Value = "Description";
                sheet.Cell(row, 4).Value = "Status Id";
                sheet.Cell(row, 5).Value = "Status Name";
                sheet.Cell(row, 6).Value = "Opening Date";

                row++;
            }

            sheet.Cell(row, 1).Value = ticket.Id;
            sheet.Cell(row, 2).Value = ticket.Title;
            sheet.Cell(row, 3).Value = ticket.Description;
            sheet.Cell(row, 4).Value = ticket.StatusId;
            sheet.Cell(row, 5).Value = ticket.StatusName;
            sheet.Cell(row, 6).Value = ticket.OpeningDate.ToString("d");

            row++;
        }

        var firstRow = sheet.FirstRowUsed();

        firstRow.Style.Font.Bold = true;
        firstRow.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        sheet.Columns().AdjustToContents();

        var stream = new MemoryStream();
        excelWorkBook.SaveAs(stream);

        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", string.Empty);
    }
}
