using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace QualisIC.Models 
{
    public class QualisDbContext : DbContext
    {
    public DbSet<Area> Areas { get; set; }
    public DbSet<Classificacao> Classificacaos { get; set; }
    public DbSet<Conferencia> Conferencias { get; set; }
    public DbSet<Extrato> Extratos { get; set; }
    public DbSet<Periodico> Periodicos { get; set; }
}
}