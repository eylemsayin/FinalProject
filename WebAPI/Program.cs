using Business.Abstracts;
using Business.Concretes;
using DataAccess.Concretes.EntityFramework;
using Entities.Abstracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Autofac, Ninjecy, CastleWindsor, ScructorMap, LightInject, DryInjecy --> IoC Container
//AOP 
builder.Services.AddControllers();
builder.Services.AddSingleton<IProductService,ProductManager>();
builder.Services.AddSingleton<IProductDal, EfProductDal>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
