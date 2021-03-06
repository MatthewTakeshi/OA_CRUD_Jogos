﻿// <auto-generated />
using Desafio_CRUD.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Desafio_CRUD.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Desafio_CRUD.Shared.Genero", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("Desafio_CRUD.Shared.Jogo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PlataformaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PlataformaID");

                    b.ToTable("Jogos");
                });

            modelBuilder.Entity("Desafio_CRUD.Shared.JogoGenero", b =>
                {
                    b.Property<int>("JogoID")
                        .HasColumnType("int");

                    b.Property<int>("GeneroID")
                        .HasColumnType("int");

                    b.HasKey("JogoID", "GeneroID");

                    b.HasIndex("GeneroID");

                    b.ToTable("JogoGenero");
                });

            modelBuilder.Entity("Desafio_CRUD.Shared.Plataforma", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Plataformas");
                });

            modelBuilder.Entity("Desafio_CRUD.Shared.Jogo", b =>
                {
                    b.HasOne("Desafio_CRUD.Shared.Plataforma", "Plataforma")
                        .WithMany("Jogos")
                        .HasForeignKey("PlataformaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Desafio_CRUD.Shared.JogoGenero", b =>
                {
                    b.HasOne("Desafio_CRUD.Shared.Genero", "Genero")
                        .WithMany("JogoGeneros")
                        .HasForeignKey("GeneroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Desafio_CRUD.Shared.Jogo", "Jogo")
                        .WithMany("JogoGeneros")
                        .HasForeignKey("JogoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
