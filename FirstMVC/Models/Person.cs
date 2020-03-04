using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstMVC.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama harus diisi")]
        [StringLength(10, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Alamat terlalu panjang")]
        [MinLength(5)]
        public string Address { get; set; }
    }
}