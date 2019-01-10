using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class renamerow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVacantionRequests_VacationTypes_VacantionTypeId",
                table: "UserVacantionRequests");

            migrationBuilder.RenameColumn(
                name: "VacantionTypeId",
                table: "UserVacantionRequests",
                newName: "VacationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserVacantionRequests_VacantionTypeId",
                table: "UserVacantionRequests",
                newName: "IX_UserVacantionRequests_VacationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVacantionRequests_VacationTypes_VacationTypeId",
                table: "UserVacantionRequests",
                column: "VacationTypeId",
                principalTable: "VacationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVacantionRequests_VacationTypes_VacationTypeId",
                table: "UserVacantionRequests");

            migrationBuilder.RenameColumn(
                name: "VacationTypeId",
                table: "UserVacantionRequests",
                newName: "VacantionTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserVacantionRequests_VacationTypeId",
                table: "UserVacantionRequests",
                newName: "IX_UserVacantionRequests_VacantionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVacantionRequests_VacationTypes_VacantionTypeId",
                table: "UserVacantionRequests",
                column: "VacantionTypeId",
                principalTable: "VacationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
