﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Model.Postgres.Migrations
{
    [DbContext(typeof(WellbeingDbContext))]
    [Migration("20211002185613_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Model.Trackable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("FieldType")
                        .HasColumnType("integer");

                    b.Property<bool>("Inactive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("TrackingSetupId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TrackingSetupId");

                    b.ToTable("Trackables");
                });

            modelBuilder.Entity("Model.TrackedItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FieldValueJson")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("TrackableId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TrackingEntryId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TrackableId");

                    b.HasIndex("TrackingEntryId");

                    b.ToTable("TrackedItems");
                });

            modelBuilder.Entity("Model.TrackingEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("TrackingEntries");
                });

            modelBuilder.Entity("Model.TrackingSetup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserGuid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserGuid")
                        .IsUnique();

                    b.ToTable("TrackingSetups");
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Model.Trackable", b =>
                {
                    b.HasOne("Model.TrackingSetup", null)
                        .WithMany("Trackables")
                        .HasForeignKey("TrackingSetupId");
                });

            modelBuilder.Entity("Model.TrackedItem", b =>
                {
                    b.HasOne("Model.Trackable", "Trackable")
                        .WithMany()
                        .HasForeignKey("TrackableId");

                    b.HasOne("Model.TrackingEntry", null)
                        .WithMany("TrackedItems")
                        .HasForeignKey("TrackingEntryId");

                    b.Navigation("Trackable");
                });

            modelBuilder.Entity("Model.TrackingSetup", b =>
                {
                    b.HasOne("Model.User", "User")
                        .WithOne("TrackingSetup")
                        .HasForeignKey("Model.TrackingSetup", "UserGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Model.TrackingEntry", b =>
                {
                    b.Navigation("TrackedItems");
                });

            modelBuilder.Entity("Model.TrackingSetup", b =>
                {
                    b.Navigation("Trackables");
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.Navigation("TrackingSetup")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}