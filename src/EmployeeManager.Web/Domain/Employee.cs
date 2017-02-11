namespace EmployeeManager.Web.Domain
{
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public int Id { get; set; }

        [Display(Name="First Name")]
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required]
        [StringLength(25)]
        public string Department { get; set; }

        [Required]
        [StringLength(50)]
        public string WhoDidThis { get; set; }
    }
}