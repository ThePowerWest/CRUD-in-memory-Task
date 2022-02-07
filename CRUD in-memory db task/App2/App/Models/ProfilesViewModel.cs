using App.Settings;
using System;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class ProfilesViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "ФИО")]
        [StringLength(100, ErrorMessage = "Длина строки должна быть до 100 символов")]
        public string Fullname { get; set; }

        [Required]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [CustomDate(-65, -18, ErrorMessage = "Значение должно быть от (*текущая дата* - 65 лет) до (*текущая дата* - 18 лет)")]
        public string Date { get; set; }

        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "Длина строки должна быть до 50 символов")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, ErrorMessage = "Длина строки должна быть до 15 символов")]
        public string Phone { get; set; }

        public WorkersViewModel WorkersViewModel { get; set; }

    }
}
