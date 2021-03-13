using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGDDomex.Models
{
    /// <summary>klasa do tworzenia produktow</summary>
    public class Produkt
    {
        /// <summary>waściwość do przechowywania id katalogu do ktorego przypisany jest produkt</summary>
        public int katalogProduktowIdKatalogu { get; set; }
        /// <summary>waściwość do przechowywania id produktu</summary>
        public int idProduktu { get; set; }
        /// <summary>waściwość do przechowywania nazwy produktu</summary>
        public String nazwa { get; set; }
        /// <summary>waściwość do przecgowywania ceny produktu</summary>
        public float cena { get; set; }
        /// <summary>waściwośc do przechowywania marki produktu</summary>
        public String marka { get; set; }
        /// <summary>waściwość do przechowywania ilosci produktu</summary>
        public int ilosc { get; set; }
        /// <summary>waściwość do przechowywania minimalnej ilosci produktu w sklepie</summary>
        public int minimalnaIloscWSklepie { get; set; }
        /// <summary>waściwość do przechowywania minimalnej ilosci produktu w magazynie</summary>
        public int minimalnaIloscWMagazynie { get; set; }
        /// <summary>waściwość do przechowywania sciezki do zjecia produktu</summary>
        public String zdjecie { get; set; }
        /// <summary>wlasciwosc do przechowywania szczegolowych danych produktu</summary>
        public String szczegoly { get; set; }

        /// <summary>konstruktor inicjalizujacy zmienne produktu</summary>
        /// <param name="idKat">cyfra zawierajace id katalogu do ktorego nalezy produkt</param>
        /// <param name="idP">cyfra zawieraja id produktu</param>
        /// <param name="nazwaP">napis zawierajacy nazwę produktu</param>
        /// <param name="koszt">cyfra zawierajaca cyfrę produktu</param>
        /// <param name="markaK">napis zawierajacy nazwę marki produktu</param>
        /// <param name="ile">cyfra zawierajaca ilosc produktu</param>
        /// <param name="ileMinWSklepie">cyfra zawierajaca minimalna ilosc produktu w sklepie</param>
        /// <param name="ileMinWMagazynie">cyfra zawierajaca minimalna ilosc produktu w magazynie</param>
        /// <param name="zdj">napis zawierajacy sciezke do zdjecia produktu</param>
        /// <param name="szcz">napis zawierjacy szczegolowe informacje o produkcie</param>
        public Produkt(int idKat, int idP, String nazwaP, float koszt, String markaK, int ile, int ileMinWSklepie, int ileMinWMagazynie, String zdj, String szcz)
        {
            katalogProduktowIdKatalogu = idKat;
            idProduktu = idP;
            nazwa = nazwaP;
            cena = koszt;
            marka = markaK;
            ilosc = ile;
            minimalnaIloscWSklepie = ileMinWSklepie;
            minimalnaIloscWMagazynie = ileMinWMagazynie;
            zdjecie = zdj;
            szczegoly = szcz;
        }

        /// <summary>konstruktor inicjalizujacy zmienne domyślnymi wartościami</summary>
        public Produkt()
        {
            katalogProduktowIdKatalogu = 0;
            idProduktu = 0;
            nazwa = "";
            cena = 0;
            marka = "";
            ilosc = 0;
            minimalnaIloscWSklepie = 0;
            minimalnaIloscWMagazynie = 0;
            zdjecie = "";
            szczegoly = "";
        }

        /// <summary>zwraca liczbe: 1, 0 lub -1 mowiaca o tym w jakim stosunku do siebie są porownywane produkty biorac pod uwage ceny tych produktow gdy chcemy sortowac je rosnaco</summary>
        /// <param name="p1">pierwszy porownywany produkt</param>
        /// <param name="p2">drugi porownywany produkt</param>
        public static int rosnaco(Produkt p1, Produkt p2)
        {
            return p1.cena.CompareTo(p2.cena);
        }

        /// <summary>zwraca liczbe: 1, 0 lub -1 mowiaca o tym w jakim stosunku do siebie są porownywane produkty biorac pod uwage ceny tych produktow gdy chcemy sortowac je malejaco</summary>
        /// <param name="p1">pierwszy porownywany produkt</param>
        /// <param name="p2">drugi porownywany produkt</param>
        public static int malejaco(Produkt p1, Produkt p2)
        {
            return rosnaco(p2, p1);
        }
    }
}