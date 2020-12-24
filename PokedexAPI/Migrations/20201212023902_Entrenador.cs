using Microsoft.EntityFrameworkCore.Migrations;

namespace PokedexAPI.Migrations
{
    public partial class Entrenador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EntrenadorId",
                table: "Pokemones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Entrenadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrenadores", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemones_EntrenadorId",
                table: "Pokemones",
                column: "EntrenadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemones_Entrenadores_EntrenadorId",
                table: "Pokemones",
                column: "EntrenadorId",
                principalTable: "Entrenadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemones_Entrenadores_EntrenadorId",
                table: "Pokemones");

            migrationBuilder.DropTable(
                name: "Entrenadores");

            migrationBuilder.DropIndex(
                name: "IX_Pokemones_EntrenadorId",
                table: "Pokemones");

            migrationBuilder.DropColumn(
                name: "EntrenadorId",
                table: "Pokemones");
        }
    }
}
