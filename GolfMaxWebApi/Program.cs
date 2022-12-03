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
builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddScoped<IUserMapper, UserMapper>();
builder.Services.AddScoped<ICourseMapper, CourseMapper>();

builder.Services.AddScoped<GolfMaxDataAccessor>();


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

