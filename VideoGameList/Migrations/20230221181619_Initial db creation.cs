using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameList.Migrations
{
    public partial class Initialdbcreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    ReleaseYear = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoanedTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoanedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "games");
        }
    }
}
