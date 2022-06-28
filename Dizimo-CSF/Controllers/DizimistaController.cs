using Dizimo_CSF.Data;
using Dizimo_CSF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dizimo_CSF.Controllers
{
    [ApiController]
    public class DizimistaController : ControllerBase
    {
        #region Variáveis
        private readonly ApplicationContext _context;
        #endregion

        #region Construtores
        public DizimistaController(ApplicationContext context)
        {
            _context = context;
        }
        #endregion

        #region
        [HttpPost, Route("/api/AdcionarDizimista")]
        public async Task<ActionResult<DizimistaModel>> AdcionarDizimista(DizimistaModel dizimista)
        {
            string mensagem = "Dizimista Cadastrado";

            _context.Dizimista.Add(dizimista);
            await _context.SaveChangesAsync();

            return Ok(mensagem);
        }

        [HttpGet, Route("/api/ListaDizimista")]
        public async Task<ActionResult<IEnumerable<DizimistaModel>>> ListaHeroi()
        {
            var dizimista = await _context.Dizimista.ToListAsync();
            if (dizimista == null)
            {
                return NoContent();
            }

            return Ok(dizimista);
        }

        [HttpPost, Route("/api/ConsultaDizmista/{id}")]
        public async Task<ActionResult<DizimistaModel>> ConsultaHeroiPeloId(int id)
        {
            string mensagem = "Dizimista não localizado";

            var dizimista = await _context.Dizimista.FindAsync(id);

            if (dizimista == null)
            {
                return NotFound(mensagem);
            }

            return dizimista;
        }

        [HttpDelete, Route("/api/DeletarDizimista")]
        public async Task<IActionResult> DeletarDizimista(int id)
        {
            string mensagem = "Dizimista Não Encontrado";
            string mensagemOk = "Dizimista Deletado";
            var dizimista = await _context.Dizimista.FindAsync(id);
            if (dizimista == null)
            {
                return NotFound(mensagem);
            }
            _context.Dizimista.Remove(dizimista);
            await _context.SaveChangesAsync();

            return Ok(mensagemOk);
        }

        [HttpPut, Route("/api/AtualizaDizimista")]
        public async Task<IActionResult> EditarHeroi(DizimistaModel dizimista)
        {
            if (!_context.Dizimista.Any(e => e.Id == dizimista.Id))
            {
                return NotFound();
            }

            _context.Entry(dizimista).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(dizimista);
        }
        #endregion
    }
}
