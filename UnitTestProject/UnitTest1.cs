using Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;
using RealWeb.Controllers;
using Xunit.Sdk;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private App injection;
        private const string connection = @"Server=(localdb)\mssqllocaldb;Database=EFDatabase;Trusted_Connection=True;ConnectRetryCount=0";
        public UnitTest1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBCoreContext>();
            optionsBuilder.UseSqlServer(connection);
            var repoInjection = new TransacaoRepository(new DBCoreContext(optionsBuilder.Options));
            injection = new App(repoInjection);
        }

        [TestMethod]
        public void TestMethod1()
        {
            string vTotal = "20";
            string vPago = "20";
            string expected = "0";

            var controller = new OperationController();
            var res = controller.Get(injection, vTotal, vPago);

            Assert.AreEqual(expected, res.Value);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string vTotal = "10,55";
            string vPago = "500.50";
            string expected = "4 nota(s) de R$ 100\n1 nota(s) de R$ 50\n1 nota(s) de R$ 20\n1 nota(s) de R$ 10\n\n19 moeda(s) de 50 centavo(s) \n4 moeda(s) de 10 centavo(s) \n1 moeda(s) de 5 centavo(s) \n";

            var controller = new OperationController();
            var res = controller.Get(injection, vTotal, vPago);

            Assert.AreEqual(expected, res.Value);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string vTotal = "20";
            string vPago = "100";
            string expected = "1 nota(s) de R$ 50\n1 nota(s) de R$ 20\n1 nota(s) de R$ 10\n\n";

            var controller = new OperationController();
            var res = controller.Get(injection, vTotal, vPago);

            Assert.AreEqual(expected, res.Value);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string vTotal = "49";
            string vPago = "200";
            string expected = "1 nota(s) de R$ 100\n1 nota(s) de R$ 50\n\n2 moeda(s) de 50 centavo(s) \n";

            var controller = new OperationController();
            var res = controller.Get(injection, vTotal, vPago);

            Assert.AreEqual(expected, res.Value);
        }
    }
}
