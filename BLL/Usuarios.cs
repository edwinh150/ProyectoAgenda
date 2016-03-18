using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL
{
    public class Usuarios : ClaseMaestra
    {
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int TipoUsuarioId { get; set; }
        public static int Id = 0;

        public Usuarios()
        {
            this.UsuarioId = 0;
            this.NombreUsuario = "";
            this.Contrasena = "";
            this.Nombre = "";
            this.Apellido = "";
            this.Email = "";
            this.Telefono = "";
            this.TipoUsuarioId = 0;

        }

        public bool IniciarSesion()
        {
            ConexionDB con = new ConexionDB();

            bool retorno = false;

            Id = (int)con.ObtenerDatos(string.Format("select * from Usuarios where NombreUsuario = '{0}' and Contrasena = '{1}' ", this.NombreUsuario, this.Contrasena)).Rows[0]["UsuarioId"];

            if (Id > 0)
            {
                 retorno = true;
            }
            else
            {
                retorno = false;
            }

            return retorno;
        }

        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDB Conexion = new ConexionDB();

            try
            {
                retorno = Conexion.Ejecutar(string.Format("insert into Usuarios(NombreUsuario,Contrasena,Nombre,Apellido,Email,Telefono, FechaNacimiento,TipoUsuarioId) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7}) ", this.NombreUsuario, this.Contrasena, this.Nombre, this.Apellido, this.Email, this.Telefono, this.FechaNacimiento.ToString("yyyy-MM-dd"), this.TipoUsuarioId));
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
                retorno = Conexion.Ejecutar(string.Format("update Usuarios set NombreUsuario = '{0}',Contrasena = '{1}', Nombre = '{2}',Apellido = '{3}', Email = '{4}', Telefono = '{5}', FechaNacimiento = '{6}' TipoUsuarioId = {7} where UsuarioId = {8}", this.NombreUsuario, this.Contrasena, this.Nombre, this.Apellido, this.Email, this.Telefono, this.TipoUsuarioId, this.FechaNacimiento.ToString("yyyy-MM-dd"), this.UsuarioId));
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
                retorno = Conexion.Ejecutar(string.Format("delete from Usuarios where UsuarioId = {0}", this.UsuarioId));
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
                dt = Conexion.ObtenerDatos(string.Format("select * from Usuarios where UsuarioId = {0} ", IdBuscado));

                if (dt.Rows.Count > 0)
                {
                    this.NombreUsuario = dt.Rows[0]["NombreUsuario"].ToString();
                    this.Contrasena = dt.Rows[0]["Contrasena"].ToString();
                    this.Nombre = dt.Rows[0]["Nombre"].ToString();
                    this.Apellido = dt.Rows[0]["Apellido"].ToString();
                    this.Email = dt.Rows[0]["Email"].ToString();
                    this.Telefono = dt.Rows[0]["Telefono"].ToString();
                    this.FechaNacimiento = (DateTime)dt.Rows[0]["FechaNacimiento"];
                    this.TipoUsuarioId = (int)dt.Rows[0]["TipoUsuarioId"];
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
                return Conexion.ObtenerDatos(string.Format("select " + Campos + " From Usuarios where " + Condicion + " " + Orden));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
