using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGDDomex.Models
{
    /// <summary>klasa do obslugi formularza</summary>
    public class Formularz
    {
        /// <summary>zmienna do przechowywania napisu z wybranymi markami po przecinku</summary>
        String marki;
        /// <summary>zmienna do przechowywania napisu z wybranymi rodzajami produktow po przecinku</summary>
        String rodzaje;
        /// <summary>zmienna do przechowywania napisu informujacego o tym czy i jak posortowac liste produktow</summary>
        String sort;
        /// <summary>zmienna do przechowywania napisu informujacego o maksymalnej cenie produktow na liscie</summary>
        String cena;

        /// <summary>konstruktor inicjalizujący zmienne formularza</summary>
        /// <param name="m">napis zaiwerający wybrane marki wypisane po przecinku</param>
        /// <param name="r">napis zaiwerający wybrane rodzaje produktow wypisane po przecinku</param>
        /// <param name="s">napis zawierajacy informacje o tym czy i jak sortowac listę produktow</param>
        /// <param name="c">napis zawierajacy informacje o maksymalnej cenie produktow na liscie</param>
        public Formularz(String m, String r, String s, String c)
        {
            marki = m;
            rodzaje = r;
            sort = s;
            cena = c;
        }

        /// <summary>metoda zwracająca tablicę Stringow zawierającą wybrane w formularzu marki</summary>
        public String[] dajMarki()
        {
            String[] wybraneMarki = new String[0];
            
            if (marki != null)
            {
                wybraneMarki = marki.Split(',');
            }
            return wybraneMarki;
        }

        /// <summary>metoda zwracająca tablicę Stringow zawierającą wybrane w formularzu rodzaje produktow</summary>
        public String[] dajRodzaje()
        {
            String[] wybraneRodzaje = new String[0];

            if (rodzaje != null)
            {
                wybraneRodzaje = rodzaje.Split(',');
            }

            return wybraneRodzaje;
        }

        /// <summary>metoda zwracająca listę produktow, ktore są produkowane przez marki wybrane w formularzu</summary>
        /// <param name="produkty2">parametr zawierajacy listę produktow z ktorych chcemy wybrac te, ktore są produkowane przez wybrane w formularzy marki</param>
        public List<Produkt> wybierzMarki(List<Produkt> produkty2)
        {
            List<Produkt> produkty3 = new List<Produkt>();

            if (marki != null)
            {
                foreach (Produkt p in produkty2)
                {
                    if (dajMarki().Contains(p.marka))
                    {
                        produkty3.Add(p);
                    }
                }
            }
            else
            {
                produkty3 = produkty2;
            }
            return produkty3;
        }

        /// <summary>metoda zwracająca listę produktow, ktore nalezą do rodzajów wybranych w formularzu</summary>
        /// <param name="produkty3">parametr zawierajacy listę produktow z ktorych chcemy wybrac te, ktore należą do rodzajow wybranych w formularzu</param>
        public List<Produkt> wybierzRodzaje(List<Produkt> produkty3)
        {
            List<Produkt> produkty = new List<Produkt>();

            if (rodzaje != null)
            {
                foreach (Produkt p in produkty3)
                {
                    String slowo = p.nazwa.Replace(p.marka, "");

                    if (dajRodzaje().Contains(slowo))
                    {
                        produkty.Add(p);
                    }
                }
            }
            else
            {
                produkty = produkty3;
            }

            return produkty;
        }

        /// <summary>metoda zwracajaca listę produktow posortowana w odpowiedni wybrany w formularzu sposob</summary>
        /// <param name="listaWgSortowania">parametr zawierajacy listę produktow ktore chcemy posortowac</param>
        public List<Produkt> sortuj(List<Produkt> listaWgSortowania)
        {
            if (sort == "ros")
            {
                listaWgSortowania.Sort(Produkt.rosnaco);
            }
            else if (sort == "mal")
            {
                listaWgSortowania.Sort(Produkt.malejaco);
            }
            return listaWgSortowania;
        }

        /// <summary>metoda zwracająca napis informujacy o tym jakie wartości wybrano w formularzu</summary>
        public string dajInfo()
        {
            String inf = "";
            if (rodzaje != null)
            {
                inf += "     Wybrane rodzaje: " + rodzaje;
            }
            if (marki != null)
            {
                inf += "     Wybrane marki: " + marki;
            }
            if (cena != null && cena != "" && cena.Length > 0)
            {
                inf += "     Maks. cena: " + cena + " zł";
            }
            if (sort == "ros")
            {
                inf += " Sortowanie: ceny rosnąco";
            }
            if (sort == "mal")
            {
                inf += " Sortowanie: ceny malejąco";
            }
            return inf;
        }
    }
}