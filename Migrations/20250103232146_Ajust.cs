using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetCsharpWebS5.Migrations
{
    /// <inheritdoc />
    public partial class Ajust : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Users");

            migrationBuilder.AlterColumn<float>(
                name: "Solde",
                table: "Clients",
                type: "float",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "float",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Solde",
                table: "Clients",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float");
        }
    }
}
