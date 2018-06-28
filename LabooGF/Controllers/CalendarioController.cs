using LabooGF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

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

        public JsonResult GetEvents()
        {
            var events = db.Encontros.ToList();
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult SaveEvent(Encontro e)
        {
            var status = false;
                if (e.IdEncontro > 0)
                {
                    //Update the event
                    var v = db.Encontros.Where(a => a.IdEncontro == e.IdEncontro).FirstOrDefault();
                    if (v != null)
                    {
                        v.Titulo = e.Titulo;
                        v.DtEncontro = e.DtEncontro;
                        v.DtEncontroFim = e.DtEncontroFim;
                        v.Descricao = e.Descricao;
                    }
                }
                else
                {
                    db.Encontros.Add(e);
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