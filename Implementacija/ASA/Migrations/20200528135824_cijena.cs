using Microsoft.EntityFrameworkCore.Migrations;

namespace ASA.Migrations
{
    public partial class cijena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Putovanje_Cijena_CijenaId",
                table: "Putovanje");

            migrationBuilder.DropIndex(
                name: "IX_Putovanje_CijenaId",
                table: "Putovanje");

            migrationBuilder.DropColumn(
                name: "CijenaId",
                table: "Putovanje");

            migrationBuilder.AddColumn<double>(
                name: "Cijena",
                table: "Putovanje",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cijena",
                table: "Putovanje");

            migrationBuilder.AddColumn<int>(
                name: "CijenaId",
                table: "Putovanje",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Putovanje_CijenaId",
                table: "Putovanje",
                column: "CijenaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Putovanje_Cijena_CijenaId",
                table: "Putovanje",
                column: "CijenaId",
                principalTable: "Cijena",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
