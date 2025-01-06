using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetCsharpWebS5.Migrations
{
    /// <inheritdoc />
    public partial class DetailUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Details");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Total",
                table: "Details",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
