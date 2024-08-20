using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tickets.HandleTicket
{
    public sealed record HandleTicketCommand(Guid ticketGuid) : IRequest<bool>;
}
