using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestDiceRoll.Models
{
    public class DiceRoll
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string  Name { get; set; }
        public int Number { get; set; }
        public int Guess { get; set; }
        public int Result { get; set; }
        
    }
}
