using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UrlPrieto.Migrations
{
    /// <inheritdoc />
    public partial class categories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCategory",
                table: "Url",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "deportes" },
                    { 2, "politica" },
                    { 3, "animales" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Url_IdCategory",
                table: "Url",
                column: "IdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Url_Categories_IdCategory",
                table: "Url",
                column: "IdCategory",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Url_Categories_IdCategory",
                table: "Url");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Url_IdCategory",
                table: "Url");

            migrationBuilder.DropColumn(
                name: "IdCategory",
                table: "Url");
        }
    }
}
