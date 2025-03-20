using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CozyHouse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserRequestFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_OwnerId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_OwnerId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Requests");

            migrationBuilder.CreateTable(
                name: "UserRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsClosed = table.Column<bool>(type: "INTEGER", nullable: false),
                    AdopterId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OwnerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ListingId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRequests_AspNetUsers_AdopterId",
                        column: x => x.AdopterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRequests_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRequests_UserListings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "UserListings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRequests_AdopterId",
                table: "UserRequests",
                column: "AdopterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRequests_ListingId",
                table: "UserRequests",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRequests_OwnerId",
                table: "UserRequests",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRequests");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Requests",
                type: "TEXT",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Requests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_OwnerId",
                table: "Requests",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_OwnerId",
                table: "Requests",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
