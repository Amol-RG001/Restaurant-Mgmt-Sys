using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodRecipe.Migrations
{
    public partial class AddedRelationInFoodEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "FoodRecipes");

            migrationBuilder.AddColumn<string>(
                name: "EventName",
                table: "EventRegistrationForm",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FoodEventEventNo",
                table: "EventRegistrationForm",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrationForm_FoodEventEventNo",
                table: "EventRegistrationForm",
                column: "FoodEventEventNo");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrationForm_FoodEvents_FoodEventEventNo",
                table: "EventRegistrationForm",
                column: "FoodEventEventNo",
                principalTable: "FoodEvents",
                principalColumn: "EventNo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrationForm_FoodEvents_FoodEventEventNo",
                table: "EventRegistrationForm");

            migrationBuilder.DropIndex(
                name: "IX_EventRegistrationForm_FoodEventEventNo",
                table: "EventRegistrationForm");

            migrationBuilder.DropColumn(
                name: "EventName",
                table: "EventRegistrationForm");

            migrationBuilder.DropColumn(
                name: "FoodEventEventNo",
                table: "EventRegistrationForm");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "FoodRecipes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
