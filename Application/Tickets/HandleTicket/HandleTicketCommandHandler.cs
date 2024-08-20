using Domain.Enums;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tickets.HandleTicket
{
    public class HandleTicketCommandHandler : IRequestHandler<HandleTicketCommand, bool>
    {
        private readonly ITicketRepository _ticketRepository;

        public HandleTicketCommandHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public async Task<bool> Handle(HandleTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketRepository.GetFirstAsync(t => !t.Deleted && !t.IsHandled && t.TicketGuid == request.ticketGuid);

            if (ticket == null)
            {
                return false;
            }

            ticket.IsHandled = true;
            ticket.Color = (int)TicketColorEnum.Red;
            var updateProcess = await _ticketRepository.UpdateAsync(ticket);

            return updateProcess == 1;
        }
    }
}
