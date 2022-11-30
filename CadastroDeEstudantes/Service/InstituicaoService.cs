using CadastroDeEstudantes.Data;
using CadastroDeEstudantes.DTO;
using CadastroDeEstudantes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeEstudantes.Service
{  
    public class InstituicaoService : IInstituicaoService
    {
        private CadastroContext _context;

        public InstituicaoService(CadastroContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Instituicao>> AdicionarInstituicao(InstituicaoDTO instituicaoDTO)
        {
            var instituicao = new Instituicao()
            {
                Nome = instituicaoDTO.Nome,
                Cidade = instituicaoDTO.Cidade,
                Estado = instituicaoDTO.Estado.ToUpper(),
            };
            await _context.AddAsync(instituicao);
            await _context.SaveChangesAsync();
            return new CreatedResult("nameof(SelecionarInstituicao)", instituicao);
        }

        public async Task<ActionResult<Instituicao>> SelecionarInstituicao(string nome)
        {
            Instituicao instituicao = await _context.Instituicoes.AsNoTracking().FirstOrDefaultAsync(i => i.Nome == nome);
            return new OkObjectResult(instituicao);
        }

        public async Task<ActionResult<List<Instituicao>>> SelecionarTodasInstituicao()
        {
            List<Instituicao> instituicoes = await _context.Instituicoes.AsNoTracking().ToListAsync();
            return new OkObjectResult(instituicoes);
        }

        public async Task<ActionResult<List<Instituicao>>> SelecionarInstituicaoPorEstado(string estado)
        {
            List<Instituicao> instituicoes = await _context.Instituicoes.AsNoTracking().Where(i => i.Estado == estado.ToUpper()).ToListAsync();
            return new OkObjectResult(instituicoes);
        }

        public async Task<ActionResult> DeletarInstituicao(int ID) 
        {
            Instituicao instituicao = await _context.Instituicoes.AsNoTracking().FirstOrDefaultAsync(i => i.ID == ID);
            _context.Instituicoes.Remove(instituicao);
            await _context.SaveChangesAsync();
            return new AcceptedResult();
        }


    }
}
