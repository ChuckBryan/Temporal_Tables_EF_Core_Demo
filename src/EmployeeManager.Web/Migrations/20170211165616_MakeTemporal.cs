namespace EmployeeManager.Web.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class MakeTemporal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
ALTER TABLE Employees ADD
  StartDate datetime2 GENERATED ALWAYS AS ROW START NOT NULL CONSTRAINT [df_StartDate] DEFAULT CAST('1900-01-01 00:00:00.0000000' AS datetime2) ,
  EndDate   datetime2 GENERATED ALWAYS AS ROW END NOT NULL CONSTRAINT [df_EndDate] DEFAULT  CAST('9999-12-31 23:59:59.9999999' AS datetime2)  ,
PERIOD FOR SYSTEM_TIME (StartDate, EndDate)");

            migrationBuilder.Sql(@"
ALTER TABLE Employees 
    SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.EmployeesHistory))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE Employees SET (SYSTEM_VERSIONING = OFF)");
            migrationBuilder.Sql(@"ALTER TABLE Employees DROP PERIOD FOR SYSTEM_TIME");
            migrationBuilder.Sql(@"ALTER TABLE Employees DROP DF_StartDate, DF_EndDate");
            migrationBuilder.Sql(@"ALTER TABLE Employees DROP COLUMN StartDate, COLUMN EndDate");
            migrationBuilder.Sql(@"DROP TABLE EmployeesHistory");
        }
    }
}