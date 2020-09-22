using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class MyWorks
    {
        public int Id { get; set; }
        [Required]
        public int ImageId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Head { get; set; }
        public virtual Category Category { get; set; }
        public virtual Image Image { get; set; }

        public string ModalName { get; set; }
        public string ShortName { get; set; }
        public string CloseName { get; set; }
    }
}
