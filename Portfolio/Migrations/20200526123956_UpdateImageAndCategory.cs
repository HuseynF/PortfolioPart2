using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Migrations
{
    public partial class UpdateImageAndCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MyWorks_CategoryId",
                table: "MyWorks",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MyWorks_ImageId",
                table: "MyWorks",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyWorks_Categories_CategoryId",
                table: "MyWorks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MyWorks_Images_ImageId",
                table: "MyWorks",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyWorks_Categories_CategoryId",
                table: "MyWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_MyWorks_Images_ImageId",
                table: "MyWorks");

            migrationBuilder.DropIndex(
                name: "IX_MyWorks_CategoryId",
                table: "MyWorks");

            migrationBuilder.DropIndex(
                name: "IX_MyWorks_ImageId",
                table: "MyWorks");
        }
    }
}
