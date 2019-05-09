using System.ComponentModel.DataAnnotations;

namespace Dekanat.Shared {
    public class RegisterViewModel {

        [Required(ErrorMessage = "Укажите почту")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Неверный формат")]
        [EmailAddress(ErrorMessage = "Неверный формат почты")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password, ErrorMessage = "Неверный формат пароля")]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "Пароль должен содержать не менее 8 символов")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }
    }
}
