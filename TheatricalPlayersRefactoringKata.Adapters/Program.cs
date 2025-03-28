using Microsoft.EntityFrameworkCore;
using TheatricalPlayersRefactoringKata.Adapters.Infra.Database.Persistence;
using TheatricalPlayersRefactoringKata.Adapters.InQueue;
using TheatricalPlayersRefactoringKata.Application.Services;
using TheatricalPlayersRefactoringKata.Domain.Ports;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=invoice.db"));

builder.Services.AddScoped<IInvoiceProcessor, InvoiceProcessor>();
builder.Services.AddSingleton<IInvoiceQueue, InMemoryInvoiceQueue>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();