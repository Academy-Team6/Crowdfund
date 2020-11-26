using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfund.Migrations
{
    public partial class fixedNameInBacker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Backers_BackerId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_RewardPackages_Backers_BackerId",
                table: "RewardPackages");

            migrationBuilder.DropIndex(
                name: "IX_RewardPackages_BackerId",
                table: "RewardPackages");

            migrationBuilder.DropIndex(
                name: "IX_Projects_BackerId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "BackerId",
                table: "RewardPackages");

            migrationBuilder.DropColumn(
                name: "BackerId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Backers");

            migrationBuilder.AlterColumn<int>(
                name: "Reward",
                table: "RewardPackages",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Backers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Backers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Backers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Backers");

            migrationBuilder.AlterColumn<string>(
                name: "Reward",
                table: "RewardPackages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BackerId",
                table: "RewardPackages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BackerId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Backers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RewardPackages_BackerId",
                table: "RewardPackages",
                column: "BackerId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_BackerId",
                table: "Projects",
                column: "BackerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Backers_BackerId",
                table: "Projects",
                column: "BackerId",
                principalTable: "Backers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RewardPackages_Backers_BackerId",
                table: "RewardPackages",
                column: "BackerId",
                principalTable: "Backers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
