using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstMVC.Models
{
    public class EmployeeDTO
    {
        [Required]        
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"(\d{4}\-\d{2}-\d{2})")]
        public DateTime HiredDate { get; set; }

        [Required]
        [Range(100.0, 9999.0)]
        public long Salary { get; set; }
    }
}