using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CozyHouse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OnModelCreatingAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAdoptionRequests_AspNetUsers_AdopterId",
                table: "UserAdoptionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAdoptionRequests_AspNetUsers_OwnerId",
                table: "UserAdoptionRequests");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAdoptionRequests_AspNetUsers_AdopterId",
                table: "UserAdoptionRequests",
                column: "AdopterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAdoptionRequests_AspNetUsers_OwnerId",
                table: "UserAdoptionRequests",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAdoptionRequests_AspNetUsers_AdopterId",
                table: "UserAdoptionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAdoptionRequests_AspNetUsers_OwnerId",
                table: "UserAdoptionRequests");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAdoptionRequests_AspNetUsers_AdopterId",
                table: "UserAdoptionRequests",
                column: "AdopterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAdoptionRequests_AspNetUsers_OwnerId",
                table: "UserAdoptionRequests",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
