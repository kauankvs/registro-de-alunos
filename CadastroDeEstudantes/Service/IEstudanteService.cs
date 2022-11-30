using CadastroDeEstudantes.DTO;
using CadastroDeEstudantes.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeEstudantes.Service
{
    public interface IEstudanteService
    {
        public Task<ActionResult<Estudante>> SelecionarEstudante(string email);
        public Task<ActionResult<Estudante>> RegistrarEstudante(EstudanteDTO estudanteDTO);
        public bool ChecarSeEstudanteExiste(string email);
    }
}
