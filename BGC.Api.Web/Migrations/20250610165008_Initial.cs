using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BGC.Api.Web.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BGC");

            migrationBuilder.CreateTable(
                name: "Boardgames",
                schema: "BGC",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boardgames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                schema: "BGC",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cover = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardgameCollection",
                schema: "BGC",
                columns: table => new
                {
                    BoardgamesId = table.Column<long>(type: "bigint", nullable: false),
                    CollectionsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardgameCollection", x => new { x.BoardgamesId, x.CollectionsId });
                    table.ForeignKey(
                        name: "FK_BoardgameCollection_Boardgames_BoardgamesId",
                        column: x => x.BoardgamesId,
                        principalSchema: "BGC",
                        principalTable: "Boardgames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardgameCollection_Collections_CollectionsId",
                        column: x => x.CollectionsId,
                        principalSchema: "BGC",
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardgameCollection_CollectionsId",
                schema: "BGC",
                table: "BoardgameCollection",
                column: "CollectionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardgameCollection",
                schema: "BGC");

            migrationBuilder.DropTable(
                name: "Boardgames",
                schema: "BGC");

            migrationBuilder.DropTable(
                name: "Collections",
                schema: "BGC");
        }
    }
}
