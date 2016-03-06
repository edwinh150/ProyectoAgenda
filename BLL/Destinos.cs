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
        public int PaisId { get; set; }
        public int CiudadId { get; set; }


        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDB Conexion = new ConexionDB();

            try
            {
                retorno = Conexion.Ejecutar(string.Format("insert into Usuarios(NombreUsuario,Contrasena,Nombre,Apellido,Email,Telefono,TipoUsuarioId) values('{0}','{1}','{2}','{3}','{4}','{5}',{6}) ", this.CiudadId));
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
                retorno = Conexion.Ejecutar(string.Format("update Usuarios set NombreUsuario = '{0}',Contrasena = '{1}', Nombre = '{2}',Apellido = '{3}', Email = '{4}', Telefono = '{5}', TipoUsuarioId = {6} from Usuarios where UsuarioId = {7}", this.PaisId));
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
                retorno = Conexion.Ejecutar(string.Format("delete from Usuarios where UsuarioId = {0}", this.DestinoId));
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
