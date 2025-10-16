using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProductAPI_backend.DTOs;
using ProductAPI_backend.Models;
using ProductAPI_backend.Repository;
using ProductAPI_backend.Services;
using ProductAPI_backend.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository<Product, Guid>, ProductsRepository>();
builder.Services.AddScoped<ICommonService<ProductDTO, ProductInsertDTO, ProductUpdateDTO, Guid>, ProductService>();
builder.Services.AddScoped<IValidator<ProductInsertDTO>, ProductInsertDtoValidator>();
builder.Services.AddScoped<IValidator<ProductUpdateDTO>, ProductUpdateDtoValidator>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "https://lemon-stone-0c62b0b0f.1.azurestaticapps.net/")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
