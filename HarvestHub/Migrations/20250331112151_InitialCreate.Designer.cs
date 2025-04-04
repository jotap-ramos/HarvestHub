﻿// <auto-generated />
using System;
using HarvestHub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HarvestHub.Migrations
{
    [DbContext(typeof(HarvestHubContext))]
    [Migration("20250331112151_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HarvestHub.Models.Contador", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .HasColumnType("integer");

                    b.Property<string>("CRC")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("FuncionarioId");

                    b.ToTable("Contador");
                });

            modelBuilder.Entity("HarvestHub.Models.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("date");

                    b.Property<int>("FornecedorId")
                        .HasColumnType("integer");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("integer");

                    b.Property<string>("NumeroContrato")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("HarvestHub.Models.Despesa", b =>
                {
                    b.Property<int>("Iddespesa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Iddespesa"));

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataRegistro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Iddespesa");

                    b.ToTable("Despesas");
                });

            modelBuilder.Entity("HarvestHub.Models.Estoque", b =>
                {
                    b.Property<int>("Idlocal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Idlocal"));

                    b.Property<int>("InsumoId")
                        .HasColumnType("integer");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Idlocal");

                    b.HasIndex("InsumoId");

                    b.ToTable("Estoque");
                });

            modelBuilder.Entity("HarvestHub.Models.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("HarvestHub.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<DateTime>("DataAdmissao")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("character varying(45)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("DECIMAL(10, 2)");

                    b.Property<short>("Status")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("HarvestHub.Models.GerenteDeProducao", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .HasColumnType("integer");

                    b.Property<string>("CREA")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("character varying(9)");

                    b.HasKey("FuncionarioId");

                    b.ToTable("GerenteDeProducao");
                });

            modelBuilder.Entity("HarvestHub.Models.Insumo", b =>
                {
                    b.Property<int>("IdInsumo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdInsumo"));

                    b.Property<string>("CodInsumo")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("character varying(45)");

                    b.Property<decimal>("Custo")
                        .HasColumnType("DECIMAL(10, 2)");

                    b.Property<string>("Descricao")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("GerenteDeProducaoId")
                        .HasMaxLength(9)
                        .HasColumnType("integer");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("character varying(45)");

                    b.Property<string>("TipoInsumo")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("character varying(45)");

                    b.Property<string>("Volume")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("character varying(45)");

                    b.HasKey("IdInsumo");

                    b.HasIndex("GerenteDeProducaoId");

                    b.ToTable("INSUMO");
                });

            modelBuilder.Entity("HarvestHub.Models.Patrimonio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataAquisicao")
                        .HasColumnType("date");

                    b.Property<int>("GerenteDeProducaoId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("GerenteDeProducaoId");

                    b.ToTable("Patrimonios");
                });

            modelBuilder.Entity("HarvestHub.Models.Producao", b =>
                {
                    b.Property<int>("IdProducao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdProducao"));

                    b.Property<decimal>("Custo")
                        .HasColumnType("numeric");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Volume")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("IdProducao");

                    b.ToTable("PRODUCAO");
                });

            modelBuilder.Entity("HarvestHub.Models.Receita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("idRECEITA");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ContadorFuncionarioId")
                        .HasColumnType("integer")
                        .HasColumnName("CONTADOR_FUNCIONARIO_idFUNCIONARIO");

                    b.Property<DateTime>("DataRegistro")
                        .HasColumnType("DATE")
                        .HasColumnName("DATA_REGISTRO");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("character varying(45)")
                        .HasColumnName("TIPO");

                    b.Property<decimal>("Valor")
                        .HasColumnType("DECIMAL(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ContadorFuncionarioId");

                    b.ToTable("RECEITA");
                });

            modelBuilder.Entity("HarvestHub.Models.RecursosHumanos", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .HasColumnType("integer");

                    b.Property<string>("CRA")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("FuncionarioId");

                    b.ToTable("RecursosHumanos");
                });

            modelBuilder.Entity("HarvestHub.Models.Contador", b =>
                {
                    b.HasOne("HarvestHub.Models.Funcionario", "Funcionario")
                        .WithOne("Contador")
                        .HasForeignKey("HarvestHub.Models.Contador", "FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("HarvestHub.Models.Contrato", b =>
                {
                    b.HasOne("HarvestHub.Models.Fornecedor", "Fornecedor")
                        .WithMany("Contratos")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HarvestHub.Models.Funcionario", "Funcionario")
                        .WithMany("Contratos")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("HarvestHub.Models.Estoque", b =>
                {
                    b.HasOne("HarvestHub.Models.Insumo", "Insumo")
                        .WithMany("Estoques")
                        .HasForeignKey("InsumoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Insumo");
                });

            modelBuilder.Entity("HarvestHub.Models.GerenteDeProducao", b =>
                {
                    b.HasOne("HarvestHub.Models.Funcionario", "Funcionario")
                        .WithOne("GerenteDeProducao")
                        .HasForeignKey("HarvestHub.Models.GerenteDeProducao", "FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("HarvestHub.Models.Insumo", b =>
                {
                    b.HasOne("HarvestHub.Models.GerenteDeProducao", "GerenteDeProducao")
                        .WithMany("Insumos")
                        .HasForeignKey("GerenteDeProducaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GerenteDeProducao");
                });

            modelBuilder.Entity("HarvestHub.Models.Patrimonio", b =>
                {
                    b.HasOne("HarvestHub.Models.GerenteDeProducao", "GerenteDeProducao")
                        .WithMany("Patrimonios")
                        .HasForeignKey("GerenteDeProducaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GerenteDeProducao");
                });

            modelBuilder.Entity("HarvestHub.Models.Receita", b =>
                {
                    b.HasOne("HarvestHub.Models.Contador", "Contador")
                        .WithMany("Receitas")
                        .HasForeignKey("ContadorFuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contador");
                });

            modelBuilder.Entity("HarvestHub.Models.RecursosHumanos", b =>
                {
                    b.HasOne("HarvestHub.Models.Funcionario", "Funcionario")
                        .WithOne("RecursosHumanos")
                        .HasForeignKey("HarvestHub.Models.RecursosHumanos", "FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("HarvestHub.Models.Contador", b =>
                {
                    b.Navigation("Receitas");
                });

            modelBuilder.Entity("HarvestHub.Models.Fornecedor", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("HarvestHub.Models.Funcionario", b =>
                {
                    b.Navigation("Contador");

                    b.Navigation("Contratos");

                    b.Navigation("GerenteDeProducao");

                    b.Navigation("RecursosHumanos");
                });

            modelBuilder.Entity("HarvestHub.Models.GerenteDeProducao", b =>
                {
                    b.Navigation("Insumos");

                    b.Navigation("Patrimonios");
                });

            modelBuilder.Entity("HarvestHub.Models.Insumo", b =>
                {
                    b.Navigation("Estoques");
                });
#pragma warning restore 612, 618
        }
    }
}
