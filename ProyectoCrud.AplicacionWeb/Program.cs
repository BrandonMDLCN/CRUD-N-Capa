using Microsoft.EntityFrameworkCore;
using ProyectoCrud.Datos.DataContext;
using ProyectoCrud.Datos.Repositorio;
using ProyectoCrud.Models;
using ProyectoCrud.Negocio.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbcrudNCapaContext>(opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

// EN ASP.NET CORE YA NO SE HACEN INSTANCIAS HACIA LOS REPOSITORIOS, SI NO SE HACE POR MEDIO DE DEPENDENCIAS
// AQUI DECIMOS QUE LA CLASE CONTACTOREPOSITORY TRABAJA CON EL REPOSITORIO IGENERICREPOSITORY
builder.Services.AddScoped<IGenericRepository<Contacto>, ContactoRepository>();
builder.Services.AddScoped<IContactoService, ContactoService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
