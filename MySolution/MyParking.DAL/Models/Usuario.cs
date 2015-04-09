using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyParking.DAL.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_usuario { get; set; }

        [Required(ErrorMessage="O nome deve ser informado.")]
        [DisplayName("Nome")]
        [StringLength(30, MinimumLength=5, ErrorMessage="O Nome deve conter no minímo 5 caracteres e no máximo 30.")]
        public string Nome { get; set; }

        [Required(ErrorMessage="O Login deve ser informado.")]
        [DisplayName("Login")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "O Login deve conter no minimo 1 caractere e no máximo 10.")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ]+$", ErrorMessage = "O login não deve conter espaço")]
        public string Login { get; set; }

        [Required(ErrorMessage="A senha deve ser informada")]
        [DataType(DataType.Password)]
        [DisplayName("Senha")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "A senha deve conter no minimo 6 caracteres e no máximo 15.")]
        public string Password { get; set; }

        [DisplayName("Confirmação de Senha")]
        [Compare("Password", ErrorMessage="A confirmação não confere.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [DisplayName("Administrador?")]
        public bool Administrador { get; set; }
    }
}
