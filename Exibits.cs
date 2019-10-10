using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jurassic.Park.Data
{
    public class Exibits
    {
         [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EID { get; set; }

        [Display(Name = "Exibits Amount")]
        public string EAmount { get; set; }

        [Display(Name = "Exibits Name")]
        public string EName { get; set; }
    }
}
