//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LavaCar.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehiculo_Servicio
    {
        public int ID_Vehiculo_Servicio { get; set; }
        public int ID_Servicio { get; set; }
        public int ID_Vehiculo { get; set; }
    
        public virtual Servicios Servicios { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}
