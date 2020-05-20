using Microsoft.EntityFrameworkCore.Migrations;

namespace ASA.Migrations
{
    public partial class F : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IteratorId",
                table: "Agencija",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agencija_IteratorId",
                table: "Agencija",
                column: "IteratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agencija_Iterator_IteratorId",
                table: "Agencija",
                column: "IteratorId",
                principalTable: "Iterator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agencija_Iterator_IteratorId",
                table: "Agencija");

            migrationBuilder.DropIndex(
                name: "IX_Agencija_IteratorId",
                table: "Agencija");

            migrationBuilder.DropColumn(
                name: "IteratorId",
                table: "Agencija");
        }
    }
}
