using Microsoft.EntityFrameworkCore.Migrations;

namespace _2Late2CareBack.Migrations
{
    public partial class Add_manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "TicketTag",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false),
                    TicketId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTag", x => new { x.TagId, x.TicketId });
                    table.ForeignKey(
                        name: "FK_TicketTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketTag_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketTag_TicketId",
                table: "TicketTag",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketTag");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Tickets",
                type: "int",
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
    }
}
