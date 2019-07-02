using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PutovanjaAPI.ViewModels
{
    public class StatusVM
    {
        public int PutovanjeId { get; set; }
        public string ImePrezime { get; set; }
        public string Email { get; set; }
        public string Odrediste { get; set; }
        public string DatumPolaska { get; set; }
        public string DatumPovratka { get; set; }
        public bool Odobreno { get; set; }
        public string Hotel { get; set; }
        public string Prevoz { get; set; }
        public bool Dokumentacija { get; set; }
        public bool Osiguranje { get; set; }
        public bool Uplate { get; set; }
    }
}
