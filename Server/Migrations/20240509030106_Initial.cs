using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentProject.Server.Migrations
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
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CollectionVocabs",
                columns: table => new
                {
                    CollectionVocabId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollectionVocabName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionVocabs", x => x.CollectionVocabId);
                    table.ForeignKey(
                        name: "FK_CollectionVocabs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    StatisticsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Experience = table.Column<int>(type: "int", nullable: true),
                    Time = table.Column<int>(type: "int", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.StatisticsId);
                    table.ForeignKey(
                        name: "FK_Statistics_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Vocabs",
                columns: table => new
                {
                    VocabId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Original_word = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Translated_word = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Original_language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Translated_language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vocabs", x => x.VocabId);
                    table.ForeignKey(
                        name: "FK_Vocabs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "CollectionMaps",
                columns: table => new
                {
                    CollectionMapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VocabId = table.Column<int>(type: "int", nullable: false),
                    CollectionVocabId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionMaps", x => x.CollectionMapId);
                    table.ForeignKey(
                        name: "FK_CollectionMaps_CollectionVocabs_CollectionVocabId",
                        column: x => x.CollectionVocabId,
                        principalTable: "CollectionVocabs",
                        principalColumn: "CollectionVocabId");
                    table.ForeignKey(
                        name: "FK_CollectionMaps_Vocabs_VocabId",
                        column: x => x.VocabId,
                        principalTable: "Vocabs",
                        principalColumn: "VocabId");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password", "Role" },
                values: new object[] { 1, "Email@address.com", "Rachel", "Allsop", "Password", "User" });

            migrationBuilder.InsertData(
                table: "CollectionVocabs",
                columns: new[] { "CollectionVocabId", "CollectionVocabName", "UserId" },
                values: new object[] { 1, "Animals", 1 });

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "StatisticsId", "Experience", "Language", "Time", "UserId" },
                values: new object[] { 1, 0, "French", 0, 1 });

            migrationBuilder.InsertData(
                table: "Vocabs",
                columns: new[] { "VocabId", "Original_language", "Original_word", "Translated_language", "Translated_word", "UserId" },
                values: new object[] { 1, "English", "Horse", "French", "Cheval", 1 });

            migrationBuilder.InsertData(
                table: "CollectionMaps",
                columns: new[] { "CollectionMapId", "CollectionVocabId", "VocabId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionMaps_CollectionVocabId",
                table: "CollectionMaps",
                column: "CollectionVocabId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionMaps_VocabId",
                table: "CollectionMaps",
                column: "VocabId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionVocabs_UserId",
                table: "CollectionVocabs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_UserId",
                table: "Statistics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vocabs_UserId",
                table: "Vocabs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionMaps");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "CollectionVocabs");

            migrationBuilder.DropTable(
                name: "Vocabs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
