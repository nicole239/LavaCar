using LavaCar.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LavaCar.AccesoDatos
{
    public class AccesoServicio
    {
       
        public static List<Servicios> Listar()
        {
            var db = new LavaCarDBEntities();
            return db.Servicios.ToList();
        }

        public static void Crear(Servicios servicio)
        {
            var db = new LavaCarDBEntities();
            db.Servicios.Add(servicio);
            db.SaveChanges();
        }

        public static void Editar(Servicios servicio)
        {
            var db = new LavaCarDBEntities();
            db.Entry(servicio).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void Eliminar(Servicios servicio)
        {
            var db = new LavaCarDBEntities();
            db.Servicios.Remove(servicio);
        }

        public static List<Vehiculo> ListarVehiculos(Servicios servicio)
        {
            var db = new LavaCarDBEntities();
            return db.Vehiculo.SqlQuery("SELECT v.ID_Vehiculo, v.Placa, v.Dueño, v.Marca from [Vehiculo-Servicio] vs INNER JOIN Vehiculo v ON (v.ID_Vehiculo = vs.ID_Vehiculo) WHERE vs.ID_Servicio = @id",
                new SqlParameter("@id", servicio.ID_Servicio))
                .ToList<Vehiculo>();
        }
    }
}