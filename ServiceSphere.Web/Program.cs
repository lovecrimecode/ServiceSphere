using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
//using ServiceSphere.Application;
using ServiceSphere.Application.Services;
using ServiceSphere.Application.Interfaces;
using ServiceSphere.Domain.InterfacesRepos;
using ServiceSphere.Infrastructure.Repositories;
using ServiceSphere.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); //MVC views
builder.Services.AddHttpClient(); //Enable HttpClient for API requests

//
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ServiceSphereDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<SupplierService>();
builder.Services.AddScoped<ServiceService>();
builder.Services.AddScoped<GuestService>();
builder.Services.AddScoped<OrganizerService>();

builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IGuestRepository, GuestRepository>();
builder.Services.AddScoped<IOrganizerRepository, OrganizerRepository>();
//

var app = builder.Build();

// Enable detailed error messages in development
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Shared/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

/*app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});*/

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Welcome}/{id?}");

//
app.MapRazorPages();
//

app.Run();

