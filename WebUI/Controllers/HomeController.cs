using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string dateNow = DateTime.Today.ToString("dd.MM.yyyy");
            XDocument xmlDocument = XDocument.Load($"https://www.cbar.az/currencies/{dateNow}.xml");
            ICollection<Valute> mezenneler = xmlDocument.Descendants("Valute")
                 .Select(a => new Valute
                 {
                     Code = a.Attribute("Code")?.Value,
                     Nominal = a.Element("Nominal")?.Value,
                     Name = a.Element("Name")?.Value,
                     Value = a.Element("Value")?.Value,
                     DateTime = DateTime.Today
                 }).ToList();
            return View(mezenneler);
        }
    }
}