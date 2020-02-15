using Microsoft.EntityFrameworkCore.Migrations;

namespace _2Late2CareBack.Migrations
{
    public partial class Fix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketTag",
                columns: table => new
                {
                    libelle = table.Column<string>(nullable: false),
                    TicketId = table.Column<int>(nullable: false),
                    tagId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTag", x => new { x.libelle, x.TicketId });
                    table.ForeignKey(
                        name: "FK_TicketTag_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketTag_Tags_tagId",
                        column: x => x.tagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketTag_TicketId",
                table: "TicketTag",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTag_tagId",
                table: "TicketTag",
                column: "tagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketTag");
        }
    }
}
