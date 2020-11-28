using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfund.Migrations
{
    public partial class MediaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Projects_Video_ProjectId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_Video_ProjectId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Video_ProjectId",
                table: "Media");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Media",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Video_ProjectId",
                table: "Media",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Media_Video_ProjectId",
                table: "Media",
                column: "Video_ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Projects_Video_ProjectId",
                table: "Media",
                column: "Video_ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
