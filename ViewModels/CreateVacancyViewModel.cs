using FindWorkApp.Models;
using System.ComponentModel.DataAnnotations;

namespace FindWorkApp.ViewModels
{
    public class CreateVacancyViewModel
    {

        [Range(0, 99, ErrorMessage = "Введите корректное число для стажа")]
        public int WorkExpirienceAge { get; set; }
        [Range(0, 5000000, ErrorMessage = "Укажите правильно заработную плату")]
        public int Salary { get; set; }
        public string? ProgrammingLanguage { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Email { get; set; }
        public string? Date { get; set; }
        public string? DistanceWork { get; set; } 
        public string? CompanyInfo { get; set; } 

        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
