using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stairways.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    ProfileImage = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roadmaps",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<string>(type: "text", nullable: false),
                    Meta_Description = table.Column<string>(type: "text", nullable: false),
                    Meta_ImageURL = table.Column<string>(type: "text", nullable: false),
                    Meta_Privacity = table.Column<int>(type: "integer", nullable: false),
                    Meta_Tags = table.Column<string[]>(type: "text[]", nullable: false),
                    Meta_Title = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roadmaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roadmaps_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    RoadmapEntityId = table.Column<string>(type: "text", nullable: true),
                    Box_Height = table.Column<float>(type: "real", nullable: false),
                    Box_Width = table.Column<float>(type: "real", nullable: false),
                    Box_X = table.Column<int>(type: "integer", nullable: false),
                    Box_Y = table.Column<int>(type: "integer", nullable: false),
                    Content_Description = table.Column<string>(type: "text", nullable: false),
                    Content_Title = table.Column<string>(type: "text", nullable: false),
                    Info_Label = table.Column<string>(type: "text", nullable: false),
                    Info_LabelSize = table.Column<int>(type: "integer", nullable: false),
                    Info_LabelWidth = table.Column<int>(type: "integer", nullable: false),
                    Info_LinkTo = table.Column<string>(type: "text", nullable: false),
                    Info_Type = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Roadmaps_RoadmapEntityId",
                        column: x => x.RoadmapEntityId,
                        principalTable: "Roadmaps",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Edges",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    StartItemAnchor = table.Column<int>(type: "integer", nullable: false),
                    EndItemAnchor = table.Column<int>(type: "integer", nullable: false),
                    Format = table.Column<int>(type: "integer", nullable: false),
                    Style = table.Column<int>(type: "integer", nullable: false),
                    StartItemId = table.Column<string>(type: "text", nullable: false),
                    EndItemId = table.Column<string>(type: "text", nullable: false),
                    RoadmapEntityId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edges_Items_EndItemId",
                        column: x => x.EndItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edges_Items_StartItemId",
                        column: x => x.StartItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edges_Roadmaps_RoadmapEntityId",
                        column: x => x.RoadmapEntityId,
                        principalTable: "Roadmaps",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemLinks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    URL = table.Column<string>(type: "text", nullable: false),
                    RoadmapItemEntityId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemLinks_Items_RoadmapItemEntityId",
                        column: x => x.RoadmapItemEntityId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edges_EndItemId",
                table: "Edges",
                column: "EndItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Edges_RoadmapEntityId",
                table: "Edges",
                column: "RoadmapEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Edges_StartItemId",
                table: "Edges",
                column: "StartItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemLinks_RoadmapItemEntityId",
                table: "ItemLinks",
                column: "RoadmapItemEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_RoadmapEntityId",
                table: "Items",
                column: "RoadmapEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Roadmaps_AuthorId",
                table: "Roadmaps",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edges");

            migrationBuilder.DropTable(
                name: "ItemLinks");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Roadmaps");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
