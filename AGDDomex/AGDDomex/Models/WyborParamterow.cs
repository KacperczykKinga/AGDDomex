using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGDDomex.Models
{
    /// <summary>klasa z metodami wybierajacymi parametry do formularza</summary>
    public class WyborParamterow
    {
        /// <summary>metoda zwraca listę nazw marek produkujących produkty będące na liście produktow</summary>
        /// <param name="produktyKatalogu">lista produktow z ktorych nazwy marek chcemy wybrac</param>
        public static List<String> wybierzMarki(List<Produkt> produktyKatalogu)
        {
            List<String> marki = new List<String>();
            foreach (Produkt p in produktyKatalogu)
            {
                if (marki.Find(x => x == p.marka) == null)
                {
                    marki.Add(p.marka);
                }
            }
            return marki;
        }

        /// <summary>metoda zwraca listę nazw rodzajow produktow będących na liście produktow</summary>
        /// <param name="produktyKatalogu">lista produktow z ktorych nazwy rodzajow produktow chcemy wybrac</param>
        public static List<String> wybierzRodzaje(List<Produkt> produktyKatalogu)
        {
            List<String> rodzaje = new List<String>();
            foreach (Produkt p in produktyKatalogu)
            {
                String slowo = p.nazwa.Replace(p.marka, "");
                
                if (rodzaje.Find(x => x == slowo) == null)
                {
                    rodzaje.Add(slowo);
                }
            }
            return rodzaje;
        }
    }
}