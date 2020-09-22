using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class MessageMe
    {
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Post { get; set; }
    }
}
