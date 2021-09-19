
using System.Collections.Generic;
using System.Linq;

using Calculadora.Dominio.Entidades;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculadora.Teste.Entidades
{
    [TestClass]
    public class DivisorNaturalTests
    {
        [TestMethod]
        [TestCategory("Dominio")]
        public void Dado_um_numero_deve_calcular_os_fatores_primos()
        {
            var numero = 45;
            var fakeDivisores = new List<long>() { 1, 3, 5 };

            var divisorNatural = new DivisorNatural();
            var fatoresPrimos = divisorNatural.CalcularFatorPrimo(numero).ToList();

            var atual = fatoresPrimos.Distinct().OrderBy(x => x).ToList();

            CollectionAssert.AreEqual(fakeDivisores, atual);
        }

        [TestMethod]
        [TestCategory("Dominio")]
        public void Dado_um_numero_deve_calcular_os_divisores_naturais()
        {
            var numero = 45;
            var fakeDivisores = new List<long>() { 1, 3, 5, 9, 15, 45 };

            var divisorNatural = new DivisorNatural();
            var fatoresPrimos = divisorNatural.CalcularFatorPrimo(numero).ToList();
            var divisores = divisorNatural.CalcularDivisores(fatoresPrimos);

            var atual = divisores.Distinct().OrderBy(x => x).ToList();

            CollectionAssert.AreEqual(fakeDivisores, atual);
        }
    }
}
