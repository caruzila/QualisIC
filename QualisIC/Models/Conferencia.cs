using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QualisIC.Models
{
    [Table("Conferencia")]
    public class Conferencia
    {
        [Key] public int Conferencia_ID { get; set; }

        public string Sigla { get; set; }

        public string Conferencia_name { get; set; }

        public string Extrato { get; set; }
    }
}