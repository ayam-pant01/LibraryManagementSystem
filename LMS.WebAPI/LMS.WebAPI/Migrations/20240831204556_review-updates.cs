using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class reviewupdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_CheckoutDetails_BookId",
                table: "CheckoutDetails");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId_UserId",
                table: "Reviews",
                columns: new[] { "BookId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutDetails_BookId_ReturnedDate",
                table: "CheckoutDetails",
                columns: new[] { "BookId", "ReturnedDate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reviews_BookId_UserId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_CheckoutDetails_BookId_ReturnedDate",
                table: "CheckoutDetails");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutDetails_BookId",
                table: "CheckoutDetails",
                column: "BookId");
        }
    }
}
