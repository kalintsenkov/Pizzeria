namespace Pizzeria.Server.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class PizzaCartSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "ShoppingCartsPizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "ShoppingCartsPizzas");
        }
    }
}
