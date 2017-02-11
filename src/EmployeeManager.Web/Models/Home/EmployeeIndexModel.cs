namespace EmployeeManager.Web.Models.Home
{
    using System;

    public class EmployeeIndexModel
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        public string EmployeeIdDisplay => EmployeeId.ToString().PadLeft(5, '0');
    }
}