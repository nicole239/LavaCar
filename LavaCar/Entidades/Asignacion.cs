using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace LavaCar.Entidades
{
    public class Asignacion
    {
        public Vehiculo vehiculo { get; set; }
        public IEnumerable<Servicios> servicios { get; set; }

        public Asignacion()
        {
            servicios = new Collection<Servicios>();
        }
    }
}