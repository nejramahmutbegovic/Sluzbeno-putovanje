using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;
using PutovanjaAPI.Context;
using PutovanjaAPI.Helpers;
using PutovanjaAPI.Models;
using PutovanjaAPI.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PutovanjaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllCORS")]
    public class PutovanjaController : ControllerBase
    {
        private readonly MojContext _db;
        public PutovanjaController(MojContext db)
        {
            _db = db;
        }
        // GET: api/Putovanja
        [HttpGet]
        public ActionResult<List<StatusVM>> GetPutovanjaNotExamined()
        {
            var putovanja = _db.UposlenikOdrediste.Include(x => x.Uposlenik).Include(x => x.Odrediste)
                .Where(x=>!x.Odobravano).ToList();

            if (putovanja == null || putovanja.Count == 0)
            {
                return NotFound();
            }

            var putovanjaStatus = new List<StatusVM>();
            foreach (var o in putovanja)
            {
                putovanjaStatus.Add(new StatusVM
                {
                    PutovanjeId = o.Id,
                    ImePrezime = o.Uposlenik.Ime + " " + o.Uposlenik.Prezime,
                    Email = o.Uposlenik.Email,
                    DatumPolaska = o.DatumPolaska.ToShortDateString(),
                    DatumPovratka = o.DatumPovratka.ToShortDateString(),
                    Dokumentacija = o.Dokumentacija,
                    Hotel = o.Hotel,
                    Odobreno = o.Odobreno,
                    Odrediste = o.Odrediste.Naziv,
                    Osiguranje = o.Osiguranje,
                    Prevoz = o.Prevoz,
                    Uplate = o.Uplate
                });
            }
            return putovanjaStatus;
        }

        //GET: api/Putovanja/all
        [HttpGet("all")]
        public ActionResult<List<StatusVM>> GetAllPutovanja()
        {
            var putovanja = _db.UposlenikOdrediste.Include(x => x.Uposlenik).Include(x => x.Odrediste).ToList();

            if (putovanja == null || putovanja.Count == 0)
            {
                return NotFound();
            }

            var putovanjaStatus = new List<StatusVM>();
            foreach (var o in putovanja)
            {
                putovanjaStatus.Add(new StatusVM
                {
                    PutovanjeId = o.Id,
                    ImePrezime = o.Uposlenik.Ime + " " + o.Uposlenik.Prezime,
                    Email = o.Uposlenik.Email,
                    DatumPolaska = o.DatumPolaska.ToShortDateString(),
                    DatumPovratka = o.DatumPovratka.ToShortDateString(),
                    Dokumentacija = o.Dokumentacija,
                    Hotel = o.Hotel,
                    Odobreno = o.Odobreno,
                    Odrediste = o.Odrediste.Naziv,
                    Osiguranje = o.Osiguranje,
                    Prevoz = o.Prevoz,
                    Uplate = o.Uplate
                });
            }
            return putovanjaStatus;
        }

        //GET: api/Putovanja/odobrena
        [HttpGet("odobrena")]
        public ActionResult<List<StatusVM>> GetOdobrenaPutovanja()
        {
            var putovanja = _db.UposlenikOdrediste.Include(x => x.Uposlenik).Include(x => x.Odrediste)
                .Where(x=>x.Odobreno && !x.Zavrseno).ToList();

            if (putovanja == null || putovanja.Count == 0)
            {
                return NotFound();
            }

            var putovanjaStatus = new List<StatusVM>();
            foreach (var o in putovanja)
            {
                putovanjaStatus.Add(new StatusVM
                {
                    PutovanjeId = o.Id,
                    ImePrezime = o.Uposlenik.Ime + " " + o.Uposlenik.Prezime,
                    Email = o.Uposlenik.Email,
                    DatumPolaska = o.DatumPolaska.ToShortDateString(),
                    DatumPovratka = o.DatumPovratka.ToShortDateString(),
                    Dokumentacija = o.Dokumentacija,
                    Hotel = o.Hotel,
                    Odobreno = o.Odobreno,
                    Odrediste = o.Odrediste.Naziv,
                    Osiguranje = o.Osiguranje,
                    Prevoz = o.Prevoz,
                    Uplate = o.Uplate
                });
            }
            return putovanjaStatus;
        }

        //GET: api/Putovanja/id
        [HttpGet("{id}")]
        public ActionResult<StatusVM> GetDetailPutovanje(int id)
        {
            var putovanje = _db.UposlenikOdrediste.Include(x=>x.Uposlenik).Include(x=>x.Odrediste).Where(x => x.Id == id).FirstOrDefault();

            if (putovanje == null)
                return BadRequest();

            return new StatusVM
            {
                PutovanjeId = putovanje.Id,
                ImePrezime = putovanje.Uposlenik.Ime + " " + putovanje.Uposlenik.Prezime,
                Email = putovanje.Uposlenik.Email,
                DatumPolaska = putovanje.DatumPolaska.ToShortDateString(),
                DatumPovratka = putovanje.DatumPovratka.ToShortDateString(),
                Dokumentacija = putovanje.Dokumentacija,
                Hotel = putovanje.Hotel,
                Odobreno = putovanje.Odobreno,
                Odrediste = putovanje.Odrediste.Naziv,
                Osiguranje = putovanje.Osiguranje,
                Prevoz = putovanje.Prevoz,
                Uplate = putovanje.Uplate
            };
        }

        //GET: api/Putovanja/Odredista
        [HttpGet("odredista")]
        public ActionResult<List<Odrediste>> GetOdredista()
        {
            var odredista = _db.Odrediste.ToList();

            if (odredista == null || odredista.Count == 0)
            {
                return NotFound();
            }
            return odredista;
        }

        // POST: api/Putovanja
        [HttpPost]
        public ActionResult Post([FromForm] PrijavaVM model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            Uposlenik u = _db.Uposlenik.Where(x => x.Ime == model.Ime && x.Prezime == model.Prezime && x.Email == model.Email).FirstOrDefault();

            if (u == null)
            {
                u = new Uposlenik
                {
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    Email = model.Email
                };
                _db.Uposlenik.Add(u);
            }
            
            UposlenikOdrediste uo = new UposlenikOdrediste
            {
                UposlenikId = u.Id,
                OdredisteId = model.OdredisteId,
                DatumPolaska = model.DatumPolaska,
                DatumPovratka = model.DatumPovratka,
                Odobreno = false
            };
            _db.UposlenikOdrediste.Add(uo);

            _db.SaveChanges();

            var poruka = new TextPart(TextFormat.Html)
            {
                Text = "Vaše službeno putovanje u " + _db.Odrediste.Where(x => x.Id == uo.OdredisteId).FirstOrDefault().Naziv + ", od " + uo.DatumPolaska.ToShortDateString() + " do " + uo.DatumPovratka.ToShortDateString() + " je zakazano i čeka potvrdu."
            };
            EmailHelper.PosaljiEmail(u, "Zakazivanje Službenog putovanja", poruka);

            return Ok("Ok");
        }

        // POST: api/Putovanja/update
        [HttpPost("update")]
        public ActionResult PutovanjaUpdate([FromForm] StatusVM model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            UposlenikOdrediste putovanje = _db.UposlenikOdrediste.Include(x=>x.Odrediste).Where(x => x.Id == model.PutovanjeId).FirstOrDefault();

            if (putovanje == null)
                return BadRequest();

            Uposlenik u = _db.Uposlenik.Where(x => x.Id == putovanje.UposlenikId).FirstOrDefault();

            putovanje.Hotel = model.Hotel;
            putovanje.Prevoz = model.Prevoz;
            putovanje.Dokumentacija = model.Dokumentacija;
            putovanje.Uplate = model.Uplate;
            putovanje.Osiguranje = model.Osiguranje;



            if (putovanje.Hotel != null && putovanje.Prevoz != null && putovanje.Hotel.Count() > 0 && putovanje.Prevoz.Count() > 0 && putovanje.Osiguranje && putovanje.Dokumentacija && putovanje.Uplate)
            {
                putovanje.Zavrseno = true;
                var poruka = new TextPart(TextFormat.Html)
                {
                    Text = "Vaše službeno putovanje u " + putovanje.Odrediste.Naziv + ", od " + putovanje.DatumPolaska.ToShortDateString() + " do " + putovanje.DatumPovratka.ToShortDateString() + " je obrađen te su informacije sljedeće: "
                    + "<br />Hotel: <b>" + putovanje.Hotel + "</b><br />Prevoz: <b>" + putovanje.Prevoz + "</b><br />Smjestaj placen: <b>" + (putovanje.Uplate ? "Da" : "Ne")
                    + "</b><br /><br />Hvala što koristite naše usluge. <i>PutovanjaAPI</i>"

                };
                EmailHelper.PosaljiEmail(u, "Zakazivanje Službenog putovanja", poruka);
            }

            _db.UposlenikOdrediste.Update(putovanje);

            _db.SaveChanges();

            return Ok("Ok");
        }

        // PUT: api/Putovanja/5
        [HttpPost("{id}")]
        public ActionResult UpdatePutovanje(int id, [FromQuery] bool odobri)
        {
            var put = _db.UposlenikOdrediste.Where(x => x.Id == id).FirstOrDefault();
            if (put == null)
                return NotFound("NotFound");
            var u = _db.Uposlenik.Where(x => x.Id == put.UposlenikId).FirstOrDefault();
            put.Odobravano = true;
            put.Odobreno = odobri;
            _db.Update(put);
            _db.SaveChanges();

            var poruka = new TextPart
            {
                Text = "Vaše službeno putovanje u " + _db.Odrediste.Where(x => x.Id == put.OdredisteId).FirstOrDefault().Naziv + ", od " + put.DatumPolaska.ToShortDateString() + " do " + put.DatumPovratka.ToShortDateString() + " je " + (odobri ? "odobreno." : "odbijeno.")

            };
            EmailHelper.PosaljiEmail(u, "Nove obavijesti o službenom putovanju", poruka);
            return Ok("Ok");
        }

        
    }
}
