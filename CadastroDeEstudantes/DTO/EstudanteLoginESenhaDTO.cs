using System.ComponentModel.DataAnnotations;

namespace CadastroDeEstudantes.DTO
{
    public class EstudanteLoginESenhaDTO
    {
        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        [MinLength(8, ErrorMessage = "A senha deve ser no mínimo 8 caracteres")]
        public string Senha { get; set; }
    }
}
