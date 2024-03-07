using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstracts;
using Business.Concretes;
using Business.DependencyResolvers.Autofac;
using DataAccess.Concretes.EntityFramework;
using Entities.Abstracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Autofac, Ninjecy, CastleWindsor, ScructorMap, LightInject, DryInjecy --> IoC Container
//AOP 
//Postsharp
builder.Services.AddControllers();
//builder.Services.AddSingleton<IProductService,ProductManager>();
//builder.Services.AddSingleton<IProductDal, EfProductDal>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
