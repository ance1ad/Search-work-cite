using System.ComponentModel.DataAnnotations;

namespace FindWorkApp.ViewModels
{
    public class EditCompanyViewModel
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        [Range(2, 1000000, ErrorMessage = "Введите корректное число сотрудников")]
        public int Count { get; set; }
        public string? Image { get; set; }
        public string? Cities { get; set; }
        public string? OfficialSite { get; set; }
    }
}
