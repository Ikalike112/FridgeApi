using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class FixFridgeProductsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FridgeProducts_Products_ProductsId",
                table: "FridgeProducts");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "FridgeProducts",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_FridgeProducts_ProductsId",
                table: "FridgeProducts",
                newName: "IX_FridgeProducts_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "DefaultQuantity",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FridgeProducts_Products_ProductId",
                table: "FridgeProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FridgeProducts_Products_ProductId",
                table: "FridgeProducts");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "FridgeProducts",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_FridgeProducts_ProductId",
                table: "FridgeProducts",
                newName: "IX_FridgeProducts_ProductsId");

            migrationBuilder.AlterColumn<int>(
                name: "DefaultQuantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FridgeProducts_Products_ProductsId",
                table: "FridgeProducts",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
