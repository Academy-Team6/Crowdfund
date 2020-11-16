using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfund.Migrations
{
    public partial class TableCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Backer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCreator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCreator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TargetBudget = table.Column<decimal>(nullable: false),
                    CurrentBudget = table.Column<decimal>(nullable: false),
                    BudgetRatio = table.Column<decimal>(nullable: false),
                    ProjectCreatorId = table.Column<int>(nullable: true),
                    BackerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Backer_BackerId",
                        column: x => x.BackerId,
                        principalTable: "Backer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_ProjectCreator_ProjectCreatorId",
                        column: x => x.ProjectCreatorId,
                        principalTable: "ProjectCreator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Paload = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    ProjectId = table.Column<int>(nullable: true),
                    Video_ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Media_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Media_Project_Video_ProjectId",
                        column: x => x.Video_ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RewardPackage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(nullable: false),
                    ProjectId = table.Column<int>(nullable: true),
                    Reward = table.Column<string>(nullable: true),
                    BackerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardPackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RewardPackage_Backer_BackerId",
                        column: x => x.BackerId,
                        principalTable: "Backer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RewardPackage_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Media_ProjectId",
                table: "Media",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_Video_ProjectId",
                table: "Media",
                column: "Video_ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_BackerId",
                table: "Project",
                column: "BackerId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectCreatorId",
                table: "Project",
                column: "ProjectCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_RewardPackage_BackerId",
                table: "RewardPackage",
                column: "BackerId");

            migrationBuilder.CreateIndex(
                name: "IX_RewardPackage_ProjectId",
                table: "RewardPackage",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "RewardPackage");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Backer");

            migrationBuilder.DropTable(
                name: "ProjectCreator");
        }
    }
}
