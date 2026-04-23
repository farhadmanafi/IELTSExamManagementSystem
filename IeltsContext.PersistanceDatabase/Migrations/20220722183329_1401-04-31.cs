using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamContext.PersistanceDatabase.Migrations
{
    public partial class _14010431 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IeltsExamParticipantsId",
                table: "UserResualt",
                newName: "ParticipantsId");

            migrationBuilder.RenameColumn(
                name: "IeltsExamParticipantsId",
                table: "BankTransaction",
                newName: "ParticipantsId");

            migrationBuilder.CreateTable(
                name: "PlacementExamParticipantsStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacementExamParticipantsStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlacementExamParticipants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlacementExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlacementExamPriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlacementExamOrederNumber = table.Column<int>(type: "int", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PlacementExamParticipantsStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacementExamParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlacementExamParticipants_PlacementExamParticipantsStatus_PlacementExamParticipantsStatusId",
                        column: x => x.PlacementExamParticipantsStatusId,
                        principalTable: "PlacementExamParticipantsStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlacementExamParticipants_PlacementExamParticipantsStatusId",
                table: "PlacementExamParticipants",
                column: "PlacementExamParticipantsStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlacementExamParticipants");

            migrationBuilder.DropTable(
                name: "PlacementExamParticipantsStatus");

            migrationBuilder.RenameColumn(
                name: "ParticipantsId",
                table: "UserResualt",
                newName: "IeltsExamParticipantsId");

            migrationBuilder.RenameColumn(
                name: "ParticipantsId",
                table: "BankTransaction",
                newName: "IeltsExamParticipantsId");
        }
    }
}
