﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurvaStore.Migrations
{
    /// <inheritdoc />
    public partial class ss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_colorsAndSizes",
                table: "colorsAndSizes");

            migrationBuilder.AlterColumn<string>(
                name: "Img",
                table: "products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "colorsAndSizes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_colorsAndSizes",
                table: "colorsAndSizes",
                column: "color");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_colorsAndSizes",
                table: "colorsAndSizes");

            migrationBuilder.AlterColumn<string>(
                name: "Img",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "colorsAndSizes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_colorsAndSizes",
                table: "colorsAndSizes",
                columns: new[] { "id", "ProductId", "color", "Size" });
        }
    }
}
