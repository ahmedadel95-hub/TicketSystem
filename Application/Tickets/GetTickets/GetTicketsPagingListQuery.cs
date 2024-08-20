using MediatR;

namespace Application.Tickets.GetTickets;

public sealed record GetTicketsPagingListQuery(int? pageSize, int? pageNumber = 1, string lang = "en") : IRequest<List<TicketResponse>>;
