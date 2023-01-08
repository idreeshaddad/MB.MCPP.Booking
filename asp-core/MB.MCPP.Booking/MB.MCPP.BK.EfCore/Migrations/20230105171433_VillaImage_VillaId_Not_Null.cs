using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MB.MCPP.BK.EfCore.Migrations
{
    public partial class VillaImage_VillaId_Not_Null : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaImages_Villas_VillaId",
                table: "VillaImages");

            migrationBuilder.AlterColumn<int>(
                name: "VillaId",
                table: "VillaImages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VillaImages_Villas_VillaId",
                table: "VillaImages",
                column: "VillaId",
                principalTable: "Villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaImages_Villas_VillaId",
                table: "VillaImages");

            migrationBuilder.AlterColumn<int>(
                name: "VillaId",
                table: "VillaImages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_VillaImages_Villas_VillaId",
                table: "VillaImages",
                column: "VillaId",
                principalTable: "Villas",
                principalColumn: "Id");
        }
    }
}
