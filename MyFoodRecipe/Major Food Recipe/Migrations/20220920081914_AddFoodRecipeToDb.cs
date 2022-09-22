using Microsoft.EntityFrameworkCore.Migrations;

namespace Major_Food_Recipe.Migrations
{
    public partial class AddFoodRecipeToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodRecipes_FoodCategories_FoodCategoryId",
                table: "FoodRecipes");

            migrationBuilder.AlterColumn<int>(
                name: "FoodCategoryId",
                table: "FoodRecipes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodRecipes_FoodCategories_FoodCategoryId",
                table: "FoodRecipes",
                column: "FoodCategoryId",
                principalTable: "FoodCategories",
                principalColumn: "FoodCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodRecipes_FoodCategories_FoodCategoryId",
                table: "FoodRecipes");

            migrationBuilder.AlterColumn<int>(
                name: "FoodCategoryId",
                table: "FoodRecipes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodRecipes_FoodCategories_FoodCategoryId",
                table: "FoodRecipes",
                column: "FoodCategoryId",
                principalTable: "FoodCategories",
                principalColumn: "FoodCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
