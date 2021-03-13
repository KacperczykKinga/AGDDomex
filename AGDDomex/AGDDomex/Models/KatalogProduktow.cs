using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGDDomex.Models
{
    /// <summary>
    ///   <para>klasa do tworzenia katalogow produktow</para>
    /// </summary>
    public class KatalogProduktow
    {
        /// <summary>wlasciwosc do przechowywania id katalogu produktow</summary>
        public int idKatalogu { get; set; }
        /// <summary>wlasciwosc do przechowywania nazwy katalogu produktow</summary>
        public String nazwa { get; set; }
        /// <summary>wlasciwosc do przechowywania sciezki do obrazu odpowiadajacego katalogowi produktow</summary>
        public String obrazek { get; set; }

        /// <summary>konstruktor inicjalizujący zmienne katalogu produktow</summary>
        /// <param name="nr">liczba zawierająca id katalogu produktow</param>
        /// <param name="nazwaK">napis zawierajacy nazwę katalogu produktow</param>
        /// <param name="obraz">napis zawierajacy ściezke do obrazku odpowiadajacego katalogowi produktow</param>
        public KatalogProduktow(int nr, String nazwaK, String obraz)
        {
            idKatalogu = nr;
            nazwa = nazwaK;
            obrazek = obraz;
        }

        /// <summary>konstruktor inicjalizujacy zmienne domyślnymi wartościami</summary>
        public KatalogProduktow()
        {
            idKatalogu = 0;
            nazwa = "NIC";
            obrazek = "pusty.png";
        }
    }
}