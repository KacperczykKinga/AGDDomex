using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGDDomex.Models
{
    /// <summary>klasa do tworzenia pozycji koszyka</summary>
    public class PozycjaKoszyka
    {
        /// <summary>waściwość do przechowywania id produktu ktorego pozycja koszyka dotyczy</summary>
        public int ProduktIdProduktu { get; set; }
        /// <summary>waściwość do przechowywania id koszyka ktorego pozycja koszyka dotyczy</summary>
        public int KoszykIdKoszyka { get; set; }
        /// <summary>waściwośc do przechowywania ilosci produktu w pozycji koszyka</summary>
        public int ilosc { get; set; }

        /// <summary>konstruktor inicjalizujący zmienne pozycji koszyka</summary>
        /// <param name="idP">cyfra zawierajaca id produktu ktorego dotyczy pozycja koszyka</param>
        /// <param name="idK">cyfra zawierajaca id koszyka ktorego dotyczy pozycja koszyka</param>
        /// <param name="ile">cyfra zawierajaca ilosc produktu w pozycji koszyka</param>
        public PozycjaKoszyka(int idP, int idK, int ile)
        {
            ProduktIdProduktu = idP;
            KoszykIdKoszyka = idK;
            ilosc = ile;
        }

        /// <summary>konstruktor inicjalizujacy zmienne domyślnymi wartościami</summary>
        public PozycjaKoszyka()
        {
            ProduktIdProduktu = 0;
            KoszykIdKoszyka = 0;
            ilosc = 0;
        }
    }
}