using Microsoft.EntityFrameworkCore.Migrations;

namespace EFlowerShop.Repository.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FlowerInShoppingCarts",
                table: "FlowerInShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlowerInOrders",
                table: "FlowerInOrders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlowerInShoppingCarts",
                table: "FlowerInShoppingCarts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlowerInOrders",
                table: "FlowerInOrders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FlowerInShoppingCarts_FlowerId",
                table: "FlowerInShoppingCarts",
                column: "FlowerId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowerInOrders_FlowerId",
                table: "FlowerInOrders",
                column: "FlowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FlowerInShoppingCarts",
                table: "FlowerInShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_FlowerInShoppingCarts_FlowerId",
                table: "FlowerInShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlowerInOrders",
                table: "FlowerInOrders");

            migrationBuilder.DropIndex(
                name: "IX_FlowerInOrders_FlowerId",
                table: "FlowerInOrders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlowerInShoppingCarts",
                table: "FlowerInShoppingCarts",
                columns: new[] { "FlowerId", "ShoppingCartId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlowerInOrders",
                table: "FlowerInOrders",
                columns: new[] { "FlowerId", "OrderId" });
        }
    }
}
