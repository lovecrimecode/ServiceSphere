﻿using Microsoft.EntityFrameworkCore;
using ServiceSphere.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.Infrastructure.Data
{
    public class ServiceSphereDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public ServiceSphereDbContext(DbContextOptions<ServiceSphereDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasMany(e => e.Guests)
                .WithOne(g => g.Event)
                .HasForeignKey(g => g.EventId);

            modelBuilder.Entity<Service>()
                .HasMany(s => s.Suppliers)
                .WithOne()
                .HasForeignKey(v => v.SupplierId);

            base.OnModelCreating(modelBuilder);
        }
    }

}
