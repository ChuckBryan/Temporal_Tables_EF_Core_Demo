using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManager.Web.Migrations
{
    public partial class AdjustDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Turn off so we can update...
            migrationBuilder.Sql("ALTER TABLE Employees SET (SYSTEM_VERSIONING = OFF)");

            // First update was 35 days ago
            migrationBuilder.Sql(@"            
                UPDATE EmployeesHistory SET
                EndDate = DATEADD(D, -35, EndDate)
                WHERE FirstName = 'Gail'");

            // Second was 25 days ago
            migrationBuilder.Sql(@"            
                UPDATE EmployeesHistory SET
                StartDate = DATEADD(D, -35, StartDate),
                EndDate = DATEADD(D, -25, EndDate)
                WHERE FirstName = 'Gabriel' AND Department = 'Engineering'");

            // Third was just now
            migrationBuilder.Sql(@"            
                UPDATE EmployeesHistory SET
                StartDate = DATEADD(D, -25, StartDate)
                WHERE FirstName = 'Gabriel' AND Department = 'Support'");

             // Delete was 25 days ago
            migrationBuilder.Sql(@"            
                UPDATE EmployeesHistory SET
                EndDate = DATEADD(D, -25, EndDate)
                WHERE Id = 8");

            //re-enable temporal
             migrationBuilder.Sql(
                  @"ALTER TABLE Employees SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.EmployeesHistory))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
