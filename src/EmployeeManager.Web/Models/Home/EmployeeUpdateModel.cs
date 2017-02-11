namespace EmployeeManager.Web.Models.Home
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    public class EmployeeUpdateModel
    {
        [HiddenInput]
        public int EmployeeId { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required]
        [StringLength(25)]
        public string Department { get; set; }
    }
}