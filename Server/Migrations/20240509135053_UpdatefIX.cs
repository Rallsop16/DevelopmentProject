using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentProject.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdatefIX : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CollectionVocabs",
                columns: new[] { "CollectionVocabId", "CollectionVocabName", "UserId" },
                values: new object[] { 99, "Dog Breeds", 2 });

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "StatisticsId", "Experience", "Language", "Time", "UserId" },
                values: new object[] { 2, 0, "French", 0, 2 });

            migrationBuilder.InsertData(
                table: "Vocabs",
                columns: new[] { "VocabId", "Original_language", "Original_word", "Translated_language", "Translated_word", "UserId" },
                values: new object[] { 98, "English", "DOG", "French", "CHIEN", 2 });

            migrationBuilder.InsertData(
                table: "CollectionMaps",
                columns: new[] { "CollectionMapId", "CollectionVocabId", "VocabId" },
                values: new object[] { 88, 99, 98 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CollectionMaps",
                keyColumn: "CollectionMapId",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Statistics",
                keyColumn: "StatisticsId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CollectionVocabs",
                keyColumn: "CollectionVocabId",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Vocabs",
                keyColumn: "VocabId",
                keyValue: 98);
        }
    }
}
