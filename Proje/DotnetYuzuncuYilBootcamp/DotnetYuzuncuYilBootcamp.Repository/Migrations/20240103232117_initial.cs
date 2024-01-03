using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetYuzuncuYilBootcamp.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StartedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Duties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DutyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    StartedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Duties_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeesProfiles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "Password", "Position", "StartedDate", "UpdatedDate", "UserName" },
                values: new object[] { 1, "gonulkb12@gmail.com", "123456", "Front-end Developer", new DateTime(2024, 1, 4, 2, 21, 17, 200, DateTimeKind.Local).AddTicks(9775), null, "gonulkaba" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "Password", "Position", "StartedDate", "UpdatedDate", "UserName" },
                values: new object[] { 2, "aysecet48@gmail.com", "45879545", "Back-end Developer", new DateTime(2024, 1, 4, 2, 21, 17, 200, DateTimeKind.Local).AddTicks(9778), null, "aysecetin" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "Password", "Position", "StartedDate", "UpdatedDate", "UserName" },
                values: new object[] { 3, "velialii98@gmail.com", "85697452", "Full Stack Developer", new DateTime(2024, 1, 4, 2, 21, 17, 200, DateTimeKind.Local).AddTicks(9780), null, "alivelii1" });

            migrationBuilder.InsertData(
                table: "Duties",
                columns: new[] { "Id", "Description", "DutyName", "EmployeeId", "StartedDate", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Müşteri talepleri doğrultusunda, mevcut sistemde kullanılan veritabanı güncelleme aracını geliştirme.", "Veritabanı Güncelleme", 1, new DateTime(2024, 1, 4, 2, 21, 17, 200, DateTimeKind.Local).AddTicks(9186), "Tamamlanmadı", null },
                    { 2, "Mevcut müşteri mobil uygulamasının performansını artırmak ve kullanıcı deneyimini optimize etmek.", "Performans Optimizasyonu", 2, new DateTime(2024, 1, 4, 2, 21, 17, 200, DateTimeKind.Local).AddTicks(9205), "Tamamlanmadı", null },
                    { 3, "Web sitenin güvenliğini artırmak ve potansiyel güvenlik açıklarını önlemek için güvenlik denetimi gerçekleştirmek.", "Güvenlik Denetimi", 3, new DateTime(2024, 1, 4, 2, 21, 17, 200, DateTimeKind.Local).AddTicks(9207), "Tamamlanmadı", null }
                });

            migrationBuilder.InsertData(
                table: "EmployeesProfiles",
                columns: new[] { "Id", "Address", "EmployeeId", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Düzce/Merkez", 1, "Gönül", "Kaba", "05978456895" },
                    { 2, "Ankara/Merkez", 2, "Ayşe", "Çetin", "05768459212" },
                    { 3, "Mersin/Merkez", 3, "Ali", "Veli", "05632165498" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Duties_EmployeeId",
                table: "Duties",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesProfiles_EmployeeId",
                table: "EmployeesProfiles",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Duties");

            migrationBuilder.DropTable(
                name: "EmployeesProfiles");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
