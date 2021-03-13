using System;
using AGDDomex.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AGDDomexTest
{
    //testy do Formularza
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMarki()
        {
            Formularz f = new Formularz("Bosch,Philips,Łucznik", null, null, null);
            Assert.AreEqual(f.dajMarki()[0], "Bosch");
            Assert.AreEqual(f.dajMarki()[1], "Philips");
            Assert.AreEqual(f.dajMarki()[2], "Łucznik");
            Assert.AreEqual(f.dajMarki().Length, 3);
        }

        [TestMethod]
        public void TestMarkiGraniczny()
        {
            Formularz f = new Formularz(null, null, null, null);
            Assert.AreEqual(f.dajMarki().Length, 0);
        }

        [TestMethod]
        public void TestInfo()
        {
            Formularz f = new Formularz("Bosch,Philips,Łucznik", null, null, "100");
            Assert.AreEqual(f.dajInfo(), "     Wybrane marki: Bosch,Philips,Łucznik     Maks. cena: 100 zł");
        }

        [TestMethod]
        public void TestInfoGraniczny1()
        {
            Formularz f = new Formularz(null, null, null, null);
            Assert.AreEqual(f.dajInfo(), "");
        }

        [TestMethod]
        public void TestInfoGraniczny2()
        {
            Formularz f = new Formularz("Bosch,Philips,Łucznik", "czajnik elektroniczny,toster", "ros", "100");
            Assert.AreEqual(f.dajInfo(), "     Wybrane rodzaje: czajnik elektroniczny,toster     Wybrane marki: Bosch,Philips,Łucznik     Maks. cena: 100 zł Sortowanie: ceny rosnąco");
        }


    }
}
