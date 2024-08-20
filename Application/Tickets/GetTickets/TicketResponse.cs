namespace Application.Tickets.GetTickets;

public class TicketResponse
{
    public Guid Id { get; set; }
    public string Governorate { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public bool IsHandled { get; set; }
    public string Color { get; set; }
}