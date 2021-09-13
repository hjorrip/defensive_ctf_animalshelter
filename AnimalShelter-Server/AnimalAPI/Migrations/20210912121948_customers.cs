using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAPI.Migrations
{
    public partial class customers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNr = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNr" },
                values: new object[] { 1, "johnsnow@youknownothing.com", "John", "Snow", "661 1111" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNr" },
                values: new object[] { 2, "buffy@slayer.com", "Buffy", "Summers", "849 4491" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });
        }
    }
}
