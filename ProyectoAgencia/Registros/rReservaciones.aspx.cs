using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace ProyectoAgencia.Registros
{
    public partial class rReservaciones : System.Web.UI.Page
    {
        Reservaciones Reservacion = new Reservaciones();
        ReservacionDetalles ReservacionDetalle = new ReservacionDetalles();
        int Eleccion = 0;
        string EleccionText = "";
        int Estado = 0;
        int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuarios Usuario = new Usuarios();
                Configuraciones Configuracion = new Configuraciones();

                DataTable dt = new DataTable();

                dt = Configuracion.Listado("*", " 1=1 ", "");

                if (dt.Rows.Count > 0)
                {
                    ImpuestoTextBox.Text = dt.Rows[0]["Impuesto"].ToString();
                }
                else
                {
                    Mensajes.ShowToastr(this, "Error", "No hay Configuracion", "Error");
                }

                LlenarDropDownList();
                UsuarioIdLabel.Text = Context.User.Identity.Name;
                if (Usuarios.Id == 0)
                {
                    Usuario.NombreUsuario = UsuarioIdLabel.Text;
                    Usuario.Comprobar();
                }
                EsActivoCheckBox.Checked = true;
                FechaCreacionLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
                EliminarButton.Visible = false;

                if (Request.QueryString["Id"] != null)
                {
                    id = Seguridad.ValidarEntero(Request.QueryString["Id"].ToString());
                    Reservacion.SolicitudId = id;
                }

                SolicitudIdLabel.Text = Reservacion.SolicitudId.ToString();
                DetalleGridView.Visible = false;

                FechaInicialTextBox.Attributes.Add("readonly", "true");
                FechaFinalTextBox.Attributes.Add("readonly", "true");
                CalendarExtender1.StartDate = DateTime.Now;
            }
        }

        public void LlenarDropDownList()
        {
            TipoSolicitudes TipoSolicitud = new TipoSolicitudes();
            Companias compania = new Companias();
            Categorias Categoria = new Categorias();
            Ciudades Ciudad = new Ciudades();
            Paises Pais = new Paises();

            //Tiposolicitud
            TipoSolicitudIdDropDownList.DataSource = TipoSolicitud.Listado("*", " 1=1 ", "");
            TipoSolicitudIdDropDownList.DataTextField = "Descripcion";
            TipoSolicitudIdDropDownList.DataValueField = "TipoSolicitudId";
            TipoSolicitudIdDropDownList.DataBind();
            //compania
            CompaniaIdDropDownList.DataSource = compania.Listado("*", "TipoCompaniaId = " + TipoSolicitudIdDropDownList.SelectedValue, "");
            CompaniaIdDropDownList.DataTextField = "Descripcion";
            CompaniaIdDropDownList.DataValueField = "CompaniaId";
            CompaniaIdDropDownList.DataBind();
            //Categoria
            CategoriaIdDropDownList.DataSource = Categoria.Listado("*", "TipoCategoriaId = " + TipoSolicitudIdDropDownList.SelectedValue, "");
            CategoriaIdDropDownList.DataTextField = "Descripcion";
            CategoriaIdDropDownList.DataValueField = "CategoriaId";
            CategoriaIdDropDownList.DataBind();
            //pais
            PaisOrigenDropDownList.DataSource = Pais.Listado("*", "1=1", "");
            PaisOrigenDropDownList.DataTextField = "Descripcion";
            PaisOrigenDropDownList.DataValueField = "PaisId";
            PaisOrigenDropDownList.DataBind();
            //pais
            PaisDestinoDropDownList.DataSource = Pais.Listado("*", "1=1", "");
            PaisDestinoDropDownList.DataTextField = "Descripcion";
            PaisDestinoDropDownList.DataValueField = "PaisId";
            PaisDestinoDropDownList.DataBind();
            //ciudad
            DestinoDropDownList.DataSource = Ciudad.Listado(" * ", " PaisId = " + PaisDestinoDropDownList.SelectedValue, "");
            DestinoDropDownList.DataTextField = "Descripcion";
            DestinoDropDownList.DataValueField = "CiudadId";
            DestinoDropDownList.DataBind();
            //ciudad
            OrigenDropDownList.DataSource = Ciudad.Listado(" * ", " PaisId = " + PaisOrigenDropDownList.SelectedValue, "");
            OrigenDropDownList.DataTextField = "Descripcion";
            OrigenDropDownList.DataValueField = "CiudadId";
            OrigenDropDownList.DataBind();
            //ciudad
            DestinoDropDownList.DataSource = Ciudad.Listado(" * ", " PaisId = " + PaisDestinoDropDownList.SelectedValue + " AND CiudadId <> " + OrigenDropDownList.SelectedValue, "");
            DestinoDropDownList.DataTextField = "Descripcion";
            DestinoDropDownList.DataValueField = "CiudadId";
            DestinoDropDownList.DataBind();
        }

        public void ValidacionLimpiar()
        {
            ReservacionIdDiv.Attributes.Remove("class");
            ReservacionIdDiv.Attributes.Add("class", "col-md-8 col-xs-8");

            AsuntoDiv.Attributes.Remove("class");
            AsuntoDiv.Attributes.Add("class", "col-md-8 col-xs-8");

            PrecioDiv.Attributes.Remove("class");
            PrecioDiv.Attributes.Add("class", "controls");

            ImpuestoDiv.Attributes.Remove("class");
            ImpuestoDiv.Attributes.Add("class", "controls");
        }

        public void LlenarForm()
        {
            ValidacionLimpiar();

            UsuarioIdLabel.Text = Reservacion.UsuarioId.ToString();

            FechaCreacionLabel.Text = Reservacion.FechaCreacion.ToString("dd/MM/yyyy");
            AsuntoTextBox.Text = Reservacion.Asunto;

            TipoSolicitudIdDropDownList.SelectedIndex = ReservacionDetalle.TipoSolicitudId;
            CompaniaIdDropDownList.SelectedIndex = ReservacionDetalle.CompaniaId;
            CategoriaIdDropDownList.SelectedIndex = ReservacionDetalle.CategoriaId;
            if (ReservacionDetalle.EleccionDestino == 0)
            {
                EstadoCheckBox.Checked = false;
            }
            else
            {
                EstadoCheckBox.Checked = true;
            }
            OrigenDropDownList.SelectedIndex = Seguridad.ValidarEntero(ReservacionDetalle.Origen);
            DestinoDropDownList.SelectedIndex = Seguridad.ValidarEntero(ReservacionDetalle.Destino);
            FechaInicialTextBox.Text = ReservacionDetalle.FechaInicial.ToString("dd/MM/yyyy");
            FechaFinalTextBox.Text = ReservacionDetalle.FechaFinal.ToString("dd/MM/yyyy");
            PrecioTextBox.Text = ReservacionDetalle.Precio.ToString();
            ImpuestoTextBox.Text = ReservacionDetalle.Impuesto.ToString();
            TotalTextBox.Text = ReservacionDetalle.Total.ToString();
            CantidadPersonaDropDownList.SelectedIndex = ReservacionDetalle.CantidadPersona;
            CantidadNinoDropDownList.SelectedIndex = ReservacionDetalle.CantidadNino;
            CantidadBebeDropDownList.SelectedIndex = ReservacionDetalle.CantidadBebe;
            DetalleTextGridView.DataSource = Reservacion.DetalleText;
            DetalleTextGridView.DataBind();
            GuardarButton.Text = "Guardar";
            EliminarButton.Visible = false;
        }

        public void Limpiar()
        {
            ReservacionIdTextBox.Text = "";
            AsuntoTextBox.Text = "";
            FechaInicialTextBox.Text = "";
            FechaFinalTextBox.Text = "";
            PrecioTextBox.Text = "";
            TotalTextBox.Text = "";
            ValidacionLimpiar();
            DetalleGridView.DataSource = string.Empty;
            DetalleGridView.DataBind();
            DetalleTextGridView.DataSource = string.Empty;
            DetalleTextGridView.DataBind();
        }

        bool LLenarDatos()
        {
            bool retorno = true;
            ValidacionLimpiar();

            if (!Seguridad.ValidarNombre(AsuntoTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Asunto Invalido", "Error");
                AsuntoDiv.Attributes.Add("class", " col-md-8 col-xs-8 has-error ");
                retorno = false;
            }

            if (retorno)
            {
                Reservacion.Asunto = AsuntoTextBox.Text;
                Reservacion.FechaCreacion = DateTime.Now;
                Reservacion.UsuarioId = Usuarios.Id;
                Reservacion.SolicitudId = Seguridad.ValidarEntero(SolicitudIdLabel.Text);
                if (EsActivoCheckBox.Checked == true)
                {
                    Estado = 1;
                }
                else
                {
                    Estado = 0;
                }
                Reservacion.EsActivo = Estado;

                if (DetalleGridView.Rows.Count > 0)
                {
                    foreach (GridViewRow dr in DetalleGridView.Rows)
                    {
                        Reservacion.AgregarReservacion(Seguridad.ValidarEntero(dr.Cells[0].Text), Seguridad.ValidarEntero(dr.Cells[1].Text), Seguridad.ValidarEntero(dr.Cells[2].Text), Seguridad.ValidarEntero(dr.Cells[3].Text), dr.Cells[4].Text, dr.Cells[5].Text, Seguridad.ValidarDateTime(dr.Cells[6].Text), Seguridad.ValidarDateTime(dr.Cells[7].Text), Seguridad.ValidarEntero(dr.Cells[8].Text), Seguridad.ValidarEntero(dr.Cells[9].Text), Seguridad.ValidarEntero(dr.Cells[10].Text), Seguridad.ValidarDouble(dr.Cells[11].Text), Seguridad.ValidarDouble(dr.Cells[12].Text), Seguridad.ValidarDouble(dr.Cells[13].Text));
                    }
                }
                else
                {
                    retorno = false;
                }
            }

            return retorno;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Reservaciones ReservacionDetalle;

            if (Session["ReservacionSession"] == null)
            {
                Session["ReservacionSession"] = new Reservaciones();
            }

            ReservacionDetalle = (Reservaciones)Session["ReservacionSession"];

            if (ReservacionIdTextBox.Text.Length > 0)
            {
                if (LLenarDatos())
                {
                    Reservacion.ReservacionId = Seguridad.ValidarEntero(ReservacionIdTextBox.Text);

                    if (Reservacion.Editar())
                    {
                        Mensajes.ShowToastr(this.Page, "Se Modifico", "Informacion", "Success");
                        Limpiar();
                    }
                    else
                    {
                        Mensajes.ShowToastr(this.Page, "No Se Modifico", "Error", "Error");
                    }

                }
                else
                {
                    Mensajes.ShowToastr(this.Page, "Faltan Datos", "Error", "Error");
                }
            }
            else
            {
                if (LLenarDatos())
                {
                    if (Reservacion.Insertar())
                    {
                        Mensajes.ShowToastr(this.Page, "Se Registro", "Felicidades", "Success");
                        Limpiar();
                    }
                    else
                    {
                        Mensajes.ShowToastr(this.Page, "No se pudo Registrar", "Error", "Error");
                    }
                }
                else
                {
                    Mensajes.ShowToastr(this.Page, "Faltan Datos", "Error", "Error");
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (ReservacionIdTextBox.Text.Length > 0)
            {
                if (Seguridad.ValidarEntero(ReservacionIdTextBox.Text) > 0)
                {
                    Reservacion.ReservacionId = Seguridad.ValidarEntero(ReservacionIdTextBox.Text);

                    if (Reservacion.Eliminar())
                    {
                        Mensajes.ShowToastr(this.Page, "Se Guardo", "Informacion", "Success");
                        Limpiar();
                    }
                    else
                    {
                        Mensajes.ShowToastr(this.Page, "No Se Elimino", "Error", "Error");
                    }
                }
                else
                {
                    Mensajes.ShowToastr(this.Page, "No hay Registro", "Error", "Error");
                    Limpiar();
                }
            }
            else
            {
                Mensajes.ShowToastr(this.Page, "Ingrese un Id valido primero", "Error", "Error");
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int Id = 0;
            bool retorno = true;

            ValidacionLimpiar();

            if (!Seguridad.ValidarSoloNumero(ReservacionIdTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Id de Reservacion Invalido", "Error");
                ReservacionIdDiv.Attributes.Add("class", " col-md-8 has-error ");
                retorno = false;
            }

            if (retorno)
            {
                Id = Seguridad.ValidarEntero(ReservacionIdTextBox.Text);
            }

            if (Id > 0)
            {
                if (Reservacion.Buscar(Id))
                {
                    LlenarForm();
                    GuardarButton.Text = "Modificar";
                    EliminarButton.Visible = true;

                }
                else
                {
                    Mensajes.ShowToastr(this.Page, "No hay Registro", "Informacion", "info");
                    Limpiar();
                }
            }
            else
            {
                Mensajes.ShowToastr(this.Page, "Ingrese un Id valido primero", "Error", "Error");
                Limpiar();
            }
        }

        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        protected void AgregarDetalleButton_Click(object sender, EventArgs e)
        {
            Reservaciones ReservacionDetalle;
            bool retorno = true;
            ValidacionLimpiar();

            if (!Seguridad.ValidarSoloNumero(PrecioTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Precio Invalido", "Error");
                PrecioDiv.Attributes.Add("class", " controls has-error ");
                retorno = false;
            }

            if (!Seguridad.ValidarSoloNumero(ImpuestoTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Impuesto Invalido", "Error");
                ImpuestoDiv.Attributes.Add("class", " controls has-error ");
                retorno = false;
            }

            if (retorno)
            {
                if (EstadoCheckBox.Checked == true)
                {
                    Eleccion = 1; // ida
                    EleccionText = "Solo Ida";
                }
                else
                {
                    Eleccion = 0; // ida/vuelta
                    EleccionText = "Ida/Vuelta";

                    if (FechaFinalTextBox.Text.Length == 0)
                    {
                        retorno = false;
                    }
                }
            }


            if (retorno == true)
            {
                if (Session["ReservacionSession"] == null)
                {
                    Session["ReservacionSession"] = new Reservaciones();
                }

                ReservacionDetalle = (Reservaciones)Session["ReservacionSession"];

                ReservacionDetalle.AgregarReservacion(Eleccion, Seguridad.ValidarEntero(TipoSolicitudIdDropDownList.SelectedValue), Seguridad.ValidarEntero(CompaniaIdDropDownList.SelectedValue), Seguridad.ValidarEntero(CategoriaIdDropDownList.SelectedValue), OrigenDropDownList.SelectedItem.Text, DestinoDropDownList.SelectedItem.Text, Seguridad.ValidarDateTime(FechaInicialTextBox.Text), Seguridad.ValidarDateTime(FechaFinalTextBox.Text), Seguridad.ValidarEntero(CantidadPersonaDropDownList.SelectedValue), Seguridad.ValidarEntero(CantidadNinoDropDownList.SelectedValue), Seguridad.ValidarEntero(CantidadBebeDropDownList.SelectedValue), Seguridad.ValidarDouble(PrecioTextBox.Text), Seguridad.ValidarDouble(ImpuestoTextBox.Text), Seguridad.ValidarDouble(TotalTextBox.Text));

                ReservacionDetalle.AgregarReservacionText(EleccionText, TipoSolicitudIdDropDownList.SelectedItem.Text, CompaniaIdDropDownList.SelectedItem.Text, CategoriaIdDropDownList.SelectedItem.Text, OrigenDropDownList.SelectedItem.Text, DestinoDropDownList.SelectedItem.Text, Seguridad.ValidarDateTime(FechaInicialTextBox.Text), Seguridad.ValidarDateTime(FechaFinalTextBox.Text), Seguridad.ValidarEntero(CantidadPersonaDropDownList.SelectedValue), Seguridad.ValidarEntero(CantidadNinoDropDownList.SelectedValue), Seguridad.ValidarEntero(CantidadBebeDropDownList.SelectedValue), Seguridad.ValidarDouble(PrecioTextBox.Text), Seguridad.ValidarDouble(ImpuestoTextBox.Text), Seguridad.ValidarDouble(TotalTextBox.Text));

                Session["ReservacionSession"] = ReservacionDetalle;

                DetalleGridView.DataSource = ReservacionDetalle.Detalle;
                DetalleGridView.DataBind();
                DetalleTextGridView.DataSource = ReservacionDetalle.DetalleText;
                DetalleTextGridView.DataBind();
            }
            else
            {
                Mensajes.ShowToastr(this.Page, "Faltan Datos en el Detalle", "Error", "Error");
            }

        }

        protected void OrigenDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ciudades Ciudad = new Ciudades();

            DestinoDropDownList.DataSource = Ciudad.Listado(" * ", " PaisId = " + PaisDestinoDropDownList.SelectedValue + "AND CiudadId <> " + OrigenDropDownList.SelectedValue, "");
            DestinoDropDownList.DataTextField = "Descripcion";
            DestinoDropDownList.DataValueField = "CiudadId";
            DestinoDropDownList.DataBind();
        }

        protected void EstadoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (EstadoCheckBox.Checked == true)
            {
                FechaFinal.Visible = false;
            }
            else
            {
                FechaFinal.Visible = true;
            }
        }

        protected void DestinoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void PaisOrigenDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ciudades Ciudad = new Ciudades();

            OrigenDropDownList.DataSource = Ciudad.Listado(" * ", " PaisId = " + PaisOrigenDropDownList.SelectedValue, "");
            OrigenDropDownList.DataTextField = "Descripcion";
            OrigenDropDownList.DataValueField = "CiudadId";
            OrigenDropDownList.DataBind();
        }

        protected void PaisDestinoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ciudades Ciudad = new Ciudades();

            DestinoDropDownList.DataSource = Ciudad.Listado(" * ", " PaisId = " + PaisDestinoDropDownList.SelectedValue + "AND CiudadId <> " + OrigenDropDownList.SelectedValue, "");
            DestinoDropDownList.DataTextField = "Descripcion";
            DestinoDropDownList.DataValueField = "CiudadId";
            DestinoDropDownList.DataBind();
        }

        protected void TipoSolicitudIdDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Companias compania = new Companias();
            Categorias Categoria = new Categorias();

            CompaniaIdDropDownList.DataSource = compania.Listado(" * ", " TipoCompaniaId = " + TipoSolicitudIdDropDownList.SelectedValue, "");
            CompaniaIdDropDownList.DataTextField = "Descripcion";
            CompaniaIdDropDownList.DataValueField = "CompaniaId";
            CompaniaIdDropDownList.DataBind();

            CategoriaIdDropDownList.DataSource = Categoria.Listado(" * ", " TipoCategoriaId = " + TipoSolicitudIdDropDownList.SelectedValue, "");
            CategoriaIdDropDownList.DataTextField = "Descripcion";
            CategoriaIdDropDownList.DataValueField = "CategoriaId";
            CategoriaIdDropDownList.DataBind();

            if (TipoSolicitudIdDropDownList.SelectedValue == "1")
            {
                OrigenLabel.Visible = true;
                PaisOrigenDropDownList.Visible = true;
                OrigenDropDownList.Visible = true;
                EstadoCheckBox.Visible = true;
                EstadoLabel.Visible = true;
                FechaFinal.Visible = true;
            }

            if (TipoSolicitudIdDropDownList.SelectedValue == "2")
            {
                OrigenLabel.Visible = true;
                PaisOrigenDropDownList.Visible = true;
                OrigenDropDownList.Visible = true;
                EstadoCheckBox.Visible = false;
                EstadoLabel.Visible = false;
            }

            if (TipoSolicitudIdDropDownList.SelectedValue == "3")
            {
                OrigenLabel.Visible = false;
                PaisOrigenDropDownList.Visible = false;
                OrigenDropDownList.Visible = false;
                EstadoCheckBox.Visible = false;
                EstadoLabel.Visible = false;
                FechaFinal.Visible = false;
            }
        }

        protected void PrecioTextBox_TextChanged(object sender, EventArgs e)
        {
            double Total = 0;

            Total = Seguridad.ValidarDouble(PrecioTextBox.Text) * Seguridad.ValidarDouble(ImpuestoTextBox.Text);
            TotalTextBox.Text = Total.ToString();
        }

        protected void ImpuestoTextBox_TextChanged(object sender, EventArgs e)
        {
            double Total = 0;

            Total = Seguridad.ValidarDouble(PrecioTextBox.Text) * Seguridad.ValidarDouble(ImpuestoTextBox.Text);
            TotalTextBox.Text = Total.ToString();
        }

        protected void FechaInicialTextBox_TextChanged(object sender, EventArgs e)
        {
            CalendarExtender2.StartDate = Convert.ToDateTime(FechaInicialTextBox.Text).AddDays(2);
        }
    }
}