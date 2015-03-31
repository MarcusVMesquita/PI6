using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MyParking.DAL.Models
{
    public class Veiculo
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "A placa do veículo deve ser informada.")]
        [RegularExpression(@"^[a-zA-Z]{3}\-\d{4}$", ErrorMessage = "A placa deve estar no formato AAA-0000")]
        [DisplayName("Placa")]
        [StringLength(8, MinimumLength = 8)]
        public string PlacaVeiculo { get; set; }

        [DisplayName("Modelo")]
        public string ModeloVeiculo { get; set; }

        //Chaves Estrangeiras
        public virtual MarcaVeiculo marcaVeiculo { get; set; }

        public virtual CorVeiculo corVeiculo { get; set; }
    }
}
