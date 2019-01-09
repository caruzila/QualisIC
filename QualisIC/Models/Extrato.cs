using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QualisIC.Models
{
    [Table("Extrato")]
    public class Extrato
    {
        [Key] public int Extrato_ID { get; set; }

        public string Extrato_nota { get; set; }

        public int Periodico_ID { get; set; }
        public virtual Periodico Periodico { get; set; }

        public int Area_ID { get; set; }
        public virtual Area Area { get; set; }

        public int Classificacao_ID { get; set; }
        public virtual Classificacao Classificacao { get; set; }
    }
}