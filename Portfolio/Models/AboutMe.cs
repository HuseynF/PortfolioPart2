using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class AboutMe
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
