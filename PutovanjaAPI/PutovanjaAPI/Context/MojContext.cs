using Microsoft.EntityFrameworkCore;
using PutovanjaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PutovanjaAPI.Context
{
    public class MojContext : DbContext
    {

        public MojContext(DbContextOptions<MojContext> x) : base(x)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Uposlenik> Uposlenik { get; set; }
        public DbSet<Odrediste> Odrediste { get; set; }
        public DbSet<UposlenikOdrediste> UposlenikOdrediste { get; set; }
    }
}
