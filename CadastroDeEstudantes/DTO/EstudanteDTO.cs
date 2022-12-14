using System.ComponentModel.DataAnnotations;

namespace CadastroDeEstudantes.DTO
{
    public class EstudanteDTO
    {
        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        [MinLength(8, ErrorMessage = "A senha deve ser no mínimo 8 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public int InstituicaoID { get; set; }
    }
}
