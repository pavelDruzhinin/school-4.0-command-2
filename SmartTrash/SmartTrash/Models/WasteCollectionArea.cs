using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTrash.Models
{
    public class WasteCollectionArea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public decimal Volume { get; set; }
        public decimal FilledVolume { get; set; }
        public decimal PercentOfFill => (100 * FilledVolume) / Volume;

        public WasteCollectionArea()
        {

        }

    }
}
