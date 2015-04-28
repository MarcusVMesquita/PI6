using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyParking.DAL.Models
{
    public class Vaga
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_Vaga { get; set; }

        [Required]
        [DisplayName("Ocupado")]
        //[StringLength(1, MinimumLength = 1, ErrorMessage = "O campo deve ser preenchido com 0 (Falso) ou 1 (Verdadeiro)")]
        public bool Ocupado { get; set; }

        [RegularExpression(@"^[a-zA-Z]{3}\-\d{4}$", ErrorMessage = "A placa deve estar no formato AAA-0000")]
        [DisplayName("Placa")]
        public string PlacaVeiculo { get; set; }
        
        public DateTime  HorarioEntrada { get;set; }


    }
}
