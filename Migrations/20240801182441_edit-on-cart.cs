using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurvaStore.Migrations
{
    /// <inheritdoc />
    public partial class editoncart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "carts",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "ColorSizeId",
                table: "carts",
                newName: "colorSizeId");

            migrationBuilder.AddColumn<int>(
                name: "colorsizeProductId",
                table: "carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_carts_colorSizeId_colorsizeProductId",
                table: "carts",
                columns: new[] { "colorSizeId", "colorsizeProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_carts_productId",
                table: "carts",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_colorsAndSizes_colorSizeId_colorsizeProductId",
                table: "carts",
                columns: new[] { "colorSizeId", "colorsizeProductId" },
                principalTable: "colorsAndSizes",
                principalColumns: new[] { "id", "ProductId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_carts_products_productId",
                table: "carts",
                column: "productId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_colorsAndSizes_colorSizeId_colorsizeProductId",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_carts_products_productId",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_colorSizeId_colorsizeProductId",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_productId",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "colorsizeProductId",
                table: "carts");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "carts",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "colorSizeId",
                table: "carts",
                newName: "ColorSizeId");
        }
    }
}
