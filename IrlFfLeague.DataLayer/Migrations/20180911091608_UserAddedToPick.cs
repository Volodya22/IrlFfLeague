using Microsoft.EntityFrameworkCore.Migrations;

namespace IrlFfLeague.DataLayer.Migrations
{
    public partial class UserAddedToPick : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Picks",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Picks_UserId",
                table: "Picks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Picks_Users_UserId",
                table: "Picks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picks_Users_UserId",
                table: "Picks");

            migrationBuilder.DropIndex(
                name: "IX_Picks_UserId",
                table: "Picks");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Picks",
                newName: "PlayerId");
        }
    }
}
