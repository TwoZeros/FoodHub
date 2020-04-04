using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkerCRM.Data.Migrations
{
    public partial class comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Clients_ClientId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ClientId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IdClient",
                table: "Comments",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IdUser",
                table: "Comments",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Clients_IdClient",
                table: "Comments",
                column: "IdClient",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_IdUser",
                table: "Comments",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Clients_IdClient",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_IdUser",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_IdClient",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_IdUser",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ClientId",
                table: "Comments",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Clients_ClientId",
                table: "Comments",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
