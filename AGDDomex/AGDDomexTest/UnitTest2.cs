using System;
using System.Collections.Generic;
using AGDDomex.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//testy dla wybor parametrow
namespace AGDDomexTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestWyboruRodzaji()
        {
            var p1 = new Produkt(1, 1, "Czajnik elektryczny Kassel", 139.99f, "Kassel", 3, 2, 1, "/zdjecia/czajnik_elektryczny_kassel_sza.png", " Pojemność: 1.7 l \n Moc: 2200 W \n Wykonanie: metal, tworzywo sztuczne \n Element grzejny: grzałka płytowa \n Kolor: srebrny / szary");
            var p2 = new Produkt(1, 2, "Czajnik elektryczny Philips", 119.99f, "Philips", 2, 1, 1, "/zdjecia/pobraneXD.png", " Pojemność: 1.5 l \n Moc: 2000 W \n Wykonanie: tworzywo sztuczne \n Element grzejny: grzałka płytowa \n Kolor: srebrny / bordo / czarny");
            var p3 = new Produkt(1, 5, "Czajnik elektryczny Łucznik", 39.99f, "Łucznik", 5, 3, 2, "/zdjecia/ucznik_wk_1800.png", " Pojemność: 1.9 l \n Moc: 2300 W \n Wykonanie: metal, tworzywo sztuczne \n Element grzejny: grzałka płytowa \n Kolor: srebrny / czarny");
            var p4 = new Produkt(1, 6, "Czajnik elektryczny Ariete", 159.99f, "Ariete", 2, 1, 1, "/zdjecia/ariete_286905_vintage_niebiesk.png", " Pojemność: 1.2 l \n Moc: 2400 W \n Wykonanie: metal, tworzywo sztuczne \n Element grzejny: grzałka płytowa \n Kolor: srebrny / niebieski / kremowy");
            var p5 = new Produkt(1, 7, "Ekspres do kawy Philips", 2159.99f, "Philips", 1, 1, 0, "/zdjecia/pobrane__3_.png", " Typ ekspresu: automatyczny \n Dostępne napoje: Americano, Cappuccino, Cortado, Espresso, Espresso Macchiato, Flat White, Gorąca woda, Kawa z mlekiem, Latte Macchiato, Spienione mleko \n Ciśnienie / Moc: 19 barów / 1500 W");

            List<Produkt> listaP = new List<Produkt>();
            listaP.Add(p1);
            listaP.Add(p2);
            listaP.Add(p3);
            listaP.Add(p4);
            listaP.Add(p5);

            Assert.AreEqual(WyborParamterow.wybierzRodzaje(listaP)[0], "Czajnik elektryczny ");
            Assert.AreEqual(WyborParamterow.wybierzRodzaje(listaP)[1], "Ekspres do kawy ");
            Assert.AreEqual(WyborParamterow.wybierzRodzaje(listaP).Count, 2);
        }

        [TestMethod]
        public void TestWyboruRodzajiGraniczny()
        {
            List<Produkt> listaP = new List<Produkt>();
            Assert.AreEqual(WyborParamterow.wybierzRodzaje(listaP).Count, 0);
        }

        [TestMethod]
        public void TestWyboruMarek()
        {
            var p1 = new Produkt(1, 1, "Czajnik elektryczny Kassel", 139.99f, "Kassel", 3, 2, 1, "/zdjecia/czajnik_elektryczny_kassel_sza.png", " Pojemność: 1.7 l \n Moc: 2200 W \n Wykonanie: metal, tworzywo sztuczne \n Element grzejny: grzałka płytowa \n Kolor: srebrny / szary");
            var p2 = new Produkt(1, 2, "Czajnik elektryczny Philips", 119.99f, "Philips", 2, 1, 1, "/zdjecia/pobraneXD.png", " Pojemność: 1.5 l \n Moc: 2000 W \n Wykonanie: tworzywo sztuczne \n Element grzejny: grzałka płytowa \n Kolor: srebrny / bordo / czarny");
            var p3 = new Produkt(1, 5, "Czajnik elektryczny Łucznik", 39.99f, "Łucznik", 5, 3, 2, "/zdjecia/ucznik_wk_1800.png", " Pojemność: 1.9 l \n Moc: 2300 W \n Wykonanie: metal, tworzywo sztuczne \n Element grzejny: grzałka płytowa \n Kolor: srebrny / czarny");

            List<Produkt> listaP = new List<Produkt>();
            listaP.Add(p1);
            listaP.Add(p2);
            listaP.Add(p3);

            Assert.AreEqual(WyborParamterow.wybierzMarki(listaP)[0], "Kassel");
            Assert.AreEqual(WyborParamterow.wybierzMarki(listaP)[1], "Philips");
            Assert.AreEqual(WyborParamterow.wybierzMarki(listaP)[2], "Łucznik");
            Assert.AreEqual(WyborParamterow.wybierzMarki(listaP).Count, 3);
        }

        [TestMethod]
        public void TestWyboruMarekGraniczny()
        {
            List<Produkt> listaP = new List<Produkt>();
            Assert.AreEqual(WyborParamterow.wybierzMarki(listaP).Count, 0);
        }
    }
}
