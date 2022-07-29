using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMEDU.Data.Migrations
{
    public partial class AddedUniqueKeysAndUsernameColumnOnBasics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teachers_BasicsId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_ClassId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_ConnectionId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_BasicsId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Admins_BasicsId",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_ConnectionId",
                table: "Admins");

            migrationBuilder.AddColumn<Guid>(
                name: "ReporterCode",
                table: "Reporters",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReporterCode",
                table: "ClassReporters",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Basics",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_BasicsId",
                table: "Teachers",
                column: "BasicsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ClassId",
                table: "Teachers",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ConnectionId",
                table: "Teachers",
                column: "ConnectionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_BasicsId",
                table: "Students",
                column: "BasicsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ConnectionId",
                table: "Students",
                column: "ConnectionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Security_Login",
                table: "Security",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Title",
                table: "Courses",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Connections_Email",
                table: "Connections",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Basics_SecurityId",
                table: "Basics",
                column: "SecurityId");

            migrationBuilder.CreateIndex(
                name: "IX_Basics_Username",
                table: "Basics",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_BasicsId",
                table: "Admins",
                column: "BasicsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_ConnectionId",
                table: "Admins",
                column: "ConnectionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Basics_Security_SecurityId",
                table: "Basics",
                column: "SecurityId",
                principalTable: "Security",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Connections_ConnectionId",
                table: "Students",
                column: "ConnectionId",
                principalTable: "Connections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basics_Security_SecurityId",
                table: "Basics");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Connections_ConnectionId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_BasicsId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_ClassId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_ConnectionId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_BasicsId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ConnectionId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Security_Login",
                table: "Security");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Title",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Connections_Email",
                table: "Connections");

            migrationBuilder.DropIndex(
                name: "IX_Basics_SecurityId",
                table: "Basics");

            migrationBuilder.DropIndex(
                name: "IX_Basics_Username",
                table: "Basics");

            migrationBuilder.DropIndex(
                name: "IX_Admins_BasicsId",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_ConnectionId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "ReporterCode",
                table: "Reporters");

            migrationBuilder.DropColumn(
                name: "ReporterCode",
                table: "ClassReporters");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Basics");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_BasicsId",
                table: "Teachers",
                column: "BasicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ClassId",
                table: "Teachers",
                column: "ClassId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ConnectionId",
                table: "Teachers",
                column: "ConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_BasicsId",
                table: "Students",
                column: "BasicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_BasicsId",
                table: "Admins",
                column: "BasicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_ConnectionId",
                table: "Admins",
                column: "ConnectionId");
        }
    }
}
