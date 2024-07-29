using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stairways.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddedCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Meta_Tags",
                table: "Roadmaps");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Roadmaps",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roadmaps_CategoryId",
                table: "Roadmaps",
                column: "CategoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Roadmaps_Categories_CategoryId",
                table: "Roadmaps",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roadmaps_Categories_CategoryId",
                table: "Roadmaps");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Roadmaps_CategoryId",
                table: "Roadmaps");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Roadmaps");

            migrationBuilder.AddColumn<string[]>(
                name: "Meta_Tags",
                table: "Roadmaps",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);
        }
    }
}
