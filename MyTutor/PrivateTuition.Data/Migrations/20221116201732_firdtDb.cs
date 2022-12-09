using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrivateTuition.Data.Migrations
{
    public partial class firdtDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    il_adi = table.Column<string>(type: "TEXT", nullable: true),
                    plaka_kodu = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Job = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    Language = table.Column<string>(type: "TEXT", nullable: true),
                    Mail = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    District = table.Column<string>(type: "TEXT", nullable: true),
                    AvatarUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeacherInfo = table.Column<string>(type: "TEXT", nullable: true),
                    WorkMethods = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherStatue = table.Column<int>(type: "INTEGER", nullable: false),
                    RatingPoint = table.Column<byte>(type: "INTEGER", nullable: false),
                    Professions = table.Column<string>(type: "TEXT", nullable: true),
                    ResponseRange = table.Column<string>(type: "TEXT", nullable: true),
                    TotalLesson = table.Column<int>(type: "INTEGER", nullable: false),
                    Certificate = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Job = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    Language = table.Column<string>(type: "TEXT", nullable: true),
                    Mail = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    District = table.Column<string>(type: "TEXT", nullable: true),
                    AvatarUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ilce_adi = table.Column<string>(type: "TEXT", nullable: true),
                    CityId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectCategories",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectCategories", x => new { x.SubjectId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_SubjectCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectCategories_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    StdComment = table.Column<string>(type: "TEXT", nullable: true),
                    Point = table.Column<byte>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShowCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    LessonPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowCards_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowCards_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Expectations = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    ContactNumber = table.Column<string>(type: "TEXT", nullable: true),
                    ResponseTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    ShowCardId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonRequests_ShowCards_ShowCardId",
                        column: x => x.ShowCardId,
                        principalTable: "ShowCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonRequests_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "Url" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Lise", "lise" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "Url" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "İlköğretim", "ilkogretim" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "Url" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Bilgisayar", "bilgisayar" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "Url" },
                values: new object[] { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Sınava Hazırlık", "sınava-hazırlık" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AvatarUrl", "City", "CreatedDate", "District", "FirstName", "Gender", "IsDeleted", "Job", "Language", "LastName", "Mail", "Name", "PhoneNumber", "Url", "UserName" },
                values: new object[] { 1, null, "İstanbul", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florya", null, null, false, null, null, null, "hsnkra@gmail.com", "Hasan Karaoğlan", null, "hasan-karaoglan", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AvatarUrl", "City", "CreatedDate", "District", "FirstName", "Gender", "IsDeleted", "Job", "Language", "LastName", "Mail", "Name", "PhoneNumber", "Url", "UserName" },
                values: new object[] { 2, null, "İstanbul", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avcılar", null, null, false, null, null, null, "ynsgny@gmail.com", "Yunus Güney", null, "yunus", null });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "Url" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Matematik", "matematik" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "Url" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Fizik", "fizik" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "Url" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Kimya", "kimya" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "Url" },
                values: new object[] { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "C#", "c#" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "Url" },
                values: new object[] { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Javascript", "javascript" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "Url" },
                values: new object[] { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "KPSS", "kpss" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "Url" },
                values: new object[] { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "YGS-LYS", "ygs-lys" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "Url" },
                values: new object[] { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Hayat Bilgisi", "hayat-bilgisi" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "Url" },
                values: new object[] { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "İngilizce", "ingilizce" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "Url" },
                values: new object[] { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "IELTS-TOEFL", "ielts-toefl" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "AvatarUrl", "Certificate", "City", "CreatedDate", "District", "FirstName", "Gender", "IsDeleted", "Job", "Language", "LastName", "Mail", "Name", "PhoneNumber", "Professions", "RatingPoint", "ResponseRange", "TeacherInfo", "TeacherStatue", "TotalLesson", "Url", "UserName", "WorkMethods" },
                values: new object[] { 1, null, null, "İstanbul", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avcılar", null, null, false, null, null, null, "hsnkra@gmail.com", "Semih Karaoğlan", null, null, (byte)0, null, "5 Yıl deneyimli uzman öğretmen.", 2, 0, "5-yil-deneyimli-uzman", null, 0 });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "AvatarUrl", "Certificate", "City", "CreatedDate", "District", "FirstName", "Gender", "IsDeleted", "Job", "Language", "LastName", "Mail", "Name", "PhoneNumber", "Professions", "RatingPoint", "ResponseRange", "TeacherInfo", "TeacherStatue", "TotalLesson", "Url", "UserName", "WorkMethods" },
                values: new object[] { 2, null, null, "İstanbul", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Küçükçekmece", null, null, false, null, null, null, "hsnkra@gmail.com", "Yasin Güney", null, null, (byte)0, null, "6 Yıl deneyimli uzman öğretmen ve eğitim koçu.", 3, 0, "5-yil-deneyimli-uzman-ogretmen", null, 0 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "Point", "StdComment", "StudentId", "TeacherId", "Title", "Url" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, (byte)0, "Gerçekten alanında çok başarılı ve anlaşılır bir hoca", 1, 1, "Çok iyii", "123" });

            migrationBuilder.InsertData(
                table: "ShowCards",
                columns: new[] { "Id", "CreatedDate", "Description", "IsDeleted", "LessonPrice", "Name", "SubjectId", "TeacherId", "Title", "Url" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uzun yıllardır eğitim vermekteyim,dersler dışarıda veya online olabilir.", false, 200m, null, 1, 1, "Uzmanından matematik dersleri", "1" });

            migrationBuilder.InsertData(
                table: "ShowCards",
                columns: new[] { "Id", "CreatedDate", "Description", "IsDeleted", "LessonPrice", "Name", "SubjectId", "TeacherId", "Title", "Url" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İlkokuldan üniversiteye kadar ... ", false, 350m, null, 3, 2, "Dersler ersler dışarıda veya online olabilir.", "2" });

            migrationBuilder.InsertData(
                table: "SubjectCategories",
                columns: new[] { "CategoryId", "SubjectId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "SubjectCategories",
                columns: new[] { "CategoryId", "SubjectId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "SubjectCategories",
                columns: new[] { "CategoryId", "SubjectId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "SubjectCategories",
                columns: new[] { "CategoryId", "SubjectId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "SubjectCategories",
                columns: new[] { "CategoryId", "SubjectId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "SubjectCategories",
                columns: new[] { "CategoryId", "SubjectId" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "SubjectCategories",
                columns: new[] { "CategoryId", "SubjectId" },
                values: new object[] { 3, 4 });

            migrationBuilder.InsertData(
                table: "SubjectCategories",
                columns: new[] { "CategoryId", "SubjectId" },
                values: new object[] { 3, 5 });

            migrationBuilder.InsertData(
                table: "SubjectCategories",
                columns: new[] { "CategoryId", "SubjectId" },
                values: new object[] { 4, 6 });

            migrationBuilder.InsertData(
                table: "SubjectCategories",
                columns: new[] { "CategoryId", "SubjectId" },
                values: new object[] { 4, 7 });

            migrationBuilder.InsertData(
                table: "SubjectCategories",
                columns: new[] { "CategoryId", "SubjectId" },
                values: new object[] { 2, 8 });

            migrationBuilder.InsertData(
                table: "SubjectCategories",
                columns: new[] { "CategoryId", "SubjectId" },
                values: new object[] { 1, 9 });

            migrationBuilder.InsertData(
                table: "SubjectCategories",
                columns: new[] { "CategoryId", "SubjectId" },
                values: new object[] { 2, 9 });

            migrationBuilder.InsertData(
                table: "SubjectCategories",
                columns: new[] { "CategoryId", "SubjectId" },
                values: new object[] { 4, 10 });

            migrationBuilder.InsertData(
                table: "LessonRequests",
                columns: new[] { "Id", "Address", "ContactNumber", "CreatedDate", "Expectations", "IsApproved", "IsDeleted", "Name", "ResponseTime", "ShowCardId", "StudentId", "Url" },
                values: new object[] { 1, null, "0545-719-73-78", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Haftada 4 saat matematik dersi", false, false, null, null, 1, 2, null });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_StudentId",
                table: "Comments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TeacherId",
                table: "Comments",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonRequests_ShowCardId",
                table: "LessonRequests",
                column: "ShowCardId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonRequests_StudentId",
                table: "LessonRequests",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowCards_SubjectId",
                table: "ShowCards",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowCards_TeacherId",
                table: "ShowCards",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCategories_CategoryId",
                table: "SubjectCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "LessonRequests");

            migrationBuilder.DropTable(
                name: "SubjectCategories");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "ShowCards");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
