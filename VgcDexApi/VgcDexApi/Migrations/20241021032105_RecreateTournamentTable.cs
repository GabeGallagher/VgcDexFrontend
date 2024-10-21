using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VgcDexApi.Migrations
{
    /// <inheritdoc />
    public partial class RecreateTournamentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
      migrationBuilder.CreateTable(
        name: "Tournaments",
        columns: table => new
        {
          Id = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
          TournamentId = table.Column<int>(type: "int", nullable: false),
          Division = table.Column<int>(type: "int", nullable: false),
          Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
          Date = table.Column<DateTime>(type: "datetime2", nullable: false),
          Platform = table.Column<int>(type: "int", nullable: false),
          Players = table.Column<int>(type: "int", nullable: false),
          Regulation = table.Column<int>(type: "int", nullable: false),
          Type = table.Column<int>(type: "int", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Tournaments", x => x.Id);
        });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tournaments");
        }
    }
}
