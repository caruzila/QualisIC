using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QualisIC.Models
{
    [Table("Area")]
    public class Area
    {

        [Key] public int Area_ID { get; set; }

        public string Area_name { get; set; }

        public List<Extrato>Extratos { get; set; }

    }
}