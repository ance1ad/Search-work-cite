using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindWorkApp.Models
{
    public class Vacancy
    {
        [Key]
        public int Id { get; set; }
        [Range(0, 70, ErrorMessage = "введите корректное число для стажа")]
        public int WorkExpirienceAge { get; set; }
        [Range(0, 1000000, ErrorMessage = "введите корректное число для заработной платы")]
        public int Salary { get; set; }
        [Required(ErrorMessage = "Строка обязательна для заполнения.")]
        public string? ProgrammingLanguage { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Date { get; set; }
        public string? Email { get; set; }
        public string? DistanceWork { get; set; } // возможность работать удаленно
        public string? CompanyInfo { get; set; } // информация о компании
        
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
