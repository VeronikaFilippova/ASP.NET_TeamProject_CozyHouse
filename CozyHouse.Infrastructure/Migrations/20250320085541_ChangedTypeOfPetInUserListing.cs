using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CozyHouse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTypeOfPetInUserListing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserListings_Pets_PetId",
                table: "UserListings");

            migrationBuilder.AddForeignKey(
                name: "FK_UserListings_UserPets_PetId",
                table: "UserListings",
                column: "PetId",
                principalTable: "UserPets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserListings_UserPets_PetId",
                table: "UserListings");

            migrationBuilder.AddForeignKey(
                name: "FK_UserListings_Pets_PetId",
                table: "UserListings",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
