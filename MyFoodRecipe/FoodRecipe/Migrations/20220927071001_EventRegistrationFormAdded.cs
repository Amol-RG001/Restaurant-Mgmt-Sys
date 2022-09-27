using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodRecipe.Migrations
{
    public partial class EventRegistrationFormAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "EventRegistrationForm");

            migrationBuilder.AddColumn<string>(
                name: "ParticipantName",
                table: "EventRegistrationForm",
                maxLength: 60,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParticipantName",
                table: "EventRegistrationForm");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "EventRegistrationForm",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");
        }
    }
}
