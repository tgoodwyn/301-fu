using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _301_fu.Models
{
    public class Region
    {
        public static readonly string[] options = { "North", "West", "East", "South" };
        public int id { get; set; }
        public int labelIdx { get; set; }
        public int shrineId { get; set; }
    }
}
