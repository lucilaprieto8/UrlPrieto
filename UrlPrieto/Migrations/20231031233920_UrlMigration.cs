using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlPrieto.Migrations
{
    /// <inheritdoc />
    public partial class UrlMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Url",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    largeUrl = table.Column<string>(type: "TEXT", nullable: false),
                    smallUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Url", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Url");
        }
    }
}
