using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FileManagementProject.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeePassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeDepartmentId = table.Column<int>(type: "int", nullable: false),
                    EmployeeManagerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeDepartmentId", "EmployeeEmail", "EmployeeFirstName", "EmployeeLastName", "EmployeeManagerId", "EmployeePassword" },
                values: new object[,]
                {
                    { 1, 0, "enes_bykbss@hotmail.com", "Enes", "Büyükbaş", 0, "1234" },
                    { 2, 1, "enes_buyukbas@hotmail.com", "Emre", "Büyük", null, "12345" },
                    { 3, 2, "beyzayuksel0111@gmail.com", "Beyza", "Yüksel", null, "123456789" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
