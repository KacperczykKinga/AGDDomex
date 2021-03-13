using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AGDDomex.Models;

namespace AGDDomex.Models
{
    /// <summary>klasa posiadająca metodę zwracajacą wybrany produkt</summary>
    public class WyborProduktu
    {
        /// <summary>metoda zwraca produkt ktory zostal wybrany</summary>
        /// <param name="wszystkieProdukty">parametr zawierajacy liste wszystkich produktow w aplikacji</param>
        /// <param name="index">parametr zawierajacy informacje o tym ktory produkt chcemy dostac</param>
        public static Produkt produktWybrany(List<Produkt> wszystkieProdukty, int index)
        {
            Produkt wybranyProdukt = wszystkieProdukty.Find(x => x.idProduktu == index);
            return wybranyProdukt;
        }
    }
}