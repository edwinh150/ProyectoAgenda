using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ReservacionDetalles
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
        public double Precio { get; set; }
        public double Impuesto { get; set; }
        public double Total { get; set; }

        public ReservacionDetalles()
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
            this.Precio = 0;
            this.Impuesto = 0;
            this.Total = 0;
        }

        public ReservacionDetalles(int EleccionDestino, int SolicitudId, int CompaniaId, int CategoriaId, string Origen, string Destino, DateTime FechaInicial, DateTime FechaFinal, int CantidadPersona, int CantidadNino, int CantidadBebe, double Precio, double Impuesto, double Total)
        {
            this.EleccionDestino = EleccionDestino;
            this.TipoSolicitudId = SolicitudId;
            this.CompaniaId = CompaniaId;
            this.CategoriaId = CategoriaId;
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
    }
}
