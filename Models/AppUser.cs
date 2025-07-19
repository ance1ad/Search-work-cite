using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindWorkApp.Models
{
    public class AppUser : IdentityUser
    {

       
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public ICollection<Vacancy> Vacansys { get; set; }
        public ICollection<JobResume> JobResume { get; set; }

    }
}
