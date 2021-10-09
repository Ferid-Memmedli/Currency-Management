using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ValyutaController : Controller
    {
        public ActionResult Index()
        {
            return View(toDayValute());
        }

        [HttpPost]
        public ActionResult Index(string code, string startDate, string lostDate)
        {
            var start = startDate;
            var lost = lostDate;
            var isDate = DateTime.TryParse(start, out DateTime startDatetime);
            var isDate01 = DateTime.TryParse(lost, out DateTime lostDatetime);

            List<Valute> mezenneIsCode = new List<Valute>();
            if (DateTime.Compare(startDatetime, lostDatetime) < 0)
            {
                TimeSpan araliq = lostDatetime - startDatetime;
                for (int i = 1; i <= araliq.Days; i++)
                {
                    var day = startDatetime.AddDays(i);
                    string convert = day.ToString("dd.MM.yyyy");
                    XDocument xmlDocument = XDocument.Load($"https://www.cbar.az/currencies/{convert}.xml");
                    List<Valute> mezennelerDay = xmlDocument.Descendants("Valute")
                         .Select(a => new Valute
                         {
                             Code = a.Attribute("Code")?.Value,
                             Nominal = a.Element("Nominal")?.Value,
                             Name = a.Element("Name")?.Value,
                             Value = a.Element("Value")?.Value,
                             DateTime = day
                         }).ToList();
                    foreach (var item in mezennelerDay)
                    {
                        if (item.Code == code)
                        {
                            mezenneIsCode.Add(item);
                        }
                    }
                }
            }

            ViewBag.Data = mezenneIsCode;
            return View(toDayValute());
        }

        static ICollection<Valute> toDayValute()
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
            return mezenneler;
        }
    }
}