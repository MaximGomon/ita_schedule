using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Schedule.IntIta.DataAccess.Migrations
{
    public partial class EditedRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SubGroups");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Groups");

            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Rooms",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Office_OfficeId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_OfficeId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Rooms");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SubGroups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Groups",
                nullable: false,
                defaultValue: false);
        }
    }
}
