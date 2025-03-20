using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CozyHouse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewTableUserListingsCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listing_Pets_PetId",
                table: "Listing");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Listing_ListingId",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Listing",
                table: "Listing");

            migrationBuilder.RenameTable(
                name: "Listing",
                newName: "Listings");

            migrationBuilder.RenameIndex(
                name: "IX_Listing_PetId",
                table: "Listings",
                newName: "IX_Listings_PetId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Listings",
                type: "TEXT",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Listings",
                table: "Listings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Pets_PetId",
                table: "Listings",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Listings_ListingId",
                table: "Requests",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Pets_PetId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Listings_ListingId",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Listings",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Listings");

            migrationBuilder.RenameTable(
                name: "Listings",
                newName: "Listing");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_PetId",
                table: "Listing",
                newName: "IX_Listing_PetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Listing",
                table: "Listing",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_Pets_PetId",
                table: "Listing",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Listing_ListingId",
                table: "Requests",
                column: "ListingId",
                principalTable: "Listing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
