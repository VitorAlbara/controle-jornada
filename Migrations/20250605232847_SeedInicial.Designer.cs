﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using controle_jornada.Infra.Context;

#nullable disable

namespace controle_jornada.Migrations
{
    [DbContext(typeof(ContextoBanco))]
    [Migration("20250605232847_SeedInicial")]
    partial class SeedInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("controle_jornada.Models.AppVersao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("app_versao");
                });

            modelBuilder.Entity("controle_jornada.Models.Entrada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DataEntrada")
                        .HasColumnType("date");

                    b.Property<int>("Duracao")
                        .HasColumnType("integer");

                    b.Property<int>("TarefaId")
                        .HasColumnType("integer");

                    b.Property<int>("TarefaUsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TarefaId", "TarefaUsuarioId");

                    b.ToTable("entradas");
                });

            modelBuilder.Entity("controle_jornada.Models.EntradaLocal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DataEntrada")
                        .HasColumnType("date");

                    b.Property<int>("Duracao")
                        .HasColumnType("integer");

                    b.Property<int>("TarefaId")
                        .HasColumnType("integer");

                    b.Property<int>("TarefaUsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TarefaId", "TarefaUsuarioId");

                    b.ToTable("entradas_locais");
                });

            modelBuilder.Entity("controle_jornada.Models.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("projetos");
                });

            modelBuilder.Entity("controle_jornada.Models.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("DataFinal")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DataInicial")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Projeto")
                        .HasColumnType("integer");

                    b.Property<int>("ProjetoVersaoId")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Tamanho")
                        .HasColumnType("integer");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("VersaoId")
                        .HasColumnType("integer");

                    b.HasKey("Id", "UsuarioId");

                    b.HasIndex("VersaoId", "ProjetoVersaoId");

                    b.ToTable("tarefas");
                });

            modelBuilder.Entity("controle_jornada.Models.Versao", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("DataInicio")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DataVencimento")
                        .HasColumnType("date");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id", "ProjetoId");

                    b.HasIndex("ProjetoId");

                    b.ToTable("versoes");
                });

            modelBuilder.Entity("controle_jornada.Models.Entrada", b =>
                {
                    b.HasOne("controle_jornada.Models.Tarefa", "Tarefa")
                        .WithMany("Entradas")
                        .HasForeignKey("TarefaId", "TarefaUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tarefa");
                });

            modelBuilder.Entity("controle_jornada.Models.EntradaLocal", b =>
                {
                    b.HasOne("controle_jornada.Models.Tarefa", "Tarefa")
                        .WithMany("EntradasLocais")
                        .HasForeignKey("TarefaId", "TarefaUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tarefa");
                });

            modelBuilder.Entity("controle_jornada.Models.Tarefa", b =>
                {
                    b.HasOne("controle_jornada.Models.Versao", "Versao")
                        .WithMany("Tarefas")
                        .HasForeignKey("VersaoId", "ProjetoVersaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Versao");
                });

            modelBuilder.Entity("controle_jornada.Models.Versao", b =>
                {
                    b.HasOne("controle_jornada.Models.Projeto", "Projeto")
                        .WithMany("Versoes")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("controle_jornada.Models.Projeto", b =>
                {
                    b.Navigation("Versoes");
                });

            modelBuilder.Entity("controle_jornada.Models.Tarefa", b =>
                {
                    b.Navigation("Entradas");

                    b.Navigation("EntradasLocais");
                });

            modelBuilder.Entity("controle_jornada.Models.Versao", b =>
                {
                    b.Navigation("Tarefas");
                });
#pragma warning restore 612, 618
        }
    }
}
