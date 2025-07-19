using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindWorkApp.Models
{
    public class Employer // работодатель
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public string? FullName { get; set; }

        [ForeignKey("Vacancy")]
        public int? VacancyId { get; set;}
        public Vacancy? Vacancy{ get; set; }
        public ICollection<Vacancy>? Vacansys { get; set; }
    }
}
