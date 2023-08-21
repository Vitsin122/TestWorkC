using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestWorkC.Migrations
{
    /// <inheritdoc />
    public partial class toBaseOfTheBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrillBlocksPoints_DrillBlocks_DrillBlockId",
                table: "DrillBlocksPoints");

            migrationBuilder.DropForeignKey(
                name: "FK_HolePoints_Holes_HoleId",
                table: "HolePoints");

            migrationBuilder.DropForeignKey(
                name: "FK_Holes_DrillBlocks_DrillBlockId",
                table: "Holes");

            migrationBuilder.DropIndex(
                name: "IX_Holes_DrillBlockId",
                table: "Holes");

            migrationBuilder.DropIndex(
                name: "IX_HolePoints_HoleId",
                table: "HolePoints");

            migrationBuilder.DropIndex(
                name: "IX_DrillBlocksPoints_DrillBlockId",
                table: "DrillBlocksPoints");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Holes_DrillBlockId",
                table: "Holes",
                column: "DrillBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_HolePoints_HoleId",
                table: "HolePoints",
                column: "HoleId");

            migrationBuilder.CreateIndex(
                name: "IX_DrillBlocksPoints_DrillBlockId",
                table: "DrillBlocksPoints",
                column: "DrillBlockId");

            migrationBuilder.AddForeignKey(
                name: "FK_DrillBlocksPoints_DrillBlocks_DrillBlockId",
                table: "DrillBlocksPoints",
                column: "DrillBlockId",
                principalTable: "DrillBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HolePoints_Holes_HoleId",
                table: "HolePoints",
                column: "HoleId",
                principalTable: "Holes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Holes_DrillBlocks_DrillBlockId",
                table: "Holes",
                column: "DrillBlockId",
                principalTable: "DrillBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
