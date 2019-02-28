using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetThematique.Models
{
    public class RegisterKey
    {
        public int ID { get; set; }

        [Required]
        public string ApplicationUserID { get; set; }

        [Required]
        public string Key { get; set; }
    }
}
