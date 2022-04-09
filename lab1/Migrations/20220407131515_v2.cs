using Microsoft.EntityFrameworkCore.Migrations;

namespace lab1.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_crsResults_trainees_trainee_id",
                table: "crsResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_departments_departmentId",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_departmentId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "departmentId",
                table: "Instructors");

            migrationBuilder.RenameColumn(
                name: "trainee_id",
                table: "crsResults",
                newName: "train_id");

            migrationBuilder.RenameIndex(
                name: "IX_crsResults_trainee_id",
                table: "crsResults",
                newName: "IX_crsResults_train_id");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_dept_id",
                table: "Instructors",
                column: "dept_id");

            migrationBuilder.AddForeignKey(
                name: "FK_crsResults_trainees_train_id",
                table: "crsResults",
                column: "train_id",
                principalTable: "trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_departments_dept_id",
                table: "Instructors",
                column: "dept_id",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_crsResults_trainees_train_id",
                table: "crsResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_departments_dept_id",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_dept_id",
                table: "Instructors");

            migrationBuilder.RenameColumn(
                name: "train_id",
                table: "crsResults",
                newName: "trainee_id");

            migrationBuilder.RenameIndex(
                name: "IX_crsResults_train_id",
                table: "crsResults",
                newName: "IX_crsResults_trainee_id");

            migrationBuilder.AddColumn<int>(
                name: "departmentId",
                table: "Instructors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_departmentId",
                table: "Instructors",
                column: "departmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_crsResults_trainees_trainee_id",
                table: "crsResults",
                column: "trainee_id",
                principalTable: "trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_departments_departmentId",
                table: "Instructors",
                column: "departmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
