using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _2Late2CareBack.Migrations
{
    public partial class Add_classes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_Classe_classeId",
                table: "Utilisateurs");

            migrationBuilder.DropIndex(
                name: "IX_Utilisateurs_classeId",
                table: "Utilisateurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classe",
                table: "Classe");

            migrationBuilder.DropColumn(
                name: "classeId",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Classe");

            migrationBuilder.RenameTable(
                name: "Classe",
                newName: "Classes");

            migrationBuilder.AddColumn<string>(
                name: "classelibelle",
                table: "Utilisateurs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classes",
                table: "Classes",
                column: "libelle");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_classelibelle",
                table: "Utilisateurs",
                column: "classelibelle");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_Classes_classelibelle",
                table: "Utilisateurs",
                column: "classelibelle",
                principalTable: "Classes",
                principalColumn: "libelle",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_Classes_classelibelle",
                table: "Utilisateurs");

            migrationBuilder.DropIndex(
                name: "IX_Utilisateurs_classelibelle",
                table: "Utilisateurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classes",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "classelibelle",
                table: "Utilisateurs");

            migrationBuilder.RenameTable(
                name: "Classes",
                newName: "Classe");

            migrationBuilder.AddColumn<int>(
                name: "classeId",
                table: "Utilisateurs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Classe",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classe",
                table: "Classe",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_classeId",
                table: "Utilisateurs",
                column: "classeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_Classe_classeId",
                table: "Utilisateurs",
                column: "classeId",
                principalTable: "Classe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
