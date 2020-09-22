using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public virtual ICollection<MyWorks> MyWorks { get; set; }
        [NotMapped]
        public IFormFile Photo1 { get; set; }
        [NotMapped]
        public IFormFile Photo2 { get; set; }
        [NotMapped]
        public IFormFile Photo3 { get; set; }
    }
}
