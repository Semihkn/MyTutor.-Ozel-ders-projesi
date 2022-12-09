using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrivateTuition.Data.Migrations
{
    public partial class showCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "ShowCards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(6964));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(6974));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(6975));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(6975));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(7125));

            migrationBuilder.UpdateData(
                table: "LessonRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(7147));

            migrationBuilder.UpdateData(
                table: "ShowCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(7136));

            migrationBuilder.UpdateData(
                table: "ShowCards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(7138));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(7113));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(7114));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(7054));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(7056));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(7057));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(7057));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(7058));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(7059));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(7059));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(7060));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(7061));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(7061));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(7097));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(7101));

            migrationBuilder.CreateIndex(
                name: "IX_ShowCards_CityId",
                table: "ShowCards",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowCards_Cities_CityId",
                table: "ShowCards",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowCards_Cities_CityId",
                table: "ShowCards");

            migrationBuilder.DropIndex(
                name: "IX_ShowCards_CityId",
                table: "ShowCards");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "ShowCards");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 31, 16, 449, DateTimeKind.Local).AddTicks(9709));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 31, 16, 449, DateTimeKind.Local).AddTicks(9718));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 31, 16, 449, DateTimeKind.Local).AddTicks(9720));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 31, 16, 449, DateTimeKind.Local).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 31, 16, 449, DateTimeKind.Local).AddTicks(9922));

            migrationBuilder.UpdateData(
                table: "LessonRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 31, 16, 449, DateTimeKind.Local).AddTicks(9948));

            migrationBuilder.UpdateData(
                table: "ShowCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 31, 16, 449, DateTimeKind.Local).AddTicks(9933));

            migrationBuilder.UpdateData(
                table: "ShowCards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 31, 16, 449, DateTimeKind.Local).AddTicks(9936));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 31, 16, 449, DateTimeKind.Local).AddTicks(9907));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 31, 16, 449, DateTimeKind.Local).AddTicks(9908));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 31, 16, 449, DateTimeKind.Local).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 31, 16, 449, DateTimeKind.Local).AddTicks(9815));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 31, 16, 449, DateTimeKind.Local).AddTicks(9816));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 31, 16, 449, DateTimeKind.Local).AddTicks(9817));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 31, 16, 449, DateTimeKind.Local).AddTicks(9818));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 31, 16, 449, DateTimeKind.Local).AddTicks(9818));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 31, 16, 449, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 31, 16, 449, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 31, 16, 449, DateTimeKind.Local).AddTicks(9820));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 31, 16, 449, DateTimeKind.Local).AddTicks(9821));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 31, 16, 449, DateTimeKind.Local).AddTicks(9891));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 0, 31, 16, 449, DateTimeKind.Local).AddTicks(9893));
        }
    }
}
