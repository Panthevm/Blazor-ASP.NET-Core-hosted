using System;
using System.ComponentModel.DataAnnotations;

namespace Dekanat.Shared {
    public class StudentViewModel {
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string FirsName { get; set; }

        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Факультет")]
        public string Faculty { get; set; }

        [Display(Name = "Кафедра")]
        public string Pulpit { get; set; }

        [Display(Name = "Направление подготовки")]
        public string TrainingDirection { get; set; }

        [Display(Name = "Дата поступления")]
        public DateTime ReceiptDate { get; set; }

        [Display(Name = "Год рождения")]
        public DateTime YearOfBirth { get; set; }

        [Display(Name = "Форма обучения")]
        public string FormOfStudy { get; set; }

        [Display(Name = "Адрес проживания")]
        public string Address { get; set; }

        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }
    }
}
