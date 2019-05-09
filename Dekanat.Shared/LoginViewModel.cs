using System.ComponentModel.DataAnnotations;

namespace Dekanat.Shared {
    public class LoginViewModel {

        [Required (ErrorMessage = "Укажите почту")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Неверный формат")]
        [EmailAddress (ErrorMessage = "Неверный формат почты")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required (ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password, ErrorMessage = "Неверный формат пароля")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

    }
}
