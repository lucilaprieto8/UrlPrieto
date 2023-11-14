using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlPrieto.Migrations
{
    /// <inheritdoc />
    public partial class Count : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cont",
                table: "Url",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cont",
                table: "Url");
        }
    }
}
