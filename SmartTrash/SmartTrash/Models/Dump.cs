using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTrash.Models
{
    public class Dump
    {
        int id { get; set; }
        float longitude { get; set; }
        float latitude { get; set; }
        string Name { get; set; }
        decimal Amount { get; set; }
        decimal Filled { get; set; }
        decimal PercentOfFill => (100 * Filled)/Amount;

    }
}
