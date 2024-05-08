﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using _4Tables2._0.Infra.Data.DbConfig;

#nullable disable

namespace _4Tables2._0.Infra.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240508000930_efmtolixo")]
    partial class efmtolixo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("_4Tables2._0.Domain.OrderContext.Order.Entity.OrderEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TableNumber")
                        .HasColumnType("integer");

                    b.Property<decimal>("Total")
                        .HasPrecision(8, 2)
                        .HasColumnType("numeric(8,2)");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("_4Tables2._0.Domain.OrderContext.ProductOrder.Entity.ProductOrderEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<short>("Quantity")
                        .HasColumnType("smallint");

                    b.Property<long>("SimpleOrderId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SimpleOrderId");

                    b.ToTable("ProductOrders");
                });

            modelBuilder.Entity("_4Tables2._0.Domain.OrderContext.ReceivedOrder.Entity.ReceivedOrderEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Observation")
                        .HasColumnType("text");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<int>("Table")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("ReceivedOrders");
                });

            modelBuilder.Entity("_4Tables2._0.Domain.ProductDomain.Entity.ProductEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasPrecision(8, 4)
                        .HasColumnType("numeric(8,4)");

                    b.Property<int>("TotalRequests")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("_4Tables2._0.Domain.SettingsContext.Settings.Entity.SettingsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("isWaiterFee")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("_4Tables2._0.Domain.SettingsContext.Table.Entity.TableEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("SettingsEntityId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("SettingsEntityId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("_4Tables2._0.Domain.OrderContext.ProductOrder.Entity.ProductOrderEntity", b =>
                {
                    b.HasOne("_4Tables2._0.Domain.ProductDomain.Entity.ProductEntity", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_4Tables2._0.Domain.OrderContext.ReceivedOrder.Entity.ReceivedOrderEntity", "ReceivedOrder")
                        .WithMany("ProductOrders")
                        .HasForeignKey("SimpleOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ReceivedOrder");
                });

            modelBuilder.Entity("_4Tables2._0.Domain.OrderContext.ReceivedOrder.Entity.ReceivedOrderEntity", b =>
                {
                    b.HasOne("_4Tables2._0.Domain.OrderContext.Order.Entity.OrderEntity", "Order")
                        .WithMany("ReceivedOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("_4Tables2._0.Domain.SettingsContext.Table.Entity.TableEntity", b =>
                {
                    b.HasOne("_4Tables2._0.Domain.SettingsContext.Settings.Entity.SettingsEntity", null)
                        .WithMany("Tables")
                        .HasForeignKey("SettingsEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_4Tables2._0.Domain.OrderContext.Order.Entity.OrderEntity", b =>
                {
                    b.Navigation("ReceivedOrders");
                });

            modelBuilder.Entity("_4Tables2._0.Domain.OrderContext.ReceivedOrder.Entity.ReceivedOrderEntity", b =>
                {
                    b.Navigation("ProductOrders");
                });

            modelBuilder.Entity("_4Tables2._0.Domain.SettingsContext.Settings.Entity.SettingsEntity", b =>
                {
                    b.Navigation("Tables");
                });
#pragma warning restore 612, 618
        }
    }
}