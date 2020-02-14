using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _2Late2CareBack.Migrations
{
    public partial class Add_votes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketTag_Tags_TagId",
                table: "TicketTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketTag",
                table: "TicketTag");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "TicketTag",
                newName: "tagId");

            migrationBuilder.AlterColumn<int>(
                name: "tagId",
                table: "TicketTag",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "libelle",
                table: "TicketTag",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Tickets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketTag",
                table: "TicketTag",
                columns: new[] { "libelle", "TicketId" });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    ticketId = table.Column<int>(nullable: false),
                    utilisateurId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => new { x.utilisateurId, x.ticketId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketTag_tagId",
                table: "TicketTag",
                column: "tagId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTag_Tags_tagId",
                table: "TicketTag",
                column: "tagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketTag_Tags_tagId",
                table: "TicketTag");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketTag",
                table: "TicketTag");

            migrationBuilder.DropIndex(
                name: "IX_TicketTag_tagId",
                table: "TicketTag");

            migrationBuilder.DropColumn(
                name: "libelle",
                table: "TicketTag");

            migrationBuilder.DropColumn(
                name: "date",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "tagId",
                table: "TicketTag",
                newName: "TagId");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "TicketTag",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketTag",
                table: "TicketTag",
                columns: new[] { "TagId", "TicketId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTag_Tags_TagId",
                table: "TicketTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
