using Microsoft.EntityFrameworkCore.Migrations;

namespace MTC_Route_Tracker.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Register",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartingPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndingPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Via = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrequencyType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Register", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Register");
        }
    }
}
