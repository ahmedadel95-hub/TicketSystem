using Api.Endpoints;
using Application.BackgroundServices;
using Application.Tickets.CreateTicket;
using Application.Tickets.GetTickets;
using Application.Tickets.HandleTicket;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(CreateTicketCommand).Assembly,
    typeof(ApplicationDbContext).Assembly));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(GetTicketsPagingListQuery).Assembly,
    typeof(ApplicationDbContext).Assembly));


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(HandleTicketCommand).Assembly,
    typeof(ApplicationDbContext).Assembly));

builder.Services.AddScoped<ITicketRepository, TicketRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));

builder.Services.AddHostedService<TicketStatusUpdateJob>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.ApplyMigrations();
}

app.MapTicketEndpoints();
app.UseHttpsRedirection();
app.Run();
