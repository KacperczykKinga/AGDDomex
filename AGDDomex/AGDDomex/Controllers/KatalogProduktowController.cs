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
    /// <summary>kontroler kontrolujacy widoki ktore zawieraja dane o katalogach produktow</summary>
    public class KatalogProduktowController : BaseController
    {
        // GET: KatalogProduktow
        /// <summary>metoda przekazujaca do odpowiedniego widoku dane o katalogach produktow umieszczonych w zserializowanym pliku i uruchamiajaca odpowiedni widok</summary>
        public ActionResult KatalogProduktow()
        {
            string fullPath = Request.MapPath(@"~/zserializowane/katalogi.xml");
            ViewBag.Katalogi = Dane.dajKatalogi(fullPath);
            return View();
        }
    }
}