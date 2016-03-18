using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class SolicitudDetalles
    {
        public int EleccionDestino { get; set; }
        public int TipoSolicitudId { get; set; }
        public int CompaniaId { get; set; }
        public int CategoriaId { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public int CantidadPersona { get; set; }
        public int CantidadNino { get; set; }
        public int CantidadBebe { get; set; }
        public double PrecioInicial { get; set; }
        public double PrecioFinal { get; set; }

        public SolicitudDetalles()
        {
            this.EleccionDestino = 0;
            this.TipoSolicitudId = 0;
            this.CompaniaId = 0;
            this.CategoriaId = 0;
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

        public SolicitudDetalles(int EleccionDestino, int TipoSolicitudId, int CompaniaId, int CategoriaId, string Origen, string Destino, DateTime FechaInicial, DateTime FechaFinal, int CantidadPersona, int CantidadNino, int CantidadBebe, double PrecioInicial, double PrecioFinal)
        {
            this.EleccionDestino = EleccionDestino;
            this.TipoSolicitudId = TipoSolicitudId;
            this.CompaniaId = CompaniaId;
            this.CategoriaId = CategoriaId;
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
    }
}
