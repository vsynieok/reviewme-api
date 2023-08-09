using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReviewMe.Data.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "LastModified", "Name", "Rating" },
                values: new object[,]
                {
                    { new Guid("3a687de0-908b-4468-ba97-a4ffc28ef7e9"), "Чудовий готель! Привітний персонал, бездоганна чистота та неймовірний вид з вікна. Обов'язково повернуся!", new DateTime(2023, 8, 8, 20, 5, 38, 479, DateTimeKind.Utc).AddTicks(2382), "Андрій Соловйов", 5f },
                    { new Guid("ed75d05c-c17b-4cce-8026-21c76c975243"), "Загалом, гарний відпочинок. Номери комфортні, але вранці було трохи шумно через ремонт.", new DateTime(2023, 8, 8, 20, 5, 38, 479, DateTimeKind.Utc).AddTicks(2832), "Катерина Петренко", 4f },
                    { new Guid("b9652c14-0345-45ee-bade-402838e875aa"), "Середній готель. Відсутність басейну та обмежена кількість страв на сніданок розчарували.", new DateTime(2023, 8, 8, 20, 5, 38, 479, DateTimeKind.Utc).AddTicks(2842), "Максим Іванов", 3f },
                    { new Guid("32f5fda9-bb6a-4c80-b70a-9d5a3821a4a5"), "Найкраще місце для відпочинку. Розкішні номери, привітний персонал та чудовий вигляд на море.", new DateTime(2023, 8, 8, 20, 5, 38, 479, DateTimeKind.Utc).AddTicks(2844), "Лілія Григорова", 5f },
                    { new Guid("fc9b0b8e-7252-40f5-9f6a-886819a6703f"), "Незадовільний сервіс. Брудний номер, некомпетентний персонал. Не рекомендую.", new DateTime(2023, 8, 8, 20, 5, 38, 479, DateTimeKind.Utc).AddTicks(2846), "Андрій Коваль", 2f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("32f5fda9-bb6a-4c80-b70a-9d5a3821a4a5"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("3a687de0-908b-4468-ba97-a4ffc28ef7e9"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("b9652c14-0345-45ee-bade-402838e875aa"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("ed75d05c-c17b-4cce-8026-21c76c975243"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("fc9b0b8e-7252-40f5-9f6a-886819a6703f"));
        }
    }
}
