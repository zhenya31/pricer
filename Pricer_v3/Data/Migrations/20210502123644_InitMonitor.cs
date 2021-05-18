using Microsoft.EntityFrameworkCore.Migrations;

namespace Pricer_v3.Migrations
{
    public partial class InitMonitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonitorItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Site = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    FirstPrice = table.Column<double>(nullable: false),
                    LastPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitorItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonitorItems");
        }
    }
}
