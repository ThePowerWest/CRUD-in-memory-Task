using System;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class WorkersViewModel
    {
        
        public  int Id { get; set; }

        [Required]
        [Display(Name = "Должность")]
        [StringLength(100, ErrorMessage = "Длина строки должна быть до 100 символов")]
        public string Position { get; set; }

        [Required]
        [Display(Name = "Подразделение")]
        [StringLength(150, ErrorMessage = "Длина строки должна быть до 150 символов")]
        public string Subdivision { get; set; }

        [Required]
        [Display(Name = "Оклад")]
        [Range(1, 200000, ErrorMessage = "Диапозон значений от 1 до 200000")]
        public int Salary { get; set; }
        public virtual ProfilesViewModel Profile { get; set; }

    }
}
