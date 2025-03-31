using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Models;

public partial class HarvesthubContext : DbContext
{
    public HarvesthubContext()
    {
    }

    public HarvesthubContext(DbContextOptions<HarvesthubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contador> Contador { get; set; }

    public virtual DbSet<Contrato> Contrato { get; set; }

    public virtual DbSet<Despesa> Despesa { get; set; }

    public virtual DbSet<Estoque> Estoque { get; set; }

    public virtual DbSet<Fornecedor> Fornecedor { get; set; }

    public virtual DbSet<Funcionario> Funcionario { get; set; }

    public virtual DbSet<GerenteDeProducao> GerenteDeProducao { get; set; }

    public virtual DbSet<Insumo> Insumo { get; set; }

    public virtual DbSet<Patrimonio> Patrimonio { get; set; }

    public virtual DbSet<Producao> Producao { get; set; }

    public virtual DbSet<Receita> Receita { get; set; }

    public virtual DbSet<RecursosHumanos> RecursosHumanos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=192.168.0.106;Database=harvesthub;Username=marcelo;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contador>(entity =>
        {
            entity.HasKey(e => e.FuncionarioId).HasName("contador_pkey");

            entity.ToTable("contador", "harvesthub");

            entity.HasIndex(e => e.CRC, "contador_crc_key").IsUnique();

            entity.Property(e => e.FuncionarioId)
                .ValueGeneratedNever()
                .HasColumnName("funcionario_idfuncionario");
            entity.Property(e => e.CRC)
                .HasMaxLength(15)
                .HasColumnName("crc");

            entity.HasOne(c => c.Funcionario).WithOne(f => f.Contador)
                .HasForeignKey<Contador>(c => c.FuncionarioId)
                .HasConstraintName("fk_contador_funcionario");
        });

        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contrato_pkey");

            entity.ToTable("contrato", "harvesthub");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('harvesthub.contrato_idcontrato_seq'::regclass)")
                .HasColumnName("idcontrato");
            entity.Property(e => e.DataInicio).HasColumnName("data_inicio");
            entity.Property(e => e.FuncionarioId).HasColumnName("funcionario_idfuncionario");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .HasColumnName("telefone");

            entity.HasOne(d => d.Funcionario).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.FuncionarioId)
                .HasConstraintName("fk_contrato_funcionario");
        });

        modelBuilder.Entity<Despesa>(entity =>
        {
            entity.HasKey(e => e.Iddespesa).HasName("despesa_pkey");

            entity.ToTable("despesa", "harvesthub");

            entity.Property(e => e.Iddespesa)
                .HasDefaultValueSql("nextval('harvesthub.despesa_iddespesa_seq'::regclass)")
                .HasColumnName("iddespesa");
            entity.Property(e => e.DataPagamento).HasColumnName("data_pagamento");
            entity.Property(e => e.DataRegistro).HasColumnName("data_registro");
            entity.Property(e => e.Tipo)
                .HasMaxLength(45)
                .HasColumnName("tipo");
            entity.Property(e => e.Valor)
                .HasPrecision(10, 2)
                .HasColumnName("valor");
        });

        modelBuilder.Entity<Estoque>(entity =>
        {
            entity.HasKey(e => e.Idlocal).HasName("estoque_pkey");

            entity.ToTable("estoque", "harvesthub");

            entity.Property(e => e.Idlocal)
                .HasDefaultValueSql("nextval('harvesthub.estoque_idlocal_seq'::regclass)")
                .HasColumnName("idlocal");
            entity.Property(e => e.InsumoId).HasColumnName("insumo_idinsumo");
            entity.Property(e => e.Local)
                .HasMaxLength(45)
                .HasColumnName("local");
            entity.Property(e => e.Nome)
                .HasMaxLength(45)
                .HasColumnName("nome");

            entity.HasOne(e => e.Insumo).WithMany(i => i.Estoques)
                .HasForeignKey(e => e.InsumoId)
                .HasConstraintName("fk_estoque_insumo");
        });

        modelBuilder.Entity<Fornecedor>(entity =>
        {
            entity.HasKey(e => e.Idfornecedor).HasName("fornecedor_pkey");

            entity.ToTable("fornecedor", "harvesthub");

            entity.HasIndex(e => e.CpfCnpj, "fornecedor_cpf_cnpj_key").IsUnique();

            entity.Property(e => e.Idfornecedor)
                .HasDefaultValueSql("nextval('harvesthub.fornecedor_idfornecedor_seq'::regclass)")
                .HasColumnName("idfornecedor");
            entity.Property(e => e.CpfCnpj)
                .HasMaxLength(14)
                .HasColumnName("cpf_cnpj");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.NomeFornecedor)
                .HasMaxLength(50)
                .HasColumnName("nome_fornecedor");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("funcionario_pkey");

            entity.ToTable("funcionario", "harvesthub");

            entity.HasIndex(e => e.CPF, "funcionario_cpf_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('harvesthub.funcionario_idfuncionario_seq'::regclass)")
                .HasColumnName("idfuncionario");
            entity.Property(e => e.CPF)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("cpf");
            entity.Property(e => e.DataAdmissao).HasColumnName("data_admissao");
            entity.Property(e => e.DataNascimento).HasColumnName("data_nascimento");
            entity.Property(e => e.Nome)
                .HasMaxLength(45)
                .HasColumnName("nome");
            entity.Property(e => e.Salario)
                .HasPrecision(10, 2)
                .HasColumnName("salario");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<GerenteDeProducao>(entity =>
        {
            entity.HasKey(e => e.FuncionarioId).HasName("gerente_de_producao_pkey");

            entity.ToTable("gerente_de_producao", "harvesthub");

            entity.HasIndex(e => e.CREA, "gerente_de_producao_crea_key").IsUnique();

            entity.Property(e => e.FuncionarioId)
                .ValueGeneratedNever()
                .HasColumnName("funcionario_idfuncionario");
            entity.Property(e => e.CREA)
                .HasMaxLength(9)
                .HasColumnName("crea");

            entity.HasOne(d => d.Funcionario).WithOne(p => p.GerenteDeProducao)
                .HasForeignKey<GerenteDeProducao>(d => d.FuncionarioId)
                .HasConstraintName("fk_gerente_funcionario");
        });

        modelBuilder.Entity<Insumo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("insumo_pkey");

            entity.ToTable("insumo", "harvesthub");

            entity.HasIndex(e => e.Codigo, "insumo_cod_insumo_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('harvesthub.insumo_idinsumo_seq'::regclass)")
                .HasColumnName("idinsumo");
            entity.Property(e => e.Codigo)
                .HasMaxLength(45)
                .HasColumnName("cod_insumo");
            entity.Property(e => e.Custo)
                .HasPrecision(10, 2)
                .HasColumnName("custo");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .HasColumnName("descricao");
            entity.Property(e => e.GerenteDeProducaoCrea)
                .HasMaxLength(9)
                .HasColumnName("gerente_de_producao_crea");
            entity.Property(e => e.Marca)
                .HasMaxLength(45)
                .HasColumnName("marca");
            entity.Property(e => e.Tipo)
                .HasMaxLength(45)
                .HasColumnName("tipo_insumo");
            entity.Property(e => e.Volume)
                .HasMaxLength(45)
                .HasColumnName("volume");

            entity.HasOne(d => d.GerenteDeProducao).WithMany(p => p.Insumos)
                .HasPrincipalKey(p => p.CREA)
                .HasForeignKey(d => d.GerenteDeProducaoCrea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_insumo_gerente");
        });

        modelBuilder.Entity<Patrimonio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("patrimonio_pkey");

            entity.ToTable("patrimonio", "harvesthub");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('harvesthub.patrimonio_idpatrimonio_seq'::regclass)")
                .HasColumnName("idpatrimonio");
            entity.Property(e => e.DataAquisicao).HasColumnName("data_aquisicao");
            entity.Property(e => e.GerenteDeProducaoCrea)
                .HasMaxLength(9)
                .HasColumnName("gerente_de_producao_crea");
            entity.Property(e => e.Valor)
                .HasPrecision(15, 2)
                .HasColumnName("valor");

            entity.HasOne(d => d.GerenteDeProducao).WithMany(p => p.Patrimonios)
                .HasPrincipalKey(p => p.CREA)
                .HasForeignKey(d => d.GerenteDeProducaoCrea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_patrimonio_gerente");
        });

        modelBuilder.Entity<Producao>(entity =>
        {
            entity.HasKey(e => e.IdProducao).HasName("producao_pkey");

            entity.ToTable("producao", "harvesthub");

            entity.Property(e => e.IdProducao)
                .HasDefaultValueSql("nextval('harvesthub.producao_idproducao_seq'::regclass)")
                .HasColumnName("idproducao");
            entity.Property(e => e.Custo)
                .HasPrecision(10, 2)
                .HasColumnName("custo");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .HasColumnName("tipo");
            entity.Property(e => e.Volume)
                .HasMaxLength(20)
                .HasColumnName("volume");
        });

        modelBuilder.Entity<Receita>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("receita_pkey");

            entity.ToTable("receita", "harvesthub");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('harvesthub.receita_idreceita_seq'::regclass)")
                .HasColumnName("idreceita");
            entity.Property(e => e.ContadorFuncionarioId).HasColumnName("contador_funcionario_idfuncionario");
            entity.Property(e => e.DataRegistro).HasColumnName("data_registro");
            entity.Property(e => e.Tipo)
                .HasMaxLength(45)
                .HasColumnName("tipo");
            entity.Property(e => e.Valor)
                .HasPrecision(10, 2)
                .HasColumnName("valor");

            entity.HasOne(d => d.Contador).WithMany(p => p.Receitas)
                .HasForeignKey(d => d.ContadorFuncionarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_receita_contador");
        });

        modelBuilder.Entity<RecursosHumanos>(entity =>
        {
            entity.HasKey(e => e.FuncionarioId).HasName("recursos_humanos_pkey");

            entity.ToTable("recursos_humanos", "harvesthub");

            entity.HasIndex(e => e.CRA, "recursos_humanos_cra_key").IsUnique();

            entity.Property(e => e.FuncionarioId)
                .ValueGeneratedNever()
                .HasColumnName("funcionario_idfuncionario");
            entity.Property(e => e.CRA)
                .HasMaxLength(50)
                .HasColumnName("cra");

            entity.HasOne(d => d.Funcionario).WithOne(p => p.RecursosHumanos)
                .HasForeignKey<RecursosHumanos>(d => d.FuncionarioId)
                .HasConstraintName("fk_rh_funcionario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
