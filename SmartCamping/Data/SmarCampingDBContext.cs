using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartCamping.Models;

namespace SmartCamping.Data;

public partial class SmarCampingDBContext : DbContext
{
    public SmarCampingDBContext()
    {
    }

    public SmarCampingDBContext(DbContextOptions<SmarCampingDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alojamento> Alojamentos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<EstadoReserva> EstadoReservas { get; set; }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<MetodoPagamento> MetodoPagamentos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<TipoAlojamento> TipoAlojamentos { get; set; }

    public virtual DbSet<TipoUtilizador> TipoUtilizadors { get; set; }

    public virtual DbSet<Utilizador> Utilizadors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Database=\"smartcampingdb\";Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alojamento>(entity =>
        {
            entity.HasKey(e => e.AlojamentoId).HasName("PK__Alojamen__20BCDAA83677F621");

            entity.ToTable("Alojamento");

            entity.Property(e => e.Descricao)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.TipoAlojamento).WithMany(p => p.Alojamentos)
                .HasForeignKey(d => d.TipoAlojamentoId)
                .HasConstraintName("FK_Alojamento_TipoAlojamento");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Cliente__71ABD08771F85123");

            entity.ToTable("Cliente");

            entity.Property(e => e.CodPostal)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Localidade)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Morada).IsUnicode(false);
            entity.Property(e => e.Nif).HasColumnName("NIF");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Utilizador).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.UtilizadorId)
                .HasConstraintName("FK_Cliente_Utilizador");
        });

        modelBuilder.Entity<EstadoReserva>(entity =>
        {
            entity.HasKey(e => e.EstadoReservaId).HasName("PK__EstadoRe__DB6E9F21A4BC9F41");

            entity.ToTable("EstadoReserva");

            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.FuncionarioId).HasName("PK__Funciona__297ECCAA8F817A09");

            entity.ToTable("Funcionario");

            entity.Property(e => e.Departamento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Utilizador).WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.UtilizadorId)
                .HasConstraintName("FK_Fucionario_Utilizador");
        });

        modelBuilder.Entity<MetodoPagamento>(entity =>
        {
            entity.HasKey(e => e.MetodoPagamentoId).HasName("PK__MetodoPa__5E2C40FE6441C04D");

            entity.ToTable("MetodoPagamento");

            entity.Property(e => e.Metodo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.ReservaId).HasName("PK__Reserva__C3993763DCB894F2");

            entity.ToTable("Reserva");

            entity.Property(e => e.DataFim).HasColumnType("date");
            entity.Property(e => e.DataInicio).HasColumnType("date");
            entity.Property(e => e.Pagamento).HasColumnType("money");
            entity.Property(e => e.PrecoNoite).HasColumnType("smallmoney");
            entity.Property(e => e.PrecoTotal).HasColumnType("money");

            entity.HasOne(d => d.Alojamento).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.AlojamentoId)
                .HasConstraintName("FK_Reserva_Alojamento");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_Reserva_Cliente");

            entity.HasOne(d => d.Estado).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK_Reserva_EstadoReserva");

            entity.HasOne(d => d.Metodo).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.MetodoId)
                .HasConstraintName("FK_Reserva_MetodoPag");
        });

        modelBuilder.Entity<TipoAlojamento>(entity =>
        {
            entity.HasKey(e => e.TipoAlojamentoId).HasName("PK__TipoAloj__13D7C0AD99BCE58E");

            entity.ToTable("TipoAlojamento");

            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoUtilizador>(entity =>
        {
            entity.HasKey(e => e.TipoUtilizadorId).HasName("PK__TipoUtil__C3F01458B396E5EC");

            entity.ToTable("TipoUtilizador");

            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Utilizador>(entity =>
        {
            entity.HasKey(e => e.UtilizadorId).HasName("PK__Utilizad__90F8E1E86828AD64");

            entity.ToTable("Utilizador");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PalavraPasse)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.TipoUtilizador).WithMany(p => p.Utilizadors)
                .HasForeignKey(d => d.TipoUtilizadorId)
                .HasConstraintName("FK_Utiliador_TipoUtilizador");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
