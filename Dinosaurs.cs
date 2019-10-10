using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jurassic.Park.Data
{
    public class Dinosaurs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DID { get; set; }
        public string DB { get; set; }
        public string DH { get; set; }
        public string DN { get; set; }
     

        //foreign key
        public int EID { get; set; }

        [ForeignKey("EID")]
        public Exibits Exi { get; set; }
        
    }
}
