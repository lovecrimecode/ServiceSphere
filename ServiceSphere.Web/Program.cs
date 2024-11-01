using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ServiceSphere.Application;
using Microsoft.OpenApi.Models;
using ServiceSphere.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ServiceSphereDbContext>(options =>
   options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
   );
builder.Services.AddScoped<EventService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
