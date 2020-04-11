using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkerCRM.Data.Migrations
{
    public partial class orderfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductInOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductInOrders_ProductId",
                table: "ProductInOrders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInOrders_Products_ProductId",
                table: "ProductInOrders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInOrders_Products_ProductId",
                table: "ProductInOrders");

            migrationBuilder.DropIndex(
                name: "IX_ProductInOrders_ProductId",
                table: "ProductInOrders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductInOrders");
        }
    }
}
