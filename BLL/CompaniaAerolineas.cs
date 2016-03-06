using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class CompaniaAerolineas : ClaseMaestra
    {
        public int CompaniaAerolineaId { get; set; }
        public string Descripcion { get; set; }
        public string Email { get; set; }


        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDB Conexion = new ConexionDB();

            try
            {
                retorno = Conexion.Ejecutar(string.Format("insert into CompaniaAerolineas(Descripcion,Email) values('{0}','{1}'}) ", this.Descripcion, this.Email));
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
                retorno = Conexion.Ejecutar(string.Format("update CompaniaAerolineas set Descripcion = '{0}',Email = '{1}' where CompaniaAerolineaId = {2}", this.Descripcion, this.Email, this.CompaniaAerolineaId));
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
                retorno = Conexion.Ejecutar(string.Format("delete from CompaniaAerolineas where CompaniaAerolineaId = {0}", this.CompaniaAerolineaId));
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
                dt = Conexion.ObtenerDatos(string.Format("select * from CompaniaAerolineas where CompaniaAerolineaId = {0} ", IdBuscado));

                if (dt.Rows.Count > 0)
                {
                    this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                    this.Email = dt.Rows[0]["Email"].ToString();
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
                return Conexion.ObtenerDatos(string.Format("select " + Campos + " From CompaniaAerolineas where " + Condicion + " " + Orden));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
