/*Responsável pela inicialização da aplicação*/
using APINaPratica.Application.Services;
using APINaPratica.Application.Services.Interfaces;
using APINaPratica.Domain.Interfaces.Repositories;
using APINaPratica.Infra.Mongo.Context;
using APINaPratica.Infra.Mongo.Persistence;
using APINaPratica.Infra.Mongo.Repository;
using APINaPratica.UoW;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
///Configuração da documentação automática OpenAPI
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*Trata a injeção de dependência adicionando ao escopo de trabalho correto*/
builder.Services.AddScoped<IAnimalAppService, AnimalAppService>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMongoContext, MongoContext>();
///Configuração da persistência do mongo
MongoDbPersistence.Configure();

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
