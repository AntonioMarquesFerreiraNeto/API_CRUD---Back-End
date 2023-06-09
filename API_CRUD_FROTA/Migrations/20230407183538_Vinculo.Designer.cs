﻿// <auto-generated />
using System;
using API_CRUD_FROTA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_CRUD_FROTA.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20230407183538_Vinculo")]
    partial class Vinculo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("API_CRUD_FROTA.Models.Motorista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DataNascimento")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.HasKey("Id");

                    b.ToTable("Motorista");
                });

            modelBuilder.Entity("API_CRUD_FROTA.Models.Onibus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AnoFab")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Assentos")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("Cor")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("MotoristaId")
                        .HasColumnType("int");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Renavam")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MotoristaId");

                    b.ToTable("Onibus");
                });

            modelBuilder.Entity("API_CRUD_FROTA.Models.Onibus", b =>
                {
                    b.HasOne("API_CRUD_FROTA.Models.Motorista", "Motorista")
                        .WithMany("Onibus")
                        .HasForeignKey("MotoristaId");

                    b.Navigation("Motorista");
                });

            modelBuilder.Entity("API_CRUD_FROTA.Models.Motorista", b =>
                {
                    b.Navigation("Onibus");
                });
#pragma warning restore 612, 618
        }
    }
}
