using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Web_Api_P1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DATA BASE CONNECTION LINE and memory
//builder.Services.AddDbContext<Contact_Api_Db>(opt =>
//opt.UseInMemoryDatabase("ContactData"));
builder.Services.AddDbContext<Contact_Api_Db>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("ContactData")));


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
