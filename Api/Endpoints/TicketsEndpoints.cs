using Application.Tickets.CreateTicket;
using Application.Tickets.GetTickets;
using MediatR;
using Application.Tickets.HandleTicket;

namespace Api.Endpoints;

public static class TicketsEndpoints
{
    public static void MapTicketEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/tickets/create", async (CreateTicketRequest request, ISender sender) =>
        {
            var ticketId = await sender.Send(new CreateTicketCommand(request.PhoneNumber, request.GovernorateId
                , request.CityId, request.DistrictId));

            return Results.Ok(ticketId);
        });

        app.MapPost("api/tickets/get", async (GetTicketsRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetTicketsPagingListQuery(request.PageSize, request.PageNumber, request.Lang));

            return result is null ? Results.NotFound() : Results.Ok(result);
        });

        app.MapPut("api/tickets/handleTicket/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new HandleTicketCommand(id));

            return Results.Ok(result);
        });
    }
}
