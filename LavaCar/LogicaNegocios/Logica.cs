using LavaCar.AccesoDatos;
using LavaCar.Entidades;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace LavaCar.LogicaNegocios
{
    public class Logica
    {

        public void RegistrarVehiculo(Vehiculo vehiculo)
        {
            AccesoVehiculo.Crear(vehiculo);
        }

        public Asignacion AsignarSolucion(string placa, int ID_Servicio)
        {
            Vehiculo vehiculo = AccesoVehiculo.BuscarPlaca(placa);
            Asignacion asignacion = new Asignacion();
            if (vehiculo != null)
            {
                var registro = new Vehiculo_Servicio();
                registro.ID_Servicio = ID_Servicio;
                registro.ID_Vehiculo = vehiculo.ID_Vehiculo;
                AccesoVehiculo.AsignarServicio(registro);
                            
                asignacion.vehiculo = vehiculo;
                asignacion.servicios = AccesoVehiculo.ListarServicios(vehiculo.ID_Vehiculo);
                
            }
            return asignacion;
        }

        public ReporteServicio ReporteServicio(int ID_Servicio)
        {           
            ReporteServicio reporte = new ReporteServicio();
            Servicios servicio = new Servicios();
            servicio.ID_Servicio = ID_Servicio;
            reporte.vehiculos = AccesoServicio.ListarVehiculos(servicio);
            return reporte;
        }

        public List<Vehiculo> ListarVehiculos()
        {
            return AccesoVehiculo.Listar();
        }

        public void EditarVehiculo(Vehiculo vehiculo)
        {

            AccesoVehiculo.Editar(vehiculo);
        }

        public Vehiculo VerificarVehiculo(int? ID_Vehiculo)
        {
            if (ID_Vehiculo == null)
            {
                return null;
            }
            return AccesoVehiculo.BuscarID(ID_Vehiculo);
        }

        public void EliminarVehiculo(int ID_Vehiculo)
        {
            AccesoVehiculo.Eliminar(ID_Vehiculo);
        }



        public List<Servicios> ListarServicios()
        {
            return AccesoServicio.Listar();
        }
    }
}