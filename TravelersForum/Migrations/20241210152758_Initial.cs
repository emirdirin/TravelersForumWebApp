using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homework1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    placeName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    placeInfo = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    userName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    submissionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    locationName = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Places");
        }
    }
}
