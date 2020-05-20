using Microsoft.EntityFrameworkCore.Migrations;

namespace ASA.Migrations
{
    public partial class itter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IteratorId",
                table: "Agencija",
                type: "int",
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
    }
}
