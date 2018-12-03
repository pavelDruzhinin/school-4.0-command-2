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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Вы не заполнили поле")]
        [Display(Name = "Название")]
        [StringLength(maximumLength: 35, MinimumLength = 5, ErrorMessage = "Используйте имя длиной от 5 до 35 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Вы не заполнили поле")]
        [RegularExpression(@"^[0-9]{1,5}(?:[,][0-9]{5})?$", ErrorMessage = "Используйте формат 61,12345")]
        [Range(minimum: 61.71159, maximum: 61.86249, ErrorMessage = "Допустимая широта 61,71159 - 61,86249 (Петрозаводск)")]
        [Display(Name = "Широта")]
        public float Latitude { get; set; }
        [Required(ErrorMessage = "Вы не заполнили поле")]
        [RegularExpression(@"^[0-9]{1,5}(?:[,][0-9]{5})?$", ErrorMessage = "Используйте формат 34,12345")]
        [Range(minimum: 34.18193, maximum: 34.57194, ErrorMessage = "Допустимая широта 34,18193 - 34,57194 (Петрозаводск)")]
        [Display(Name = "Долгота")]
        public float Longitude { get; set; }
        [Required(ErrorMessage = "Вы не заполнили поле")]
        [RegularExpression(@"^[0-9]{1,5}(?:[,][0-9]{2})?$", ErrorMessage = "Используйте формат 1000,00")]
        [Display(Name = "Объем")]
        [Range(typeof(decimal), "1000,00", "10000,00", ErrorMessage = "Допустимый диапазон 1000 - 15000")]
        public decimal Volume { get; set; }
        public decimal FilledVolume { get; set; }
        public decimal PercentOfFill
        {
            get
            {
                return Volume == 0 ? 0 : (100 * FilledVolume) / Volume;
            }
        }

    }
}
