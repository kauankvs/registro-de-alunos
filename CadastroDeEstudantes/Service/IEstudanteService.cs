using CadastroDeEstudantes.DTO;
using CadastroDeEstudantes.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeEstudantes.Service
{
    public interface IEstudanteService
    {
        public Task<ActionResult<Estudante>> SelecionarEstudante(string email);
        public Task<ActionResult<Estudante>> RegistrarEstudante(EstudanteDTO estudanteDTO);
        public Task<ActionResult<string>> Login(EstudanteLoginESenhaDTO estudante);
        public Task<ActionResult<Estudante>> DeletarEstudante(string email, string senha);
        public Task<ActionResult<List<string>>> SelecionarTodosEmails();

    }
}
