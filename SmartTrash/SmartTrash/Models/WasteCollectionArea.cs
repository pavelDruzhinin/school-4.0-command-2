using Microsoft.AspNetCore.Mvc;
using SmartTrash.CustomValidation;
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
        [Required(ErrorMessage ="Введите широту")]
        [Coordinate]
        public float? Latitude { get; set; }
        [Display(Name = "Долгота")]
        [Required(ErrorMessage = "Введите долготу")]
        [Coordinate]
        public float? Longitude { get; set; }
        [Display(Name = "Объём")]
        [Required(ErrorMessage = "Введите объём")]
        [Volume]
        public decimal? Volume { get; set; }
        public decimal FilledVolume { get; set; }
        public decimal PercentOfFill
        {
            get
            {
                return Volume == null || Volume==0 ? 0 : (100 * FilledVolume) / (decimal)Volume;
            }
        }
        public WasteCollectionArea()
        {

        }

    }
}
