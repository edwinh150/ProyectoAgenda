using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia.Consultas
{
    public partial class cPerfilNotificaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuarios Usuario = new Usuarios();
            if (!IsPostBack)
            {
                if (Usuarios.Id == 0)
                {
                    Usuario.Comprobar();
                }

                LlenarGrid(" s.UsuarioId = " + Usuarios.Id, " r.UsuarioId = " + Usuarios.Id);

                if (SolicitudesGridView.Rows.Count == 0)
                {
                    Mensajes.ShowToastr(this.Page, "No hay Registro", "Error", "Error");
                }

                if (ReservacionesGridView.Rows.Count == 0)
                {
                    Mensajes.ShowToastr(this.Page, "No hay Registro", "Error", "Error");
                }
            }
        }

        public void Limpiar()
        {
            SolicitudesGridView.DataSource = string.Empty;
            ReservacionesGridView.DataSource = string.Empty;
        }

        void LlenarGrid(string Condicion, string Condicion2)
        {
            SolicitudDetalleText Solicitud = new SolicitudDetalleText();
            ReservacionDetalleText Reservacion = new ReservacionDetalleText();
            DataTable dt = new DataTable();

            SolicitudesGridView.DataSource = Solicitud.SoloSolicitudListado(Condicion);
            SolicitudesGridView.DataBind();

            ReservacionesGridView.DataSource = Reservacion.SoloReservacionListado(Condicion2);
            ReservacionesGridView.DataBind();
        }
    }
}