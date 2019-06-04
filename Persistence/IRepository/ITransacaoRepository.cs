using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.IRepository
{
    public interface ITransacaoRepository : IBaseRepository<Transacao>
    {
        void AddTransacao(double valorTotal, double valorPago, double troco);
    }
}
