using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MB.MCPP.BK.EfCore.Migrations
{
    public partial class rename_addOn_addon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddOnVilla_AddOns_AddOnsId",
                table: "AddOnVilla");

            migrationBuilder.DropForeignKey(
                name: "FK_AddOnVilla_Villas_VillasId",
                table: "AddOnVilla");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddOnVilla",
                table: "AddOnVilla");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddOns",
                table: "AddOns");

            migrationBuilder.RenameTable(
                name: "AddOnVilla",
                newName: "AddonVilla");

            migrationBuilder.RenameTable(
                name: "AddOns",
                newName: "Addons");

            migrationBuilder.RenameColumn(
                name: "AddOnsId",
                table: "AddonVilla",
                newName: "AddonsId");

            migrationBuilder.RenameIndex(
                name: "IX_AddOnVilla_VillasId",
                table: "AddonVilla",
                newName: "IX_AddonVilla_VillasId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddonVilla",
                table: "AddonVilla",
                columns: new[] { "AddonsId", "VillasId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addons",
                table: "Addons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddonVilla_Addons_AddonsId",
                table: "AddonVilla",
                column: "AddonsId",
                principalTable: "Addons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AddonVilla_Villas_VillasId",
                table: "AddonVilla",
                column: "VillasId",
                principalTable: "Villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddonVilla_Addons_AddonsId",
                table: "AddonVilla");

            migrationBuilder.DropForeignKey(
                name: "FK_AddonVilla_Villas_VillasId",
                table: "AddonVilla");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddonVilla",
                table: "AddonVilla");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addons",
                table: "Addons");

            migrationBuilder.RenameTable(
                name: "AddonVilla",
                newName: "AddOnVilla");

            migrationBuilder.RenameTable(
                name: "Addons",
                newName: "AddOns");

            migrationBuilder.RenameColumn(
                name: "AddonsId",
                table: "AddOnVilla",
                newName: "AddOnsId");

            migrationBuilder.RenameIndex(
                name: "IX_AddonVilla_VillasId",
                table: "AddOnVilla",
                newName: "IX_AddOnVilla_VillasId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddOnVilla",
                table: "AddOnVilla",
                columns: new[] { "AddOnsId", "VillasId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddOns",
                table: "AddOns",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddOnVilla_AddOns_AddOnsId",
                table: "AddOnVilla",
                column: "AddOnsId",
                principalTable: "AddOns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AddOnVilla_Villas_VillasId",
                table: "AddOnVilla",
                column: "VillasId",
                principalTable: "Villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
