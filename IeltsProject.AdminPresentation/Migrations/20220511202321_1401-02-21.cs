using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IeltsProject.AdminPresentation.Migrations
{
    public partial class _14010221 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserInformationId",
                schema: "Identity",
                table: "AspUser");

            migrationBuilder.DropColumn(
                name: "UserTypeId",
                schema: "Identity",
                table: "AspUser");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "Identity",
                table: "AspUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                schema: "Identity",
                table: "AspUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Identity",
                table: "AspUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Identity",
                table: "AspUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                schema: "Identity",
                table: "AspUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalCode",
                schema: "Identity",
                table: "AspUser",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                schema: "Identity",
                table: "AspUser");

            migrationBuilder.DropColumn(
                name: "Birthday",
                schema: "Identity",
                table: "AspUser");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Identity",
                table: "AspUser");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Identity",
                table: "AspUser");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                schema: "Identity",
                table: "AspUser");

            migrationBuilder.DropColumn(
                name: "NationalCode",
                schema: "Identity",
                table: "AspUser");

            migrationBuilder.AddColumn<Guid>(
                name: "UserInformationId",
                schema: "Identity",
                table: "AspUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserTypeId",
                schema: "Identity",
                table: "AspUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
