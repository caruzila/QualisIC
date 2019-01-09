using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QualisIC.Models
{
    [Table("Classificacao")]
    public class Classificacao
    {
        [Key] public int Classificacao_ID { get; set; }

        public string Classificacao_name { get; set; }

        public List<Extrato>Extratos { get; set; }
    }
}