using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LavaCar.Entidades
{
    public class ReporteServicio
    {
        public IEnumerable<Vehiculo> vehiculos { get; set; }

        
        public IEnumerable<SelectListItem> servicio { get; set; }

        //public IEnumerable<SelectListItem> id_servicio { get; set; }

        public ReporteServicio()
        {
            vehiculos = new Collection<Vehiculo>();
           
        }




    }
}