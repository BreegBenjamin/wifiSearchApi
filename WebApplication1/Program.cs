using Microsoft.EntityFrameworkCore;
using WiFiSharing.Application.Interfaces;
using WiFiSharing.Infrastructure.DataAccess;
using WiFiSharing.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//services scope
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IAdminRepository, AdminRepository>();
builder.Services.AddTransient<IReportRepository, ReportRepository>();
builder.Services.AddTransient<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddTransient<IReputationRepository, ReputationRepository>();
builder.Services.AddTransient<IWiFiNetworkRepository, WiFiNetworkRepository>();

//external Services
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//DbContext Services
builder.Services.AddDbContext<WifiSearchContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WifiSearch")));

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

app.Run();
