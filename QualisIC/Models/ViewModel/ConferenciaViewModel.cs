using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QualisIC.Models.ViewModel
{
    public class ConferenciaViewModel
    {
        public string searchSigla { get; set; }

        public string sortOrderc { get; set; }
        public string searchConferencia { get; set; }
        public int? page { get; set; }
        public string searchExtratoc { get; set; }
        public string searchAreac { get; set; }

        public PagedList.IPagedList<QualisIC.Models.Conferencia> listac { get; set; }

    }
}