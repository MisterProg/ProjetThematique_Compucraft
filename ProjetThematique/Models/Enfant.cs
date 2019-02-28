using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetThematique.Models
{
    public class Enfant
    {
        public int ID { get; set; }

        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public bool IsTemoin { get; set; }

        public int IDTypeAutisme { get; set; }


    }
}
