using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTrash.Models
{
    public class GarbageTruck
    {
        public int Id { get; set; }

        // A truck registration plate
        public string NumberPlate { get; set; }

        // Truck model
        public string Model { get; set; }

        // Volume of garbage truck (in litres) 
        // Volume = (Average coefficient of garbage compacting * truck body volume)
        public decimal Volume { get; set; }

        // Average maintanance cost factor by 1 km of road
        public decimal MaintananceCostFactor { get; set; }
    }
}
