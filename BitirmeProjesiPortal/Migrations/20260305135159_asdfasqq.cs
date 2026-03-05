using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitirmeProjesiPortal.Migrations
{
    /// <inheritdoc />
    public partial class asdfasqq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassReferences_UserAccounts_UsersId",
                table: "ClassReferences");

            migrationBuilder.DropIndex(
                name: "IX_ClassReferences_UsersId",
                table: "ClassReferences");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "ClassReferences");

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassReferenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_ClassReferences_ClassReferenceId",
                        column: x => x.ClassReferenceId,
                        principalTable: "ClassReferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassReferences_UserId",
                table: "ClassReferences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_ClassReferenceId",
                table: "Assignments",
                column: "ClassReferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassReferences_UserAccounts_UserId",
                table: "ClassReferences",
                column: "UserId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassReferences_UserAccounts_UserId",
                table: "ClassReferences");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_ClassReferences_UserId",
                table: "ClassReferences");

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "ClassReferences",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassReferences_UsersId",
                table: "ClassReferences",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassReferences_UserAccounts_UsersId",
                table: "ClassReferences",
                column: "UsersId",
                principalTable: "UserAccounts",
                principalColumn: "Id");
        }
    }
}
