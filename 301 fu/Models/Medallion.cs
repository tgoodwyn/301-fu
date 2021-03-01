using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _301_fu.Models
{
    public class Medallion
    {
        public static readonly string[] options = { "iron", "bronze", "silver", "gold", "platinum", "diamond" };
        public int id { get; set; }
        public int labelIdx { get; set; }
        public int shrineId { get; set; }

    }
}
