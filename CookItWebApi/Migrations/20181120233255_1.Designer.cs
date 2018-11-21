﻿// <auto-generated />
using CookItWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CookItWebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181120233255_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CookItWebApi.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CookItWebApi.Models.Ingrediente", b =>
                {
                    b.Property<int>("_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("_AptoCeliacos");

                    b.Property<bool>("_AptoDiabeticos");

                    b.Property<bool>("_AptoVeganos");

                    b.Property<bool>("_AptoVegetarianos");

                    b.Property<int>("_CantCaloriasPorMedida");

                    b.Property<int>("_Costo");

                    b.Property<int>("_Estacion");

                    b.Property<int>("_Medida");

                    b.Property<int>("_MedidaPorGramo");

                    b.Property<int>("_MedidaPromedio");

                    b.Property<string>("_Nombre")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("_Tipo");

                    b.HasKey("_Id");

                    b.HasIndex("_Nombre")
                        .IsUnique();

                    b.ToTable("Ingredientes");
                });

            modelBuilder.Entity("CookItWebApi.Models.IngredienteReceta", b =>
                {
                    b.Property<int>("_IdIngrediente");

                    b.Property<int>("_IdReceta");

                    b.Property<int>("_Cantidad");

                    b.HasKey("_IdIngrediente", "_IdReceta");

                    b.HasIndex("_IdReceta");

                    b.ToTable("IngredientesRecetas");
                });

            modelBuilder.Entity("CookItWebApi.Models.PasoReceta", b =>
                {
                    b.Property<int>("_IdPasoReceta");

                    b.Property<int>("_IdReceta");

                    b.Property<string>("_Texto")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("_TiempoReloj");

                    b.Property<string>("_UrlVideo");

                    b.HasKey("_IdPasoReceta", "_IdReceta");

                    b.HasIndex("_IdReceta");

                    b.ToTable("PasoRecetas");
                });

            modelBuilder.Entity("CookItWebApi.Models.Receta", b =>
                {
                    b.Property<int>("_IdReceta")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("_AptoCeliacos");

                    b.Property<bool>("_AptoDiabeticos");

                    b.Property<bool>("_AptoVeganos");

                    b.Property<bool>("_AptoVegetarianos");

                    b.Property<int>("_CantPlatos");

                    b.Property<float>("_Costo");

                    b.Property<int>("_Dificultad");

                    b.Property<string>("_EmailCreador")
                        .IsRequired();

                    b.Property<int>("_Estacion");

                    b.Property<DateTime>("_FechaCreacion");

                    b.Property<byte[]>("_Foto");

                    b.Property<bool>("_Habilitada");

                    b.Property<int>("_MomentoDia");

                    b.Property<float>("_PuntajeTotal");

                    b.Property<int>("_TiempoPreparacion");

                    b.Property<string>("_Titulo");

                    b.HasKey("_IdReceta");

                    b.HasIndex("_EmailCreador");

                    b.ToTable("Recetas");
                });

            modelBuilder.Entity("CookItWebApi.Models.UserInfo", b =>
                {
                    b.Property<string>("_Email")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("_Password");

                    b.HasKey("_Email");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CookItWebApi.Models.IngredienteReceta", b =>
                {
                    b.HasOne("CookItWebApi.Models.Ingrediente", "_Ingrediente")
                        .WithMany()
                        .HasForeignKey("_IdIngrediente")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CookItWebApi.Models.Receta", "_Receta")
                        .WithMany("_Ingredientes")
                        .HasForeignKey("_IdReceta")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CookItWebApi.Models.PasoReceta", b =>
                {
                    b.HasOne("CookItWebApi.Models.Receta", "_Receta")
                        .WithMany("_Pasos")
                        .HasForeignKey("_IdReceta")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CookItWebApi.Models.Receta", b =>
                {
                    b.HasOne("CookItWebApi.Models.UserInfo", "_Creador")
                        .WithMany()
                        .HasForeignKey("_EmailCreador")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CookItWebApi.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CookItWebApi.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CookItWebApi.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CookItWebApi.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}