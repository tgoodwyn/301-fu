using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _301_fu.Models;

namespace _301_fu.Data
{
    public class _301_fuContext : DbContext
    {
        public _301_fuContext (DbContextOptions<_301_fuContext> options)
            : base(options)
        {
        }

        public DbSet<_301_fu.Models.Shrine> Shrine { get; set; }
        public DbSet<_301_fu.Models.Element> Element { get; set; }
        public DbSet<_301_fu.Models.Medallion> Medallion { get; set; }
        public DbSet<_301_fu.Models.Region> Region { get; set; }

    }
}
