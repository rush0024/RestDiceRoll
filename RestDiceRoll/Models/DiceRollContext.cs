using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestDiceRoll.Models
{
    public class DiceRollContext : DbContext
    {

        public DiceRollContext(DbContextOptions opts): base(opts)
        {

        }
        public DbSet<DiceRoll> DiceRolls { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        


    }
}


