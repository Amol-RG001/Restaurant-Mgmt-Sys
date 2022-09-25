using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodRecipe.Migrations
{
    public partial class AddedImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FoodRecipeName",
                table: "FoodRecipes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FoodMakingStep",
                table: "FoodRecipes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(350)",
                oldMaxLength: 350);

            migrationBuilder.AlterColumn<string>(
                name: "FoodIngredient",
                table: "FoodRecipes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "FoodRecipes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "FoodRecipes");

            migrationBuilder.AlterColumn<string>(
                name: "FoodRecipeName",
                table: "FoodRecipes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FoodMakingStep",
                table: "FoodRecipes",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FoodIngredient",
                table: "FoodRecipes",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
