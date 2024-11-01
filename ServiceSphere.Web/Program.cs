using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ServiceSphere.Application;
using Microsoft.OpenApi.Models;
using ServiceSphere.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

    builder.Services.AddDbContext<ServiceSphereDbContext>(options =>
   options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
   );
builder.Services.AddScoped<EventService>();
builder.Services.AddControllersWithViews();

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
        pattern: "{controller=Home}/{action=Welcome}/{id?}");
});
// Mapear Razor Pages
app.MapRazorPages();

app.Run();