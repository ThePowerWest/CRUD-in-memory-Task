using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Entities.Main
{
    public class Worker : BaseEntity
    {
        [Required(ErrorMessage = "Поле является обязательным!")]
        [Display(Name = "Должность")]
        [StringLength(100, ErrorMessage = "Длина строки должна быть до 100 символов")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Поле является обязательным!")]
        [Display(Name = "Подразделение")]
        [StringLength(150, ErrorMessage = "Длина строки должна быть до 150 символов")]
        public string Subdivision { get; set; }
        [Required(ErrorMessage = "Поле является обязательным!")]
        [Display(Name = "Оклад")]
        [Range(1, 200000, ErrorMessage = "Диапозон значений от 1 до 200000")]
        public int Salary { get; set; }

        public virtual Profile Profile { get; set; }


    }
}
