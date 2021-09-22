using Microsoft.EntityFrameworkCore.Migrations;

namespace BitCubeStore.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    TypeProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.TypeProductId);
                });

            migrationBuilder.CreateTable(
                name: "ProductsPurchaseOrders",
                columns: table => new
                {
                    ProductPurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TypeProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsPurchaseOrders", x => x.ProductPurchaseId);
                    table.ForeignKey(
                        name: "FK_ProductsPurchaseOrders_ProductTypes_TypeProductId",
                        column: x => x.TypeProductId,
                        principalTable: "ProductTypes",
                        principalColumn: "TypeProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductPurchaseId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SellPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolProducts_ProductsPurchaseOrders_ProductPurchaseId",
                        column: x => x.ProductPurchaseId,
                        principalTable: "ProductsPurchaseOrders",
                        principalColumn: "ProductPurchaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsPurchaseOrders_TypeProductId",
                table: "ProductsPurchaseOrders",
                column: "TypeProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SolProducts_ProductPurchaseId",
                table: "SolProducts",
                column: "ProductPurchaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolProducts");

            migrationBuilder.DropTable(
                name: "ProductsPurchaseOrders");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}
