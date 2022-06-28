using Dizimo_CSF.Data;
using Dizimo_CSF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Dizimo_CSF.Controllers
{
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        #region Variáveis
        private readonly ApplicationContext _context;
        #endregion

        #region Construtores
        public PagamentoController(ApplicationContext context)
        {
            _context = context;
        }
        #endregion

        #region
        [HttpPost, Route("/api/AdcionarPagamento")]
        public async Task<ActionResult<PagamentoModel>> AdcionarPagamento(PagamentoModel pagamento)
        {
            string mensagem = "Pagamento Cadastrado";

            _context.Pagamento.Add(pagamento);
            await _context.SaveChangesAsync();

            return Ok(mensagem);
        }
        
        [HttpGet, Route("/api/ListaPagamento")]
        public dynamic ListaPagamentos ()
        {
            var query = from pagamento in _context.Pagamento
                        join dizimista in _context.Dizimista on pagamento.IdDizimista equals dizimista.Id
                        select new
                        {
                            Id = pagamento.Id,
                            IdDizimista = pagamento.IdDizimista,

                            Nome = dizimista.Nome,
                            Valor = pagamento.Valor,
                            DataPagamento = pagamento.DataPagamento
                        };

                        return query;
        }

        [HttpDelete, Route("/api/DeletarPagamento")]
        public async Task<IActionResult> DeletarPagamento(int id)
        {
            string mensagem = "Pagamento Não Encontrado";
            string mensagemOk = "Pagamento Deletado";

            var pagamento = await _context.Pagamento.FindAsync(id);
            if (pagamento == null)
            {
                return NotFound(mensagem);
            }

            _context.Pagamento.Remove(pagamento);
            await _context.SaveChangesAsync();

            return Ok(mensagemOk);
        }

        [HttpPut, Route("/api/AtualizaPagamento")]
        public async Task<ActionResult> EditarPagamento (PagamentoModel pagamento)
        {
            if(!_context.Pagamento.Any(p => p.Id == pagamento.Id))
            {
                return NotFound();
            }

            _context.Entry(pagamento).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(pagamento);
        }
        #endregion
    }
}
