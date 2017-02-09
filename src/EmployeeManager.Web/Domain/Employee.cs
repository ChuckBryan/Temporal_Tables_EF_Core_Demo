namespace EmployeeManager.Web.Domain
{
    using EnsureThat;

    public enum Department
    {
        Executive,
        Engineering,
        Support
    }

    public class Employee
    {
        public Employee(string firstName, string lastName, Department department)
        {
            Ensure.That(() => firstName).IsNotNullOrWhiteSpace();
            Ensure.That(() => lastName).IsNotNullOrWhiteSpace();

            FirstName = firstName;
            LastName = lastName;
            Department = department;
        }

        private Employee()
        {
        }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public Department Department { get; private set; }

        public void ChangeEmployeeDepartment(Department newDepartment)
        {
            Department = newDepartment;
        }

        public void UpdateEmployeeName(string firstName, string lastName)
        {
            Ensure.That(() => firstName).IsNotNullOrWhiteSpace();
            Ensure.That(() => lastName).IsNotNullOrWhiteSpace();

            FirstName = firstName;
            LastName = lastName;
        }
    }
}