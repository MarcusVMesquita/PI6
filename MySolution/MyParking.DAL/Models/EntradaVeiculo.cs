using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyParking.DAL.Models
{
    public class EntradaVeiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Numero da vaga")]
        public int id_Entrada { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]{3}\-\d{4}$", ErrorMessage = "A placa deve estar no formato AAA-0000")]
        [DisplayName("Placa do Veículo")]
        public string PlacaVeiculo { get; set; }

        [Required]
        [DisplayName("Horario de Entrada")]
        public DateTime HorarioEntrada { get; set; } 
    }
}
