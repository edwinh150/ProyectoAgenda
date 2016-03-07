using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Viajes : ClaseMaestra
    {
        public int ViajeId { get; set; }
        public int OrigenId { get; set; }
        public int DestinoId { get; set; }
        public DateTime FechaIncial { get; set; }
        public DateTime FechaFinal { get; set; }
        public int CantidadPersona { get; set; }
        public int CantidadNino { get; set; }
        public string EdadesNino { get; set; }
        public double PrecioInicial { get; set; }
        public double PrecioFinal { get; set; }

        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDB Conexion = new ConexionDB();

            try
            {
                retorno = Conexion.Ejecutar(string.Format("insert into Viajes(OrigenId,DestinoId,FechaInicial,FechaFinal,CantidadPersona,CantidadNino,EdadesNino,PrecioInicial,PrecioFinal) values({0},{1},'{2}','{3}',{4},{5},'{6}',{7},{8}) ", this.OrigenId, this.DestinoId, this.FechaIncial, this.FechaFinal, this.CantidadPersona, this.CantidadNino, this.EdadesNino, this.FechaIncial, this.FechaFinal));
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
                retorno = Conexion.Ejecutar(string.Format("Update Viajes set OrigenId = {0}, DestinoId = {1}, FechaInicial = {2}, FechaFinal = {3}, CantidadPersona = {4}, CantidadNino = {5}, EdadesNino = {6}, PrecioInicial = {7}, PrecioFinal = {8} where ViajeId = {9}", this.OrigenId, this.DestinoId, this.FechaIncial, this.FechaFinal, this.CantidadPersona, this.CantidadNino, this.EdadesNino, this.FechaIncial, this.FechaFinal, this.ViajeId));
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
                retorno = Conexion.Ejecutar(string.Format("delete from Viajes where ViajeId = {0}", this.ViajeId));
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
                dt = Conexion.ObtenerDatos(string.Format("select * from Viajes where ViajeId = {0} ", IdBuscado));

                if (dt.Rows.Count > 0)
                {
                    this.OrigenId = (int)dt.Rows[0]["OrigenId"];
                    this.DestinoId = (int)dt.Rows[0]["DestinoId"];
                    this.ViajeId = (int)dt.Rows[0]["ViajeId"];
                    this.FechaIncial = (DateTime)dt.Rows[0]["FechaIncial"];
                    this.FechaFinal = (DateTime)dt.Rows[0]["FechaFinal"];
                    this.CantidadPersona = (int)dt.Rows[0]["CantidadPersona"];
                    this.CantidadNino = (int)dt.Rows[0]["CantidadNino"];
                    this.EdadesNino = dt.Rows[0]["EdadesNino"].ToString();
                    this.PrecioInicial = (double)dt.Rows[0]["PrecioInicial"];
                    this.PrecioFinal = (double)dt.Rows[0]["PrecioFinal"];
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
                return Conexion.ObtenerDatos(string.Format("select " + Campos + " From Viajes where " + Condicion + " " + Orden));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
