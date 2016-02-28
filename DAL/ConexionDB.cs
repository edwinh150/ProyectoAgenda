using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ConexionDB
    {
        private SqlConnection con;
        private SqlCommand Cmd;

        public ConexionDB()
        {
            //"Data Source=DARLENISM\\SQLEXPRESS;Initial Catalog=TareaUsuario;Integrated Security=True"//
            //Data Source=tcp:edwinh1501.database.windows.net,1433;Initial Catalog=AgenciaViajesDb;User ID=Edwinh150@edwinh1501;Password=Edwin2410..//
            con = new SqlConnection("Data Source=tcp:edwinh1501.database.windows.net,1433;Initial Catalog=AgenciaViajesDb;User ID=Edwinh150@edwinh1501;Password=Edwin2410..");
            Cmd = new SqlCommand();
        }

        public bool Ejecutar(String ComandoSql)
        {
            bool retorno = false;

            try
            {
                con.Open();
                Cmd.Connection = con;
                Cmd.CommandText = ComandoSql;
                Cmd.ExecuteNonQuery();
                retorno = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

            return retorno;
        }

        public DataTable ObtenerDatos(String ComandoSql)
        {

            SqlDataAdapter adapter;
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                Cmd.Connection = con;
                Cmd.CommandText = ComandoSql;

                adapter = new SqlDataAdapter(Cmd);
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
    }
}
