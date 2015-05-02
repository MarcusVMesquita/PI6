using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyParking.DAL.Models
{
    public class ConfVagas
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_configuracao { get; set; }

        [Required]
        [DisplayName("Qtde Vaga")]
        public int qtdeVagas { get; set; }


    }
}
