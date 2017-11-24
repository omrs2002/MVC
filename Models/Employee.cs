using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCourse2017.Models
{
    public class Employee
    {
        [Required]
        [Display(Name = "Emp ID")]
        [Key]
        public long EmpID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }


        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Salary")]
        public double Salary { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartID { get; set; }

    }

}