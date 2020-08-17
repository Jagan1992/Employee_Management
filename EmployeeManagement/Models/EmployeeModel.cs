using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please Enter EmployeeName")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Please Enter Age")]
        [Range(20, 60, ErrorMessage = "Age should be between 20 and 60.")]
        [RegularExpression(@"[0-9]{2}", ErrorMessage = "Age should not exceed more than 2 numbers and not less than that.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter PhoneNumber")]
        [RegularExpression(@"[0-9]{10}", ErrorMessage = "Phone Number should not exceed more than 10 numbers and not less than that.")]
        public long PhoneNumber { get; set; }
    }
}