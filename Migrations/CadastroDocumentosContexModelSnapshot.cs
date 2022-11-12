﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cadastro_documento_api.Source.Infraestructure.Contexts;

#nullable disable

namespace cadastro_documento_api.Migrations
{
    [DbContext(typeof(CadastroDocumentosContex))]
    partial class CadastroDocumentosContexModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("cadastro_documento_api.Source.Core.Entities.DocumentoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ArquivoId")
                        .HasColumnType("char(36)");

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

                    b.HasIndex("ArquivoId")
                        .IsUnique();

                    b.HasIndex("ProcessoId");

                    b.ToTable("Documento");
                });

            modelBuilder.Entity("cadastro_documento_api.Source.Core.Entities.FileEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("FileBytes")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("File");
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
                            CriadoEm = new DateTime(2022, 11, 11, 21, 55, 50, 724, DateTimeKind.Local).AddTicks(2966),
                            Nome = "A"
                        },
                        new
                        {
                            Id = 2,
                            CriadoEm = new DateTime(2022, 11, 11, 21, 55, 50, 724, DateTimeKind.Local).AddTicks(2979),
                            Nome = "B"
                        },
                        new
                        {
                            Id = 3,
                            CriadoEm = new DateTime(2022, 11, 11, 21, 55, 50, 724, DateTimeKind.Local).AddTicks(2981),
                            Nome = "C"
                        },
                        new
                        {
                            Id = 4,
                            CriadoEm = new DateTime(2022, 11, 11, 21, 55, 50, 724, DateTimeKind.Local).AddTicks(2982),
                            Nome = "D"
                        });
                });

            modelBuilder.Entity("cadastro_documento_api.Source.Core.Entities.DocumentoEntity", b =>
                {
                    b.HasOne("cadastro_documento_api.Source.Core.Entities.FileEntity", "Arquivo")
                        .WithOne("Documeto")
                        .HasForeignKey("cadastro_documento_api.Source.Core.Entities.DocumentoEntity", "ArquivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cadastro_documento_api.Source.Core.Entities.ProcessoEntity", "Processo")
                        .WithMany("Documentos")
                        .HasForeignKey("ProcessoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arquivo");

                    b.Navigation("Processo");
                });

            modelBuilder.Entity("cadastro_documento_api.Source.Core.Entities.FileEntity", b =>
                {
                    b.Navigation("Documeto")
                        .IsRequired();
                });

            modelBuilder.Entity("cadastro_documento_api.Source.Core.Entities.ProcessoEntity", b =>
                {
                    b.Navigation("Documentos");
                });
#pragma warning restore 612, 618
        }
    }
}
