using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookingg.DataAccess.Migrations
{
    public partial class addProductProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 31, 19, 6, 31, 227, DateTimeKind.Local).AddTicks(808));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 31, 19, 6, 31, 227, DateTimeKind.Local).AddTicks(856));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 31, 19, 6, 31, 227, DateTimeKind.Local).AddTicks(860));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 31, 19, 6, 31, 227, DateTimeKind.Local).AddTicks(865));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 31, 17, 11, 8, 999, DateTimeKind.Local).AddTicks(7367));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 31, 17, 11, 8, 999, DateTimeKind.Local).AddTicks(7423));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 31, 17, 11, 8, 999, DateTimeKind.Local).AddTicks(7434));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 31, 17, 11, 8, 999, DateTimeKind.Local).AddTicks(7444));
        }
    }
}
