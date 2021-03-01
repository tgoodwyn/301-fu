using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _301_fu.Models
{
    public class Shrine
    {
        public int id { get; set; }

        [Display(Name = "Shrine name: ")]
        [StringLength(10)]
        public string name { get; set; }

        public Region region { get; set; }
        public Element element { get; set; }
        public List<Medallion> medallions { get; set; }

    }
}
