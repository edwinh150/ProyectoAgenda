using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Reservaciones : ClaseMaestra
    {
        public int ReservacionId { get; set; }
        public int UsuarioId { get; set; }
        public int SolicitudId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int EsActivo { get; set; }
        public string Asunto { get; set; }

        public List<ReservacionDetalles> Detalle;

        public List<ReservacionDetalleText> DetalleText;

        public Reservaciones()
        {
            this.ReservacionId = 0;
            this.UsuarioId = 0;
            this.SolicitudId = 0;
            this.FechaCreacion = DateTime.Now;
            this.EsActivo = 0;
            this.Asunto = "";
            Detalle = new List<ReservacionDetalles>();
            DetalleText = new List<ReservacionDetalleText>();
        }

        public void AgregarReservacion(int EleccionDestino, int TipoSolicitudId, int CompaniaId, int CategoriaId, string Origen, string Destino, DateTime FechaInicial, DateTime FechaFinal, int CantidadPersona, int CantidadNino, int CantidadBebe, double Precio, double Impuesto, double Total)
        {
            Detalle.Add(new ReservacionDetalles(EleccionDestino, TipoSolicitudId, CompaniaId, CategoriaId, Origen, Destino, FechaInicial, FechaFinal, CantidadPersona, CantidadNino, CantidadBebe, Precio, Impuesto, Total));
        }

        public void AgregarReservacionText(string EleccionDestino, string TipoSolicitudId, string CompaniaId, string CategoriaId, string Origen, string Destino, DateTime FechaInicial, DateTime FechaFinal, int CantidadPersona, int CantidadNino, int CantidadBebe, double Precio, double Impuesto, double Total)
        {
            DetalleText.Add(new ReservacionDetalleText(EleccionDestino, TipoSolicitudId, CompaniaId, CategoriaId, Origen, Destino, FechaInicial, FechaFinal, CantidadPersona, CantidadNino, CantidadBebe, Precio, Impuesto, Total));
        }

        public override bool Insertar()
        {
            int retorno = 0;
            ConexionDB Conexion = new ConexionDB();
            object Identity;

            try
            {
                Identity = Conexion.ObtenerValor(string.Format("insert into Reservaciones(UsuarioId,SolicitudId,FechaCreacion,EsActivo,Asunto) values({0},{1},'{2}',{3},'{4}') select @@Identity ", this.UsuarioId, this.SolicitudId, this.FechaCreacion.ToString("yyyy-MM-dd hh:mm:ss"), this.EsActivo, this.Asunto));

                int.TryParse(Identity.ToString(), out retorno);

                this.ReservacionId = retorno;

                foreach (ReservacionDetalles item in this.Detalle)
                {
                    if (item.EleccionDestino == 1)
                    {
                        Conexion.Ejecutar(string.Format("insert into ReservacionDetalles(EleccionDestino,ReservacionId,TipoSolicitudId,CompaniaId,CategoriaId,Origen,Destino,FechaInicial,CantidadPersona,CantidadNino,CantidadBebe,Precio,Impuesto,Total) values({0},{1},{2},{3},{4},'{5}','{6}','{7}',{8},{9},{10},{11},{12},{13}) ", (int)item.EleccionDestino, retorno, (int)item.TipoSolicitudId, (int)item.CompaniaId, (int)item.CategoriaId, item.Origen, item.Destino, item.FechaInicial.ToString("yyyy-MM-dd"), (int)item.CantidadPersona, (int)item.CantidadNino, (int)item.CantidadBebe, (double)item.Precio, (double)item.Impuesto,(double)item.Total));
                    }
                    else
                    {
                        Conexion.Ejecutar(string.Format("insert into ReservacionDetalles(EleccionDestino,ReservacionId,TipoSolicitudId,CompaniaId,CategoriaId,Origen,Destino,FechaInicial,FechaFinal,CantidadPersona,CantidadNino,CantidadBebe,Precio,Impuesto,Total) values({0},{1},{2},{3},{4},'{5}','{6}','{7}','{8}','{9}',{10},{11},{12},{13},{14}) ", (int)item.EleccionDestino, retorno, (int)item.TipoSolicitudId, (int)item.CompaniaId, (int)item.CategoriaId, item.Origen, item.Destino, item.FechaInicial.ToString("yyyy-MM-dd"), item.FechaFinal.ToString("yyyy-MM-dd"), (int)item.CantidadPersona, (int)item.CantidadNino, (int)item.CantidadBebe, (double)item.Precio, (double)item.Impuesto, (double)item.Total));
                    }
                }
            }
            catch (Exception)
            {
                retorno = 0;
            }

            return retorno > 0;
        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDB Conexion = new ConexionDB();

            try
            {
                retorno = Conexion.Ejecutar(string.Format("Update Reservaciones set UsuarioId = {0}, SolicitudId = {1}, FechaCreacion = '{2}', EsActivo = {3}, Asunto = '{4}' where ReservacionId = {5}", this.UsuarioId, this.SolicitudId, this.FechaCreacion.ToString("yyyy-MM-dd hh:mm:ss"), this.EsActivo, this.Asunto, this.ReservacionId));

                Conexion.Ejecutar(string.Format("Delete from ReservacionDetalles where ReservacionId = {0}", this.ReservacionId));

                foreach (ReservacionDetalles item in this.Detalle)
                {
                    if (item.EleccionDestino == 1)
                    {
                        Conexion.Ejecutar(string.Format("insert into ReservacionDetalles(EleccionDestino,ReservacionId,TipoSolicitudId,CompaniaId,CategoriaId,Origen,Destino,FechaInicial,CantidadPersona,CantidadNino,CantidadBebe,Precio,Impuesto,Total) values({0},{1},{2},{3},{4},'{5}','{6}','{7}',{8},{9},{10},{11},{12},{13}) ", (int)item.EleccionDestino, this.ReservacionId, (int)item.TipoSolicitudId, (int)item.CompaniaId, (int)item.CategoriaId, item.Origen, item.Destino, item.FechaInicial.ToString("yyyy-MM-dd"), (int)item.CantidadPersona, (int)item.CantidadNino, (int)item.CantidadBebe, (double)item.Precio, (double)item.Impuesto, (double)item.Total));
                    }
                    else
                    {
                        Conexion.Ejecutar(string.Format("insert into ReservacionDetalles(EleccionDestino,ReservacionId,TipoSolicitudId,CompaniaId,CategoriaId,Origen,Destino,FechaInicial,FechaFinal,CantidadPersona,CantidadNino,CantidadBebe,Precio,Impuesto,Total) values({0},{1},{2},{3},{4},'{5}','{6}','{7}','{8}','{9}',{10},{11},{12},{13},{14}) ", (int)item.EleccionDestino, this.ReservacionId, (int)item.TipoSolicitudId, (int)item.CompaniaId, (int)item.CategoriaId, item.Origen, item.Destino, item.FechaInicial.ToString("yyyy-MM-dd"), item.FechaFinal.ToString("yyyy-MM-dd"), (int)item.CantidadPersona, (int)item.CantidadNino, (int)item.CantidadBebe, (double)item.Precio, (double)item.Impuesto, (double)item.Total));
                    }
                }
                retorno = true;
            }
            catch (Exception)
            {
                retorno = false;
            }

            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            ConexionDB Conexion = new ConexionDB();

            try
            {
                retorno = Conexion.Ejecutar(string.Format("Delete from ReservacionDetalles where ReservacionId = {0}", this.ReservacionId));
                retorno = Conexion.Ejecutar(string.Format("Delete from Reservaciones where ReservacionId = {0} ", this.ReservacionId));
            }
            catch (Exception)
            {

                retorno = false;
            }

            return retorno;
        }

        public override bool Buscar(int IdBuscado)
        {
            bool retorno = false;
            DataTable dt = new DataTable();
            DataTable Detalledt = new DataTable();
            ConexionDB Conexion = new ConexionDB();
            string EleccionText = "";
            DateTime FechaFinal = DateTime.Now;

            try
            {
                dt = Conexion.ObtenerDatos(string.Format("select * from Reservaciones where ReservacionId = {0} ", IdBuscado));

                if (dt.Rows.Count > 0)
                {
                    this.ReservacionId = (int)dt.Rows[0]["ReservacionId"];
                    this.UsuarioId = (int)dt.Rows[0]["UsuarioId"];
                    this.SolicitudId = (int)dt.Rows[0]["SolicitudId"];
                    this.FechaCreacion = (DateTime)dt.Rows[0]["FechaCreacion"];
                    this.EsActivo = Seguridad.ValidarBit(dt.Rows[0]["EsActivo"].ToString());
                    this.Asunto = dt.Rows[0]["Asunto"].ToString();
                    retorno = true;
                }

                Detalledt = Conexion.ObtenerDatos(string.Format("select rd.EleccionDestino,r.ReservacionId, ts.Descripcion, cp.Descripcion, ct.Descripcion, rd.Origen, rd.Destino, rd.FechaInicial, rd.FechaFinal, " +
                " rd.cantidadPersona, rd.CantidadNino, rd.CantidadBebe, rd.Precio, rd.Impuesto, rd.Total from ReservacionDetalles rd inner join Reservaciones r on rd.ReservacionId = r.ReservacionId inner join TipoSolicitudes ts on ts.TipoSolicitudId = rd.TipoSolicitudId inner join Companias cp on cp.CompaniaId = rd.CompaniaId " +
                "inner join Categorias ct on ct.CategoriaId = rd.CategoriaId where r.ReservacionId = {0} ", this.ReservacionId));

                if (Detalledt.Rows.Count > 0)
                {
                    foreach (DataRow Dr in Detalledt.Rows)
                    {
                        if (Seguridad.ValidarBit(Dr["EleccionDestino"].ToString()) == 1)
                        {
                            EleccionText = "Solo Ida";
                            FechaFinal = Seguridad.ValidarDateTime("00/00/0000 00:00:00");
                        }

                        if (Seguridad.ValidarBit(Dr["EleccionDestino"].ToString()) == 0)
                        {
                            EleccionText = "Ida/Vuelta";
                            FechaFinal = Seguridad.ValidarDateTime(Dr["FechaFinal"].ToString());
                        }

                        AgregarReservacionText(EleccionText, Dr["Descripcion"].ToString(), Dr["Descripcion1"].ToString(), Dr["Descripcion"].ToString(), Dr["Origen"].ToString(), Dr["Destino"].ToString(), Seguridad.ValidarDateTime(Dr["FechaInicial"].ToString()), FechaFinal, Seguridad.ValidarEntero(Dr["CantidadPersona"].ToString()), Seguridad.ValidarEntero(Dr["CantidadNino"].ToString()), Seguridad.ValidarEntero(Dr["CantidadBebe"].ToString()), Seguridad.ValidarDouble(Dr["Precio"].ToString()), Seguridad.ValidarDouble(Dr["Impuesto"].ToString()), Seguridad.ValidarDouble(Dr["Total"].ToString()));
                    }
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            catch (Exception)
            {
                retorno = false;
            }

            return retorno;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDB Conexion = new ConexionDB();

            try
            {
                return Conexion.ObtenerDatos(string.Format("select " + Campos + " From Reservaciones where " + Condicion + " " + Orden));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
