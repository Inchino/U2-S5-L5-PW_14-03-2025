using GestionaleMunicipale.Models;
using GestionaleMunicipale.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using GestionaleMunicipale.Services.Report;
using GestionaleMunicipale.Services;

var builder = WebApplication.CreateBuilder(args);

// Aggiunta del DbContext al container dei servizi
builder.Services.AddDbContext<GestionaleMunicipaleDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(GenericService<>));
builder.Services.AddScoped<VerbaliPerTrasgressoreService>();
builder.Services.AddScoped<PuntiDecurtatiPerTrasgressoreService>();
builder.Services.AddScoped<VerbaliSopra10PuntiService>();
builder.Services.AddScoped<VerbaliSopra400EuroService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
