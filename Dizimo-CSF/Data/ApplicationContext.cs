using Dizimo_CSF.Models;
using EntityFrameworkCore.EncryptColumn;
using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.EntityFrameworkCore;

namespace Dizimo_CSF.Data
{
    public class ApplicationContext : DbContext
    {

        private readonly IEncryptionProvider provider;

        #region Construtores
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Initialize.EncryptionKey = "example_encrypt_key_key1";
            provider = new GenerateEncryptionProvider();
        }
        #endregion

        #region Propriedades Públicas
        //Váriavel com o valor da Model carregando seus atributos
        public DbSet<DizimistaModel> Dizimista { get; set; }
        public DbSet<PagamentoModel> Pagamento { get; set; }
        #endregion

        #region Métodos/Operadores Protegidos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseEncryption(provider);
            modelBuilder.HasDefaultSchema("dizimista");

            
        }
        
        #endregion
    }
}
