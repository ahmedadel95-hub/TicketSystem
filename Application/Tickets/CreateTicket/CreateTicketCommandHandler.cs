using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using MediatR;

namespace Application.Tickets.CreateTicket;

internal sealed class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, uint?>
{
    private readonly ITicketRepository _ticketRepository;

    public CreateTicketCommandHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<uint?> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = new Ticket
        {
            TicketGuid = Guid.NewGuid(),
            PhoneNumber = request.PhoneNumber,
            GovernorateId = request.GovernorateId,
            CityId = request.CityId,
            DistrictId = request.DistrictId,
            IsHandled = false,
            Color = (int)TicketColorEnum.Yellow
        };

        var addedTicked = await _ticketRepository.AddAsync(ticket);
        return addedTicked?.Id;
    }
}