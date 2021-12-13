using Microsoft.EntityFrameworkCore.Migrations;

namespace Indimin.Challenge.Tasking.API.Data.Migrations.Tasking
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "IndiminChallenge");

            migrationBuilder.CreateSequence(
                name: "citizentaskseq",
                schema: "IndiminChallenge",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "DayOfWeek",
                schema: "IndiminChallenge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOfWeek", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CitizenTask",
                schema: "IndiminChallenge",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CitizenId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitizenTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CitizenTask_DayOfWeek_DayOfWeek",
                        column: x => x.DayOfWeek,
                        principalSchema: "IndiminChallenge",
                        principalTable: "DayOfWeek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "IndiminChallenge",
                table: "DayOfWeek",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Lunes" },
                    { 2, "Martes" },
                    { 3, "Miercoles" },
                    { 4, "Jueves" },
                    { 5, "Viernes" },
                    { 6, "Sabado" },
                    { 7, "Domingo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CitizenTask_DayOfWeek",
                schema: "IndiminChallenge",
                table: "CitizenTask",
                column: "DayOfWeek");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitizenTask",
                schema: "IndiminChallenge");

            migrationBuilder.DropTable(
                name: "DayOfWeek",
                schema: "IndiminChallenge");

            migrationBuilder.DropSequence(
                name: "citizentaskseq",
                schema: "IndiminChallenge");
        }
    }
}
