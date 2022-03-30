using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    // table from the database for the teams
    public class Team
    {
        [Key]
        [Required]
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int CaptainID { get; set; }
    
    }
}
