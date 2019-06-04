using Business;
using Persistence.IRepository;
using System;

namespace Application
{
    public class App : IApp
    {
        private ITransacaoRepository repo;

        public App(ITransacaoRepository _repo)
        {
            repo = _repo;
        }
        public string getTroco(double valorTotal, double valorPago)
        {
            var notas = new int[] { 100, 50, 20, 10 };
            var moedas = new int[] { 50, 10, 5, 1 };

            var troco = valorPago - valorTotal;

            if (troco <= 0)
                return "0";

            string result = "";
            double valor = 0;
            int count = 0;
            double limite = 9.99;

            valor = troco;
            int i = 0;
            while (valor != 0 && valor > limite)
            {
                count = (int)valor / notas[i]; 
                if (count != 0)
                {
                    result = result + (count + " nota(s) de R$ " + notas[i] + "\n");
                    valor = valor % notas[i];
                }
                i = i + 1;
            }

            result = result + "\n";

            valor = Math.Round(valor * 100);
            i = 0;
            while (valor != 0)
            {
                count = (int)valor / moedas[i];
                if (count != 0)
                {
                    result = result + (count + " moeda(s) de " + moedas[i] + " centavo(s) \n");
                    valor = valor % moedas[i];
                }
                i = i + 1;
            }

            salvarTransacao(valorTotal, valorPago, troco);

            return (result);
        }

        public void salvarTransacao(double valorTotal, double valorPago, double troco)
        {   
            repo.AddTransacao(valorTotal, valorPago, troco);
        }
    }
}
