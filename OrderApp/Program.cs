using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using OrderApp.BLL.Interface;
using OrderApp.BLL.Manager;
using OrderApp.BLL.Utility;
using OrderApp.DAL;
using OrderApp.DAL.Interface;
using OrderApp.DAL.Repository;
using OrderApp.Models;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddDbContext<OrderDbContext>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//builder.Services.AddSingleton<WeatherForecastService>();
//builder.Services.AddTransient<IBaseRepository<Order>, OrderRepository>();

builder.Services.AddScoped<ToastManager>();

builder.Services.AddTransient<IOrderManager, OrderManager>();
builder.Services.AddTransient<IOrderWindowManager, OrderWindowManager>();
builder.Services.AddTransient<IOrderWindowDetailManager, OrderWindowDetailManager>();

builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderWindowRepository, OrderWindowRepository>();
builder.Services.AddTransient<IOrderWindowDetailRepository, OrderWindowDetailRepository>();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7273") });
//builder.Services.AddScoped<IOrderService, OrderService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
