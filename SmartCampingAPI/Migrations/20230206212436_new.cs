using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartCampingAPI.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoNoite",
                table: "Reservas");

            migrationBuilder.AddColumn<double>(
                name: "PrecoNoite",
                table: "Alojamentos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoNoite",
                table: "Alojamentos");

            migrationBuilder.AddColumn<double>(
                name: "PrecoNoite",
                table: "Reservas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
