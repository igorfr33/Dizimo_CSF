using Dizimo_CSF.Models;
using FluentValidation;
namespace Dizimo_CSF.Validators

{
    public class PagamentoValidator : AbstractValidator<PagamentoModel>
    {
        public PagamentoValidator ()
        {
            RuleFor(pagamento => pagamento.Valor).NotEmpty();
            RuleFor(pagamento => pagamento.DataPagamento).NotEmpty();
            RuleFor(pagamento => pagamento.IdDizimista).NotEmpty();
        }
    }
}
