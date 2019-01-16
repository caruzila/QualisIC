using QualisIC.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using QualisIC.Models.ViewModel;
using System.Data.Entity;

namespace QualisIC.Controllers
{
    public class HomeController : Controller
    {

        QualisDbContext db;
        public HomeController()
        {
            db = new QualisDbContext();
        }
        public ActionResult Index(PeriodicoViewModel vm)
        {
            ViewBag.CurrentSort = vm.sortOrder;
            ViewBag.PeriodicoSortParm = String.IsNullOrEmpty(vm.sortOrder) ? "Periodico_desc" : "";
            ViewBag.ISSNSortParm = vm.sortOrder == "ISSN" ? "ISSN_desc" : "ISSN";
            ViewBag.AreaSortParm = vm.sortOrder == "Area" ? "Area_desc" : "Area";
            ViewBag.ExtratoSortParm = vm.sortOrder == "Extrato" ? "Extrato_desc" : "Extrato";
            
            ViewBag.CurrentFilter = vm.searchPeriodico;

            var extratos = from e in db.Extratos select e;
            var areaModel = from a in db.Areas select a;

            ViewBag.AreaModel = areaModel.ToList();

            if (!String.IsNullOrEmpty(vm.searchPeriodico))
            {
                //extratos = extratos.Where(e => e.Periodico.Periodico_name.Contains(vm.searchPeriodico));
                extratos = extratos.Where(e => DbFunctions.Like(e.Periodico.Periodico_name.ToUpper(), "%"+vm.searchPeriodico.ToUpper()+"%"));
            }
            if (!String.IsNullOrEmpty(vm.searchISSN))
            {
                extratos = extratos.Where(e => e.Periodico.ISSN == vm.searchISSN);
            }
            if (!String.IsNullOrEmpty(vm.searchExtrato))
            {
                extratos = extratos.Where(e => e.Extrato_nota.Contains(vm.searchExtrato));
            }
            if (!String.IsNullOrEmpty(vm.searchArea))
            {
                extratos = extratos.Where(e => e.Area.Area_name.Contains(vm.searchArea));
            }
            switch (vm.sortOrder)
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
            int pageSize = 2;
            int pageNumber = (vm.page ?? 1);
            vm.lista = extratos.ToPagedList(pageNumber, pageSize);
            return View(vm);

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