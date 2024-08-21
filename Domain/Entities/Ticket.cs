using Domain.Enums;

namespace Domain.Entities;

public class Ticket
{
    public Ticket()
    {
        Status = (int)TicketStatus.New;
    }
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public string PhoneNumber { get; set; }
    public string Governorate { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public TicketStatus Status { get; set; }

    public TicketColor Color { get; set; }

    public TicketColor CalculateTicketColor()
    {
        var timeElapsed = DateTime.UtcNow - CreationDate;

        if (timeElapsed.TotalMinutes < 15)
            return TicketColor.Yellow;
        else if (timeElapsed.TotalMinutes < 30)
            return TicketColor.Green;
        else if (timeElapsed.TotalMinutes < 45)
            return TicketColor.Blue;
        else
            return TicketColor.Red;
    }
}
