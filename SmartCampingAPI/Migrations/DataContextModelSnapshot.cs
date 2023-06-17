﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartCampingAPI.Data;

#nullable disable

namespace SmartCampingAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SmartCampingAPI.Models.Alojamento", b =>
                {
                    b.Property<int>("AlojamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlojamentoId"));

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrecoNoite")
                        .HasColumnType("float");

                    b.Property<int>("TipoAlojamentoId")
                        .HasColumnType("int");

                    b.HasKey("AlojamentoId");

                    b.HasIndex("TipoAlojamentoId");

                    b.ToTable("Alojamentos");
                });

            modelBuilder.Entity("SmartCampingAPI.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("CodPostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NIF")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telemovel")
                        .HasColumnType("int");

                    b.Property<int>("UtilizadorId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SmartCampingAPI.Models.EstadoReserva", b =>
                {
                    b.Property<int>("EstadoReservaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoReservaId"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoReservaId");

                    b.ToTable("EstadoReservas");
                });

            modelBuilder.Entity("SmartCampingAPI.Models.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FuncionarioId"));

                    b.Property<string>("Departamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telemovel")
                        .HasColumnType("int");

                    b.Property<int>("UtilizadorId")
                        .HasColumnType("int");

                    b.HasKey("FuncionarioId");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("SmartCampingAPI.Models.MetodoPagamento", b =>
                {
                    b.Property<int>("MetodoPagamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MetodoPagamentoId"));

                    b.Property<string>("Metodo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MetodoPagamentoId");

                    b.ToTable("MetodoPagamentos");
                });

            modelBuilder.Entity("SmartCampingAPI.Models.Reserva", b =>
                {
                    b.Property<int>("ReservaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservaId"));

                    b.Property<int>("AlojamentoId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("EstadoReservaId")
                        .HasColumnType("int");

                    b.Property<int>("MetodoPagamentoId")
                        .HasColumnType("int");

                    b.Property<double>("Pagamento")
                        .HasColumnType("float");

                    b.Property<double>("PrecoTotal")
                        .HasColumnType("float");

                    b.HasKey("ReservaId");

                    b.HasIndex("AlojamentoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EstadoReservaId");

                    b.HasIndex("MetodoPagamentoId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("SmartCampingAPI.Models.TipoAlojamento", b =>
                {
                    b.Property<int>("TipoAlojamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoAlojamentoId"));

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoAlojamentoId");

                    b.ToTable("TipoAlojamentos");
                });

            modelBuilder.Entity("SmartCampingAPI.Models.TipoUtilizador", b =>
                {
                    b.Property<int>("TipoUtilizadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoUtilizadorId"));

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoUtilizadorId");

                    b.ToTable("TipoUtilizadores");
                });

            modelBuilder.Entity("SmartCampingAPI.Models.Utilizador", b =>
                {
                    b.Property<int>("UtilizadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UtilizadorId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PalavraPasse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoUtilizadorId")
                        .HasColumnType("int");

                    b.HasKey("UtilizadorId");

                    b.HasIndex("TipoUtilizadorId");

                    b.ToTable("Utilizadores");
                });

            modelBuilder.Entity("SmartCampingAPI.Models.Alojamento", b =>
                {
                    b.HasOne("SmartCampingAPI.Models.TipoAlojamento", "TipoAlojamento")
                        .WithMany("Alojamentos")
                        .HasForeignKey("TipoAlojamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoAlojamento");
                });

            modelBuilder.Entity("SmartCampingAPI.Models.Cliente", b =>
                {
                    b.HasOne("SmartCampingAPI.Models.Utilizador", "Utilizador")
                        .WithMany("Clientes")
                        .HasForeignKey("UtilizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("SmartCampingAPI.Models.Funcionario", b =>
                {
                    b.HasOne("SmartCampingAPI.Models.Utilizador", "Utilizador")
                        .WithMany("Funcionarios")
                        .HasForeignKey("UtilizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("SmartCampingAPI.Models.Reserva", b =>
                {
                    b.HasOne("SmartCampingAPI.Models.Alojamento", "Alojamento")
                        .WithMany("Reservas")
                        .HasForeignKey("AlojamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartCampingAPI.Models.Cliente", "Cliente")
                        .WithMany("Reservas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartCampingAPI.Models.EstadoReserva", "EstadoReserva")
                        .WithMany("Reservas")
                        .HasForeignKey("EstadoReservaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartCampingAPI.Models.MetodoPagamento", "MetodoPagamento")
                        .WithMany("Reservas")
                        .HasForeignKey("MetodoPagamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alojamento");

                    b.Navigation("Cliente");

                    b.Navigation("EstadoReserva");

                    b.Navigation("MetodoPagamento");
                });

            modelBuilder.Entity("SmartCampingAPI.Models.Utilizador", b =>
                {
                    b.HasOne("SmartCampingAPI.Models.TipoUtilizador", "TipoUtilizador")
                        .WithMany("Utilizadores")
                        .HasForeignKey("TipoUtilizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoUtilizador");
                });

            modelBuilder.Entity("SmartCampingAPI.Models.Alojamento", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("SmartCampingAPI.Models.Cliente", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("SmartCampingAPI.Models.EstadoReserva", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("SmartCampingAPI.Models.MetodoPagamento", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("SmartCampingAPI.Models.TipoAlojamento", b =>
                {
                    b.Navigation("Alojamentos");
                });

            modelBuilder.Entity("SmartCampingAPI.Models.TipoUtilizador", b =>
                {
                    b.Navigation("Utilizadores");
                });

            modelBuilder.Entity("SmartCampingAPI.Models.Utilizador", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Funcionarios");
                });
#pragma warning restore 612, 618
        }
    }
}
