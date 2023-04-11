using Microsoft.EntityFrameworkCore;
using RouteProviders.Application.Extensions;
using RouteProviders.Persistence.DataAccess.Extensions;
using RouteProviders.Persistence.DataAccess.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddPersistence(o => o.UseLazyLoadingProxies().UseSqlite("Data Source=RP.db"));
builder.Services.AddApplication();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddResponseCaching();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
    app.UseSwagger();

    using (IServiceScope scope = app.Services.CreateScope())
    {
        await SeedingHelper.SeedData(scope);
    }
}

app.UseResponseCaching();
app.MapControllers();
app.Run();