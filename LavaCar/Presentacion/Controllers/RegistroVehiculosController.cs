using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LavaCar.Entidades;
using LavaCar.LogicaNegocios;

namespace LavaCar.Presentacion.Controllers
{
    public class RegistroVehiculosController : Controller
    {
        private Logica logica = new Logica();

        // GET: RegistroVehiculos
        public ActionResult Index()
        {
            return View(logica.ListarVehiculos());
        }

        // GET: RegistroVehiculos/Details/5
        public ActionResult Details(int? id)
        {
            Vehiculo vehiculo = logica.VerificarVehiculo(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // GET: RegistroVehiculos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistroVehiculos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Vehiculo,Placa,Dueño,Marca")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                logica.RegistrarVehiculo(vehiculo);
                return RedirectToAction("Index");
            }

            return View(vehiculo);
        }

        // GET: RegistroVehiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            Vehiculo vehiculo = logica.VerificarVehiculo(id);
            if (vehiculo  == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // POST: RegistroVehiculos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Vehiculo,Placa,Dueño,Marca")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                logica.EditarVehiculo(vehiculo);
                return RedirectToAction("Index");
            }
            return View(vehiculo);
        }

        // GET: RegistroVehiculos/Delete/5
        public ActionResult Delete(int? id)
        {
            Vehiculo vehiculo = logica.VerificarVehiculo(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // POST: RegistroVehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            logica.EliminarVehiculo(id);
            return RedirectToAction("Index");
        }

    }
}
