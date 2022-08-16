using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaPrep.Migrations
{
    public partial class updateRecipeWithDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "RecipeIngredients");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Recipes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Recipes");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Recipes",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Recipes",
                type: "BLOB",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "RecipeIngredients",
                type: "BLOB",
                rowVersion: true,
                nullable: true);
        }
    }
}
