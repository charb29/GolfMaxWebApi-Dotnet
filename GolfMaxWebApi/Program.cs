using GolfMaxWebApi.Context;
using GolfMaxWebApi.Models.Mappers.Implementations;
using GolfMaxWebApi.Models.Mappers.Interfaces;
using GolfMaxWebApi.Repositories.Implementations;
using GolfMaxWebApi.Repositories.Interfaces;
using GolfMaxWebApi.Services.Implementations;
using GolfMaxWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SqlConnection");

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserMapper, UserMapper>();
builder.Services.AddScoped<GolfMaxDbContext>();

builder.Services.AddDbContext<GolfMaxDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version()),
        mySqlActions => mySqlActions.EnableRetryOnFailure())
);

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dataContext = scope.ServiceProvider.GetRequiredService<GolfMaxDbContext>();

dataContext.Database.EnsureCreated();
dataContext.Database.Migrate();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
app.Run();
