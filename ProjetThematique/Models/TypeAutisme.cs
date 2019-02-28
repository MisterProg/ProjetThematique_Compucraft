using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetThematique.Models
{
    public class TypeAutisme
    {
        public int ID { get; set; }
   
        [Required]
        public string Libelle { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
