using Microsoft.EntityFrameworkCore.Migrations;

namespace _301_fu.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shrine",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shrine", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Element",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    labelIdx = table.Column<int>(type: "int", nullable: false),
                    shrineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Element", x => x.id);
                    table.ForeignKey(
                        name: "FK_Element_Shrine_shrineId",
                        column: x => x.shrineId,
                        principalTable: "Shrine",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medallion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    labelIdx = table.Column<int>(type: "int", nullable: false),
                    shrineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medallion", x => x.id);
                    table.ForeignKey(
                        name: "FK_Medallion_Shrine_shrineId",
                        column: x => x.shrineId,
                        principalTable: "Shrine",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    labelIdx = table.Column<int>(type: "int", nullable: false),
                    shrineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.id);
                    table.ForeignKey(
                        name: "FK_Region_Shrine_shrineId",
                        column: x => x.shrineId,
                        principalTable: "Shrine",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Element_shrineId",
                table: "Element",
                column: "shrineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medallion_shrineId",
                table: "Medallion",
                column: "shrineId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_shrineId",
                table: "Region",
                column: "shrineId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Element");

            migrationBuilder.DropTable(
                name: "Medallion");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Shrine");
        }
    }
}
