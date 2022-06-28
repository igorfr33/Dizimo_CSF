using EntityFrameworkCore.EncryptColumn.Attribute;
namespace Dizimo_CSF.Models
{
    public class PagamentoModel
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public int IdDizimista { get; set; }
        public string DataPagamento { get; set; }
    }
}
