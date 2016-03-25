using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class SolicitudDetalleText
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
        public double PrecioInicial { get; set; }
        public double PrecioFinal { get; set; }

        public SolicitudDetalleText()
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
            this.PrecioInicial = 0;
            this.PrecioFinal = 0;
        }

        public SolicitudDetalleText(string EleccionDestino, string TipoSolicitudId, string CompaniaId, string CategoriaId, string Origen, string Destino, DateTime FechaInicial, DateTime FechaFinal, int CantidadPersona, int  CantidadNino, int CantidadBebe, double PrecioInicial, double PrecioFinal)
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
            this.PrecioInicial = PrecioInicial;
            this.PrecioFinal = PrecioFinal;
        }

        public DataTable Listado(string Condicion)
        {
            ConexionDB Conexion = new ConexionDB();

            try
            {
                return Conexion.ObtenerDatos("select sd.SolicitudDetalleId, sd.EleccionDestino, s.SolicitudId, ts.Descripcion, cp.Descripcion, ct.Descripcion, sd.Origen, sd.Destino, sd.FechaInicial, sd.FechaFinal, " +
                " sd.cantidadPersona, sd.CantidadNino, sd.CantidadBebe, sd.PrecioInicial, sd.PrecioFinal from SolicitudDetalles sd inner join Solicitudes s on sd.SolicitudId = s.SolicitudId inner join TipoSolicitudes ts on ts.TipoSolicitudId = sd.TipoSolicitudId inner join Companias cp on cp.CompaniaId = sd.CompaniaId " +
                "inner join Categorias ct on ct.CategoriaId = sd.CategoriaId where " + Condicion );
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
