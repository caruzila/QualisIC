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
            
            ViewBag.filterISSN = vm.searchISSN;
            ViewBag.filterPeriodico = vm.searchPeriodico;
            ViewBag.filterExtrato = vm.searchExtrato;
            ViewBag.filterArea = vm.searchArea;

            var extratos = from e in db.Extratos select e;
            var areaModel = from a in db.Areas select a;

            ViewBag.AreaModel = areaModel.ToList();

            if (!String.IsNullOrEmpty(vm.searchPeriodico))
            {
                ViewBag.CurrentFilter = vm.searchPeriodico;
                extratos = extratos.Where(e => DbFunctions.Like(e.Periodico.Periodico_name.ToUpper(), "%"+vm.searchPeriodico.ToUpper()+"%"));
            }
            
            if (!String.IsNullOrEmpty(vm.searchISSN))
            {
                extratos = extratos.Where(e => e.Periodico.ISSN == vm.searchISSN);
            }
            if (!String.IsNullOrEmpty(vm.searchExtrato))
            {
                extratos = extratos.Where(e => DbFunctions.Like(e.Extrato_nota.ToUpper(), "%" + vm.searchExtrato.ToUpper() + "%"));
            }
            if (vm.searchArea > 0)
            {
                extratos = extratos.Where(e => e.Area.Area_ID == vm.searchArea);
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
            int pageSize = 10;
            int pageNumber = (vm.page ?? 1);
            vm.listap = extratos.ToPagedList(pageNumber, pageSize);
            return View(vm);

        }

        
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Conferencias(ConferenciaViewModel vmc)
        {
            ViewBag.CurrentSort = vmc.sortOrderc;
            ViewBag.ConferenciaSortParm = String.IsNullOrEmpty(vmc.sortOrderc) ? "Conferencia_desc" : "";
            ViewBag.SiglaSortParm = vmc.sortOrderc == "Sigla" ? "Sigla_desc" : "Sigla";
            ViewBag.AreacSortParm = vmc.sortOrderc == "Area" ? "Area_desc" : "Area";
            ViewBag.ExtratocSortParm = vmc.sortOrderc == "Extrato" ? "Extrato_desc" : "Extrato";

            
            ViewBag.filterSigla = vmc.searchSigla;
            ViewBag.filterConferencia = vmc.searchConferencia;
            ViewBag.filterExtratoc = vmc.searchExtratoc;
            ViewBag.filterAreac = vmc.searchAreac;

            var conferencias = from c in db.Conferencias select c;

            ViewBag.AreaModelc = db.Conferencias.Select(x => x.Area_name).Distinct().ToList();
            
            if (!String.IsNullOrEmpty(vmc.searchConferencia))
            {
                
                conferencias = conferencias.Where(c => DbFunctions.Like(c.Conferencia_name, "%" + vmc.searchConferencia.ToUpper() + "%"));
            }

            if (!String.IsNullOrEmpty(vmc.searchSigla))
            {
                conferencias = conferencias.Where(c => c.Sigla == vmc.searchSigla);
            }
            if (!String.IsNullOrEmpty(vmc.searchExtratoc))
            {
                conferencias = conferencias.Where(c => DbFunctions.Like(c.Extrato.ToUpper(), "%" + vmc.searchExtratoc.ToUpper() + "%"));
            }
            if (!String.IsNullOrEmpty(vmc.searchAreac))
            {
                conferencias = conferencias.Where(c => DbFunctions.Like(c.Area_name.ToUpper(), "%" + vmc.searchAreac.ToUpper() + "%"));
            }
            switch (vmc.sortOrderc)
            {
                case "Conferencia_desc":
                    conferencias = conferencias.OrderByDescending(c => c.Conferencia_name);
                    break;
                case "Sigla":
                    conferencias = conferencias.OrderBy(c => c.Sigla);
                    break;
                case "Sigla_desc":
                    conferencias = conferencias.OrderByDescending(c => c.Sigla);
                    break;
                case "Area":
                    conferencias = conferencias.OrderBy(c => c.Area_name);
                    break;
                case "Area_desc":
                    conferencias = conferencias.OrderByDescending(c => c.Area_name);
                    break;
                case "Extrato":
                    conferencias = conferencias.OrderBy(c => c.Extrato);
                    break;
                case "Extrato_desc":
                    conferencias = conferencias.OrderByDescending(c => c.Extrato);
                    break;
                default:
                    conferencias = conferencias.OrderBy(c => c.Conferencia_name);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (vmc.page ?? 1);
            vmc.listac = conferencias.ToPagedList(pageNumber, pageSize);
            return View(vmc);

        }


        public ActionResult Correlacao(CorrelacaoViewModel vm)
        {
            ViewBag.CurrentSort = vm.sortOrder;
            ViewBag.PeriodicoCrSortParm = String.IsNullOrEmpty(vm.sortOrder) ? "Periodico_desc" : "";
            ViewBag.ISSNCrSortParm = vm.sortOrder == "ISSN" ? "ISSN_desc" : "ISSN";
            ViewBag.ExtratoUmSortParm = vm.sortOrder == "Extrato1" ? "Extrato1_desc" : "Extrato1";
            ViewBag.NomeArea2SortParm = vm.sortOrder == "Area" ? "Area_desc" : "Area";
            ViewBag.ExtratoDoisSortParm = vm.sortOrder == "Extrato2" ? "Extrato2_desc" : "Extrato2";

            
            ViewBag.filterPeriodicoCr = vm.searchPeriodico;
            ViewBag.filterISSNCr = vm.searchISSN;
            ViewBag.filterExtratoUm = vm.searchAreaUm;
            ViewBag.filterExtratoDois = vm.searchAreaDois;


            var resultados = from e in db.Extratos
                             join e2 in db.Extratos on e.Periodico_ID equals e2.Periodico_ID
                             where e.Area_ID != e2.Area_ID
                             select new CorrelacaoVM { extrato1 = e, extrato2 = e2 };
            var areaModel = from a in db.Areas orderby a.Area_name select a;

            
            ViewBag.AreaModel = areaModel.ToList();
            
            if (!String.IsNullOrEmpty(vm.searchPeriodico))
            {
                resultados = resultados.Where(e => DbFunctions.Like(e.extrato1.Periodico.Periodico_name.ToUpper(), "%" + vm.searchPeriodico.ToUpper() + "%"));
            }

            if (!String.IsNullOrEmpty(vm.searchISSN))
            {
                resultados = resultados.Where(e => e.extrato1.Periodico.ISSN == vm.searchISSN);
            }
           
            resultados = resultados.Where(e => e.extrato1.Area_ID == vm.searchAreaUm);

            if (vm.searchAreaDois > 0)
            {
                resultados = resultados.Where(e => e.extrato2.Area_ID == vm.searchAreaDois);
            }

            switch (vm.sortOrder)
            {
                case "Periodico_desc":
                    resultados = resultados.OrderByDescending(e => e.extrato1.Periodico.Periodico_name);
                    break;
                case "ISSN":
                    resultados = resultados.OrderBy(e => e.extrato1.Periodico.ISSN);
                    break;
                case "ISSN_desc":
                    resultados = resultados.OrderByDescending(e => e.extrato1.Periodico.ISSN);
                    break;
                case "Area":
                    resultados = resultados.OrderBy(e => e.extrato2.Area.Area_name);
                    break;
                case "Area_desc":
                    resultados = resultados.OrderByDescending(e => e.extrato2.Area.Area_name);
                    break;
                case "Extrato1":
                    resultados = resultados.OrderBy(e => e.extrato1.Extrato_nota);
                    break;
                case "Extrato1_desc":
                    resultados = resultados.OrderByDescending(e => e.extrato2.Extrato_nota);
                    break;
                case "Extrato2":
                    resultados = resultados.OrderBy(e => e.extrato1.Extrato_nota);
                    break;
                case "Extrato2_desc":
                    resultados = resultados.OrderByDescending(e => e.extrato2.Extrato_nota);
                    break;
                default:
                    resultados = resultados.OrderBy(e => e.extrato1.Periodico.Periodico_name);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (vm.page ?? 1);
            vm.listar = resultados.ToPagedList(pageNumber, pageSize);
            return View(vm);

        }
    }
}