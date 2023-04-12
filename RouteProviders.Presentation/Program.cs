using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using RouteProviders.Application.Extensions;
using RouteProviders.Persistence.DataAccess.Extensions;
using RouteProviders.Persistence.DataAccess.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddPersistence(o => o.UseLazyLoadingProxies().UseSqlite("Data Source=RP.db"));
builder.Services.AddApplication();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (IServiceScope scope = app.Services.CreateScope())
    {
        await SeedingHelper.SeedData(scope);
    }
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();