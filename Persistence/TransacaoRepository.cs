using Model;
using Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class TransacaoRepository : BaseRepository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(DBCoreContext dbContext)
            : base(dbContext)
        {
            
        }

        public void AddTransacao(double valorTotal, double valorPago, double troco)
        {
            Transacao entity = new Transacao();
            entity.DataHoraTransacao = DateTime.Now;
            entity.ValorPago = valorPago;
            entity.ValorTotal = valorTotal;
            entity.Troco = troco;
            base.Add(entity);
            base.Save();
        }
    }
}
