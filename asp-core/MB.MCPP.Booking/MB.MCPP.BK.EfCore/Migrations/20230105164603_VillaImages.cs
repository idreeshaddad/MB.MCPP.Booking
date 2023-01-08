using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MB.MCPP.BK.EfCore.Migrations
{
    public partial class VillaImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VillaImages_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VillaImages_VillaId",
                table: "VillaImages",
                column: "VillaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaImages");
        }
    }
}
