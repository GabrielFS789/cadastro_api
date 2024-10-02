﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using backend.DataContext;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241002141006_AdicionaEstados")]
    partial class AdicionaEstados
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("backend.Model.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoIBGE")
                        .HasColumnType("text");

                    b.Property<int>("EstadoId")
                        .HasColumnType("integer");

                    b.Property<string>("NomeCidade")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("backend.Model.Entidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .HasColumnType("text");

                    b.Property<string>("Celular")
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<int>("CidadeId")
                        .HasColumnType("integer");

                    b.Property<string>("Complemento")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Endereco")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<bool>("Inativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("NumeroEndereco")
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.ToTable("Entidade");
                });

            modelBuilder.Entity("backend.Model.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("NomeEstado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("backend.Model.Cidade", b =>
                {
                    b.HasOne("backend.Model.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("backend.Model.Entidade", b =>
                {
                    b.HasOne("backend.Model.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");
                });
#pragma warning restore 612, 618
        }
    }
}
