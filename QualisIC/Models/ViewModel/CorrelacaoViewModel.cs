using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QualisIC.Models.ViewModel
{
    public class CorrelacaoViewModel
    {
        public string searchISSN { get; set; }
        public string sortOrder { get; set; }
        public string searchPeriodico { get; set; }
        public int? page { get; set; }
        public string searchExtrato { get; set; }
        public int searchAreaUm { get; set; }

        public int searchAreaDois { get; set; }

        public PagedList.IPagedList<CorrelacaoVM> listar { get; set; }

    }
}