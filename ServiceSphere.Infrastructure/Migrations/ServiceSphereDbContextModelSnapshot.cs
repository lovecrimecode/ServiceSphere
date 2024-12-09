﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceSphere.Infrastructure.Context;

#nullable disable

namespace ServiceSphere.Infrastructure.Migrations
{
    [DbContext(typeof(ServiceSphereDbContext))]
    partial class ServiceSphereDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("EventService", b =>
                {
                    b.Property<int>("EventsEventId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServicesServiceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EventsEventId", "ServicesServiceId");

                    b.HasIndex("ServicesServiceId");

                    b.ToTable("EventService");
                });

            modelBuilder.Entity("ServiceSphere.Domain.Entities.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Budget")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrganizerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EventId");

                    b.HasIndex("OrganizerId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ServiceSphere.Domain.Entities.Guest", b =>
                {
                    b.Property<int>("GuestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EventName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAttending")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GuestId");

                    b.HasIndex("EventId");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("ServiceSphere.Domain.Entities.Organizer", b =>
                {
                    b.Property<int>("OrganizerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("OrganizerId");

                    b.ToTable("Organizers");
                });

            modelBuilder.Entity("ServiceSphere.Domain.Entities.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cost")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ServiceId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("ServiceSphere.Domain.Entities.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("EventService", b =>
                {
                    b.HasOne("ServiceSphere.Domain.Entities.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServiceSphere.Domain.Entities.Service", null)
                        .WithMany()
                        .HasForeignKey("ServicesServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ServiceSphere.Domain.Entities.Event", b =>
                {
                    b.HasOne("ServiceSphere.Domain.Entities.Organizer", "Organizer")
                        .WithMany("Events")
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Organizer");
                });

            modelBuilder.Entity("ServiceSphere.Domain.Entities.Guest", b =>
                {
                    b.HasOne("ServiceSphere.Domain.Entities.Event", "Event")
                        .WithMany("Guests")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Event");
                });

            modelBuilder.Entity("ServiceSphere.Domain.Entities.Service", b =>
                {
                    b.HasOne("ServiceSphere.Domain.Entities.Supplier", "Supplier")
                        .WithMany("Services")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ServiceSphere.Domain.Entities.Event", b =>
                {
                    b.Navigation("Guests");
                });

            modelBuilder.Entity("ServiceSphere.Domain.Entities.Organizer", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("ServiceSphere.Domain.Entities.Supplier", b =>
                {
                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}
