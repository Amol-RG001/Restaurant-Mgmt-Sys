using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodRecipe.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodCategories",
                columns: table => new
                {
                    FoodCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodCategoryName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategories", x => x.FoodCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "FoodSubCategories",
                columns: table => new
                {
                    FoodSubCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodSubCategoryName = table.Column<string>(maxLength: 50, nullable: false),
                    FoodCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodSubCategories", x => x.FoodSubCategoryId);
                    table.ForeignKey(
                        name: "FK_FoodSubCategories_FoodCategories_FoodCategoryId",
                        column: x => x.FoodCategoryId,
                        principalTable: "FoodCategories",
                        principalColumn: "FoodCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodRecipes",
                columns: table => new
                {
                    FoodRecipeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodRecipeName = table.Column<string>(maxLength: 50, nullable: false),
                    FoodSubCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodRecipes", x => x.FoodRecipeId);
                    table.ForeignKey(
                        name: "FK_FoodRecipes_FoodSubCategories_FoodSubCategoryId",
                        column: x => x.FoodSubCategoryId,
                        principalTable: "FoodSubCategories",
                        principalColumn: "FoodSubCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodRecipes_FoodSubCategoryId",
                table: "FoodRecipes",
                column: "FoodSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodSubCategories_FoodCategoryId",
                table: "FoodSubCategories",
                column: "FoodCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodRecipes");

            migrationBuilder.DropTable(
                name: "FoodSubCategories");

            migrationBuilder.DropTable(
                name: "FoodCategories");
        }
    }
}
