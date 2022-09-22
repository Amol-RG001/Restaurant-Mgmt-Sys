using Microsoft.EntityFrameworkCore.Migrations;

namespace Major_Food_Recipe.Migrations
{
    public partial class AddedFoodRecipeToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodRecipes",
                columns: table => new
                {
                    FoodRecipeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodRecipeName = table.Column<string>(maxLength: 50, nullable: false),
                    FoodCategoryId = table.Column<int>(nullable: false),
                    FoodSubCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodRecipes", x => x.FoodRecipeId);
                    table.ForeignKey(
                        name: "FK_FoodRecipes_FoodCategories_FoodCategoryId",
                        column: x => x.FoodCategoryId,
                        principalTable: "FoodCategories",
                        principalColumn: "FoodCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodRecipes_FoodSubCategories_FoodSubCategoryId",
                        column: x => x.FoodSubCategoryId,
                        principalTable: "FoodSubCategories",
                        principalColumn: "FoodSubCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodRecipes_FoodCategoryId",
                table: "FoodRecipes",
                column: "FoodCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRecipes_FoodSubCategoryId",
                table: "FoodRecipes",
                column: "FoodSubCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodRecipes");
        }
    }
}
