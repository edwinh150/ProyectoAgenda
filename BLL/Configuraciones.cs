using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Configuraciones : ClaseMaestra
    {
        public double Impuesto { get; set; }

        public Configuraciones()
        {
            this.Impuesto = 0;
        }

        public Configuraciones(double Impuesto)
        {
            this.Impuesto = Impuesto;
        }

        public override bool Buscar(int IdBuscado)
        {
            throw new NotImplementedException();
        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDB Conexion = new ConexionDB();

            try
            {
                retorno = Conexion.Ejecutar(string.Format("Update Configuraciones set Impuesto = {0} ", this.Impuesto));
            }
            catch (Exception)
            {
                retorno = false;
            }

            return retorno;
        }

        public override bool Eliminar()
        {
            throw new NotImplementedException();
        }

        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDB Conexion = new ConexionDB();

            try
            {
                retorno = Conexion.Ejecutar(string.Format("insert into Configuraciones(Impuesto) values({0}) ", this.Impuesto));
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
                return Conexion.ObtenerDatos(string.Format("select " + Campos + " From Configuraciones where " + Condicion + " " + Orden));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
