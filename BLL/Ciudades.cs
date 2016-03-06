using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Ciudades : ClaseMaestra
    {
        public int CiudadId { get; set; }
        public string Descripcion { get; set; }
        public int PaisId { get; set; }


        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDB Conexion = new ConexionDB();

            try
            {
                retorno = Conexion.Ejecutar(string.Format("insert into Ciudades(Descripcion, PaisId) values('{0}',{1}) ", this.Descripcion, this.PaisId));
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
                retorno = Conexion.Ejecutar(string.Format("update Ciudades set Descripcion = '{0}', PaisId = {1} where CiudadId = {2}", this.Descripcion, this.PaisId, this.CiudadId));
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
                retorno = Conexion.Ejecutar(string.Format("delete from Ciudades where CiudadId = {0}", this.CiudadId));
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
                dt = Conexion.ObtenerDatos(string.Format("select * from Ciudades where CiudadId = {0} ", IdBuscado));

                if (dt.Rows.Count > 0)
                {
                    this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                    this.PaisId = (int)dt.Rows[0]["PaisId"];
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
                return Conexion.ObtenerDatos(string.Format("select " + Campos + " From Ciudades where " + Condicion + " " + Orden));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
