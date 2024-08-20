using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
namespace Persistence.Repositories;

public sealed class TicketRepository : GenericRepository<Ticket>, ITicketRepository
{
    public TicketRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}
