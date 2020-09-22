using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){ }

        public DbSet<AboutMe> AboutMe { get; set; }
        public DbSet<AboutSkills> AboutSkills { get; set; }
        public DbSet<Contact> Contact { get; set; } 
        public DbSet<MyWorks> MyWorks { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<MessageMe> MessageMe { get; set; }
    }
}
