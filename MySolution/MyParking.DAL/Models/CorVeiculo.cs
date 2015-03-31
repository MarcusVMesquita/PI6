using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyParking.DAL.Models
{
    public class CorVeiculo
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage="A cor do veículo deve ser informada.")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "A cor deve ter pelo menos 3 caracteres e no máximo 10.")] 
        [DisplayName("Cor do Veículo")]
        public string corVeiculo { get; set; }
    }
}
