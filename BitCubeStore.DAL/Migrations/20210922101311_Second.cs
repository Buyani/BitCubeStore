using Microsoft.EntityFrameworkCore.Migrations;

namespace BitCubeStore.DAL.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsPurchaseOrders_ProductTypes_TypeProductId",
                table: "ProductsPurchaseOrders");

            migrationBuilder.AlterColumn<int>(
                name: "TypeProductId",
                table: "ProductsPurchaseOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId",
                table: "ProductsPurchaseOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsPurchaseOrders_ProductTypes_TypeProductId",
                table: "ProductsPurchaseOrders",
                column: "TypeProductId",
                principalTable: "ProductTypes",
                principalColumn: "TypeProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsPurchaseOrders_ProductTypes_TypeProductId",
                table: "ProductsPurchaseOrders");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                table: "ProductsPurchaseOrders");

            migrationBuilder.AlterColumn<int>(
                name: "TypeProductId",
                table: "ProductsPurchaseOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsPurchaseOrders_ProductTypes_TypeProductId",
                table: "ProductsPurchaseOrders",
                column: "TypeProductId",
                principalTable: "ProductTypes",
                principalColumn: "TypeProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
