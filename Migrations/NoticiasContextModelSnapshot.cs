﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_noticias;

#nullable disable

namespace api_noticias.Migrations
{
    [DbContext(typeof(NoticiasContext))]
    partial class NoticiasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api_noticias.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nom_Categoria")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb4ef"),
                            Nom_Categoria = "Política"
                        },
                        new
                        {
                            CategoriaId = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb401"),
                            Nom_Categoria = "Deportivas"
                        },
                        new
                        {
                            CategoriaId = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb402"),
                            Nom_Categoria = "Culturales"
                        },
                        new
                        {
                            CategoriaId = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb403"),
                            Nom_Categoria = "Sociales"
                        },
                        new
                        {
                            CategoriaId = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb404"),
                            Nom_Categoria = "De Farandula"
                        },
                        new
                        {
                            CategoriaId = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb405"),
                            Nom_Categoria = "Cientificas"
                        },
                        new
                        {
                            CategoriaId = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb406"),
                            Nom_Categoria = "Económicas"
                        });
                });

            modelBuilder.Entity("api_noticias.Models.Noticia", b =>
                {
                    b.Property<Guid>("NoticiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Calificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("0");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasMaxLength(8000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("SYSDATETIME()");

                    b.Property<string>("Img")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nom_Autor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resumen")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("NoticiaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Noticia", (string)null);
                });

            modelBuilder.Entity("api_noticias.Models.Noticia", b =>
                {
                    b.HasOne("api_noticias.Models.Categoria", "Categoria")
                        .WithMany("Noticia")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("api_noticias.Models.Categoria", b =>
                {
                    b.Navigation("Noticia");
                });
#pragma warning restore 612, 618
        }
    }
}
