using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Destinos : ClaseMaestra
    {
        public int DestinoId { get; set; }
        public string Descripcion { get; set; }
        public int TipoDestinoId { get; set; }
        public int CiudadId { get; set; }


        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDB Conexion = new ConexionDB();

            try
            {
                retorno = Conexion.Ejecutar(string.Format("insert into Destinos(Descripcion,TipoDestinoId,CiudadId) values('{0}',{1}) ", this.Descripcion, this.TipoDestinoId, this.CiudadId));
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
                retorno = Conexion.Ejecutar(string.Format("update Destinos set Descripcion = '{0}', TipoDestinoId = {1}, CiudadId = {2} where DestinoId = {3}",this.Descripcion, this.TipoDestinoId, this.CiudadId, this.DestinoId));
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
                retorno = Conexion.Ejecutar(string.Format("delete from Destinos where DestinoId = {0}", this.DestinoId));
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
                dt = Conexion.ObtenerDatos(string.Format("select * from Destinos where DestinoId = {0} ", IdBuscado));

                if (dt.Rows.Count > 0)
                {
                    this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                    this.TipoDestinoId = (int)dt.Rows[0]["TipoDestinoId"];
                    this.CiudadId = (int)dt.Rows[0]["CiudadId"];
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
                return Conexion.ObtenerDatos(string.Format("select " + Campos + " From Destinos where " + Condicion + " " + Orden));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
