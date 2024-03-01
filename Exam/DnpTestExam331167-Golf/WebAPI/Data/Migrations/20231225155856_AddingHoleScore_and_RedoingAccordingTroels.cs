using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfcDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingHoleScore_and_RedoingAccordingTroels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HoleScores",
                columns: table => new
                {
                    HoleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoundId = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfStrikes = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerPhone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoleScores", x => x.HoleId);
                    table.ForeignKey(
                        name: "FK_HoleScores_Players_PlayerPhone",
                        column: x => x.PlayerPhone,
                        principalTable: "Players",
                        principalColumn: "Phone");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoleScores_PlayerPhone",
                table: "HoleScores",
                column: "PlayerPhone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoleScores");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Players");
        }
    }
}
