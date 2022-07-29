using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMEDU.Data.Migrations
{
    public partial class AddedUniqueKeyToClassClassName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Classes_ClassName",
                table: "Classes",
                column: "ClassName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Classes_ClassName",
                table: "Classes");
        }
    }
}
