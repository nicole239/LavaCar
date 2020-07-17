using LavaCar.Entidades;
using LavaCar.LogicaNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LavaCar.Controllers
{
    public class HomeController : Controller
    {
        private Logica logica = new Logica();

    
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Reporte()
        {
            ViewBag.servicio = new SelectList(logica.ListarServicios(), "ID_Servicio", "Descripción");
            return View(new ReporteServicio());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reporte([Bind(Include = "servicio")] ReporteServicio reporte)
        {
            int idServicio = int.Parse(Request.Form["servicio"].ToString());
            ViewBag.servicio = new SelectList(logica.ListarServicios(), "ID_Servicio", "Descripción");
            return View(logica.ReporteServicio(idServicio));
        }

        public ActionResult AsignarServicio()
        {
            ViewBag.servicio = new SelectList(logica.ListarServicios(), "ID_Servicio", "Descripción");
            return View(new Asignacion());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AsignarServicio([Bind(Include = "Placa,servicio")] Asignacion reporte)
        {
            int idServicio = int.Parse(Request.Form["servicio"].ToString());
            string placa = Request.Form["Placa"].ToString();            
            Asignacion asignacion = logica.AsignarSolucion(placa, idServicio);
            if(asignacion == null)
            {
                return RedirectToAction("Shared/Error");
            }
            ViewBag.servicio = new SelectList(logica.ListarServicios(), "ID_Servicio", "Descripción");
            return View(asignacion);
        }

        }
    }