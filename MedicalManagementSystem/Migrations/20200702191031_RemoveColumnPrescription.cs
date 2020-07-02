using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalManagementSystem.Migrations
{
    public partial class RemoveColumnPrescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Doctors_AddedById",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_AddedById",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "Prescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AddedById",
                table: "Prescription",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_AddedById",
                table: "Prescription",
                column: "AddedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Doctors_AddedById",
                table: "Prescription",
                column: "AddedById",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
