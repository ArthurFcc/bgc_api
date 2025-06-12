using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BGC.Api.Web.Migrations
{
    /// <inheritdoc />
    public partial class Boardgame_Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "BGC",
                table: "Boardgames");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "BGC",
                table: "Boardgames");

            migrationBuilder.RenameColumn(
                name: "ReleaseYear",
                schema: "BGC",
                table: "Boardgames",
                newName: "YearPublished");

            migrationBuilder.AddColumn<bool>(
                name: "IsExpansion",
                schema: "BGC",
                table: "Boardgames",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "BGC",
                table: "Boardgames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsExpansion",
                schema: "BGC",
                table: "Boardgames");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "BGC",
                table: "Boardgames");

            migrationBuilder.RenameColumn(
                name: "YearPublished",
                schema: "BGC",
                table: "Boardgames",
                newName: "ReleaseYear");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "BGC",
                table: "Boardgames",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "BGC",
                table: "Boardgames",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
