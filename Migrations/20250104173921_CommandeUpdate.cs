using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetCsharpWebS5.Migrations
{
    /// <inheritdoc />
    public partial class CommandeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LivraisonId",
                table: "Commandes");

            migrationBuilder.DropColumn(
                name: "PaiementId",
                table: "Commandes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LivraisonId",
                table: "Commandes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaiementId",
                table: "Commandes",
                type: "int",
                nullable: true);
        }
    }
}
