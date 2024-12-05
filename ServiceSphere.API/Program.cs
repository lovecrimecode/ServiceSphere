using Microsoft.EntityFrameworkCore;
using ServiceSphere.Infrastructure.Persistence.Context;

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

// Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "api/{controller=Home}/{action=Index}/{id?}");
});

app.MapControllers();

app.Run();
