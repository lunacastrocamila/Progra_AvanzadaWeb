using Microsoft.EntityFrameworkCore;
using Proyecto_PrograAvanzada.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ServiciosSoporteContext>(op =>
    op.UseSqlServer(builder.Configuration.GetConnectionString("ServiciosSoporte")));

// Configuración de sesiones
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tiempo de expiración de la sesión
    options.Cookie.HttpOnly = true; // Asegura que la cookie solo se envíe en solicitudes HTTP
    options.Cookie.IsEssential = true; // Requerido para cumplimiento de GDPR
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Habilitar HSTS en producción
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Habilitar sesiones en el pipeline
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
