using FeedbackApi.Data;
using FeedbackApi.Data.Repositories;
using FeedbackGrpc.Infrastructure.Mappings;
using FeedbackGrpc.Services;
using Google.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.


builder.Services.AddDbContext<FeedbacksDbContext>(options =>
{
    //    options.UseLazyLoadingProxies();
    options.UseSqlServer(builder.Configuration.GetConnectionString("Feedbacks"));
    options.EnableSensitiveDataLogging();
});

builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddGrpc().AddJsonTranscoding();
builder.Services.AddGrpcReflection();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(FeedbackMappings));

builder.Services.AddGrpcSwagger();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My transformed API V1");
});

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<FeedbackService>();
IWebHostEnvironment env = app.Environment;

if (env.IsDevelopment())
{
    app.MapGrpcReflectionService();
}
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
