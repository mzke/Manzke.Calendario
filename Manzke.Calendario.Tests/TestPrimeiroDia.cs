using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manzke.Calendario.Tests
{
    [TestClass]
    public class TestPrimeiroDia
    {
        [TestMethod]
        public void Test()
        {
            var esperado = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var result = Calendario.PrimeiroDia(DateTime.Now);
            Assert.AreEqual(esperado, result);
        }

        [TestMethod]
        public void TestNull()
        {
            var esperado = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var result = Calendario.PrimeiroDia(null);
            Assert.AreEqual(esperado, result);
        }

        [TestMethod]
        public void TestInstanciado()
        {
            var esperado = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var calendario = new Calendario(DateTime.Now);
            var result = calendario.PrimeiroDia();
            Assert.AreEqual(esperado, result);
        }

    }
}
