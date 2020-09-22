using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.ViewModels
{
    public class HomeVM
    {
        public AboutMe AboutMe { get; set; }
        public AboutSkills AboutSkills { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public Contact Contact { get; set; }
        public IEnumerable<MyWorks> MyWorks { get; set; }
        public IEnumerable<Services> Services { get; set; }

    }
}
