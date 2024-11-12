using Macrix.Database;
using MacrixPoc.Services;
using MacrixPoc.User.Application.Builder;
using MacrixPoc.User.Application.Command.UserCreate;
using MacrixPoc.User.Application.Facade;
using MacrixPoc.User.Contracts;
using MacrixPoc.User.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserFacade, UserFacade>();
builder.Services.AddScoped<IAgeBuilder, AgeBuilder>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddCors(options =>
    options.AddPolicy("AllowSpecificOrigin" , build => 
        build.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod())
);

builder.Services.AddMediatR(
    options => options.RegisterServicesFromAssembly(typeof(UserCreateCommand).Assembly));
//builder.Services.AddHostedService<StartupTask>();
builder.Services.AddDbContext<MacrixContext>(
    options =>
        options.UseNpgsql(
            builder.Configuration.GetConnectionString("MacrixDatabase")));
var app = builder.Build();

app.UseCors("AllowSpecificOrigin");
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
    app.UseAuthorization();
app.MapControllers();
app.Run();