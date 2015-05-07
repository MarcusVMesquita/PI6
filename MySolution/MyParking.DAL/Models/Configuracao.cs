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
    public class Configuracao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_configuracao { get; set; }

        [Required(ErrorMessage = "A quantidade de vagas deve ser informada")]
        [DisplayName("Quantidade de Vagas")]
        public int qtdeVagas { get; set; }

        [Required(ErrorMessage = "O valor da Primeira Hora deve ser informado")]
        [DisplayName("Valor da Primeira Hora")]
        public decimal valorPrimeiraHora { get; set; }

        [Required(ErrorMessage = "O valor das Demais Horas deve ser informado")]
        [DisplayName("Valor da Hora Adicional")]
        public decimal valorHoraAdicional { get; set; }

        [Required(ErrorMessage = "O valor da Mensalista deve ser informado")]
        [DisplayName("Valor da Mensalista")]
        public decimal valorMensalista {get;set;}


    }
}
