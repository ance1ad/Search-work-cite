using System.ComponentModel.DataAnnotations;

namespace FindWorkApp.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Введите адрес электронной почты")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Поле обязательно для ввода")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
