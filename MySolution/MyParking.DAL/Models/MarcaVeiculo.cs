using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyParking.DAL.Models
{
    public class MarcaVeiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_marca { get; set; }

        [Required(ErrorMessage = "O nome da marca deve ser informado")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "A marca deve ter pelo menos 3 caracteres e no máximo 15.")]
        [DisplayName("Marca")]
        public string NomeMarca { get; set; }
    }
}
