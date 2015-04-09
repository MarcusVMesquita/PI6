using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyParking.DAL.Models
{
    public class Veiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_veiculo { get; set; }

        [Required(ErrorMessage = "A placa do veículo deve ser informada.")]
        [RegularExpression(@"^[a-zA-Z]{3}\-\d{4}$", ErrorMessage = "A placa deve estar no formato AAA-0000")]
        [DisplayName("Placa")]
        [StringLength(8, MinimumLength = 8)]
        public string PlacaVeiculo { get; set; }

        [DisplayName("Modelo")]
        public string ModeloVeiculo { get; set; }

        //Chaves Estrangeiras
        [Column("id_marca")]
        [Display(Name = "chvMarca")]
        public int MarcaID { get; set; }

        [ForeignKey("MarcaID")]
        public virtual MarcaVeiculo MarcaVeiculo { get; set; }

        [Column("id_cor")]
        [Display(Name = "chvCor")]
        public int CorID { get; set; }

        [ForeignKey("CorID")]
        public virtual CorVeiculo CorVeiculo { get; set; }
    }
}
