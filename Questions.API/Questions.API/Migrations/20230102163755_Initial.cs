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
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    QuestionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Answer = table.Column<string>(type: "TEXT", nullable: false),
                    IsCorrectAnswer = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Language = table.Column<string>(type: "TEXT", nullable: false),
                    Question = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WalkDifficulty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalkDifficulty", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Answer", "IsCorrectAnswer", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("05d71be1-bdd7-47d5-8c2e-4dec11109f7d"), "Maradona", false, new Guid("3994d4a4-7114-41f2-b56d-5518c63dc327") },
                    { new Guid("0cfdae16-c2f2-45a7-825f-c90cdc5fe164"), "Titanic", true, new Guid("3b79e828-ab7a-44ee-8256-8539098a6e46") },
                    { new Guid("7458d5f3-24e0-46b2-86ba-0b42332a497f"), "Lionking", true, new Guid("3b79e828-ab7a-44ee-8256-8539098a6e46") },
                    { new Guid("95103e20-a1c6-42db-b29b-0645619c1908"), "Messi", true, new Guid("3994d4a4-7114-41f2-b56d-5518c63dc327") },
                    { new Guid("a7a20f6a-0dd0-4160-9387-e9398fcff169"), "Avatar", true, new Guid("3b79e828-ab7a-44ee-8256-8539098a6e46") },
                    { new Guid("b937696b-fdee-4da6-b616-fd68da195ff0"), "Pele", false, new Guid("3994d4a4-7114-41f2-b56d-5518c63dc327") }
                });

            migrationBuilder.InsertData(
                table: "Qns",
                columns: new[] { "Id", "Category", "Language", "Question" },
                values: new object[,]
                {
                    { new Guid("3994d4a4-7114-41f2-b56d-5518c63dc327"), "Sport", "Svenska", "Best forballplayer?" },
                    { new Guid("3b79e828-ab7a-44ee-8256-8539098a6e46"), "Movies", "Eng", "Best movie?" }
                });

            migrationBuilder.InsertData(
                table: "WalkDifficulty",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { new Guid("75c7f549-a546-48c2-8cc5-4ebd3dba5f1a"), "Code 1" },
                    { new Guid("aa23131e-cc1b-4757-9843-7a6988abe365"), "Code 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Qns");

            migrationBuilder.DropTable(
                name: "WalkDifficulty");
        }
    }
}
