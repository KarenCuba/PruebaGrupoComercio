using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppWebBancos.Models;
namespace AppWebBancos.Controllers
{
    public class BancoController : Controller
    {
        //
        // GET: /Banco/
        Banco objBanco = new Banco();
        public ActionResult Index()
        {         
            return View(objBanco.ListarBancos());
        }

        public ActionResult Editar(int id = 0)
        {
            return View(id == 0 ? new Banco() : objBanco.ObtenerPorId(id));
        }
        
        public ActionResult Eliminar(int id = 0)
        {
            return View(id == 0 ? new Banco() : objBanco.ObtenerPorId(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Banco banco)
        {      
            if (ModelState.IsValid)
            {
                if(objBanco.InsertarBanco(banco))
                {
                    ViewBag.Mensaje = "Registrado Satisfactoriamente";   
                }                
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Editar(Banco objBanco)
        {
            if (ModelState.IsValid)
            {
                if (objBanco.ActualizarBanco(objBanco))
                {
                    ViewBag.Mensaje = "Actualizado Satisfactoriamente";   
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Eliminar(Banco objBanco)
        {
            if (ModelState.IsValid)
            {
                if (objBanco.EliminarBanco(objBanco))
                {
                    ViewBag.Mensaje = "Registro Eliminado";
                }
            }
            return RedirectToAction("Index");
        }


    }
}
