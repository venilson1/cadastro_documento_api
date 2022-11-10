﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cadastro_documento_api.Source.Infraestructure.Contexts;

#nullable disable

namespace cadastro_documento_api.Migrations
{
    [DbContext(typeof(CadastroDocumentosContex))]
    [Migration("20221110221656_update_type_field_titulo")]
    partial class update_type_field_titulo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("cadastro_documento_api.Source.Core.Entities.DocumentoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Arquivo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ProcessoId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ProcessoId")
                        .IsUnique();

                    b.ToTable("Documento");
                });

            modelBuilder.Entity("cadastro_documento_api.Source.Core.Entities.ProcessoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Processo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CriadoEm = new DateTime(2022, 11, 10, 19, 16, 55, 977, DateTimeKind.Local).AddTicks(5686),
                            Nome = "A"
                        },
                        new
                        {
                            Id = 2,
                            CriadoEm = new DateTime(2022, 11, 10, 19, 16, 55, 977, DateTimeKind.Local).AddTicks(5698),
                            Nome = "B"
                        },
                        new
                        {
                            Id = 3,
                            CriadoEm = new DateTime(2022, 11, 10, 19, 16, 55, 977, DateTimeKind.Local).AddTicks(5699),
                            Nome = "C"
                        },
                        new
                        {
                            Id = 4,
                            CriadoEm = new DateTime(2022, 11, 10, 19, 16, 55, 977, DateTimeKind.Local).AddTicks(5700),
                            Nome = "D"
                        });
                });

            modelBuilder.Entity("cadastro_documento_api.Source.Core.Entities.DocumentoEntity", b =>
                {
                    b.HasOne("cadastro_documento_api.Source.Core.Entities.ProcessoEntity", "Processo")
                        .WithOne("Documento")
                        .HasForeignKey("cadastro_documento_api.Source.Core.Entities.DocumentoEntity", "ProcessoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Processo");
                });

            modelBuilder.Entity("cadastro_documento_api.Source.Core.Entities.ProcessoEntity", b =>
                {
                    b.Navigation("Documento")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}