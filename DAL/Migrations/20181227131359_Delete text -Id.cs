using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DeletetextId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Teams_TeamIdId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_ManagerIdId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamUsers_Teams_TeamIdId",
                table: "TeamUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamUsers_Users_UserIdId",
                table: "TeamUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleIdId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserIdId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVacantionRequests_Users_UserIdId",
                table: "UserVacantionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVacantionRequests_VacationTypes_VacantionTypeIdId",
                table: "UserVacantionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_VacationPolicies_VacationTypes_VacationTypeIdId",
                table: "VacationPolicies");

            migrationBuilder.RenameColumn(
                name: "VacationTypeIdId",
                table: "VacationPolicies",
                newName: "VacationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_VacationPolicies_VacationTypeIdId",
                table: "VacationPolicies",
                newName: "IX_VacationPolicies_VacationTypeId");

            migrationBuilder.RenameColumn(
                name: "VacantionTypeIdId",
                table: "UserVacantionRequests",
                newName: "VacantionTypeId");

            migrationBuilder.RenameColumn(
                name: "UserIdId",
                table: "UserVacantionRequests",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserVacantionRequests_VacantionTypeIdId",
                table: "UserVacantionRequests",
                newName: "IX_UserVacantionRequests_VacantionTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserVacantionRequests_UserIdId",
                table: "UserVacantionRequests",
                newName: "IX_UserVacantionRequests_UserId");

            migrationBuilder.RenameColumn(
                name: "UserIdId",
                table: "UserRoles",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "RoleIdId",
                table: "UserRoles",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_UserIdId",
                table: "UserRoles",
                newName: "IX_UserRoles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleIdId",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.RenameColumn(
                name: "UserIdId",
                table: "TeamUsers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "TeamIdId",
                table: "TeamUsers",
                newName: "TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamUsers_UserIdId",
                table: "TeamUsers",
                newName: "IX_TeamUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamUsers_TeamIdId",
                table: "TeamUsers",
                newName: "IX_TeamUsers_TeamId");

            migrationBuilder.RenameColumn(
                name: "ManagerIdId",
                table: "Teams",
                newName: "ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_ManagerIdId",
                table: "Teams",
                newName: "IX_Teams_ManagerId");

            migrationBuilder.RenameColumn(
                name: "TeamIdId",
                table: "Projects",
                newName: "TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_TeamIdId",
                table: "Projects",
                newName: "IX_Projects_TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Teams_TeamId",
                table: "Projects",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_ManagerId",
                table: "Teams",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUsers_Teams_TeamId",
                table: "TeamUsers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUsers_Users_UserId",
                table: "TeamUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVacantionRequests_Users_UserId",
                table: "UserVacantionRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVacantionRequests_VacationTypes_VacantionTypeId",
                table: "UserVacantionRequests",
                column: "VacantionTypeId",
                principalTable: "VacationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VacationPolicies_VacationTypes_VacationTypeId",
                table: "VacationPolicies",
                column: "VacationTypeId",
                principalTable: "VacationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Teams_TeamId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_ManagerId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamUsers_Teams_TeamId",
                table: "TeamUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamUsers_Users_UserId",
                table: "TeamUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVacantionRequests_Users_UserId",
                table: "UserVacantionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVacantionRequests_VacationTypes_VacantionTypeId",
                table: "UserVacantionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_VacationPolicies_VacationTypes_VacationTypeId",
                table: "VacationPolicies");

            migrationBuilder.RenameColumn(
                name: "VacationTypeId",
                table: "VacationPolicies",
                newName: "VacationTypeIdId");

            migrationBuilder.RenameIndex(
                name: "IX_VacationPolicies_VacationTypeId",
                table: "VacationPolicies",
                newName: "IX_VacationPolicies_VacationTypeIdId");

            migrationBuilder.RenameColumn(
                name: "VacantionTypeId",
                table: "UserVacantionRequests",
                newName: "VacantionTypeIdId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserVacantionRequests",
                newName: "UserIdId");

            migrationBuilder.RenameIndex(
                name: "IX_UserVacantionRequests_VacantionTypeId",
                table: "UserVacantionRequests",
                newName: "IX_UserVacantionRequests_VacantionTypeIdId");

            migrationBuilder.RenameIndex(
                name: "IX_UserVacantionRequests_UserId",
                table: "UserVacantionRequests",
                newName: "IX_UserVacantionRequests_UserIdId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserRoles",
                newName: "UserIdId");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "UserRoles",
                newName: "RoleIdId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                newName: "IX_UserRoles_UserIdId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleIdId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TeamUsers",
                newName: "UserIdId");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "TeamUsers",
                newName: "TeamIdId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamUsers_UserId",
                table: "TeamUsers",
                newName: "IX_TeamUsers_UserIdId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamUsers_TeamId",
                table: "TeamUsers",
                newName: "IX_TeamUsers_TeamIdId");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "Teams",
                newName: "ManagerIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_ManagerId",
                table: "Teams",
                newName: "IX_Teams_ManagerIdId");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Projects",
                newName: "TeamIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_TeamId",
                table: "Projects",
                newName: "IX_Projects_TeamIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Teams_TeamIdId",
                table: "Projects",
                column: "TeamIdId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_ManagerIdId",
                table: "Teams",
                column: "ManagerIdId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUsers_Teams_TeamIdId",
                table: "TeamUsers",
                column: "TeamIdId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUsers_Users_UserIdId",
                table: "TeamUsers",
                column: "UserIdId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleIdId",
                table: "UserRoles",
                column: "RoleIdId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserIdId",
                table: "UserRoles",
                column: "UserIdId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVacantionRequests_Users_UserIdId",
                table: "UserVacantionRequests",
                column: "UserIdId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVacantionRequests_VacationTypes_VacantionTypeIdId",
                table: "UserVacantionRequests",
                column: "VacantionTypeIdId",
                principalTable: "VacationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VacationPolicies_VacationTypes_VacationTypeIdId",
                table: "VacationPolicies",
                column: "VacationTypeIdId",
                principalTable: "VacationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
