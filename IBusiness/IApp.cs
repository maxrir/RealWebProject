using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface IApp
    {
        string getTroco(double valorTotal,double valorPago);
        void salvarTransacao(double valorTotal, double valorPago, double troco);
    }
}
