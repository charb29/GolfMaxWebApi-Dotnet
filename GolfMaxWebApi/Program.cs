using GolfMaxWebApi.DataAccess;
using GolfMaxWebApi.Models.Mappers.Implementations;
using GolfMaxWebApi.Models.Mappers.Interfaces;
using GolfMaxWebApi.Repositories.Implementations;
using GolfMaxWebApi.Repositories.Interfaces;
using GolfMaxWebApi.Services.Implementations;
using GolfMaxWebApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserMapper, UserMapper>();
builder.Services.AddScoped<GolfMaxDataAccessor>();


var app = builder.Build();

using var scope = app.Services.CreateScope();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

