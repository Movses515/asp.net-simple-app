using Demo.Bll.Interfaces;
using Demo.Bll.Services;
using Demo.Core.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration["ConnectionsStrings:DefaultConnection"];

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 30))));

builder.Services.AddScoped<IUserService, UserService>();
builder.WebHost.UseUrls("http://0.0.0.0:8080");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Health check OK");
app.Run();
