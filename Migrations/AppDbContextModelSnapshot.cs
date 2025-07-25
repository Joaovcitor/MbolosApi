﻿// <auto-generated />
using System;
using MBolosApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MBolosApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MBolosApi.Models.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nome");

                    b.Property<string>("SenhaHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("senha_hash");

                    b.HasKey("Id");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("MBolosApi.Models.Entities.Pedidos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DataCriacao")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EnderecoEntrega")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("StatusPedido")
                        .HasColumnType("integer");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("pedido");
                });

            modelBuilder.Entity("MBolosApi.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<DateTime?>("DataValidade")
                        .HasColumnType("date")
                        .HasColumnName("data_validade");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nome");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("QuantidadeEstoque")
                        .HasColumnType("integer")
                        .HasColumnName("quantidade_estoque");

                    b.Property<int>("TipoProduto")
                        .HasColumnType("integer")
                        .HasColumnName("tipo_produto");

                    b.HasKey("Id");

                    b.ToTable("produtos");
                });

            modelBuilder.Entity("MbolosApi.Models.Entities.ItemPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PedidoId")
                        .HasColumnType("integer");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("item_pedido");
                });

            modelBuilder.Entity("MBolosApi.Models.Entities.Pedidos", b =>
                {
                    b.HasOne("MBolosApi.Models.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("MbolosApi.Models.Entities.ItemPedido", b =>
                {
                    b.HasOne("MBolosApi.Models.Entities.Pedidos", "Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MBolosApi.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("MBolosApi.Models.Entities.Pedidos", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
