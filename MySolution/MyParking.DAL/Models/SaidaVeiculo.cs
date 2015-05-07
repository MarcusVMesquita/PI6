using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyParking.DAL.Models
{
    public class SaidaVeiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_SaidaVeiculo;

        [Required]
        [DisplayName("Valor da estadia")]
        public double ValorEstadia;

        [Required]
        [DisplayName("Horario da Saída")]
        public DateTime HorarioSaida;

        [Column("id_Entrada")]
        [DisplayName("chvEntrada")]
        public int VeiculoID { get; set; }

        [ForeignKey("EntradaID")]
        public virtual Veiculo Veiculo { get; set; }
    }
}
