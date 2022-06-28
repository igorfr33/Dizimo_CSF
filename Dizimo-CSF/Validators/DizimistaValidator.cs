using Dizimo_CSF.Models;
using FluentValidation;

namespace Dizimo_CSF.Validators
{
    public class DizimistaValidator : AbstractValidator<DizimistaModel>
    {
        public DizimistaValidator ()
        {
            RuleFor(dizimista => dizimista.Nome).NotEmpty();
            RuleFor(dizimista => dizimista.DataNascimento).NotEmpty();
            RuleFor(dizimista => dizimista.Rua).NotEmpty();
            RuleFor(dizimista => dizimista.Bairro).NotEmpty();
            RuleFor(dizimista => dizimista.Cidade).NotEmpty();
            RuleFor(dizimista => dizimista.Uf).NotEmpty();
            RuleFor(dizimista => dizimista.Cpf).NotEmpty();
            RuleFor(dizimista => dizimista.Cep).NotEmpty();
            RuleFor(dizimista => dizimista.Fone).NotEmpty();
            RuleFor(dizimista => dizimista.Whatsapp).NotEmpty();
        }
    }

}