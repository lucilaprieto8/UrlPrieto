﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UrlPrieto.Data;

#nullable disable

namespace UrlPrieto.Migrations
{
    [DbContext(typeof(UrlContext))]
    partial class UrlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("UrlPrieto.Entities.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "deportes"
                        },
                        new
                        {
                            Id = 2,
                            Name = "politica"
                        },
                        new
                        {
                            Id = 3,
                            Name = "animales"
                        });
                });

            modelBuilder.Entity("UrlPrieto.Entities.Url", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cont")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdCategory")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdUser")
                        .HasColumnType("INTEGER");

                    b.Property<string>("largeUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("smallUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("IdCategory");

                    b.HasIndex("IdUser");

                    b.ToTable("Url");
                });

            modelBuilder.Entity("UrlPrieto.Entities.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Restantes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "joakopiola",
                            Restantes = 10,
                            User = "jOAKO"
                        },
                        new
                        {
                            Id = 2,
                            Password = "112002",
                            Restantes = 10,
                            User = "Luliiprie"
                        });
                });

            modelBuilder.Entity("UrlPrieto.Entities.Url", b =>
                {
                    b.HasOne("UrlPrieto.Entities.Categories", "Category")
                        .WithMany("urls")
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UrlPrieto.Entities.Users", "Users")
                        .WithMany("urls")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("UrlPrieto.Entities.Categories", b =>
                {
                    b.Navigation("urls");
                });

            modelBuilder.Entity("UrlPrieto.Entities.Users", b =>
                {
                    b.Navigation("urls");
                });
#pragma warning restore 612, 618
        }
    }
}
