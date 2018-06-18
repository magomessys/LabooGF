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

        // GET: Responsavel
        public ActionResult Index()
        {
            var resp = db.Responsaveis.OrderBy(r => r.Nome);

            return View(resp);
        }

        // GET: Responsavel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var responsavel = db.Responsaveis.Find(id);

            if (responsavel == null)
                return HttpNotFound();

            return View(responsavel);
        }

        // GET: Responsavel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Responsavel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdResponsavel, Nome, Endereço, Email, Telefone")] Responsavel responsavel)
        {
            try
            {
                    db.Responsaveis.Add(responsavel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Responsavel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var responsavel = db.Responsaveis.Find(id);

            if (responsavel == null)
                return HttpNotFound();

            return View(responsavel);
        }

        // POST: Responsavel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdResponsavel, Nome, Endereço, Email, Telefone")] Responsavel responsavel)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(responsavel).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(responsavel);
            }
            catch
            {
                return View();
            }
        }

        // GET: Responsavel/Delete/5
        public ActionResult Delete(int id)
        {
            var resp = db.Responsaveis.Find(id);
            db.Responsaveis.Remove(resp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Responsavel/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here
        //        var resp = db.Responsaveis.Find(id);
        //        db.Responsaveis.Remove(resp);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
