using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrarion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReadDirection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direction = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadDirection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Situation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipamentIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UfSourceId = table.Column<int>(type: "int", nullable: false),
                    UfDestinationId = table.Column<int>(type: "int", nullable: false),
                    ReadDirectionId = table.Column<int>(type: "int", nullable: false),
                    SituationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipament", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipament_ReadDirection_ReadDirectionId",
                        column: x => x.ReadDirectionId,
                        principalTable: "ReadDirection",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipament_Situation_SituationId",
                        column: x => x.SituationId,
                        principalTable: "Situation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipament_UF_UfDestinationId",
                        column: x => x.UfDestinationId,
                        principalTable: "UF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipament_UF_UfSourceId",
                        column: x => x.UfSourceId,
                        principalTable: "UF",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipament_ReadDirectionId",
                table: "Equipament",
                column: "ReadDirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipament_SituationId",
                table: "Equipament",
                column: "SituationId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipament_UfDestinationId",
                table: "Equipament",
                column: "UfDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipament_UfSourceId",
                table: "Equipament",
                column: "UfSourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipament");

            migrationBuilder.DropTable(
                name: "ReadDirection");

            migrationBuilder.DropTable(
                name: "Situation");

            migrationBuilder.DropTable(
                name: "UF");
        }
    }
}
