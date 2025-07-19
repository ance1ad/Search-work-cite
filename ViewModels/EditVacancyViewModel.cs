using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FindWorkApp.Models;

namespace FindWorkApp.ViewModels
{
    public class EditVacancyViewModel
    {
        public int Id { get; set; }
        [Range(0, 90, ErrorMessage = "Введите корректное число для стажа")]
        public int WorkExpirienceAge { get; set; }
        [Range(0, 1000000, ErrorMessage = "Введите корректное число для заработной платы")]
        public int Salary { get; set; }
        [Required(ErrorMessage = "Строка обязательна для заполнения.")]
        public string? ProgrammingLanguage { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Email { get; set; }
        public string? DistanceWork { get; set; } // возможность работать удаленно
        public string? CompanyInfo { get; set; } // информация о компании
        public string? Date { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public string? AppUserId { get; set; }
    }
}
