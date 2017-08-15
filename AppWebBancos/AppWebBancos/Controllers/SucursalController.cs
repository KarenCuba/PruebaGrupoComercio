using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppWebBancos.Models;
namespace AppWebBancos.Controllers
{
    public class SucursalController : Controller
    {
        //
        // GET: /Sucursal/
        Sucursal objSucursal = new Sucursal();
        Banco objBanco = new Banco();
        public ActionResult Index()
        {
            
            return View(objSucursal.ListarSucursal());
        }



        public ActionResult Editar(int id = 0)
        {
            return View(id == 0 ? new Sucursal() : objSucursal.ObtenerPorId(id));
        }

        public ActionResult Eliminar(int id = 0)
        {
            return View(id == 0 ? new Sucursal() : objSucursal.ObtenerPorId(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ListarSucursalXBanco()
        {
            //ViewBag.Banco = (from c in objBanco.ListarBancos()
            //                 select c.Nombre).Distinct();
            Sucursal model = new Sucursal()
            {
                ListaBanco = new SelectList(objBanco.ListarBancos(), "Id", "Nombre")
            };
            return View(model);
        }


        [HttpPost]
        public ActionResult Create(Sucursal Sucursal)
        {
            if (ModelState.IsValid)
            {
                if (objSucursal.InsertarSucursal(Sucursal))
                {
                    ViewBag.Mensaje = "Registrado Satisfactoriamente";
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Editar(Sucursal objSucursal)
        {
            if (ModelState.IsValid)
            {
                if (objSucursal.ActualizarSucursal(objSucursal))
                {
                    ViewBag.Mensaje = "Actualizado Satisfactoriamente";
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Eliminar(Sucursal objSucursal)
        {
            if (ModelState.IsValid)
            {
                if (objSucursal.EliminarSucursal(objSucursal))
                {
                    ViewBag.Mensaje = "Registro Eliminado";
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ListarSucursalXBanco(int Id)
        {

            ServiceReference1.WebServiceOperacionesBancoClient wsr = new ServiceReference1.WebServiceOperacionesBancoClient();
            ServiceReference1.Sucursal[] arrSucursal = wsr.ObtenerSucursalPorBanco(Id);


            List<Sucursal> lstSucursal = new List<Sucursal>();
           
            foreach (ServiceReference1.Sucursal s in arrSucursal)
            {
                Sucursal objSuc = new Sucursal();
                objSuc.Id = s.Id;
                objSuc.Nombre = s.Nombre;
                objSuc.Direccion = s.Direccion;
                objSuc.FechaRegistro = s.FechaRegistro;
                objSuc.IdBanco = s.IdBanco;
                lstSucursal.Add(objSuc);
            //    List<SelectListItem> item = new List<SelectListItem>{Id = s.Id }
            }

            Sucursal model = new Sucursal()
            {
                ListaBanco = new SelectList(objBanco.ListarBancos(), "Id", "Nombre"),
                lstSucursal = lstSucursal,               
            };


            return View(model);
        }
    }
}
