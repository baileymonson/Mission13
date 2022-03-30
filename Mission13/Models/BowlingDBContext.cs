using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class BowlingDBContext : DbContext
    {
        public BowlingDBContext(DbContextOptions<BowlingDBContext>options) : base(options)
        {

        }
        // connecting the two tables here
        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
