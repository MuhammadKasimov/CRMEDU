using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CRMEDU.Data.Migrations
{
    public partial class AddedReferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Basics_BasicsId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Basics_BasicsId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "GotCommentsId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "GotCommentsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "GotCommentsId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "SentCommentsId",
                table: "Admins");

            migrationBuilder.AlterColumn<long>(
                name: "BasicsId",
                table: "Teachers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BasicsId",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BasicsId",
                table: "Comments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "ClassReporters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClassId = table.Column<long>(type: "bigint", nullable: false),
                    ReporterId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassReporters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassReporters_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassReporters_Reporters_ReporterId",
                        column: x => x.ReporterId,
                        principalTable: "Reporters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentClasses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    ClassId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentClasses_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentClasses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Teachers_CourseId",
                table: "Teachers",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SentCommentsId",
                table: "Teachers",
                column: "SentCommentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SentCommentsId",
                table: "Students",
                column: "SentCommentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Reporters_StudentId",
                table: "Reporters",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ClassId",
                table: "Lessons",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BasicsId",
                table: "Comments",
                column: "BasicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CourseId",
                table: "Classes",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_BasicsId",
                table: "Admins",
                column: "BasicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_ConnectionId",
                table: "Admins",
                column: "ConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassReporters_ClassId",
                table: "ClassReporters",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassReporters_ReporterId",
                table: "ClassReporters",
                column: "ReporterId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClasses_ClassId",
                table: "StudentClasses",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClasses_StudentId",
                table: "StudentClasses",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Basics_BasicsId",
                table: "Admins",
                column: "BasicsId",
                principalTable: "Basics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Connections_ConnectionId",
                table: "Admins",
                column: "ConnectionId",
                principalTable: "Connections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Courses_CourseId",
                table: "Classes",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Basics_BasicsId",
                table: "Comments",
                column: "BasicsId",
                principalTable: "Basics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Classes_ClassId",
                table: "Lessons",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reporters_Students_StudentId",
                table: "Reporters",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Basics_BasicsId",
                table: "Students",
                column: "BasicsId",
                principalTable: "Basics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Comments_SentCommentsId",
                table: "Students",
                column: "SentCommentsId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Basics_BasicsId",
                table: "Teachers",
                column: "BasicsId",
                principalTable: "Basics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Classes_ClassId",
                table: "Teachers",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Comments_SentCommentsId",
                table: "Teachers",
                column: "SentCommentsId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Connections_ConnectionId",
                table: "Teachers",
                column: "ConnectionId",
                principalTable: "Connections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Courses_CourseId",
                table: "Teachers",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Basics_BasicsId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Connections_ConnectionId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Courses_CourseId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Basics_BasicsId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Classes_ClassId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Reporters_Students_StudentId",
                table: "Reporters");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Basics_BasicsId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Comments_SentCommentsId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Basics_BasicsId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Classes_ClassId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Comments_SentCommentsId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Connections_ConnectionId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Courses_CourseId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "ClassReporters");

            migrationBuilder.DropTable(
                name: "StudentClasses");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_ClassId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_ConnectionId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_CourseId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_SentCommentsId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_SentCommentsId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Reporters_StudentId",
                table: "Reporters");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_ClassId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BasicsId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Classes_CourseId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Admins_BasicsId",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_ConnectionId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "BasicsId",
                table: "Comments");

            migrationBuilder.AlterColumn<long>(
                name: "BasicsId",
                table: "Teachers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "GotCommentsId",
                table: "Teachers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "BasicsId",
                table: "Students",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "GotCommentsId",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ClassId",
                table: "Courses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TeacherId",
                table: "Classes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "GotCommentsId",
                table: "Admins",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SentCommentsId",
                table: "Admins",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Basics_BasicsId",
                table: "Students",
                column: "BasicsId",
                principalTable: "Basics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Basics_BasicsId",
                table: "Teachers",
                column: "BasicsId",
                principalTable: "Basics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
