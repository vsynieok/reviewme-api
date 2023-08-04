using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReviewMe.Data.Migrations
{
    public partial class AddReviewDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Reviews",
                nullable: true,
                defaultValueSql: "getutcdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Reviews");
        }
    }
}
