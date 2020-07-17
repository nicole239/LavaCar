using LavaCar.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LavaCar.AccesoDatos
{
    public class AccesoVehiculo
    {        
        public static List<Vehiculo> Listar()
        {
            var db = new LavaCarDBEntities();
            return db.Vehiculo.ToList();
        }

        public static void Crear(Vehiculo vehiculo)
        {
            var db = new LavaCarDBEntities();
            db.Vehiculo.Add(vehiculo);
            db.SaveChanges();

        }

        public static void Editar(Vehiculo vehiculo)
        {
            var db = new LavaCarDBEntities();
            db.Entry(vehiculo).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void Eliminar(int ID_Vehiculo)
        {
            var db = new LavaCarDBEntities();
            db.Database.ExecuteSqlCommand("DELETE FROM Vehiculo WHERE ID_Vehiculo = @id", new SqlParameter("@id", ID_Vehiculo));
            db.SaveChanges();
        }

        public static Vehiculo BuscarID(int? ID_Vehiculo)
        {
            var db = new LavaCarDBEntities();
            return db.Vehiculo.Find(ID_Vehiculo);
        }

        public static Vehiculo BuscarPlaca(string Placa)
        {
            var db = new LavaCarDBEntities();
            return db.Database.SqlQuery<Vehiculo>("Select * FROM Vehiculo WHERE Placa LIKE '%"+Placa+"'").FirstOrDefault();
        }

        public static void AsignarServicio(Vehiculo_Servicio asignacion)
        {
            var db = new LavaCarDBEntities();
            db.Vehiculo_Servicio.Add(asignacion);
            db.SaveChanges();
        }

        public static List<Servicios> ListarServicios(int ID_Vehiculo)
        {
            var db = new LavaCarDBEntities();
            return db.Servicios.SqlQuery("SELECT s.ID_Servicio, s.Descripción, s.Monto  from [Vehiculo-Servicio] vs INNER JOIN Servicios s ON (s.ID_Servicio = vs.ID_Servicio) WHERE ID_Vehiculo = @id",
                new SqlParameter("@id", ID_Vehiculo))
                .ToList<Servicios>();
        }

          

    }
}