using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzeria.Server.Data.Migrations
{
    public partial class RenameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_UserId",
                table: "ShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartPizza_Pizzas_PizzaId",
                table: "ShoppingCartPizza");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartPizza_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartPizza");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartPizza",
                table: "ShoppingCartPizza");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart");

            migrationBuilder.RenameTable(
                name: "ShoppingCartPizza",
                newName: "ShoppingCartsPizzas");

            migrationBuilder.RenameTable(
                name: "ShoppingCart",
                newName: "ShoppingCarts");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartPizza_PizzaId",
                table: "ShoppingCartsPizzas",
                newName: "IX_ShoppingCartsPizzas_PizzaId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_UserId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartsPizzas",
                table: "ShoppingCartsPizzas",
                columns: new[] { "ShoppingCartId", "PizzaId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartsPizzas_Pizzas_PizzaId",
                table: "ShoppingCartsPizzas",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartsPizzas_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartsPizzas",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_UserId",
                table: "ShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartsPizzas_Pizzas_PizzaId",
                table: "ShoppingCartsPizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartsPizzas_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartsPizzas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartsPizzas",
                table: "ShoppingCartsPizzas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts");

            migrationBuilder.RenameTable(
                name: "ShoppingCartsPizzas",
                newName: "ShoppingCartPizza");

            migrationBuilder.RenameTable(
                name: "ShoppingCarts",
                newName: "ShoppingCart");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartsPizzas_PizzaId",
                table: "ShoppingCartPizza",
                newName: "IX_ShoppingCartPizza_PizzaId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartPizza",
                table: "ShoppingCartPizza",
                columns: new[] { "ShoppingCartId", "PizzaId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_UserId",
                table: "ShoppingCart",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartPizza_Pizzas_PizzaId",
                table: "ShoppingCartPizza",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartPizza_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartPizza",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
