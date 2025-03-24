using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CozyHouse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationUserPropertiesChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "PersonName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);
        }
    }
}
