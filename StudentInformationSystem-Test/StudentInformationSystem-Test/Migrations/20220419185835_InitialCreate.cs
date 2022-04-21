using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentInformationSystem_Test.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentEntities_DepartmentEntities_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LectureEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LectureEntities_StudentEntities_StudentEntityId",
                        column: x => x.StudentEntityId,
                        principalTable: "StudentEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentEntityLectureEntity",
                columns: table => new
                {
                    DepartmentEntitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LectureEntitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentEntityLectureEntity", x => new { x.DepartmentEntitiesId, x.LectureEntitiesId });
                    table.ForeignKey(
                        name: "FK_DepartmentEntityLectureEntity_DepartmentEntities_DepartmentEntitiesId",
                        column: x => x.DepartmentEntitiesId,
                        principalTable: "DepartmentEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentEntityLectureEntity_LectureEntities_LectureEntitiesId",
                        column: x => x.LectureEntitiesId,
                        principalTable: "LectureEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentEntityLectureEntity_LectureEntitiesId",
                table: "DepartmentEntityLectureEntity",
                column: "LectureEntitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_LectureEntities_StudentEntityId",
                table: "LectureEntities",
                column: "StudentEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEntities_DepartmentId",
                table: "StudentEntities",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentEntityLectureEntity");

            migrationBuilder.DropTable(
                name: "LectureEntities");

            migrationBuilder.DropTable(
                name: "StudentEntities");

            migrationBuilder.DropTable(
                name: "DepartmentEntities");
        }
    }
}
