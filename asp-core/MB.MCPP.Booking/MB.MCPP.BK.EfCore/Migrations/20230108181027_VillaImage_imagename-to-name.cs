using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MB.MCPP.BK.EfCore.Migrations
{
    public partial class VillaImage_imagenametoname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "VillaImages",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_VillaImages_ImageName",
                table: "VillaImages",
                newName: "IX_VillaImages_Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "VillaImages",
                newName: "ImageName");

            migrationBuilder.RenameIndex(
                name: "IX_VillaImages_Name",
                table: "VillaImages",
                newName: "IX_VillaImages_ImageName");
        }
    }
}
