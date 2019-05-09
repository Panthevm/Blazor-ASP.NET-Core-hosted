using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Dekanat.Server.Models {
    public class User : IdentityUser {

        [Display(Name = "Имя")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "Имя должно состоять не менее из 2-32 символов")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "Фамилия должна состоять не менее из 2-32 символов")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "Отчестов должно состоять не менее из 2-32 символов")]
        public string SurName { get; set; }
    }
}
