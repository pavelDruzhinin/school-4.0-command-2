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
        public float? Latitude { get; set; }
        [Display(Name = "Долгота")]
        [Required(ErrorMessage ="Введите долготу")]
        public float? Longitude { get; set; }
        [Required(ErrorMessage ="Введите объём")]
        [Display(Name = "Объём")]
        public decimal? Volume { get; set; }

        public AreaEdit()
        {

        }
    }
}
