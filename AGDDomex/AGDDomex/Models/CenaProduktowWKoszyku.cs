using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGDDomex.Models
{
    /// <summary>klasa zwracajaca cenę wszytskich produktow znajdujacych się w koszyku zalogowanej osoby</summary>
    public class CenaProduktowWKoszyku
    {
        /// <summary>metoda ktora wylicza cenę wszystkich produktow znajdujacych sie na pozycjach koszyka zalogowanej osoby</summary>
        /// <param name="index">parametr zawierajacy informacje o tym z ktorej osoby koszyka dane chcemy pobierać</param>
        /// <param name="wszystkieProdukty">parametr zawierajacy wszystkie produkty aplikacji</param>
        /// <param name="wszystkiePozycjeKoszykow">parametr zawierajacy wszystkie pozycje koszykow aplikacji</param>
        public static float cena(int index, List<Produkt> wszystkieProdukty, List<PozycjaKoszyka> wszystkiePozycjeKoszykow)
        {
            float calkowitaCena = 0;
            List<PozycjaKoszyka> pozycjeTegoKoszyka = wszystkiePozycjeKoszykow.FindAll(x => x.KoszykIdKoszyka == index);
            foreach (PozycjaKoszyka pk in pozycjeTegoKoszyka)
            {
                float cenaJednegoProduktu = wszystkieProdukty.Find(x => x.idProduktu == pk.ProduktIdProduktu).cena;
                calkowitaCena += pk.ilosc * cenaJednegoProduktu;
            }
            return calkowitaCena;

        }
    }
}