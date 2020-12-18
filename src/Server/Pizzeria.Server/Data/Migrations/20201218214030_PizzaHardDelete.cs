namespace Pizzeria.Server.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class PizzaHardDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pizzas_IsDeleted",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Pizzas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Pizzas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Pizzas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_IsDeleted",
                table: "Pizzas",
                column: "IsDeleted");
        }
    }
}
