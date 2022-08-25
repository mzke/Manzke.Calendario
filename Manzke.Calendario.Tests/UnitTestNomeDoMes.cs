namespace Manzke.Calendario.Tests
{
    [TestClass]
    public class UnitTestNomeDoMes
    {
        [TestMethod]
        public void TestNomeDoMes()
        {
            for (int mes = 1; mes <= 12; mes++)
            {
                Assert.AreEqual((new DateTime(1, mes, 1)).ToString("MMMM"), Calendario.NomeDoMes(mes));
            }
            
        }

        [TestMethod]
        public void TestNomeDoMesAbreviado()
        {
            for (int mes = 1; mes <= 12; mes++)
            {
                Assert.AreEqual((new DateTime(1, mes, 1)).ToString("MMM"), Calendario.NomeDoMes(mes, true));
            }

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),"Um número de mês invalido foi permitido.")]
        public void TestMesInvalido()
        {
            var t = Calendario.NomeDoMes(0);
        }
    }
}