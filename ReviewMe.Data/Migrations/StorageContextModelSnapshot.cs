﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReviewMe.Data;

namespace ReviewMe.Data.Migrations
{
    [DbContext(typeof(StorageContext))]
    partial class StorageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReviewMe.Data.Models.Review", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("LastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3a687de0-908b-4468-ba97-a4ffc28ef7e9"),
                            Comment = "Чудовий готель! Привітний персонал, бездоганна чистота та неймовірний вид з вікна. Обов'язково повернуся!",
                            LastModified = new DateTime(2023, 8, 8, 20, 5, 38, 479, DateTimeKind.Utc).AddTicks(2382),
                            Name = "Андрій Соловйов",
                            Rating = 5f
                        },
                        new
                        {
                            Id = new Guid("ed75d05c-c17b-4cce-8026-21c76c975243"),
                            Comment = "Загалом, гарний відпочинок. Номери комфортні, але вранці було трохи шумно через ремонт.",
                            LastModified = new DateTime(2023, 8, 8, 20, 5, 38, 479, DateTimeKind.Utc).AddTicks(2832),
                            Name = "Катерина Петренко",
                            Rating = 4f
                        },
                        new
                        {
                            Id = new Guid("b9652c14-0345-45ee-bade-402838e875aa"),
                            Comment = "Середній готель. Відсутність басейну та обмежена кількість страв на сніданок розчарували.",
                            LastModified = new DateTime(2023, 8, 8, 20, 5, 38, 479, DateTimeKind.Utc).AddTicks(2842),
                            Name = "Максим Іванов",
                            Rating = 3f
                        },
                        new
                        {
                            Id = new Guid("32f5fda9-bb6a-4c80-b70a-9d5a3821a4a5"),
                            Comment = "Найкраще місце для відпочинку. Розкішні номери, привітний персонал та чудовий вигляд на море.",
                            LastModified = new DateTime(2023, 8, 8, 20, 5, 38, 479, DateTimeKind.Utc).AddTicks(2844),
                            Name = "Лілія Григорова",
                            Rating = 5f
                        },
                        new
                        {
                            Id = new Guid("fc9b0b8e-7252-40f5-9f6a-886819a6703f"),
                            Comment = "Незадовільний сервіс. Брудний номер, некомпетентний персонал. Не рекомендую.",
                            LastModified = new DateTime(2023, 8, 8, 20, 5, 38, 479, DateTimeKind.Utc).AddTicks(2846),
                            Name = "Андрій Коваль",
                            Rating = 2f
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
