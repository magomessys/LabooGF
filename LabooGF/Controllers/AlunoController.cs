using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabooGF.Models;

namespace LabooGF.Controllers
{
    public class AlunoController : Controller
    {
        private GFContext db = new GFContext();

        // GET: Aluno
        public ActionResult Index()
        {
            var alunos = db.Alunos
                        .Include(a => a.Responsavel);

            return View(alunos.ToList());
        }

        // GET: Aluno/Details/5
        public ActionResult Details(int id)
        {
            var aluno = db.Alunos
                        .Include(a => a.Responsavel)
                        .Where(a => a.IdAluno == id).FirstOrDefault();

            if (aluno == null)
                return HttpNotFound();

            return View();
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aluno/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Aluno/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
