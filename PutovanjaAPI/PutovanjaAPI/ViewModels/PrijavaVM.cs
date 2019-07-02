using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PutovanjaAPI.ViewModels
{
    public class PrijavaVM
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public int OdredisteId { get; set; }
        public DateTime DatumPolaska { get; set; }
        public DateTime DatumPovratka { get; set; }
    }
}
