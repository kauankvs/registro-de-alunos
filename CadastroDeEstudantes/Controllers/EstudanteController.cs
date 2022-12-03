using CadastroDeEstudantes.Data;
using CadastroDeEstudantes.DTO;
using CadastroDeEstudantes.Models;
using CadastroDeEstudantes.Password;
using CadastroDeEstudantes.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace CadastroDeEstudantes.Controllers
{
    [Route("estudante")]
    [ApiController]
    public class EstudanteController : ControllerBase
    {
        
        private readonly IEstudanteService _service;

        public EstudanteController(IEstudanteService service) 
        {
            _service = service;
        }

        [Route("selecionar/eu")]
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Estudante>> SelecionarEstudante([FromBody] EstudanteLoginESenhaDTO estudante)
        {
            return await _service.SelecionarEstudante(estudante.Email);
        }

        [Route("registro")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Estudante>> RegistrarEstudante([FromBody] EstudanteDTO estudanteDTO)
        {
            return await _service.RegistrarEstudante(estudanteDTO);
        }

        [Route("login")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Login([FromBody] EstudanteLoginESenhaDTO estudante) 
        {
            return await _service.Login(estudante.Email, estudante.Senha);
        }

        [Route("deletar")]
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<Estudante>> DeletarEstudante([FromBody] EstudanteLoginESenhaDTO estudante)
        {
            return await _service.DeletarEstudante(estudante.Email, estudante.Senha);
        }

        [Route("emails")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<string>>> SelecionarTodosEmails() 
        {
            return await _service.SelecionarTodosEmails();
        }

    }
}
