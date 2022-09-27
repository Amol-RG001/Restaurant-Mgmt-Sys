using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodRecipe.Migrations
{
    public partial class FoodEventAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodEvents",
                columns: table => new
                {
                    EventNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(maxLength: 60, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    EventDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodEvents", x => x.EventNo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodEvents");
        }
    }
}
