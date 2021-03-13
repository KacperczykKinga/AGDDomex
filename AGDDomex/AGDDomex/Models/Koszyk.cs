using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGDDomex.Models
{
    /// <summary>klasa do tworzenia koszykow</summary>
    public class Koszyk
    {
        /// <summary>wlasciwosc do przechowywania id koszyka</summary>
        public int idKoszyka { get; set; }

        /// <summary>konstruktor inicjalizujący zmienne koszyka</summary>
        /// /// <param name="idK">liczba zawierająca id koszyka</param>
        public Koszyk(int idK)
        {
            idKoszyka = idK;
        }

        /// <summary>konstruktor inicjalizujacy zmienne domyślnymi wartościami</summary>
        public Koszyk()
        {
            idKoszyka = 0;
        }
    }
}