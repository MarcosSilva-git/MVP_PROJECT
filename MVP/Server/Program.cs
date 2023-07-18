using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using MVP.Infra.Context;
using MVP.Server.Configs;
using MVP.Shared.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var sqliteConnectionString = builder.Configuration["DataBase:SqliteConnectionString"];

builder.Services.AddDbContext<HelpDeskContext>(context => context.UseSqlite(sqliteConnectionString));


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddHelpDeskServices();
builder.Services.ImplementarSwagger();

builder.AddHelpDeskSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UsarSwagger();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
