using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _301_fu.Models
{
    public class Element
    {
        public static readonly string[] options = { "Earth", "Wind", "Water", "Fire" };
        public int id { get; set; }
        public int labelIdx { get; set; }
        public int shrineId { get; set; }
    }
}
