using CadastroDeEstudantes.Controllers;
using CadastroDeEstudantes.Data;
using CadastroDeEstudantes.DTO;
using CadastroDeEstudantes.Models;
using CadastroDeEstudantes.Password;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeEstudantes.Service
{
    public class EstudanteService : IEstudanteService
    {
        private PasswordHashAndSalt _password;
        private CadastroContext _context;

        public EstudanteService(PasswordHashAndSalt password, CadastroContext context)
        {
            _password = password;
            _context = context;
        }

        public async Task<ActionResult<Estudante>> SelecionarEstudante(string email)
        {
            Estudante estudante = await _context.Estudantes.AsNoTracking().FirstOrDefaultAsync(e => e.Email == email);
            return estudante;
        }
        public async Task<ActionResult<Estudante>> RegistrarEstudante(EstudanteDTO estudanteDTO)
        {
            if(ChecarSeEstudanteExiste(estudanteDTO.Email) == true) 
            {
                return new ConflictResult();
            }

            _password.CriarSenhaEmHashESalt(estudanteDTO.Senha, out byte[] hash, out byte[] salt);

            var estudante = new Estudante()
            {
                SenhaHash = hash,
                SenhaSalt = salt,
                Nome = estudanteDTO.Nome,
                Sobrenome = estudanteDTO.Sobrenome,
                Email = estudanteDTO.Email.ToLower(),
                InstituicaoID = estudanteDTO.InstituicaoID,
            };

            await _context.Estudantes.AddAsync(estudante);
            await _context.SaveChangesAsync();

            return new CreatedResult(nameof(SelecionarEstudante), estudante);
        }

        public bool ChecarSeEstudanteExiste(string email)
        {
            bool estudanteExistente = _context.Estudantes.Any(e => e.Email == email);
            return estudanteExistente;
        }

    }

}

    

