using MediatR;

namespace Application.Tickets.CreateTicket;

public sealed record CreateTicketCommand(string PhoneNumber, uint? GovernorateId, uint? CityId, uint? DistrictId)
    : IRequest<uint?>;