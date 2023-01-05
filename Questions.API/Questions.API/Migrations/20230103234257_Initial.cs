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
                    Language = table.Column<string>(type: "TEXT", nullable: false),
                    Question = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false)
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
                    { new Guid("1c3f178e-8fab-4d63-9cc8-f50438dd260c"), "Titanic", true, new Guid("0f36ca1e-ec85-47e9-a44a-cfe925411db1") },
                    { new Guid("3d7ca991-6e2a-43b6-ae10-c0e37dc1c803"), "Lionking", true, new Guid("0f36ca1e-ec85-47e9-a44a-cfe925411db1") },
                    { new Guid("4a424e1e-9c30-4b29-a4d9-5d7a55b8845c"), "Maradona", false, new Guid("a52d0157-1069-4f56-a5d5-372fcb10fa3a") },
                    { new Guid("576e5796-b434-431d-af29-0b905f0c6fe4"), "Messi", true, new Guid("a52d0157-1069-4f56-a5d5-372fcb10fa3a") },
                    { new Guid("909d1c9e-1203-4f72-a10f-0bfb9bf6dd09"), "Avatar", true, new Guid("0f36ca1e-ec85-47e9-a44a-cfe925411db1") },
                    { new Guid("ed5487ea-3b4b-41a9-9166-ee6dee5f5672"), "Pele", false, new Guid("a52d0157-1069-4f56-a5d5-372fcb10fa3a") }
                });

            migrationBuilder.InsertData(
                table: "Qns",
                columns: new[] { "Id", "Category", "Language", "Question" },
                values: new object[,]
                {
                    { new Guid("0f36ca1e-ec85-47e9-a44a-cfe925411db1"), "Movies", "Eng", "Best movie?" },
                    { new Guid("a52d0157-1069-4f56-a5d5-372fcb10fa3a"), "Sport", "Svenska", "Best forballplayer?" }
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
