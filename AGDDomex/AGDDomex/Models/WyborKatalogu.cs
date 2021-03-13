using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;
using AGDDomex.Models;

namespace AGDDomex.Models
{
    /// <summary>klasa zawierajaca metode do wyboru produktow z wybranego katalogu</summary>
    public class WyborKatalogu
    {
        /// <summary>metoda zwracajaca krotkę z lista produktow przypisanych do danego katalogu i z nazwa katalogu</summary>
        /// <param name="wszystkieKatalogi">parametr zawierajacy listę wszystkich katalogow produktow w aplikacji</param>
        /// <param name="wszystkieProdukty">parametr zawierajacy listę wszystkich produktow w aplikacji</param>
        /// <param name="idKat">parametr zawierajacy id katalogu produktu z ktorego produkty chcemy pobraa</param>
        public static Tuple<List<Produkt>, String> produktyZKatalogu(List<KatalogProduktow> wszystkieKatalogi, List<Produkt> wszystkieProdukty, int idKat)
        {
            List<Produkt> wybraneProdukty;
            KatalogProduktow tenKatalog = wszystkieKatalogi.Find(x => x.idKatalogu == idKat);
            String nazwaKatalogu = tenKatalog.nazwa;
            wybraneProdukty = wszystkieProdukty.FindAll(x => x.katalogProduktowIdKatalogu == idKat);
            return new Tuple<List<Produkt>, String>(wybraneProdukty, nazwaKatalogu);
        }
    }
}