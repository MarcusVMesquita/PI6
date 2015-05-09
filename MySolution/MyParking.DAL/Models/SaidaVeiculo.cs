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

        [Required(ErrorMessage = "É necessário informar a placa do veículo")]
        [RegularExpression(@"^[a-zA-Z]{3}\-\d{4}$", ErrorMessage = "A placa deve estar no formato AAA-0000")]
        [DisplayName("Placa do Veículo")]
        public string PlacaVeiculo { get; set; }

        [Required]
        [DisplayName("Horario da Saída")]
        public DateTime HorarioSaida{ get; set; }

        [Required]
        [DisplayName("Horario de Entrada")]
        public DateTime HorarioEntrada { get; set; }

        [Required]
        [DisplayName("Valor da estadia")]
        public decimal ValorEstadia { get; set; }
    }
}
