using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlPrieto.Migrations
{
    /// <inheritdoc />
    public partial class olivia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Url",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Url_IdUser",
                table: "Url",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Url_Users_IdUser",
                table: "Url",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Url_Users_IdUser",
                table: "Url");

            migrationBuilder.DropIndex(
                name: "IX_Url_IdUser",
                table: "Url");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Url");
        }
    }
}
