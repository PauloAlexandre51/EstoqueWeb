﻿// <auto-generated />
using System;
using EstoqueWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace estoqueweb.Migrations
{
    [DbContext(typeof(EstoqueWebContext))]
    [Migration("20230105231044_V4")]
    partial class V4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("EstoqueWeb.Models.CategoriaModel", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("EstoqueWeb.Models.ItemPedidoModel", b =>
                {
                    b.Property<int>("IdPedido")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProduto")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<double>("ValorUnitario")
                        .HasColumnType("REAL");

                    b.HasKey("IdPedido", "IdProduto");

                    b.HasIndex("IdProduto");

                    b.ToTable("ItemPedido");
                });

            modelBuilder.Entity("EstoqueWeb.Models.PedidoModel", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataEntrega")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataPedido")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdCliente")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("ValorTotal")
                        .HasColumnType("REAL");

                    b.HasKey("IdPedido");

                    b.HasIndex("IdCliente");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("EstoqueWeb.Models.ProdutoModel", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Estoque")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0);

                    b.Property<int>("IdCategoria")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<double>("Preco")
                        .HasColumnType("REAL");

                    b.HasKey("IdProduto");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("EstoqueWeb.Models.UsuarioModel", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime('now', 'localtime', 'start of day')");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("EstoqueWeb.Models.ClienteModel", b =>
                {
                    b.HasBaseType("EstoqueWeb.Models.UsuarioModel");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("char(14)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("EstoqueWeb.Models.ItemPedidoModel", b =>
                {
                    b.HasOne("EstoqueWeb.Models.PedidoModel", "Pedido")
                        .WithMany("ItensPedido")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EstoqueWeb.Models.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("EstoqueWeb.Models.PedidoModel", b =>
                {
                    b.HasOne("EstoqueWeb.Models.ClienteModel", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("EstoqueWeb.Models.EnderecoModel", "EnderecoEntrega", b1 =>
                        {
                            b1.Property<int>("PedidoModelIdPedido")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("CEP")
                                .IsRequired()
                                .HasColumnType("char(9)");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Complemento")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasColumnType("char(2)");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Referencia")
                                .HasColumnType("TEXT");

                            b1.HasKey("PedidoModelIdPedido");

                            b1.ToTable("Pedido");

                            b1.WithOwner()
                                .HasForeignKey("PedidoModelIdPedido");
                        });

                    b.Navigation("Cliente");

                    b.Navigation("EnderecoEntrega");
                });

            modelBuilder.Entity("EstoqueWeb.Models.ProdutoModel", b =>
                {
                    b.HasOne("EstoqueWeb.Models.CategoriaModel", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("EstoqueWeb.Models.ClienteModel", b =>
                {
                    b.HasOne("EstoqueWeb.Models.UsuarioModel", null)
                        .WithOne()
                        .HasForeignKey("EstoqueWeb.Models.ClienteModel", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("EstoqueWeb.Models.EnderecoModel", "Enderecos", b1 =>
                        {
                            b1.Property<int>("IdUsuario")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("IdEndereco")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("CEP")
                                .IsRequired()
                                .HasColumnType("char(9)");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Complemento")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasColumnType("char(2)");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Referencia")
                                .HasColumnType("TEXT");

                            b1.Property<bool>("Selecionado")
                                .HasColumnType("INTEGER");

                            b1.HasKey("IdUsuario", "IdEndereco");

                            b1.ToTable("Endereco");

                            b1.WithOwner()
                                .HasForeignKey("IdUsuario");
                        });

                    b.Navigation("Enderecos");
                });

            modelBuilder.Entity("EstoqueWeb.Models.CategoriaModel", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("EstoqueWeb.Models.PedidoModel", b =>
                {
                    b.Navigation("ItensPedido");
                });

            modelBuilder.Entity("EstoqueWeb.Models.ClienteModel", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
