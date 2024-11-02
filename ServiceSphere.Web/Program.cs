using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ServiceSphere.Application;
using ServiceSphere.Infrastructure.Data;
using ServiceSphere.Application;
using ServiceSphere.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
/*builder.Services.AddDbContext<ServiceSphereDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);*/
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<SupplierService>();
builder.Services.AddScoped<ServiceService>();

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<EventService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7275/"); 
});
builder.Services.AddHttpClient<ServiceService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7275/");
});
builder.Services.AddHttpClient<SupplierService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7275/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.Run();
