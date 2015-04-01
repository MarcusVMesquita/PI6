using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyParking.DAL.Models
{
    public class Usuario
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DisplayName("Nome")]
        [StringLength(30, MinimumLength=5, ErrorMessage="O Nome deve conter no minímo 5 caracteres e no máximo 30.")]
        public string Nome { get; set; }

        [Required]
        [DisplayName("Login")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "O Login deve conter no minimo 1 caractere e no máximo 10.")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ]+$", ErrorMessage = "O login não deve conter espaço")]
        public string Login { get; set; }

        [Required]
        [DisplayName("Senha")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "A senha deve conter no minimo 6 caracteres e no máximo 15.")]
        public string Password { get; set; }

        [DisplayName("Administrador")]
        public bool Administrador { get; set; }
    }
}
