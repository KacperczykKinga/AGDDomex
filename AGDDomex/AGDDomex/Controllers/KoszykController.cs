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
    /// <summary>
    /// kontroler kontrolujacy widoki ktore zawieraja pozycje koszyka oraz zapewniajacy pelna obsluge koszyka czyli dodawnaie produktu do koszyka, usuwanie produktu, zmniejszanie i zwiekszanie ilosci produktu w koszyku
    /// </summary>
    public class KoszykController : BaseController
    {

        /// <summary>
        /// metoda ktora powoduje przekazanie odpowiedniemu widokowi dane o pozycjach koszyka znajdujacych sie w koszyku zalogowanej osoby, dane kosztow popszczegolnych pozycji koszyka, kosztow wszystkich pozycji koszyka oraz dane o tym, czy ilosc danego produktu w koszyku poprawnie ulegla zwiekszeniu
        /// </summary>
        /// <param name="mess">
        /// parametr zawierajacy informacje o tym czy ilosc produktu w koszyku zostala poprawnie zwiekszona czy tez nie, przyjmuje wartosc null gdy ilosc produktu w koszyku nie probowala byc zwiekszona
        /// </param>
        public ActionResult Koszyk(String mess)
        {           
            string fullPath = Request.MapPath(@"~/zserializowane/pozycjeKoszykow.xml");
            string fullPath3 = Request.MapPath(@"~/zserializowane/produkty.xml");
            string fullPath4 = Request.MapPath(@"~/zserializowane/katalogi.xml");

            List<PozycjaKoszyka> pozycjeKoszykow = Dane.dajPozycje(1, fullPath);
            List<Produkt> produkty = Dane.dajProdukty(fullPath3);
            List<KatalogProduktow> katalogi = Dane.dajKatalogi(fullPath4);

            List<KatalogProduktow> katalogiZKoszyka = new List<KatalogProduktow>();
            List<Produkt> produktyZKoszyka = new List<Produkt>();
            List<float> cenyZKoszyka = new List<float>();
            float sumaCen = 0;
            foreach (PozycjaKoszyka p in pozycjeKoszykow)
            {
                Produkt pr = produkty.Find(x => x.idProduktu == p.ProduktIdProduktu);
                KatalogProduktow kp = katalogi.Find(x => x.idKatalogu == pr.katalogProduktowIdKatalogu);
                float calkCena = p.ilosc * pr.cena;
                produktyZKoszyka.Add(pr);
                katalogiZKoszyka.Add(kp);
                cenyZKoszyka.Add(calkCena);
                sumaCen += calkCena;
            }

            ViewBag.Pozycje = pozycjeKoszykow;
            ViewBag.ProduktyPozycji = produktyZKoszyka;
            ViewBag.KatalogiPozycji = katalogiZKoszyka;
            ViewBag.CenyPozycji = cenyZKoszyka;
            ViewBag.Koszt = sumaCen;
            ViewBag.NoteFromBasket = mess;
            return View();

        }

        /// <summary>
        /// metoda, ktora dodaje do pozycji koszyka zalogowanej osoby produkt o danym indeksie, czyli gdy taki produkt istnieje juz w pozycjach koszyka zalogowanej osoby, zwieksza jego ilosc (o ile odpowiednia liczba produktu znajduje sie w magazynie) lub dodaje nowa popzycje koszyka, przekierowuje do strony produktu, ktory chcielismy dodac wraz z informacja o tym czy produkt zostal pomyslnie dodany do koszyka czy tez bylo go zbyt malo w magazynie
        /// </summary>
        /// <param name="index">parametr z indeksem produktu, ktory chcemy dodac do koszyka</param>
        public ActionResult Add(int index)
        {
            string fullPath = Request.MapPath(@"~/zserializowane/pozycjeKoszykow.xml");
            string fullPath3 = Request.MapPath(@"~/zserializowane/produkty.xml");

            List<PozycjaKoszyka> pozycjeKoszykow = Dane.dajPozycje(1, fullPath);
            List<Produkt> produkty = Dane.dajProdukty(fullPath3);

            PozycjaKoszyka pk0 = pozycjeKoszykow.Find(x => x.ProduktIdProduktu == index);
            if (pk0 == null)
            {
                if (produkty.Find(x => x.idProduktu == index).ilosc >= 1)
                {
                    var pk1 = new PozycjaKoszyka(index, 1, 1);
                    pozycjeKoszykow.Add(pk1);
                    Dane.wezPozycje(pozycjeKoszykow);
                    return RedirectToAction("jedenProdukt", "Produkt", new { @index = index, @mess = "Added" });
                }
                else
                {
                    Dane.wezPozycje(pozycjeKoszykow);
                    return RedirectToAction("jedenProdukt", "Produkt", new { @index = index, @mess = "TooLittle" });
                }
            }
            else
            {
                if (produkty.Find(x => x.idProduktu == index).ilosc >= pk0.ilosc + 1)
                {
                    pk0.ilosc += 1;
                    Dane.wezPozycje(pozycjeKoszykow);
                    return RedirectToAction("jedenProdukt", "Produkt", new { @index = index, @mess = "Added" });
                }
                else
                {
                    Dane.wezPozycje(pozycjeKoszykow);
                    return RedirectToAction("jedenProdukt", "Produkt", new { @index = index, @mess = "TooLittle" });
                }
            }
        }


        /// <summary>
        /// metoda, ktora zwieksza ilosc danego produktu w koszyku zalogowanej osoby (o ile odpowiednia liczba danego produktu znajduje się w magazynie), przekierowuje do widoku koszyka wraz z informacja czy udalo się zwiększyć ilosc danego produktu czy też nie
        /// </summary>
        /// <param name="index">zawiera informację o tym ktrego produktu w pozycjach koszyka zalogowanej osoby ilosc chcemy zwiększyć</param>
        public ActionResult Add2(int index)
        {
            string fullPath = Request.MapPath(@"~/zserializowane/pozycjeKoszykow.xml");
            string fullPath3 = Request.MapPath(@"~/zserializowane/produkty.xml");

            List<PozycjaKoszyka> pozycjeKoszykow = Dane.dajPozycje(1, fullPath);
            List<Produkt> produkty = Dane.dajProdukty(fullPath3);

            PozycjaKoszyka pk0 = pozycjeKoszykow.Find(x => x.ProduktIdProduktu == index);
            
                if (produkty.Find(x => x.idProduktu == index).ilosc >= pk0.ilosc + 1)
                {
                    pk0.ilosc += 1;
                Dane.wezPozycje(pozycjeKoszykow);
                return RedirectToAction("Koszyk", "Koszyk", new { @mess = "Added" });
                }
                else
                {
                Dane.wezPozycje(pozycjeKoszykow);
                return RedirectToAction("Koszyk", "Koszyk", new { @mess = "TooLittle" });
                }
        }


        /// <summary>
        /// metoda, ktora zmniejsza ilosc danego produktu w koszyku zalogowanej osoby lub usuwa daną pozycje koszyka jeśli ilosc produktu tej pozycji jest rowna 0, przekierowuje do widoku koszyka ie
        /// </summary>
        /// <param name="index">zawiera informację o tym ktrego produktu w pozycjach koszyka zalogowanej osoby ilosc chcemy zmniejszyć</param>
        public ActionResult Minus(int index)
        {

            string fullPath = Request.MapPath(@"~/zserializowane/pozycjeKoszykow.xml");
            string fullPath3 = Request.MapPath(@"~/zserializowane/produkty.xml");

            List<PozycjaKoszyka> pozycjeKoszykow = Dane.dajPozycje(1, fullPath);
            List<Produkt> produkty = Dane.dajProdukty(fullPath3);

            PozycjaKoszyka pk0 = pozycjeKoszykow.Find(x => x.ProduktIdProduktu == index);
                if (pk0.ilosc - 1 > 0)
                {
                    pk0.ilosc -= 1;
                Dane.wezPozycje(pozycjeKoszykow);
                return RedirectToAction("Koszyk", "Koszyk");
                }
                else
                {
                pozycjeKoszykow.Remove(pk0);
                Dane.wezPozycje(pozycjeKoszykow);
                return RedirectToAction("Koszyk", "Koszyk");
                }
            

        }

        /// <summary>metoda, ktora usuwa pozycje koszykazalogowanej osoby, ktora zawiera dany produkt</summary>
        /// <param name="index">parametr zaiwerajcy informacje o tym ktory produkt chcemy usunac z pozycji koszyka zalogowanej osoby</param>
        public ActionResult Delete(int index)
        {
            string fullPath = Request.MapPath(@"~/zserializowane/pozycjeKoszykow.xml");
            string fullPath3 = Request.MapPath(@"~/zserializowane/produkty.xml");

            List<PozycjaKoszyka> pozycjeKoszykow = Dane.dajPozycje(1, fullPath);
            List<Produkt> produkty = Dane.dajProdukty(fullPath3);

            PozycjaKoszyka pk0 = pozycjeKoszykow.Find(x => x.ProduktIdProduktu == index);
            pozycjeKoszykow.Remove(pk0);

            Dane.wezPozycje(pozycjeKoszykow);
            return RedirectToAction("Koszyk", "Koszyk");

        }
    }
}