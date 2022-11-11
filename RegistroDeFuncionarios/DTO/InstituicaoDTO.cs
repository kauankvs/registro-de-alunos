using System.ComponentModel.DataAnnotations;

namespace RegistroDeFuncionarios.DTO
{
    public class InstituicaoDTO
    {
        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public string Nome { get; set; }

        [MaxLength(2, ErrorMessage = "Esse campo deve conter 2 caracteres")]
        [MinLength(2, ErrorMessage = "Esse campo deve conter 2 caracteres")]
        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public string Cidade { get; set; }
    }
}
