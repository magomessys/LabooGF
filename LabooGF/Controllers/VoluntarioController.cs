using LabooGF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabooGF.Controllers
{
    public class VoluntarioController : Controller
    {
        private GFContext db = new GFContext();

        public JsonResult GetVoluntarios()
        {
            var reps = db.Voluntarios
                .Select(x => new ComboDTO { id = x.IdVoluntario.ToString(), value = x.Nome });

            var teste = new JsonResult { Data = reps, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return teste;
        }



        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                ViewBag.Title = "Novo Voluntário";
                ViewBag.Bread2 = "Novo";
                return View("Edit");
            }
            else
            {
                var voluntario = db.Voluntarios.Find(id);

                if (voluntario == null)
                    return HttpNotFound();

                ViewBag.Title = "Editar Voluntário";
                ViewBag.Bread2 = "Editar";
                return View("Edit", voluntario);
            }
        }

        //POST: Responsavel/Edit/?5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Voluntario voluntario)
        {
            // Guarda o Id que entrou para saber se é edição ou inclusão
            var id = voluntario.IdVoluntario;

            if (voluntario.IdVoluntario != 0)
                db.Entry(voluntario).State = EntityState.Modified;
            else
                db.Voluntarios.Add(voluntario);
            db.SaveChanges();

            var msg = id == 0 ? "Voluntário incluido com sucesso!" : "Voluntário alterado com sucesso!";

            return RedirectToAction("Sucesso", new { msg });
        }

        public ActionResult Index()
        {
            var voluntario = db.Voluntarios.OrderBy(r => r.Nome);

            return View(voluntario);
        }

        public ActionResult Sucesso(string msg)
        {
            var voluntarios = db.Voluntarios.OrderBy(r => r.Nome);

            @ViewBag.Sucesso = msg;

            return View("Index", voluntarios);
        }

        public ActionResult Delete(int id)
        {
            var voluntario = db.Voluntarios.Find(id);
            db.Voluntarios.Remove(voluntario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}