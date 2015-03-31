using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyParking.DAL.Models
{
    public class MarcaVeiculo
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage="O nome da marca deve ser informado")]
        [StringLength(15, MinimumLength=3, ErrorMessage="A marca deve ter pelo menos 3 caracteres e no máximo 15.")] 
        [DisplayName("Marca")]
        public string NomeMarca { get; set; }
    }
}
