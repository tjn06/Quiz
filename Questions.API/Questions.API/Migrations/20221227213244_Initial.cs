using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Questions.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Area = table.Column<double>(type: "REAL", nullable: false),
                    Lat = table.Column<double>(type: "REAL", nullable: false),
                    Long = table.Column<double>(type: "REAL", nullable: false),
                    Population = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WalkDifficulty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalkDifficulty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Walks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Length = table.Column<double>(type: "REAL", nullable: false),
                    RegionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    WalkDifficultyId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Walks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Walks_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Walks_WalkDifficulty_WalkDifficultyId",
                        column: x => x.WalkDifficultyId,
                        principalTable: "WalkDifficulty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Area", "Code", "Lat", "Long", "Name", "Population" },
                values: new object[,]
                {
                    { new Guid("22fda770-9b6f-451f-9ca7-d884436f0acd"), 34.0, "NEW", 22.0, 11.0, "Newland", 77.0 },
                    { new Guid("4467c0fa-6be8-4237-a313-2e6e8f98a8e5"), 22.0, "AUCK", 33.0, 44.0, "Auckland", 45.0 }
                });

            migrationBuilder.InsertData(
                table: "WalkDifficulty",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { new Guid("40ffdbe8-cf26-4c71-94cb-ec184b78793d"), "Code 2" },
                    { new Guid("b9bf707c-89fb-45f2-88af-9a2482deb9d9"), "Code 1" }
                });

            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "Id", "Length", "Name", "RegionId", "WalkDifficultyId" },
                values: new object[,]
                {
                    { new Guid("3cf773d7-b72b-4b16-a09a-99623bb03c3b"), 3.5, "Rainbow Mou", new Guid("22fda770-9b6f-451f-9ca7-d884436f0acd"), new Guid("40ffdbe8-cf26-4c71-94cb-ec184b78793d") },
                    { new Guid("dc4757c7-b0e9-4086-8783-6ce945c0efcc"), 3.5, "One Three Hill Walk", new Guid("4467c0fa-6be8-4237-a313-2e6e8f98a8e5"), new Guid("b9bf707c-89fb-45f2-88af-9a2482deb9d9") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Walks_RegionId",
                table: "Walks",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Walks_WalkDifficultyId",
                table: "Walks",
                column: "WalkDifficultyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Walks");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "WalkDifficulty");
        }
    }
}
