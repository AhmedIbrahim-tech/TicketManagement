using Domain.Enums;

namespace Domain.Entities;

public class Ticket
{
    public Ticket()
    {
        Status = (int)TicketStatus.New;
        CreationDate = DateTime.Now;
    }
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public string PhoneNumber { get; set; }
    public string Governorate { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public TicketStatus Status { get; set; }
    public TicketColor Color => CalculateTicketColor();
    private TicketColor CalculateTicketColor()
    {
        var timeElapsed = (DateTime.UtcNow - CreationDate).TotalMinutes;

        if (timeElapsed < 15)
            return TicketColor.Yellow;

        if (timeElapsed < 30)
            return TicketColor.Green;
        
        if (timeElapsed < 45)
            return TicketColor.Blue;

        return TicketColor.Red;
    }

}
