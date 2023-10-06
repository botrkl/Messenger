using FlashApp.DAL.Context;
using FlashApp.DAL.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InjectDALServices(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<MessengerDbContext>();
        Initializer.Initialize(context);
    }
    catch (Exception)
    {
        throw;
    }
}

app.Run();
