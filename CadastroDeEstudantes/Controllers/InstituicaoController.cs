using CadastroDeEstudantes.DTO;
using CadastroDeEstudantes.Models;
using CadastroDeEstudantes.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeEstudantes.Controllers
{
    [Route("instituicao")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicaoService _service;

        public InstituicaoController(IInstituicaoService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<ActionResult<Instituicao>> AdicionarInstituicao([FromBody] InstituicaoDTO instituicaoDTO)
        {
            return await _service.AdicionarInstituicao(instituicaoDTO);
        }

        [HttpGet]
        [Route("{nome}")]
        public async Task<ActionResult<Instituicao>> SelecionarInstituicao([FromQuery] string nome)
        {
            return await _service.SelecionarInstituicao(nome);
        }

        [HttpGet]
        public async Task<ActionResult<List<Instituicao>>> SelecionarTodasInstituicao()
        {
            return await _service.SelecionarTodasInstituicao();
        }

        [HttpGet]
        [Route("{estado}")]
        public async Task<ActionResult<List<Instituicao>>> SelecionarInstituicaoPorEstado([FromQuery] string estado) 
        {
            return await _service.SelecionarInstituicaoPorEstado(estado);
        }

        [HttpDelete]
        [Route("deletar")]
        public async Task<ActionResult> DeletarInstituicao(int ID)
        {
            return await _service.DeletarInstituicao(ID);
        }


    }
}
