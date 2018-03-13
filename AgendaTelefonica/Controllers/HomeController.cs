using AgendaTelefonica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgendaTelefonica.Controllers
{
    public class HomeController : Controller
    {
        private BLL.ContatoBLL _bll;

        public HomeController()
        {
            _bll = new BLL.ContatoBLL();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(Listar());
        }

        public List<Agenda> Listar()
        {
            var lst = _bll.ListarContatos();

            if(lst.Count() < 1)
               lst = new List<Agenda>();          

            return lst;
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Agenda model)
        {
            try
            {
                _bll.Incluir(model);
                ViewBag.msg ="Contato incluído com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Editar(int id)
        {
            var obj = _bll.ObterPorId(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Editar(Agenda model)
        {
            try
            {
                _bll.Alterar(model);
                ViewBag.msg = "Contato alterado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult Excluir(int id)
        {
            try
            {
                var obj = _bll.ObterPorId(id);
                _bll.Excluir(obj);
                ViewBag.msg = "Contato excluído com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Visualizar(int id)
        {
            var obj = _bll.ObterPorId(id);
            return View(obj);
        }
    }
}