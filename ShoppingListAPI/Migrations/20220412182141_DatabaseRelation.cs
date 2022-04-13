using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListAPI.Migrations
{
    public partial class DatabaseRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdCategory",
                table: "Items",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Categories",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserId",
                table: "Categories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_UserId",
                table: "Categories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_UserId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CategoryId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UserId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Items",
                newName: "IdCategory");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Categories",
                newName: "IdUser");
        }
    }
}
