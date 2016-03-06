using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Vuelos : ClaseMaestra
    {
        public int VueloId { get; set; }
        public bool EleccionDestino { get; set; }
        public int UsuarioId { get; set; }
        public int ViajeId { get; set; }

        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDB Conexion = new ConexionDB();

            try
            {
                retorno = Conexion.Ejecutar(string.Format("insert into Vuelos(EleccionDestino,UsuarioId,ViajeId) values({0},{1},{2}) ",this.EleccionDestino, this.UsuarioId, this.ViajeId));
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
                retorno = Conexion.Ejecutar(string.Format("update Vuelos set EleccionDestino = {0},UsuarioId = {1}, ViajeId = {2} where VueloId = {3}",this.EleccionDestino, this.UsuarioId, this.ViajeId, this.VueloId));
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
                retorno = Conexion.Ejecutar(string.Format("delete from Vuelos where VueloId = {0}", this.VueloId));
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
                dt = Conexion.ObtenerDatos(string.Format("select * from Vuelos where VueloId = {0} ", IdBuscado));

                if (dt.Rows.Count > 0)
                {
                    this.EleccionDestino = (bool)dt.Rows[0]["EleccionDestino"];
                    this.UsuarioId = (int)dt.Rows[0]["UsuarioId"];
                    this.ViajeId = (int)dt.Rows[0]["ViajeId"];
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
                return Conexion.ObtenerDatos(string.Format("select " + Campos + " From Vuelos where " + Condicion + " " + Orden));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
