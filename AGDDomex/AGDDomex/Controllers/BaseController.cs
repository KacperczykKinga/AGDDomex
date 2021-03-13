using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;
using AGDDomex.Models;

namespace AGDDomex.Controllers
{
    /// <summary>
    ///   <para>klasa po ktrej dziedziczą inne kontrolery w aplikacji, zawiera metodę wykonywaną dla każdego kontrolera w aplikacjij</para>
    /// </summary>
    public class BaseController : Controller
    {
        // GET: Base 
        /// <summary>metoda wykonująca się podczas ladowanie kazdej strony aplikacji, przekazuje do glownego pliku interfejsu informacje o tym ile kosztuja produkty w koszyku zalogowanej osoby</summary>
        /// <param name="filterContext">zawiera informacje o obecnej akcji</param>
        protected override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Produkt>));
            List<Produkt> produkty;
            string fullPath = Request.MapPath(@"~/zserializowane/produkty.xml");
            using (XmlReader reader = XmlReader.Create(fullPath))
            {
                produkty = (List<Produkt>)ser.Deserialize(reader);
            }

            XmlSerializer ser2 = new XmlSerializer(typeof(List<PozycjaKoszyka>));
            List<PozycjaKoszyka> pozycjeKoszykow;
            string fullPath2 = Request.MapPath(@"~/zserializowane/pozycjeKoszykow.xml");
            using (XmlReader reader = XmlReader.Create(fullPath2))
            {
                pozycjeKoszykow = (List<PozycjaKoszyka>)ser2.Deserialize(reader);
            }

            float cena = CenaProduktowWKoszyku.cena(1, produkty, pozycjeKoszykow);
            ViewBag.Koszt = cena;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}