using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.Abstarct;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);
var conf = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());


    });

builder.Services.AddIdentity<CustomUser, IdentityRole>().AddEntityFrameworkStores<ProjectDbContext>().
    AddDefaultTokenProviders().AddRoles<IdentityRole>().AddRoleManager<RoleManager<IdentityRole>>();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthorization();
builder.Services.AddCustomAuthentication(conf);
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerJwt();




var app = builder.Build();

//ServicesConfigurations.CreateRoles(app.Services, conf).Wait();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapControllers();

app.Run();
