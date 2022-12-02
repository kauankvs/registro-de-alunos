using CadastroDeEstudantes.Data;
using CadastroDeEstudantes.DTO;
using CadastroDeEstudantes.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeEstudantes.Service
{
    public interface IInstituicaoService
    {
        public Task<ActionResult<Instituicao>> AdicionarInstituicao(InstituicaoDTO instituicaoDTO);
        public Task<ActionResult<Instituicao>> SelecionarInstituicao(string nome);
        public Task<ActionResult<List<Instituicao>>> SelecionarTodasInstituicao();
        public Task<ActionResult<List<Instituicao>>> SelecionarInstituicaoPorEstado(string estado);
        public Task<ActionResult> DeletarInstituicao(int ID);

    }
}
