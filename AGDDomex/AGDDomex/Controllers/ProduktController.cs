using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;
using AGDDomex.Models;

namespace AGDDomex.Controllers
{
    /// <summary>kontroler kontrolujacy widoki, ktore wyswietlaja dane produktow</summary>
    public class ProduktController : BaseController
    {

        /// <summary>
        /// metoda, ktora pobiera dane z formularza po jego zatwierdzeniu i wybiera oraz przekazuje do widoku produkty z produktow z danego katalogu produktow, te ktore odpowiadaja opcjom zaznaczonym w formularzu, gdy nic z formularza nie jest odznaczone, przekazuje wszystkie dane produktow z katalogu produktu, ponadto przekazuje dane do formularza na podstawie daych produktow znajdujacych sie w wybranym katalogu
        /// </summary>
        /// <param name="index">parametr zawierający informacje o tym z ktorego katalogu produkty chcemy wyswietlac</param>
        public ActionResult jedenKatalog(int index)
        {
            var value1 = Request["xd"];
            var value2 = Request["marki"];
            var value3 = Request["sort"];
            var value4 = Request["cena"];

            ViewBag.Niepoprawne = false;
            float wybranaCena;

            Formularz f = new Formularz(value2, value1, value3, value4);
            String[] wybraneMarki = f.dajMarki();
            String[] wybraneRodzaje = f.dajRodzaje();

            string fullPath = Request.MapPath(@"~/zserializowane/produkty.xml");
            List<Produkt> produkty2 = Dane.dajProdukty(fullPath);
            List<Produkt> produkty3 = f.wybierzMarki(produkty2);
            List<Produkt> produkty = f.wybierzRodzaje(produkty3);

            if (float.TryParse(value4, out wybranaCena))
            {
                produkty = produkty.FindAll(x => x.cena <= wybranaCena);
            }
            else if (value4 != null && value4 != "")
            {
                ViewBag.Niepoprawne = true;
            }
            
            string fullPath2 = Request.MapPath(@"~/zserializowane/katalogi.xml");
            List<KatalogProduktow> katalogi = Dane.dajKatalogi(fullPath2);

            var paramTuple = WyborKatalogu.produktyZKatalogu(katalogi, produkty2, index);
            var paramTuple2 = WyborKatalogu.produktyZKatalogu(katalogi, produkty, index);

            List<Produkt> listaWgSortowania = paramTuple2.Item1;           
            ViewBag.MyTuple = new Tuple<List<Produkt>, String>(f.sortuj(listaWgSortowania), paramTuple.Item2);

            var marki = WyborParamterow.wybierzMarki(paramTuple.Item1);
            ViewBag.Marki = marki;

            var rodzaje = WyborParamterow.wybierzRodzaje(paramTuple.Item1);
            ViewBag.Rodzaje = rodzaje;

            ViewBag.Idk = index;        
            ViewBag.Info = f.dajInfo();
            return View();
        }

        /// <summary>metoda przekazujaca widokowi dane wybranego produktu i opcjonalnie informacje o tym czy produkt udalo sie dodac do koszyka czy tez nie  </summary>
        /// <param name="index">parametr zawierajacy informacje o tym jakiego produktu dane chcemy zobaczyć</param>
        /// <param name="mess">parametr zawierajacy infromacje o tym czy produkt udalo sie dodać do koszyka czyt też nie, domyślnie zawiera wartość null - gdy nie chcieliśmy dodawać produktu do koszyka</param>
        public ActionResult jedenProdukt(int index, String mess)
        {
            string fullPath = Request.MapPath(@"~/zserializowane/produkty.xml");
            List<Produkt> produkty = Dane.dajProdukty(fullPath);

            ViewBag.Produkt = WyborProduktu.produktWybrany(produkty, index);
            ViewBag.NoteFromBasket = mess;
            
            return View();
        }

    }
}