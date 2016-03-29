using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Solicitudes : ClaseMaestra
    {
        public int SolicitudId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Asunto { get; set; }

        public List<SolicitudDetalles> Detalle;

        public List<SolicitudDetalleText> DetalleText;

        public Solicitudes()
        {
            this.SolicitudId = 0;
            this.UsuarioId = 0;
            this.FechaCreacion = DateTime.Now;
            this.Asunto = "";
            Detalle = new List<SolicitudDetalles>();
            DetalleText = new List<SolicitudDetalleText>();
        }

        public void AgregarSolicitud(int EleccionDestino, int TipoSolicitudId, int CompaniaId, int CategoriaId, string Origen, string Destino, DateTime FechaInicial, DateTime FechaFinal, int CantidadPersona, int CantidadNino, int CantidadBebe, double PrecioInicial, double PrecioFinal)
        {
            Detalle.Add(new SolicitudDetalles(EleccionDestino, TipoSolicitudId, CompaniaId, CategoriaId, Origen, Destino, FechaInicial, FechaFinal, CantidadPersona, CantidadNino, CantidadBebe, PrecioInicial, PrecioFinal));
        }

        public void AgregarSolicitudText(string EleccionDestino, string TipoSolicitudId, string CompaniaId, string CategoriaId, string Origen, string Destino, DateTime FechaInicial, DateTime FechaFinal, int CantidadPersona, int CantidadNino, int CantidadBebe, double PrecioInicial, double PrecioFinal)
        {
            DetalleText.Add(new SolicitudDetalleText(EleccionDestino, TipoSolicitudId, CompaniaId, CategoriaId, Origen, Destino, FechaInicial, FechaFinal, CantidadPersona, CantidadNino, CantidadBebe, PrecioInicial, PrecioFinal));
        }

        public override bool Insertar()
        {
            int retorno = 0;
            ConexionDB Conexion = new ConexionDB();
            object Identity;

            try
            {
                Identity = Conexion.ObtenerValor(string.Format("insert into Solicitudes(UsuarioId,FechaCreacion,Asunto) values({0},'{1}','{2}') select @@Identity ", this.UsuarioId, this.FechaCreacion.ToString("yyyy-MM-dd hh:mm:ss"), this.Asunto));

                int.TryParse(Identity.ToString(), out retorno);

                this.SolicitudId = retorno;

                foreach (SolicitudDetalles item in this.Detalle)
                {
                    Conexion.Ejecutar(string.Format("insert into SolicitudDetalles(EleccionDestino,SolicitudId,TipoSolicitudId,CompaniaId,CategoriaId,Origen,Destino,FechaInicial,FechaFinal,CantidadPersona,CantidadNino,CantidadBebe,PrecioInicial,PrecioFinal) values({0},{1},{2},{3},{4},'{5}','{6}','{7}','{8}','{9}',{10},{11},{12},{13}) ", (int)item.EleccionDestino, retorno, (int)item.TipoSolicitudId, (int)item.CompaniaId, (int)item.CategoriaId, item.Origen, item.Destino, item.FechaInicial.ToString("yyyy-MM-dd"), item.FechaFinal.ToString("yyyy-MM-dd"), (int)item.CantidadPersona, (int)item.CantidadNino, (int)item.CantidadBebe, (double)item.PrecioInicial, (double)item.PrecioFinal));
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
                retorno = Conexion.Ejecutar(string.Format("Update Solicitudes set UsuarioId = {0}, FechaCreacion = '{1}', Asunto = '{2}' where SolicitudId = {3}", this.UsuarioId, this.FechaCreacion.ToString("yyyy-MM-dd hh:mm:ss"), this.Asunto, this.SolicitudId));

                Conexion.Ejecutar(string.Format("Delete from SolicitudDetalles where SolicitudId = {0}", this.SolicitudId));

                foreach (SolicitudDetalles item in this.Detalle)
                {
                    Conexion.Ejecutar(string.Format("insert into SolicitudDetalles(EleccionDestino,SolicitudId,TipoSolicitudId,CompaniaId,CategoriaId,Origen,Destino,FechaInicial,FechaFinal,CantidadPersona,CantidadNino,CantidadBebe,PrecioInicial,PrecioFinal) values({0},{1},{2},{3},{4},'{5}','{6}','{7}','{8}','{9}',{10},{11},{12},{13}) ", (int)item.EleccionDestino, retorno, (int)item.TipoSolicitudId, (int)item.CompaniaId, (int)item.CategoriaId, item.Origen, item.Destino, item.FechaInicial.ToString("yyyy-MM-dd"), item.FechaFinal.ToString("yyyy-MM-dd"), (int)item.CantidadPersona, (int)item.CantidadNino, (int)item.CantidadBebe, (double)item.PrecioInicial, (double)item.PrecioFinal));
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
                retorno = Conexion.Ejecutar(string.Format("Delete from SolicitudDetalles where SolicitudId = {0}", this.SolicitudId));
                retorno = Conexion.Ejecutar(string.Format("Delete from Solicitudes where SolicitudId = {0} ", this.SolicitudId));
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

            try
            {
                dt = Conexion.ObtenerDatos(string.Format("select * from Solicitudes where SolicitudId = {0} ", IdBuscado));

                if (dt.Rows.Count > 0)
                {
                    this.SolicitudId = (int)dt.Rows[0]["SolicitudId"];
                    this.UsuarioId = (int)dt.Rows[0]["UsuarioId"];
                    this.FechaCreacion = (DateTime)dt.Rows[0]["FechaCreacion"];
                    this.Asunto = dt.Rows[0]["Asunto"].ToString();
                    retorno = true;
                }

                Detalledt = Conexion.ObtenerDatos(string.Format("select sd.EleccionDestino,s.SolicitudId, ts.Descripcion, cp.Descripcion, ct.Descripcion, sd.Origen, sd.Destino, sd.FechaInicial, sd.FechaFinal, " +
                " sd.cantidadPersona, sd.CantidadNino, sd.CantidadBebe, sd.PrecioInicial, sd.PrecioFinal from SolicitudDetalles sd inner join Solicitudes s on sd.SolicitudId = s.SolicitudId inner join TipoSolicitudes ts on ts.TipoSolicitudId = sd.TipoSolicitudId inner join Companias cp on cp.CompaniaId = sd.CompaniaId " +
                "inner join Categorias ct on ct.CategoriaId = sd.CategoriaId where s.SolicitudId = {0} ", this.SolicitudId));

                if (Detalledt.Rows.Count > 0)
                {
                    foreach (DataRow Dr in Detalledt.Rows)
                    {
                        if (Seguridad.ValidarBit(Dr["EleccionDestino"].ToString()) == 0)
                        {
                            EleccionText = "Solo Ida";
                        }
                        else
                        {
                            EleccionText = "Ida/Vuelta";
                        }

                        AgregarSolicitudText(EleccionText, Dr["Descripcion"].ToString(), Dr["Descripcion1"].ToString(), Dr["Descripcion"].ToString(), Dr["Origen"].ToString(), Dr["Destino"].ToString(), Seguridad.ValidarDateTime(Dr["FechaInicial"].ToString()), Seguridad.ValidarDateTime(Dr["FechaFinal"].ToString()), Seguridad.ValidarEntero(Dr["CantidadPersona"].ToString()), Seguridad.ValidarEntero(Dr["CantidadNino"].ToString()), Seguridad.ValidarEntero(Dr["CantidadBebe"].ToString()), Seguridad.ValidarDouble(Dr["PrecioInicial"].ToString()), Seguridad.ValidarDouble(Dr["PrecioFinal"].ToString()));
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
                return Conexion.ObtenerDatos(string.Format("select " + Campos + " From Solicitudes where " + Condicion + " " + Orden));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
