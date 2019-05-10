using System.ComponentModel.DataAnnotations;

namespace Dekanat.Shared {
    public class ProfileViewModel {

        [Required(ErrorMessage = "Укажите имя")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Укажите фамилию")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Укажите отчество")]
        [Display(Name = "Отчество")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Укажите почту")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Неверный формат")]
        [EmailAddress(ErrorMessage = "Неверный формат почты")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public string Roles { get; set; }

    }
}
