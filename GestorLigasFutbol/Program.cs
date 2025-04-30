using GestorLigasFutbol.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);
//para login 
builder.Services.AddSingleton(new ContextLogin(builder.Configuration.GetConnectionString("BdConexion")));

//sesion de autenticacion
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    //propiedades
    option.LoginPath = "/UsuariosLogin/Login"; //ruta donde esta el metodo de login dentro del controller
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbContextUsuarios>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("BdConexion")));

builder.Services.AddDbContext<DbContextTipoUsuarios>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("BdConexion")));

builder.Services.AddDbContext<DbContextSanciones>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("BdConexion")));



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

//Agregar autenticacion 
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
