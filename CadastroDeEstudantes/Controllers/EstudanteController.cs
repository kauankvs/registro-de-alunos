using CadastroDeEstudantes.Data;
using CadastroDeEstudantes.DTO;
using CadastroDeEstudantes.Models;
using CadastroDeEstudantes.Password;
using CadastroDeEstudantes.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeEstudantes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudanteController : ControllerBase
    {
        private PasswordHashAndSalt _password;
        private CadastroContext _context;
        private EstudanteService _service;

        public EstudanteController(PasswordHashAndSalt password, CadastroContext context, EstudanteService service) 
        {
            _password = password;
            _context = context;
            _service = service;
        }

        [Route("selecionar/{email}")]
        [HttpGet]
        public async Task<ActionResult<Estudante>> SelecionarEstudante([FromQuery] string email)
        {
            return await _service.SelecionarEstudante(email);
        }

        [Route("registro")]
        [HttpPost]
        public async Task<ActionResult<Estudante>> RegistrarEstudante([FromBody] EstudanteDTO estudanteDTO)
        {
            return await _service.RegistrarEstudante(estudanteDTO);
        }

    }
}
