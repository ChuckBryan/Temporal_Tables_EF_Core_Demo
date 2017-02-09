namespace EmployeeManager.Web.Domain
{
    public enum Department
    {
        Executive,
        Engineering,
        Support
    }

    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Department Department { get; set; }
    }
}