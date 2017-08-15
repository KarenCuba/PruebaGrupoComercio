using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppWebBancos.Models;
namespace AppWebBancos.Controllers
{
    public class OrdenPagoController : Controller
    {
        //
        // GET: /OrdenPago/
        OrdenPago objOrdenPago = new OrdenPago();
        public ActionResult Index()
        {
            return View(objOrdenPago.ListarOrdenPago());
        }

        public ActionResult Editar(int id = 0)
        {
            return View(id == 0 ? new OrdenPago() : objOrdenPago.ObtenerPorId(id));
        }

        public ActionResult Eliminar(int id = 0)
        {
            return View(id == 0 ? new OrdenPago() : objOrdenPago.ObtenerPorId(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(OrdenPago OrdenPago)
        {
            if (ModelState.IsValid)
            {
                if (objOrdenPago.InsertarOrdenPago(OrdenPago))
                {
                    ViewBag.Mensaje = "Registrado Satisfactoriamente";
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Editar(OrdenPago objOrdenPago)
        {
            if (ModelState.IsValid)
            {
                if (objOrdenPago.ActualizarOrdenPago(objOrdenPago))
                {
                    ViewBag.Mensaje = "Actualizado Satisfactoriamente";
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Eliminar(OrdenPago objOrdenPago)
        {
            if (ModelState.IsValid)
            {
                if (objOrdenPago.EliminarOrdenPago(objOrdenPago))
                {
                    ViewBag.Mensaje = "Registro Eliminado";
                }
            }
            return RedirectToAction("Index");
        }


    }
}
