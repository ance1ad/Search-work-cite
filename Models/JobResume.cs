
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindWorkApp.Models
{
    public class JobResume
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Строка обязательна для заполнения.")]
        [RegularExpression(@"^[A-Za-zА-Яа-яЁё\s\p{P}]+$", ErrorMessage = "Допустимы только буквы русского и английского алфавитов, пробелы и знаки препинания")]
        public string? CareerObjective { get; set; }
        [Required(ErrorMessage = "Строка обязательна для заполнения.")]
        [Range(0, 70, ErrorMessage = "введите корректное число для стажа")]
        public int WorkExpirience { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }

        [Range(0, 1000000, ErrorMessage = "введите корректное число для зарплаты")]
        public int Salary { get; set; }
        [Range(16, 99, ErrorMessage = "Возраст должен быть в диапазоне от 16 лет.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Строка обязательна для заполнения.")]

        [RegularExpression(@"^[A-Za-zА-Яа-яЁё\s\p{P}]+$", ErrorMessage = "Допустимы только буквы русского и английского алфавитов, пробелы и знаки препинания")]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "Выберите свой пол.")]
        public string? Gender{ get; set; }
        public string? PhoneNumber{ get; set; }
        public string? Date{ get; set; }

        public string? Email{ get; set; }
        public string? Education { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
