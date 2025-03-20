using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CozyHouse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ListingAdopterColumnDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_AspNetUsers_AdopterId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_AdopterId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "AdopterId",
                table: "Listings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AdopterId",
                table: "Listings",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Listings_AdopterId",
                table: "Listings",
                column: "AdopterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_AspNetUsers_AdopterId",
                table: "Listings",
                column: "AdopterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
