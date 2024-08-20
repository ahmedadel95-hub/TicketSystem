namespace Api.Endpoints;

public class CreateTicketRequest
{
    public string PhoneNumber { get; set; }
    public uint? GovernorateId { get; set; }
    public uint? CityId { get; set; }
    public uint? DistrictId { get; set; }
}