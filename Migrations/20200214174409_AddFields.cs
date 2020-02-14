using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _2Late2CareBack.Migrations
{
    public partial class AddFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "classeId",
                table: "Utilisateurs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "mail",
                table: "Utilisateurs",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "pseudo",
                table: "Utilisateurs",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "auteurId",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Tickets",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "titre",
                table: "Tickets",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "urlPhoto",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "libelle",
                table: "Tags",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "Classe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    libelle = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classe", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_classeId",
                table: "Utilisateurs",
                column: "classeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_auteurId",
                table: "Tickets",
                column: "auteurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Utilisateurs_auteurId",
                table: "Tickets",
                column: "auteurId",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_Classe_classeId",
                table: "Utilisateurs",
                column: "classeId",
                principalTable: "Classe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Utilisateurs_auteurId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_Classe_classeId",
                table: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "Classe");

            migrationBuilder.DropIndex(
                name: "IX_Utilisateurs_classeId",
                table: "Utilisateurs");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_auteurId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "classeId",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "mail",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "pseudo",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "auteurId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "titre",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "urlPhoto",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "libelle",
                table: "Tags");
        }
    }
}
