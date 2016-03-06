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
        public bool EsActivo { get; set; }
        public double Precio { get; set; }
        public double Impuesto { get; set; }
        public double Total { get; set; }

        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDB Conexion = new ConexionDB();

            try
            {
                retorno = Conexion.Ejecutar(string.Format("insert into Reservaciones(UsuarioId,EsActivo,Precio,Impuesto,Total) values({0},{1},{2},{3},{4}) ", this.UsuarioId, this.EsActivo, this.Precio, this.Impuesto, this.Total));
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
                retorno = Conexion.Ejecutar(string.Format("update Reservaciones set UsuarioId = {0},EsActivo = {1}, Precio = {2},Impuesto = {3}, Total = {4} where ReservacionId = {5}", this.UsuarioId, this.EsActivo, this.Precio, this.Impuesto, this.Total, this.ReservacionId));
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
                retorno = Conexion.Ejecutar(string.Format("delete from Reservaciones where ReservacionId = {0}", this.ReservacionId));
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
                dt = Conexion.ObtenerDatos(string.Format("select * from Reservaciones where ReservacionId = {0} ", IdBuscado));

                if (dt.Rows.Count > 0)
                {
                    this.UsuarioId = (int)dt.Rows[0]["UsuarioId"];
                    this.EsActivo = (bool)dt.Rows[0]["EsActivo"];
                    this.Precio = (double)dt.Rows[0]["Precio"];
                    this.Impuesto = (double)dt.Rows[0]["Impuesto"];
                    this.Total = (double)dt.Rows[0]["Total"];
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
                return Conexion.ObtenerDatos(string.Format("select " + Campos + " From Reservaciones where " + Condicion + " " + Orden));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
