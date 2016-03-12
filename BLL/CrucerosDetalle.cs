using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class CrucerosDetalle : ClaseMaestra
    {
        public int CruceroId { get; set; }
        public int UsuarioId { get; set; }
        public int ViajeId { get; set; }
        public int CategoriaCruceroId { get; set; }
        public int CompaniaCruceroId { get; set; }

        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDB Conexion = new ConexionDB();

            try
            {
                retorno = Conexion.Ejecutar(string.Format("insert into Cruceros(UsuarioId,SolicitudId,CategoriaId,TipoCompaniaId) values({0},{1},{2},{3}) ", this.UsuarioId, this.ViajeId, this.CategoriaCruceroId, this.CompaniaCruceroId));
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
                retorno = Conexion.Ejecutar(string.Format("update Cruceros set UsuarioId = {0}, SolicitudId = {1}, CategoriaId = {2}, TipoCompaniaId = {3} where CruceroId = {4}", this.UsuarioId, this.ViajeId, this.CategoriaCruceroId, this.CompaniaCruceroId, this.CruceroId));
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
                retorno = Conexion.Ejecutar(string.Format("delete from Cruceros where CruceroId = {0}", this.CruceroId));
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
                dt = Conexion.ObtenerDatos(string.Format("select * from Cruceros where CruceroId = {0} ", IdBuscado));

                if (dt.Rows.Count > 0)
                {
                    this.UsuarioId = (int)dt.Rows[0]["UsuarioId"];
                    this.ViajeId = (int)dt.Rows[0]["SolicitudId"];
                    this.CategoriaCruceroId = (int)dt.Rows[0]["CategoriaId"];
                    this.CompaniaCruceroId = (int)dt.Rows[0]["TipoCompaniaId"];
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
                return Conexion.ObtenerDatos(string.Format("select " + Campos + " From Cruceros where " + Condicion + " " + Orden));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
