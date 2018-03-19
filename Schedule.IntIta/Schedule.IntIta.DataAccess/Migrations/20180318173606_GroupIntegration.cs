using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Schedule.IntIta.DataAccess.Migrations
{
    public partial class GroupIntegration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Office_OfficeId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_SubGroups_Groups_GroupId",
                table: "SubGroups");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_OfficeId",
                table: "Rooms");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "SubGroups",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SubGroups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "OfficeId",
                table: "Rooms",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Groups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_SubGroups_Groups_GroupId",
                table: "SubGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubGroups_Groups_GroupId",
                table: "SubGroups");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SubGroups");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "SubGroups",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "OfficeId",
                table: "Rooms",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_OfficeId",
                table: "Rooms",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Office_OfficeId",
                table: "Rooms",
                column: "OfficeId",
                principalTable: "Office",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubGroups_Groups_GroupId",
                table: "SubGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
