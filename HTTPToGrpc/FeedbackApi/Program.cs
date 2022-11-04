using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FeedbackApi.Data;
using FeedbackApi.Data.Repositories;
using FeedbackApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FeedbacksDbContext>(options =>
{
    //    options.UseLazyLoadingProxies();
    options.UseSqlServer(builder.Configuration.GetConnectionString("Feedbacks"));
    options.EnableSensitiveDataLogging();
});

builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
    {
        serviceScope.ServiceProvider.GetService<FeedbacksDbContext>().Database.EnsureCreated();
        serviceScope.ServiceProvider.GetService<FeedbacksDbContext>().EnsureSeedData();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
