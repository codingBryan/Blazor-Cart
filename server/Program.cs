global using AutoMapper;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using server.entities.models;
global using server.entities.DTOs;
global using server.Extensions;
global using server.Repositories.ProductRepo;
global using server.Data;
global using server.Repositories.ProductRepo;


var builder = WebApplication.CreateBuilder(args);
var conn_string=builder.Configuration.GetConnectionString("ShoppingAppConnection");

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options=>{
    options.UseMySql(conn_string,ServerVersion.AutoDetect(conn_string));
});

builder.Services.AddScoped<IProductRepository,ProductRepository>();

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
