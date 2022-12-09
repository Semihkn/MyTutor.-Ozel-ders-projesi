using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrivateTuition.Data.Migrations
{
    public partial class wmethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShowCards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShowCards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "WorkMethods",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "WorkMethods",
                table: "ShowCards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 20, 36, 25, 196, DateTimeKind.Local).AddTicks(5099));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 20, 36, 25, 196, DateTimeKind.Local).AddTicks(5107));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 20, 36, 25, 196, DateTimeKind.Local).AddTicks(5108));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 20, 36, 25, 196, DateTimeKind.Local).AddTicks(5108));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 20, 36, 25, 196, DateTimeKind.Local).AddTicks(5295));

            migrationBuilder.UpdateData(
                table: "LessonRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 20, 36, 25, 196, DateTimeKind.Local).AddTicks(5307));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 20, 36, 25, 196, DateTimeKind.Local).AddTicks(5282));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 20, 36, 25, 196, DateTimeKind.Local).AddTicks(5283));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 20, 36, 25, 196, DateTimeKind.Local).AddTicks(5188));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 20, 36, 25, 196, DateTimeKind.Local).AddTicks(5189));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 20, 36, 25, 196, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 20, 36, 25, 196, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 20, 36, 25, 196, DateTimeKind.Local).AddTicks(5191));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 20, 36, 25, 196, DateTimeKind.Local).AddTicks(5192));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 20, 36, 25, 196, DateTimeKind.Local).AddTicks(5192));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 20, 36, 25, 196, DateTimeKind.Local).AddTicks(5193));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 20, 36, 25, 196, DateTimeKind.Local).AddTicks(5193));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 20, 36, 25, 196, DateTimeKind.Local).AddTicks(5194));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 20, 36, 25, 196, DateTimeKind.Local).AddTicks(5265));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 20, 36, 25, 196, DateTimeKind.Local).AddTicks(5267));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkMethods",
                table: "ShowCards");

            migrationBuilder.AddColumn<int>(
                name: "WorkMethods",
                table: "Teachers",
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

            migrationBuilder.InsertData(
                table: "ShowCards",
                columns: new[] { "Id", "CityId", "CreatedDate", "Description", "IsDeleted", "LessonPrice", "Name", "SubjectId", "TeacherId", "Title", "Url" },
                values: new object[] { 1, 0, new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(7136), "Uzun yıllardır eğitim vermekteyim,dersler dışarıda veya online olabilir.", false, 200m, null, 1, 1, "Uzmanından matematik dersleri", "1" });

            migrationBuilder.InsertData(
                table: "ShowCards",
                columns: new[] { "Id", "CityId", "CreatedDate", "Description", "IsDeleted", "LessonPrice", "Name", "SubjectId", "TeacherId", "Title", "Url" },
                values: new object[] { 2, 0, new DateTime(2022, 11, 17, 0, 32, 22, 60, DateTimeKind.Local).AddTicks(7138), "İlkokuldan üniversiteye kadar ... ", false, 350m, null, 3, 2, "Dersler ersler dışarıda veya online olabilir.", "2" });

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
        }
    }
}
