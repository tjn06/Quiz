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
                    Answer = table.Column<string>(type: "TEXT", nullable: true),
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
                    Language = table.Column<string>(type: "TEXT", nullable: true),
                    Question = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qns", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Answer", "IsCorrectAnswer", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("44a4f422-54f5-4f60-860e-78b587d6056f"), "Lionking", true, new Guid("5bb1afca-a1a7-4cf8-8130-1926a935d95b") },
                    { new Guid("4badef91-777f-4134-957b-6cddfc3c7b65"), "Titanic", true, new Guid("5bb1afca-a1a7-4cf8-8130-1926a935d95b") },
                    { new Guid("65111773-3cd7-4e03-8fed-29f7325bbff0"), "Pele", false, new Guid("d8a36fe1-35d2-49ef-b0f2-94922e14a885") },
                    { new Guid("7605b90e-42bc-4221-961a-58c173d64d80"), "Avatar", true, new Guid("5bb1afca-a1a7-4cf8-8130-1926a935d95b") },
                    { new Guid("a229f15f-8302-4465-90b8-5c2ff72c0895"), "Maradona", false, new Guid("d8a36fe1-35d2-49ef-b0f2-94922e14a885") },
                    { new Guid("c5e9ff3e-e788-4ddf-bea8-f574060300aa"), "Messi", true, new Guid("d8a36fe1-35d2-49ef-b0f2-94922e14a885") }
                });

            migrationBuilder.InsertData(
                table: "Qns",
                columns: new[] { "Id", "Category", "Language", "Question" },
                values: new object[,]
                {
                    { new Guid("5bb1afca-a1a7-4cf8-8130-1926a935d95b"), "Movies", "Eng", "Best movie?" },
                    { new Guid("d8a36fe1-35d2-49ef-b0f2-94922e14a885"), "Sport", "Svenska", "Best forballplayer?" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Qns");
        }
    }
}
