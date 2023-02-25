using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class About : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageDescription = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ImageSubDescription = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionHeader = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");
        }
    }
}
