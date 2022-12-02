using CadastroDeEstudantes.Controllers;
using CadastroDeEstudantes.Data;
using CadastroDeEstudantes.DTO;
using CadastroDeEstudantes.Models;
using CadastroDeEstudantes.Password;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace CadastroDeEstudantes.Service
{
    public class EstudanteService : IEstudanteService
    {
        private readonly PasswordHashAndSalt _password;
        private readonly CadastroContext _context;
        private readonly TokenService _tokenService;

        public EstudanteService(PasswordHashAndSalt password, CadastroContext context, TokenService tokenService)
        {
            _password = password;
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<ActionResult<Estudante>> SelecionarEstudante(string email)
        {
            Estudante estudante = await _context.Estudantes.AsNoTracking().FirstOrDefaultAsync(e => e.Email == email);
            return new OkObjectResult(estudante);
        }
        public async Task<ActionResult<Estudante>> RegistrarEstudante(EstudanteDTO estudanteDTO)
        {
            if(ChecarSeEstudanteExiste(estudanteDTO.Email).Equals(true)) 
                return new ConflictResult();

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

        public async Task<ActionResult<string>> Login(EstudanteLoginESenhaDTO estudante) 
        {
            if(ChecarSeEstudanteExiste(estudante.Email).Equals(false))
                return new NotFoundResult();
            
            if(VerificarSeSenhaECerta(estudante.Email, estudante.Senha).Equals(false))
                return new BadRequestResult(); 
            
            return _tokenService.GerarToken(estudante.Email);
        }

        public async Task<ActionResult<Estudante>> DeletarEstudante(string email, string senha)
        {
            if(ChecarSeEstudanteExiste(email).Equals(false))
                return new NotFoundResult();

            if(VerificarSeSenhaECerta(email, senha).Equals(false))
                return new BadRequestResult();

            Estudante estudante = await _context.Estudantes.AsNoTracking().FirstOrDefaultAsync(e => e.Email == email);
            _context.Estudantes.Remove(estudante);
            await _context.SaveChangesAsync();
            return new AcceptedResult();
        }

        public async Task<ActionResult<List<string>>> SelecionarTodosEmails() 
        {
            List<string> estudantesEmail = await _context.Estudantes.Select(e => e.Email).ToListAsync();
            return new OkObjectResult(estudantesEmail);
        }

         public async Task<bool> ChecarSeEstudanteExiste(string email)
        {
            Estudante estudante = await _context.Estudantes.FirstOrDefaultAsync(e => e.Email == email);
            return estudante != null;
        }

        public async Task<bool> VerificarSeSenhaECerta(string email, string senha)
        {
            Estudante estudante = _context.Estudantes.FirstOrDefault(e => e.Email == email);

            using (var hmac = new HMACSHA512(estudante.SenhaSalt)) 
            {
                var hashComputado = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
                return hashComputado.SequenceEqual(hashComputado);
            };
        }

    }

}

    

