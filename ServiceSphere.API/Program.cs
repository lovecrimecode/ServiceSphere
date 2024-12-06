using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiceSphere.Domain.Core;
using ServiceSphere.Infrastructure.Persistence.Context;
using ServiceSphere.Infrastructure.Repositories;
using ServiceSphere.Infrastructure.Core;
using ServiceSphere.Domain.InterfacesRepos;
using EventSphere.Infrastructure.Repositories;
using ServiceSphere.Application.Services;
using ServiceSphere.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de DbContext
builder.Services.AddDbContext<ServiceSphereDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuraci�n de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebApp", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Agregar Services al contenedor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//unit of works
//builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

//repositories
builder.Services.AddTransient<IEventRepository, EventRepository>();
builder.Services.AddTransient<IGuestRepository, GuestRepository>();
builder.Services.AddTransient<IOrganizerRepository, OrganizerRepository>();
builder.Services.AddTransient<ISupplierRepository, SupplierRepository>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));


//services
/*builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<IGuestService, GuestService>();
builder.Services.AddTransient<IOrganizerService, OrganizerService>();
builder.Services.AddTransient<ISupplierService, SupplierService>();
builder.Services.AddTransient<IServiceService, ServiceService>();
builder.Services.AddTransient(typeof(IService<>), typeof(BaseService<>));
*/
//builder.Services.AddTransient<CustomerService>();
//builder.Services.AddTransient<ICustomerService, CustomerService>();
var app = builder.Build();

// Configuraci�n del pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// **Orden correcto del middleware**
app.UseHttpsRedirection();

app.UseStaticFiles(); // Sirve archivos est�ticos
app.UseRouting(); // Habilita el enrutamiento

app.UseCors("AllowWebApp"); // Configuraci�n de CORS
app.UseAuthorization(); // Autorizaci�n

/*app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "api/{controller=Home}/{action=Index}/{id?}");
});*/

app.MapControllers();

app.Run();
