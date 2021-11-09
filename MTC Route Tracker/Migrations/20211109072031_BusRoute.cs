using Microsoft.EntityFrameworkCore.Migrations;

namespace MTC_Route_Tracker.Migrations
{
    public partial class BusRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Register",
                table: "Register");

            migrationBuilder.RenameTable(
                name: "Register",
                newName: "BusRoute");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusRoute",
                table: "BusRoute",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BusRoute",
                table: "BusRoute");

            migrationBuilder.RenameTable(
                name: "BusRoute",
                newName: "Register");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Register",
                table: "Register",
                column: "Id");
        }
    }
}
