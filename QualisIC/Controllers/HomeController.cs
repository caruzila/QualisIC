using QualisIC.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web.Mvc;


namespace QualisIC.Controllers
{
    public class HomeController : Controller
    {

        QualisDbContext db;
        public HomeController()
        {
            db = new QualisDbContext();
        }
        public ActionResult Index(string sortOrder)
        {
            ViewBag.PeriodicoSortParm = String.IsNullOrEmpty(sortOrder) ? "Periodico_desc" : "";
            ViewBag.ISSNSortParm = sortOrder == "ISSN" ? "ISSN_desc" : "ISSN";
            ViewBag.AreaSortParm = sortOrder == "Area" ? "Area_desc" : "Area";
            ViewBag.ExtratoSortParm = sortOrder == "Extrato" ? "Extrato_desc" : "Extrato";

            var extratos = from e in db.Extratos select e;
           switch (sortOrder)
            {
                case "Periodico_desc":
                    extratos = extratos.OrderByDescending(e => e.Periodico.Periodico_name);
                    break;
                case "ISSN":
                    extratos = extratos.OrderBy(e => e.Periodico.ISSN);
                    break;
                case "ISSN_desc":
                    extratos = extratos.OrderByDescending(e => e.Periodico.ISSN);
                    break;
                case "Area":
                    extratos = extratos.OrderBy(e => e.Area.Area_name);
                    break;
                case "Area_desc":
                    extratos = extratos.OrderByDescending(e => e.Area.Area_name);
                    break;
                case "Extrato":
                    extratos = extratos.OrderBy(e => e.Extrato_nota);
                    break;
                case "Extrato_desc":
                    extratos = extratos.OrderByDescending(e => e.Extrato_nota);
                    break;
                default:
                    extratos = extratos.OrderBy(e => e.Periodico.Periodico_name);
                    break;
            }
            return View(extratos.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Conferencias()
        {
            var conferencias = db.Conferencias.ToList();
            return View(conferencias);
        }


        public ActionResult Correlacao()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}