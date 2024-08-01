using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurvaStore.Migrations
{
    /// <inheritdoc />
    public partial class removekeyinColorSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_colorsAndSizes",
                table: "colorsAndSizes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_colorsAndSizes",
                table: "colorsAndSizes",
                columns: new[] { "ProductId", "color", "Size" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_colorsAndSizes",
                table: "colorsAndSizes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_colorsAndSizes",
                table: "colorsAndSizes",
                columns: new[] { "id", "ProductId", "color", "Size" });
        }
    }
}
