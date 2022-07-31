using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookingg.DataAccess.Migrations
{
    public partial class insertDataIntoEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDateTime", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 31, 15, 36, 29, 178, DateTimeKind.Local).AddTicks(5859), 1, "Vans" },
                    { 2, new DateTime(2022, 7, 31, 15, 36, 29, 178, DateTimeKind.Local).AddTicks(5909), 2, "Adidas" },
                    { 3, new DateTime(2022, 7, 31, 15, 36, 29, 178, DateTimeKind.Local).AddTicks(5912), 3, "Nike" },
                    { 4, new DateTime(2022, 7, 31, 15, 36, 29, 178, DateTimeKind.Local).AddTicks(5915), 4, "Volcom" }
                });

            migrationBuilder.UpdateData(
                table: "CoverTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 35);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "CoverTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 30);
        }
    }
}
