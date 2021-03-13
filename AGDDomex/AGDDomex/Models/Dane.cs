using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace AGDDomex.Models
{
    /// <summary>
    ///   <para>klasa ktora zawiera metody pobierajace dane z zserializowanych plikow i zapisujace dane do zserializowanych plikow</para>
    /// </summary>
    public class Dane
    {
        /// <summary>metoda ktora zwraca listę katalogow produktow zserializowanych w pliku</summary>
        /// <param name="fullPath">
        ///   <para>parametr zawierający informację o ścieżce do zsrializowanego pliku</para>
        /// </param>
        public static List<KatalogProduktow> dajKatalogi(String fullPath)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<KatalogProduktow>));
            List<KatalogProduktow> katalogi;            
            using (XmlReader reader = XmlReader.Create(fullPath))
            {
                katalogi = (List<KatalogProduktow>)ser.Deserialize(reader);
            }
            return katalogi;
        }

        /// <summary>metoda ktora zwraca listę pozycji koszykow zalogowanej osoby zserializowanych w pliku</summary>
        /// <param name="index">parametr zawierajacy informację o tym</param>
        /// <param name="fullPath">parametr zawierający informację o ścieżce do zsrializowanego pliku</param>
        public static List<PozycjaKoszyka> dajPozycje(int index, String fullPath)
        {
            XmlSerializer ser2 = new XmlSerializer(typeof(List<PozycjaKoszyka>));
            List<PozycjaKoszyka> pozycjeKoszykow;
            using (XmlReader reader = XmlReader.Create(fullPath))
            {
                pozycjeKoszykow = (List<PozycjaKoszyka>)ser2.Deserialize(reader);
            }
            List<PozycjaKoszyka> pozycjeTegoKoszyka = pozycjeKoszykow.FindAll(x => x.KoszykIdKoszyka == index);
            return pozycjeTegoKoszyka;
        }

        /// <summary>metoda, ktora zwraza listę produktow zserializowanych w pliku</summary>
        /// <param name="fullPath">parametr zawierający informację o ścieżce do zsrializowanego pliku</param>
        public static List<Produkt> dajProdukty(String fullPath)
        {
            XmlSerializer ser3 = new XmlSerializer(typeof(List<Produkt>));
            List<Produkt> produkty;
            using (XmlReader reader = XmlReader.Create(fullPath))
            {
                produkty = (List<Produkt>)ser3.Deserialize(reader);
            }
            return produkty;
        }

        /// <summary>metoda serializująca pozycje koszykow do pliku</summary>
        /// <param name="pozycje">parametr zawierający listę pozycji koszykow do zserializowania</param>
        public static void wezPozycje(List<PozycjaKoszyka> pozycje)
        {
            StreamWriter wr2 = new StreamWriter("C:/Users/Kinga/source/repos/AGDDomex/AGDDomex/zserializowane/pozycjeKoszykow.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<PozycjaKoszyka>));
            serializer.Serialize(wr2, pozycje);
            wr2.Flush();
            wr2.Close();
        }
    }
}