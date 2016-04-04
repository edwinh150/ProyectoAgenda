using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ReservacionDetalleText
    {
        public string EleccionDestino { get; set; }
        public string TipoSolicitud { get; set; }
        public string Compania { get; set; }
        public string Categoria { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public int CantidadPersona { get; set; }
        public int CantidadNino { get; set; }
        public int CantidadBebe { get; set; }
        public double Precio { get; set; }
        public double Impuesto { get; set; }
        public double Total { get; set; }

        public ReservacionDetalleText()
        {
            this.EleccionDestino = "";
            this.TipoSolicitud = "";
            this.Compania = "";
            this.Categoria = "";
            this.Origen = "";
            this.Destino = "";
            this.FechaInicial = DateTime.Now;
            this.FechaFinal = DateTime.Now;
            this.CantidadPersona = 0;
            this.CantidadNino = 0;
            this.CantidadBebe = 0;
            this.Precio = 0;
            this.Impuesto = 0;
            this.Total = 0;
        }

        public ReservacionDetalleText(string EleccionDestino, string TipoSolicitudId, string CompaniaId, string CategoriaId, string Origen, string Destino, DateTime FechaInicial, DateTime FechaFinal, int CantidadPersona, int CantidadNino, int CantidadBebe, double Precio, double Impuesto, double Total)
        {
            this.EleccionDestino = EleccionDestino;
            this.TipoSolicitud = TipoSolicitudId;
            this.Compania = CompaniaId;
            this.Categoria = CategoriaId;
            this.Origen = Origen;
            this.Destino = Destino;
            this.FechaInicial = FechaInicial;
            this.FechaFinal = FechaFinal;
            this.CantidadPersona = CantidadPersona;
            this.CantidadNino = CantidadNino;
            this.CantidadBebe = CantidadBebe;
            this.Precio = Precio;
            this.Impuesto = Impuesto;
            this.Total = Total;
        }

        public DataTable Listado(string Condicion)
        {
            ConexionDB Conexion = new ConexionDB();

            try
            {
                return Conexion.ObtenerDatos("select rd.EleccionDestino,r.ReservacionId, ts.Descripcion, cp.Descripcion, ct.Descripcion, rd.Origen, rd.Destino, rd.FechaInicial, rd.FechaFinal, " +
                " rd.cantidadPersona, rd.CantidadNino, rd.CantidadBebe, rd.Precio, rd.Impuesto, rd.Total from ReservacionDetalles rd inner join Reservaciones r on rd.ReservacionId = r.ReservacionId inner join TipoSolicitudes ts on ts.TipoSolicitudId = rd.TipoSolicitudId inner join Companias cp on cp.CompaniaId = rd.CompaniaId " +
                "inner join Categorias ct on ct.CategoriaId = rd.CategoriaId where " + Condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
