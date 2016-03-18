using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Companias : ClaseMaestra
    {
        public int CompaniaId { get; set; }
        public string Descripcion { get; set; }
        public string Email { get; set; }
        public int TipoCompaniaId { get; set; }


        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDB Conexion = new ConexionDB();

            try
            {
                retorno = Conexion.Ejecutar(string.Format("insert into Companias (Descripcion,Email,TipoCompaniaId) values('{0}','{1}',{2}) ", this.Descripcion, this.Email, this.TipoCompaniaId));
            }
            catch (Exception ex)
            {
                throw ex;
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
                retorno = Conexion.Ejecutar(string.Format("update Companias set Descripcion = '{0}',Email = '{1}', TipoCompaniaId = {2} where CompaniaId = {3}", this.Descripcion, this.Email, this.TipoCompaniaId, this.CompaniaId));
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
                retorno = Conexion.Ejecutar(string.Format("delete from Companias where CompaniaId = {0}", this.CompaniaId));
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
                dt = Conexion.ObtenerDatos(string.Format("select * from Companias where CompaniaId = {0} ", IdBuscado));

                if (dt.Rows.Count > 0)
                {
                    this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                    this.Email = dt.Rows[0]["Email"].ToString();
                    this.TipoCompaniaId = (int)dt.Rows[0]["TipoCompaniaId"];
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
                return Conexion.ObtenerDatos(string.Format(" select " + Campos + " from Companias where " + Condicion + "" + Orden));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
