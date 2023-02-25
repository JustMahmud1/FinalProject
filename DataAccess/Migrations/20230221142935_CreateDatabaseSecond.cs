using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class CreateDatabaseSecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Garage",
                table: "Properties",
                newName: "IsRentOrSale");

            migrationBuilder.AlterColumn<double>(
                name: "Area",
                table: "Properties",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "HasGarage",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Properties",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsAgent",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TwitterUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_UserId",
                table: "Properties",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_AspNetUsers_UserId",
                table: "Properties",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_AspNetUsers_UserId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_UserId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "HasGarage",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsAgent",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TwitterUrl",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "IsRentOrSale",
                table: "Properties",
                newName: "Garage");

            migrationBuilder.AlterColumn<string>(
                name: "Area",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
