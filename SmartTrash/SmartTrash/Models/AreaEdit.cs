using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTrash.Models
{
    [NotMapped]
    public class AreaEdit
    {
        public int Id { get; set; }
        [Display(Name="Название мусорки")]
        [Required(ErrorMessage = "Введите название точки")]
        [StringLength(200,MinimumLength =3,ErrorMessage ="Название должно содержать от 3 до 200 знаков")]
        public string Name { get; set; }
        [Display(Name = "Широта")]
        [Required(ErrorMessage ="Введите широту")]
        [RegularExpression(@"[-]?([0-9]*[,])?[0-9]+$", ErrorMessage = "Введите координату корректно через запятую")]
        public float? Latitude { get; set; }
        [Display(Name = "Долгота")]
        [Required(ErrorMessage ="Введите долготу")]
        [RegularExpression(@"[-]?([0-9]*[,])?[0-9]+$", ErrorMessage = "Введите координату корректно через запятую")]
        public float? Longitude { get; set; }
        [Required(ErrorMessage ="Введите объём")]
        [Display(Name = "Объём")]
        [RegularExpression(@"([0-9]*[,])?[0-9]+$", ErrorMessage = "Введите объём корректно через запятую, знак минуса и плюса воспрещён")]
        public decimal? Volume { get; set; }

        public AreaEdit()
        {

        }
    }
}
