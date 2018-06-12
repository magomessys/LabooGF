using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabooGF.Controllers
{
    public class ResponsavelController : Controller
    {
        // GET: Responsavel
        public ActionResult Index()
        {
            return View();
        }

        // GET: Responsavel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Responsavel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Responsavel/Create
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

        // GET: Responsavel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Responsavel/Edit/5
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

        // GET: Responsavel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Responsavel/Delete/5
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
