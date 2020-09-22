using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Facebook { get; set; }
        [Required]
        public string Instagram { get; set; }
        [Required]
        public string Linkedin { get; set; }
        [Required]
        public string Github { get; set; }
    }
}
