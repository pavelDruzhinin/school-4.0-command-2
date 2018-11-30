using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTrash.Models
{
    public class WasteCollectionArea
    {
        public int Id { get; set; }
        [Display(Name = "Название мусорки")]
        [Required(ErrorMessage = "Введите название точки")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Название должно содержать от 3 до 200 знаков")]
        public string Name { get; set; }
        [Display(Name = "Широта")]
        [Required(ErrorMessage = "Введите широту")]
        public float? Latitude { get; set; }
        [Display(Name = "Долгота")]
        [Required(ErrorMessage = "Введите долготу")]
        public float? Longitude { get; set; }
        [Required(ErrorMessage = "Введите объём")]
        [Display(Name = "Объём")]
        public decimal? Volume { get; set; }
        public decimal FilledVolume { get; set; }
        public decimal PercentOfFill
        {
            get
            {
                return Volume == null || Volume==0 ? 0 : (100 * FilledVolume) / (decimal)Volume;
            }
        }

        public bool Empty
        {
            get { return Id == 0; }
        }
        public WasteCollectionArea()
        {

        }

    }
}
