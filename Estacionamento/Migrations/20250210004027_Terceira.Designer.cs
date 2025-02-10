﻿// <auto-generated />
using System;
using Estacionamento.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Estacionamento.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250210004027_Terceira")]
    partial class Terceira
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Estacionamento.Models.Estadia", b =>
                {
                    b.Property<int>("VeiculoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtHrEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtHrSaida")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("VlrCalculado")
                        .HasColumnType("decimal");

                    b.HasKey("VeiculoId");

                    b.ToTable("Estadia");
                });

            modelBuilder.Entity("Estacionamento.Models.ValorReferencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DtIniVigencia")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("VlrHrAdicional")
                        .HasColumnType("decimal");

                    b.Property<decimal>("VlrHrInicial")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.ToTable("ValorReferencia");
                });

            modelBuilder.Entity("Estacionamento.Models.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("varchar(7)");

                    b.HasKey("Id");

                    b.ToTable("Veiculo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Placa = "QBD9X92"
                        },
                        new
                        {
                            Id = 2,
                            Placa = "LVR3P14"
                        });
                });

            modelBuilder.Entity("Estacionamento.Models.Estadia", b =>
                {
                    b.HasOne("Estacionamento.Models.Veiculo", "Veiculo")
                        .WithMany("Estadias")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("Estacionamento.Models.Veiculo", b =>
                {
                    b.Navigation("Estadias");
                });
#pragma warning restore 612, 618
        }
    }
}
