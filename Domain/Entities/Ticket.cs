using Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Ticket : TrackedEntity<uint>
{
    public required Guid TicketGuid { get; set; }
    public required string PhoneNumber { get; set; }
    public uint? GovernorateId { get; set; }
    public uint? CityId { get; set; }
    public uint? DistrictId { get; set; }
    public bool IsHandled { get; set; } = false;
    public int Color { get; set; }
    public virtual Governorate Governorate { get; set; }
    public virtual City City { get; set; }
    public virtual District District { get; set; }
}
