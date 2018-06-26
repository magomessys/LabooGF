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

        //GET: Responsavel/
        public ActionResult Index()
        {
            var alunos = db.Alunos
                        .Include(a => a.Responsavel)
                        .OrderBy(a => a.Nome);

            return View(alunos.ToList());
        }

        public ActionResult Detail(int? id)
        {
            ViewBag.Responsaveis = new SelectList(db.Responsaveis, "IdResponsavel", "Nome");

            //INCLUSÃO
            if (id == null)
            {
                ViewBag.Title = "Novo Aluno";
                ViewBag.Bread2 = "Novo";
                return View("Edit");
            }
            //EDIÇÃO
            else
            {   
                var aluno = db.Alunos.Find(id);

                //Se não encontrou o aluno.
                if (aluno == null)
                    return HttpNotFound();

                ViewBag.Title = "Editar Aluno";
                ViewBag.Bread2 = "Editar";
                return View("Edit", aluno);
            }
        }

        //POST: Responsavel/Edit/?5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Aluno aluno)
        {
            // Guarda o Id que entrou para saber se é edição ou inclusão
            var id = aluno.IdAluno;

            if (aluno.IdAluno != 0)
                db.Entry(aluno).State = EntityState.Modified; //Indica Alteração
            else
                db.Alunos.Add(aluno);

            db.SaveChanges();

            //Monta msg de inclusão/alteração.
            var msg = id == 0 ? "Aluno incluido com sucesso!" : "Aluno alterado com sucesso!";

            return RedirectToAction("Sucesso", new { msg });
        }

        public ActionResult Sucesso(string msg)
        {
            var alunos = db.Alunos
            .Include(a => a.Responsavel)
            .OrderBy(a => a.Nome);

            @ViewBag.Sucesso = msg;

            return View("Index", alunos);
        }

        public ActionResult Delete(int id)
        {
            var aluno = db.Alunos.Find(id);

            db.Alunos.Remove(aluno);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
