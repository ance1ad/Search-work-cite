using System.ComponentModel.DataAnnotations;

namespace FindWorkApp.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [RegularExpression(@"^[A-Za-zА-Яа-яЁё\s\p{P}]+$", ErrorMessage = "Допустимы только буквы русского и английского алфавита, пробелы и знаки препинания в поле")]

        public string? City { get; set; } = "не указан";
        public string? Street { get; set;} = "не указан";
        public string? Home { get; set;} = "не указан";
    }
}
