using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia.Registros
{
    public partial class rSolicitudes : System.Web.UI.Page
    {
        Solicitudes Solicitud = new Solicitudes();
        SolicitudDetalles SolicitudDetalle = new SolicitudDetalles();
        int Eleccion = 0;
        string EleccionText = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuarios Usuario = new Usuarios();

                LlenarDropDownList();
                UsuarioIdLabel.Text = Context.User.Identity.Name;
                if (Usuarios.Id == 0)
                {
                    Usuario.NombreUsuario = UsuarioIdLabel.Text;
                    Usuario.Comprobar();
                }
                FechaCreacionLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
                EliminarButton.Visible = false;
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
            TipoSolicitudIdDropDownList.DataSource = TipoSolicitud.Listado("*", "1=1", "");
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
            SolicitudIdDiv.Attributes.Remove("class");
            SolicitudIdDiv.Attributes.Add("class", "col-md-8");

            AsuntoDiv.Attributes.Remove("class");
            AsuntoDiv.Attributes.Add("class", "col-md-8");

            PrecioInicioDiv.Attributes.Remove("class");
            PrecioInicioDiv.Attributes.Add("class", "col-md-4");

            PrecioFinalDiv.Attributes.Remove("class");
            PrecioFinalDiv.Attributes.Add("class", "col-md-4");
        }

        public void LlenarForm()
        {
            ValidacionLimpiar();
            UsuarioIdLabel.Text = Solicitud.UsuarioId.ToString();
            FechaCreacionLabel.Text = Solicitud.FechaCreacion.ToString("dd/MM/yyyy");
            AsuntoTextBox.Text = Solicitud.Asunto;

            TipoSolicitudIdDropDownList.SelectedIndex = SolicitudDetalle.TipoSolicitudId;
            CompaniaIdDropDownList.SelectedIndex = SolicitudDetalle.CompaniaId;
            CategoriaIdDropDownList.SelectedIndex = SolicitudDetalle.CategoriaId;
            if (SolicitudDetalle.EleccionDestino == 0)
            {
                EstadoCheckBox.Checked = false;
            }
            else
            {
                EstadoCheckBox.Checked = true;
            }
            OrigenDropDownList.SelectedIndex = Seguridad.ValidarEntero(SolicitudDetalle.Origen);
            DestinoDropDownList.SelectedIndex = Seguridad.ValidarEntero(SolicitudDetalle.Destino);
            FechaInicialTextBox.Text = SolicitudDetalle.FechaInicial.ToString("dd/MM/yyyy");
            FechaFinalTextBox.Text = SolicitudDetalle.FechaFinal.ToString("dd/MM/yyyy");
            PrecioInicialTextBox.Text = SolicitudDetalle.PrecioInicial.ToString();
            PrecioFinalTextBox.Text = SolicitudDetalle.PrecioFinal.ToString();
            CantidadPersonaDropDownList.SelectedIndex = SolicitudDetalle.CantidadPersona;
            CantidadNinoDropDownList.SelectedIndex = SolicitudDetalle.CantidadNino;
            CantidadBebeDropDownList.SelectedIndex = SolicitudDetalle.CantidadBebe;
            DetalleTextGridView.DataSource = Solicitud.DetalleText;
            DetalleTextGridView.DataBind();
        }

        public void Limpiar()
        {
            SolicitudIdTextBox.Text = "";
            AsuntoTextBox.Text = "";
            FechaInicialTextBox.Text = "";
            FechaFinalTextBox.Text = "";
            PrecioInicialTextBox.Text = "";
            PrecioFinalTextBox.Text = "";
            ValidacionLimpiar();
            DetalleGridView.DataSource = string.Empty;
            DetalleGridView.DataBind();
            DetalleTextGridView.DataSource = string.Empty;
            DetalleTextGridView.DataBind();
            GuardarButton.Text = "Guardar";
            EliminarButton.Visible = false;
        }

        bool LLenarDatos()
        {
            bool retorno = true;
            ValidacionLimpiar();

            if (!Seguridad.ValidarNombre(AsuntoTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Asunto Invalido", "Error");
                AsuntoDiv.Attributes.Add("class", " col-md-8 has-error ");
                retorno = false;
            }
            if (retorno)
            {

                Solicitud.Asunto = AsuntoTextBox.Text;
                Solicitud.FechaCreacion = DateTime.Now;                                
                Solicitud.UsuarioId = Usuarios.Id;

                if (DetalleGridView.Rows.Count > 0)
                {
                    foreach (GridViewRow dr in DetalleGridView.Rows)
                    {
                        Solicitud.AgregarSolicitud(Seguridad.ValidarEntero(dr.Cells[0].Text), Seguridad.ValidarEntero(dr.Cells[1].Text), Seguridad.ValidarEntero(dr.Cells[2].Text), Seguridad.ValidarEntero(dr.Cells[3].Text), dr.Cells[4].Text, dr.Cells[5].Text, Seguridad.ValidarDateTime(dr.Cells[6].Text), Seguridad.ValidarDateTime(dr.Cells[7].Text), Seguridad.ValidarEntero(dr.Cells[8].Text), Seguridad.ValidarEntero(dr.Cells[9].Text), Seguridad.ValidarEntero(dr.Cells[10].Text), Seguridad.ValidarDouble(dr.Cells[11].Text), Seguridad.ValidarDouble(dr.Cells[12].Text));
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
            Solicitudes SolicitudDetalle;

            if (Session["SolicitudSession"] == null)
            {
                Session["SolicitudSession"] = new Solicitudes();
            }

            SolicitudDetalle = (Solicitudes)Session["SolicitudSession"];

            if (SolicitudIdTextBox.Text.Length > 0)
            {
                if (LLenarDatos())
                {
                    Solicitud.SolicitudId = Seguridad.ValidarEntero(SolicitudIdTextBox.Text);

                    if (Solicitud.Editar())
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
                    if (Solicitud.Insertar())
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
            if (SolicitudIdTextBox.Text.Length > 0)
            {
                if (Seguridad.ValidarEntero(SolicitudIdTextBox.Text) > 0)
                {
                    Solicitud.SolicitudId = Seguridad.ValidarEntero(SolicitudIdTextBox.Text);

                    if (Solicitud.Eliminar())
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

            if (!Seguridad.ValidarSoloNumero(SolicitudIdTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Id de Solicitud Invalido", "Error");
                SolicitudIdDiv.Attributes.Add("class", " col-md-8 has-error ");
                retorno = false;
            }

            if (retorno)
            {
                Id = Seguridad.ValidarEntero(SolicitudIdTextBox.Text);
            }

            if (Id > 0)
            {
                if (Solicitud.Buscar(Id))
                {
                    LlenarForm();
                    EliminarButton.Visible = true;
                    GuardarButton.Text = "Modificar";

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
            }
        }

        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
            
        }

        protected void AgregarDetalleButton_Click(object sender, EventArgs e)
        {
            Solicitudes SolicitudDetalle;
            bool retorno = true;
            ValidacionLimpiar();

            if (!Seguridad.ValidarSoloNumero(PrecioInicialTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Precio Invalido", "Error");
                PrecioInicioDiv.Attributes.Add("class", " col-md-4 has-error ");
                retorno = false;
            }

            if (!Seguridad.ValidarSoloNumero(PrecioFinalTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Precio Invalido", "Error");
                PrecioFinalDiv.Attributes.Add("class", " col-md-4 has-error ");
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
            else
            {
                retorno = false;
            }


            if (retorno == true)
            {
                if (Session["SolicitudSession"] == null)
                {
                    Session["SolicitudSession"] = new Solicitudes();
                }

                SolicitudDetalle = (Solicitudes)Session["SolicitudSession"];

                SolicitudDetalle.AgregarSolicitud(Eleccion, Seguridad.ValidarEntero(TipoSolicitudIdDropDownList.SelectedValue), Seguridad.ValidarEntero(CompaniaIdDropDownList.SelectedValue), Seguridad.ValidarEntero(CategoriaIdDropDownList.SelectedValue), OrigenDropDownList.SelectedItem.Text, DestinoDropDownList.SelectedItem.Text, Seguridad.ValidarDateTime(FechaInicialTextBox.Text), Seguridad.ValidarDateTime(FechaFinalTextBox.Text), Seguridad.ValidarEntero(CantidadPersonaDropDownList.SelectedValue), Seguridad.ValidarEntero(CantidadNinoDropDownList.SelectedValue), Seguridad.ValidarEntero(CantidadBebeDropDownList.SelectedValue), Seguridad.ValidarDouble(PrecioInicialTextBox.Text), Seguridad.ValidarDouble(PrecioFinalTextBox.Text));

                SolicitudDetalle.AgregarSolicitudText(EleccionText, TipoSolicitudIdDropDownList.SelectedItem.Text, CompaniaIdDropDownList.SelectedItem.Text, CategoriaIdDropDownList.SelectedItem.Text, OrigenDropDownList.SelectedItem.Text, DestinoDropDownList.SelectedItem.Text, Seguridad.ValidarDateTime(FechaInicialTextBox.Text), Seguridad.ValidarDateTime(FechaFinalTextBox.Text), Seguridad.ValidarEntero(CantidadPersonaDropDownList.SelectedValue), Seguridad.ValidarEntero(CantidadNinoDropDownList.SelectedValue), Seguridad.ValidarEntero(CantidadBebeDropDownList.SelectedValue), Seguridad.ValidarDouble(PrecioInicialTextBox.Text), Seguridad.ValidarDouble(PrecioFinalTextBox.Text));

                Session["SolicitudSession"] = SolicitudDetalle;

                DetalleGridView.DataSource = SolicitudDetalle.Detalle;
                DetalleGridView.DataBind();
                DetalleTextGridView.DataSource = SolicitudDetalle.DetalleText;
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

        protected void FechaInicialTextBox_TextChanged(object sender, EventArgs e)
        {
            CalendarExtender2.StartDate = Convert.ToDateTime(FechaInicialTextBox.Text).AddDays(2);
        }
    }
}