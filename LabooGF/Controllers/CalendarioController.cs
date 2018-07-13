using LabooGF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace LabooGF.Controllers
{
    public class CalendarioController : Controller
    {
        private GFContext db = new GFContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //Busca os encontros já cadastrados e retorna um JSON.
        public JsonResult GetEvents()
        {
            var events = db.Encontros
                         .Include(x => x.Professor)
                         .Include(x => x.Auxiliar)
                         .Include(x => x.Auxiliar2)
                         .Select(x => new EncontroDTO
            {
                IdEncontro = x.IdEncontro,
                IdProfessor = x.Professor.IdVoluntario,
                IdAuxiliar = x.IdAuxiliar,
                IdAuxiliar2 = x.IdAuxiliar2,
                NoProfessor = x.Professor.Nome,
                NoAuxiliar = x.Auxiliar.Nome,
                NoAuxiliar2 = x.Auxiliar2.Nome,
                DtEncontro = x.DtEncontro,
                DtEncontroFim = x.DtEncontroFim,
                Turma = x.Turma
            });

            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult SaveEvent(EncontroDTO e)
        {
            var status = false;
                if (e.IdEncontro > 0)
                {
                    //Update the event
                    var v = db.Encontros.Where(a => a.IdEncontro == e.IdEncontro).FirstOrDefault();
                    if (v != null)
                    {
                        v.IdProfessor = e.IdProfessor;
                        v.IdAuxiliar = e.IdAuxiliar;
                        v.IdAuxiliar2 = e.IdAuxiliar2;
                        v.Turma = e.Turma;                        
                        v.DtEncontro = DateTime.ParseExact(e.DtIni, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        v.DtEncontroFim = DateTime.ParseExact(e.DtFim, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture); 
                    }
                }
                else
                {
                var encontro = new Encontro
                                {   IdProfessor = e.IdProfessor,
                                    IdAuxiliar = e.IdAuxiliar,
                                    IdAuxiliar2 = e.IdAuxiliar2,
                                    DtEncontro = DateTime.ParseExact(e.DtIni, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                                    DtEncontroFim = DateTime.ParseExact(e.DtFim, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                                    Turma = e.Turma
                                };

                    db.Encontros.Add(encontro);
                }

                db.SaveChanges();
                status = true;

            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            {
                var v = db.Encontros.Where(a => a.IdEncontro == eventID).FirstOrDefault();
                if (v != null)
                {
                    db.Encontros.Remove(v);
                    db.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}