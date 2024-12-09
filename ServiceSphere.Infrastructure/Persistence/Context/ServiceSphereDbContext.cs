using Microsoft.EntityFrameworkCore;
using ServiceSphere.Domain.Core;
using ServiceSphere.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.Infrastructure.Persistence.Context
{
    public class ServiceSphereDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Organizer> Organizers { get; set; }

        public ServiceSphereDbContext(DbContextOptions<ServiceSphereDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>()
                .Property(s => s.SupplierId)
                .ValueGeneratedOnAdd();  // Configura la generación automática del valor

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Organizer)
                .WithMany(org => org.Events)
                .HasForeignKey(e => e.OrganizerId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Guest>()
                .HasOne(g => g.Event)
                .WithMany(ev => ev.Guests)
                .HasForeignKey(g => g.EventId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Service>()
               .HasOne(s => s.Supplier)
               .WithMany(sup => sup.Services)
               .HasForeignKey(s => s.SupplierId)
               .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }
    }

}
