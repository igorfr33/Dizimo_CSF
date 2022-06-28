using EntityFrameworkCore.EncryptColumn.Attribute;

namespace Dizimo_CSF.Models
{
    public class DizimistaModel
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? DataNascimento { get; set; }
        public string? Rua { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
        [EncryptColumn]
        public string? Cpf { get; set; }
        public string? Cep { get; set;}
        [EncryptColumn]
        public string? Fone { get; set; }
        [EncryptColumn]
        public string? Whatsapp { get; set; }
    }
}
