using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Departments_DerartmentId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_DoctorSchedules_ScheduledId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "Discription",
                table: "Departments",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ScheduledId",
                table: "Appointments",
                newName: "ScheduleId");

            migrationBuilder.RenameColumn(
                name: "DerartmentId",
                table: "Appointments",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ScheduledId",
                table: "Appointments",
                newName: "IX_Appointments_ScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_DerartmentId",
                table: "Appointments",
                newName: "IX_Appointments_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Departments_DepartmentId",
                table: "Appointments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_DoctorSchedules_ScheduleId",
                table: "Appointments",
                column: "ScheduleId",
                principalTable: "DoctorSchedules",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Departments_DepartmentId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_DoctorSchedules_ScheduleId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Departments",
                newName: "Discription");

            migrationBuilder.RenameColumn(
                name: "ScheduleId",
                table: "Appointments",
                newName: "ScheduledId");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Appointments",
                newName: "DerartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ScheduleId",
                table: "Appointments",
                newName: "IX_Appointments_ScheduledId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_DepartmentId",
                table: "Appointments",
                newName: "IX_Appointments_DerartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Departments_DerartmentId",
                table: "Appointments",
                column: "DerartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_DoctorSchedules_ScheduledId",
                table: "Appointments",
                column: "ScheduledId",
                principalTable: "DoctorSchedules",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
