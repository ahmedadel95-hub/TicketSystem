using Application.Tickets.GetTickets;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Persistence.Repositories;

namespace Persistence.Queries;
public sealed class GetTicketsPagingListQueryHandler : IRequestHandler<GetTicketsPagingListQuery, List<TicketResponse>>
{
    private readonly TicketRepository _ticketRepository;
    public GetTicketsPagingListQueryHandler(ApplicationDbContext dbContext)
    {
        _ticketRepository = new TicketRepository(dbContext);
    }

    public async Task<List<TicketResponse>> Handle(GetTicketsPagingListQuery request, CancellationToken cancellationToken)
    {
        var query = _ticketRepository.GetAsync(filter: t => !t.Deleted, orderBy: t => t.OrderBy(t => t.CreatedAt)
          , includeProperties: "Governorate,City,District"
          , pageSize: request.pageSize, pageNumber: request.pageNumber);

        return await query.Select(t => new TicketResponse()
        {
            Id = t.TicketGuid,
            Governorate = t.Governorate != null ? request.lang.Equals("ar") ? t.Governorate.ArName : t.Governorate.EnName : string.Empty,
            City = t.City != null ? request.lang.Equals("ar") ? t.City.ArName : t.City.EnName : string.Empty,
            District = t.District != null ? request.lang.Equals("ar") ? t.District.ArName : t.District.EnName : string.Empty,
            IsHandled = t.IsHandled,
            Color = Enum.GetName(typeof(TicketColorEnum), t.Color)
        }).ToListAsync(cancellationToken: cancellationToken);
    }
}
