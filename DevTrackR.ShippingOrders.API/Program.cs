using DevTrackR.ShippingOrders.Application;
using DevTrackR.ShippingOrders.Infra;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddInfrastructure()
    .AddApplication();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
