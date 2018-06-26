using LabooGF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LabooGF.Controllers
{
    public class ResponsavelController : Controller
    {
        private GFContext db = new GFContext();

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                ViewBag.Title = "Novo Responsável";
                ViewBag.Bread2 = "Novo";
                return View("Edit");
            }
            else
            {
                var resp = db.Responsaveis.Find(id);

                if (resp == null)
                    return HttpNotFound();

                ViewBag.Title = "Editar Responsável";
                ViewBag.Bread2 = "Editar";
                return View("Edit", resp);
            }
        }

        //POST: Responsavel/Edit/?5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Responsavel resp)
        {
            // Guarda o Id que entrou para saber se é edição ou inclusão
            var id = resp.IdResponsavel;

            if (resp.IdResponsavel != 0)
                db.Entry(resp).State = EntityState.Modified;
            else
                db.Responsaveis.Add(resp);
            db.SaveChanges();
        
            var msg = id == 0 ? "Responsável incluido com sucesso!" : "Responsável alterado com sucesso!";

            return RedirectToAction("Sucesso",new { msg });
        }

        public ActionResult Index()
        {
            var resps = db.Responsaveis.OrderBy(r => r.Nome);

            return View(resps);
        }        
        
        public ActionResult Sucesso(string msg)
        {
            var resps = db.Responsaveis.OrderBy(r => r.Nome);

            @ViewBag.Sucesso = msg;

            return View("Index",resps);
        }

        public ActionResult Delete(int id)
        {
            var resp = db.Responsaveis.Find(id);
            db.Responsaveis.Remove(resp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
