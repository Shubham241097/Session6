using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Session6.AppDbContext;
using Session6.HealthChecks;
using Session6.Models;
using Session6.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string con = builder.Configuration.GetConnectionString("LocalConnectionPath");
builder.Services.AddDbContext<ProductDbContext>(p => p.UseSqlServer(con));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adding HealthChecks
builder.Services
        .AddHealthChecks()
        .AddCheck<CustomHealthCheck>(nameof(CustomHealthCheck));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/healthcheck", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse

} );
app.MapHealthChecksUI();

app.Run();
