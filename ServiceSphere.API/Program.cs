using Microsoft.AspNetCore.Identity;//
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;//
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;//
using Microsoft.EntityFrameworkCore;
using ServiceSphere.Domain.Core;
using ServiceSphere.Infrastructure.Persistence.Context;
using ServiceSphere.Infrastructure.Repositories;
using ServiceSphere.Infrastructure.Core;
using ServiceSphere.Domain.InterfacesRepos;
using ServiceSphere.Application.Services;
using ServiceSphere.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
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

//repositories
builder.Services.AddTransient<IEventRepository, EventRepository>();
builder.Services.AddTransient<IGuestRepository, GuestRepository>();
builder.Services.AddTransient<IOrganizerRepository, OrganizerRepository>();
builder.Services.AddTransient<ISupplierRepository, SupplierRepository>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));


//services
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<GuestService>();
builder.Services.AddScoped<ServiceService>();
builder.Services.AddScoped<SupplierService>();
builder.Services.AddScoped<OrganizerService>();
//builder.Services.AddTransient(typeof(IService<>), typeof(BaseService<>));

// Configuraci�n de CORS


//builder.Services.AddTransient<CustomerService>();
//builder.Services.AddTransient<ICustomerService, CustomerService>();
var app = builder.Build();

// Configurar el middleware de la aplicaci�n.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Shared/Error");
    app.UseHsts();
}

// **Orden correcto del middleware**
app.UseHttpsRedirection();

app.UseStaticFiles(); // Sirve archivos est�ticos
app.UseRouting(); // Habilita el enrutamiento

app.UseCors("AllowAllOrigins"); // Configuraci�n de CORS
app.UseAuthorization(); // Autorizaci�n

app.MapControllers();

app.Run();
