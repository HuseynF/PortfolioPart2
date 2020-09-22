using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Migrations
{
    public partial class UpdateMyWorks2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CloseName",
                table: "MyWorks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModalName",
                table: "MyWorks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "MyWorks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CloseName",
                table: "MyWorks");

            migrationBuilder.DropColumn(
                name: "ModalName",
                table: "MyWorks");

            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "MyWorks");
        }
    }
}
