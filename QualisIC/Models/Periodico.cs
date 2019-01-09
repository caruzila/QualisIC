using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QualisIC.Models
{
    [Table("Periodico")]
    public class Periodico
    {
        [Key] public int Periodico_ID { get; set; }
               
        public string Periodico_name { get; set; }
                
        public string ISSN { get; set; }

        public List<Extrato> Extratos { get; set; }
    }
}