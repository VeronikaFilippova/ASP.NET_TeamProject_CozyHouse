using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CozyHouse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EntitiesUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_PetOwnerId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_UserId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserListings_UserPets_PetId",
                table: "UserListings");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserListings",
                newName: "OwnerId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Requests",
                newName: "AdopterId");

            migrationBuilder.RenameColumn(
                name: "PetOwnerId",
                table: "Requests",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_UserId",
                table: "Requests",
                newName: "IX_Requests_AdopterId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_PetOwnerId",
                table: "Requests",
                newName: "IX_Requests_OwnerId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Listings",
                newName: "AdopterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserListings_OwnerId",
                table: "UserListings",
                column: "OwnerId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_AdopterId",
                table: "Requests",
                column: "AdopterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_OwnerId",
                table: "Requests",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserListings_AspNetUsers_OwnerId",
                table: "UserListings",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserListings_Pets_PetId",
                table: "UserListings",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_AspNetUsers_AdopterId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_AdopterId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_OwnerId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserListings_AspNetUsers_OwnerId",
                table: "UserListings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserListings_Pets_PetId",
                table: "UserListings");

            migrationBuilder.DropIndex(
                name: "IX_UserListings_OwnerId",
                table: "UserListings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_AdopterId",
                table: "Listings");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "UserListings",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Requests",
                newName: "PetOwnerId");

            migrationBuilder.RenameColumn(
                name: "AdopterId",
                table: "Requests",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_OwnerId",
                table: "Requests",
                newName: "IX_Requests_PetOwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_AdopterId",
                table: "Requests",
                newName: "IX_Requests_UserId");

            migrationBuilder.RenameColumn(
                name: "AdopterId",
                table: "Listings",
                newName: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_PetOwnerId",
                table: "Requests",
                column: "PetOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_UserId",
                table: "Requests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserListings_UserPets_PetId",
                table: "UserListings",
                column: "PetId",
                principalTable: "UserPets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
