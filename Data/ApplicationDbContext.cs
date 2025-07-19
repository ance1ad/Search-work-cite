using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FindWorkApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNet.Identity;


namespace FindWorkApp.Data
{
    // то что дает нам полную функциональность для всего приложения в целом
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; } // таблица адресов
        public DbSet<Company> Companies { get; set; } // таблица адресов
        public DbSet<JobResume> JobResumes { get; set; } // таблица адресов
        public DbSet<Vacancy> Vacancies { get; set; } // таблица адресов
        
    }
}
