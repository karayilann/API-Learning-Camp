using System.Reflection;
using APIProjeKampi.WebApi.Context;
using APIProjeKampi.WebApi.Entities;
using APIProjeKampi.WebApi.ValidationRules;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApiContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); Another method for 10

builder.Services.AddScoped<IValidator<Product>, ProductValidator>(); // En optimize olan� 
//builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>(); Another Method for 15 (Orta �l�ekli projeler)

// builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
// �u anda �al��an validatorleri tara (B�y�k ve birden fazla validator varsa)

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

app.UseAuthorization();

app.MapControllers();

app.Run();
