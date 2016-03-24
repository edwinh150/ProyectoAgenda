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
        public int EleccionDestino { get; set; }
        public string TipoSolicitudIdText { get; set; }
        public string CompaniaIdText { get; set; }
        public string CategoriaIdText { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public int CantidadPersonaText { get; set; }
        public int CantidadNinoText { get; set; }
        public int CantidadBebeText { get; set; }
        public double PrecioInicialText { get; set; }
        public double PrecioFinalText { get; set; }

        public SolicitudDetalleText()
        {
            this.EleccionDestino = 0;
            this.TipoSolicitudIdText = "";
            this.CompaniaIdText = "";
            this.CategoriaIdText = "";
            this.Origen = "";
            this.Destino = "";
            this.FechaInicial = DateTime.Now;
            this.FechaFinal = DateTime.Now;
            this.CantidadPersonaText = 0;
            this.CantidadNinoText = 0;
            this.CantidadBebeText = 0;
            this.PrecioInicialText = 0;
            this.PrecioFinalText = 0;
        }

        public SolicitudDetalleText(int EleccionDestino, string TipoSolicitudId, string CompaniaId, string CategoriaId, string Origen, string Destino, DateTime FechaInicial, DateTime FechaFinal, int CantidadPersona, int  CantidadNino, int CantidadBebe, double PrecioInicial, double PrecioFinal)
        {
            this.EleccionDestino = EleccionDestino;
            this.TipoSolicitudIdText = TipoSolicitudId;
            this.CompaniaIdText = CompaniaId;
            this.CategoriaIdText = CategoriaId;
            this.Origen = Origen;
            this.Destino = Destino;
            this.FechaInicial = FechaInicial;
            this.FechaFinal = FechaFinal;
            this.CantidadPersonaText = CantidadPersona;
            this.CantidadNinoText = CantidadNino;
            this.CantidadBebeText = CantidadBebe;
            this.PrecioInicialText = PrecioInicial;
            this.PrecioFinalText = PrecioFinal;
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
