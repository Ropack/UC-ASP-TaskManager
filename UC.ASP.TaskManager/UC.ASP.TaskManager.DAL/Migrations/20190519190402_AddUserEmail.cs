using Microsoft.EntityFrameworkCore.Migrations;

namespace UC.ASP.TaskManager.DAL.Migrations
{
    public partial class AddUserEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Issues",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Issues");
        }
    }
}
