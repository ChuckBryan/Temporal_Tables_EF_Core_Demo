using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManager.Web.Migrations
{
    public partial class addemployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Employees");
            migrationBuilder.Sql(
@"INSERT INTO Employees (FirstName, LastName, Department, WhoDidThis) VALUES
 ('Ken', 'Sanchez', 'Executive', 'SomeUser'),
 ('Terri', 'Duffy', 'Engineering', 'SomeUser'),
 ('Roberto', 'Tamburello', 'Engineering', 'SomeUser'),
 ('Rob', 'Walters', 'Engineering', 'SomeUser'),
 ('Gail', 'Erickson', 'Engineering', 'SomeUser'),
 ('Jossef', 'Goldberg', 'Engineering', 'SomeUser'),
 ('Dylan', 'Miller', 'Support', 'SomeUser'),
 ( 'Diane', 'Margheim', 'Support', 'SomeUser'),
 ( 'Gigi', 'Matthew', 'Support', 'SomeUser'),
 ( 'Michael', 'Raheem', 'Support', 'SomeUser')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Employees");
        }
    }
}
