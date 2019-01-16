using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QualisIC.Models.ViewModel
{
    public class PeriodicoViewModel
    {

        public string searchISSN { get; set; }

        public string sortOrder { get; set; }
        public string searchPeriodico { get; set; }
        public int? page { get; set; }
        public string searchExtrato { get; set; }
        public string searchArea { get; set; }

        public PagedList.IPagedList<QualisIC.Models.Extrato> lista { get; set; }

    }
}