using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyParking.DAL.Models
{
    public class Cliente
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "O nome do cliente deve ser informado!")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ]+$", ErrorMessage = "O nome não deve conter espaço")]
        [DisplayName("Nome")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "O nome deve conter no mínimo 5 caracteres e no máximo 15")]
        public string NomeCliente { get; set; }

        [Required(ErrorMessage = "O sobrenome do cliente deve ser informado!")]
        [DisplayName("Sobrenome")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "O nome deve conter no mínimo 5 caracteres e no máximo 30")]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "O CPF do cliente deve ser informado!")]
        [RegularExpression(@"[0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[\-]?[0-9]{2}", ErrorMessage = "O CPF deve estar no formato 00000000000 ou 000.000.000-00")]
        [DisplayName("CPF")]
        [StringLength(14, MinimumLength = 11)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O CEP deve ser informado!")]
        [RegularExpression(@"^\d{8}$|^\d{5}-\d{3}$", ErrorMessage = "O código postal deve estar no formato 00000000 ou 00000-000")]
        [DisplayName("CEP")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório!")]
        [DisplayName("Endereco")]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "O endereço deve conter no mínimo 10 caracteres!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório!")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Digite um email válido!")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone deve ser informado!")]
        [RegularExpression(@"^(\([0-9]{2}\))\s([9]{1})?([0-9]{4})-([0-9]{4})$", ErrorMessage = "O telefone deve estar no formato (00) 0000-0000 ou (00) 00000-0000")]
        [DisplayName("Número de Telefone")]
        public string Telefone { get; set; }

        [Required]
        public virtual Veiculo veiculo { get; set; }
    }
}
