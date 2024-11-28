using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakkar_Lake_Web_Application.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalDaysToBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalDays",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalDays",
                table: "Bookings");
        }
    }
}
