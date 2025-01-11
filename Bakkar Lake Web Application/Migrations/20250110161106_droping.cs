using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakkar_Lake_Web_Application.Migrations
{
    /// <inheritdoc />
    public partial class droping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookinRooms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookinRooms",
                columns: table => new
                {
                    B_Id = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookinRooms", x => new { x.B_Id, x.RoomId });
                    table.ForeignKey(
                        name: "FK_BookinRooms_Bookings_B_Id",
                        column: x => x.B_Id,
                        principalTable: "Bookings",
                        principalColumn: "B_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookinRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookinRooms_RoomId",
                table: "BookinRooms",
                column: "RoomId");
        }
    }
}
