using Microsoft.EntityFrameworkCore.Migrations;

namespace _2Late2CareBack.Migrations
{
    public partial class Add_tickets_to_tag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Tickets_TicketId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_TicketId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Tags");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Tickets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TagId",
                table: "Tickets",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Tags_TagId",
                table: "Tickets",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Tags_TagId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TagId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TicketId",
                table: "Tags",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Tickets_TicketId",
                table: "Tags",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
