using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PutovanjaAPI.Models
{
    public class UposlenikOdrediste
    {
        public int Id { get; set; }
        public DateTime DatumPolaska { get; set; }
        public DateTime DatumPovratka { get; set; }
        public bool Odobreno { get; set; }
        public bool Odobravano { get; set; }
        public string Hotel { get; set; }
        public string Prevoz { get; set; }
        public bool Dokumentacija  { get; set; }
        public bool Osiguranje { get; set; }
        public bool Uplate { get; set; }
        public bool Zavrseno { get; set; }
        public bool UposlenikPlaca { get; set; }
        [ForeignKey(nameof(Uposlenik))]
        public int UposlenikId { get; set; }
        public Uposlenik Uposlenik { get; set; }
        [ForeignKey(nameof(Odrediste))]
        public int OdredisteId { get; set; }
        public Odrediste Odrediste { get; set; }
    }
}
