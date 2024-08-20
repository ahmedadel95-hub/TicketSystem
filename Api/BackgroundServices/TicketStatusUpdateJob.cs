using Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using System.Net.Sockets;

namespace Application.BackgroundServices
{
    public class TicketStatusUpdateJob : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public TicketStatusUpdateJob(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    var tickets = await context.Tickets.Where(t => !t.Deleted).ToListAsync();

                    tickets.ForEach(t =>
                    {
                        UpdateTicketStatusAndColor(t);
                    });
                    await context.SaveChangesAsync();
                }
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }

        private void UpdateTicketStatusAndColor(Ticket ticket)
        {
            var ageInMinutes = (DateTime.UtcNow - ticket.CreatedAt).TotalMinutes;

            ticket.Color = (int)TicketColorEnum.Yellow;

            if (ageInMinutes >= 60)
            {
                ticket.IsHandled = true;
                ticket.Color = (int)TicketColorEnum.Red;
            }
            else if (ageInMinutes >= 45)
            {
                ticket.Color = (int)TicketColorEnum.Blue;
            }
            else if (ageInMinutes >= 30)
            {
                ticket.Color = (int)TicketColorEnum.Green;
            }
            else if (ageInMinutes >= 15)
            {
                ticket.Color = (int)TicketColorEnum.Yellow;
            }
        }
    }
}
