using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabooGF.Models;

namespace LabooGF.Controllers
{
    public class HomeController : Controller
    {
        private GFContext db = new GFContext();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string login, string senha)
        {
            var obj = db.Users.Where(a => a.Login.Equals(login) && a.Senha.Equals(senha)).FirstOrDefault();
            if (obj != null)
            {
                Session["UserID"] = obj.IdUser.ToString();
                Session["UserName"] = obj.Login.ToString();
                Session["UserPermissao"] = obj.Permissao != null ? obj.Permissao.ToString() : "";
                return RedirectToAction("Index");
            }
            else
            {
                @ViewBag.Erro = "Usuário/Senha inválido";
            }
            return View(login, senha);
        }



        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult SingOut()
        {
                Session["UserID"] = null;
                Session["UserName"] = null;
                Session["UserPermissao"] = null;
                return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            if (Session["UserID"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}