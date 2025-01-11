using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakkar_Lake_Web_Application.Migrations
{
    /// <inheritdoc />
    public partial class addBookingRoomToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingRooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    B_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingRooms", x => new { x.B_Id, x.RoomId });
                    table.ForeignKey(
                        name: "FK_BookingRooms_Bookings_B_Id",
                        column: x => x.B_Id,
                        principalTable: "Bookings",
                        principalColumn: "B_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingRooms_RoomId",
                table: "BookingRooms",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingRooms");
        }
    }
}
