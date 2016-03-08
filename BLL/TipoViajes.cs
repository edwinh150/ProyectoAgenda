using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class TipoViajes : ClaseMaestra
    {
        public int TipoViajeId { get; set; }
        public string Descripcion { get; set; }

        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDB Conexion = new ConexionDB();

            try
            {
                retorno = Conexion.Ejecutar(string.Format("insert into TipoViajes(Descripcion) values('{0}') ", this.Descripcion));
            }
            catch (Exception)
            {
                retorno = false;
            }

            return retorno;
        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDB Conexion = new ConexionDB();

            try
            {
                retorno = Conexion.Ejecutar(string.Format("update TipoViajes set Descripcion = '{0}' where TipoDestinoId = {1}", this.Descripcion, this.TipoViajeId));
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
                retorno = Conexion.Ejecutar(string.Format("delete from TipoViajes where TipoDestinoId = {0}", this.TipoViajeId));
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
            ConexionDB Conexion = new ConexionDB();

            try
            {
                dt = Conexion.ObtenerDatos(string.Format("select * from TipoViajes where TipoDestinoId = {0} ", IdBuscado));

                if (dt.Rows.Count > 0)
                {
                    this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                    retorno = true;
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
                return Conexion.ObtenerDatos(string.Format("Select " + Campos + " From TipoViajes where " + Condicion + " " + Orden));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
