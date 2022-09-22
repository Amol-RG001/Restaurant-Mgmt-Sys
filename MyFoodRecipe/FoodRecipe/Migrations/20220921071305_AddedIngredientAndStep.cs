using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodRecipe.Migrations
{
    public partial class AddedIngredientAndStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FoodIngredient",
                table: "FoodRecipes",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FoodMakingStep",
                table: "FoodRecipes",
                maxLength: 350,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodIngredient",
                table: "FoodRecipes");

            migrationBuilder.DropColumn(
                name: "FoodMakingStep",
                table: "FoodRecipes");
        }
    }
}
