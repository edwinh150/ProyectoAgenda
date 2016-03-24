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
        Seguridad Seguro = new Seguridad();
        int Eleccion = 0;

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
            RequiredFieldValidator1.IsValid = true;
            RequiredFieldValidator2.IsValid = true;
            RequiredFieldValidator3.IsValid = true;
            RequiredFieldValidator4.IsValid = true;
            RequiredFieldValidator5.IsValid = true;
        }

        public void LlenarForm()
        {
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
            OrigenDropDownList.SelectedIndex = Seguro.ValidarEntero(SolicitudDetalle.Origen);
            DestinoDropDownList.SelectedIndex = Seguro.ValidarEntero(SolicitudDetalle.Destino);
            FechaInicialTextBox.Text = SolicitudDetalle.FechaInicial.ToString("dd/MM/yyyy");
            FechaFinalTextBox.Text = SolicitudDetalle.FechaFinal.ToString("dd/MM/yyyy");
            PrecioInicialTextBox.Text = SolicitudDetalle.PrecioInicial.ToString();
            PrecioFinalTextBox.Text = SolicitudDetalle.PrecioFinal.ToString();
            CantidadPersonaDropDownList.SelectedIndex = SolicitudDetalle.CantidadPersona;
            CantidadNinoDropDownList.SelectedIndex = SolicitudDetalle.CantidadNino;
            CantidadBebeDropDownList.SelectedIndex = SolicitudDetalle.CantidadBebe;
            DetalleGridView.DataSource = Solicitud.DetalleText;
            DetalleGridView.DataBind();
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
        }

        bool LLenarDatos()
        {
            bool retorno = false;

            if (AsuntoTextBox.Text.Length > 0)
            {
                Solicitud.Asunto = AsuntoTextBox.Text;
                Solicitud.FechaCreacion = DateTime.Now;
                Solicitud.UsuarioId = Usuarios.Id;

                if (DetalleGridView.Rows.Count > 0)
                {
                    foreach (GridViewRow dr in DetalleGridView.Rows)
                    {
                        Solicitud.AgregarSolicitud(Seguro.ValidarEntero(dr.Cells[0].Text), Seguro.ValidarEntero(dr.Cells[1].Text), Seguro.ValidarEntero(dr.Cells[2].Text), Seguro.ValidarEntero(dr.Cells[3].Text), dr.Cells[4].Text, dr.Cells[5].Text, Seguro.ValidarDateTime(dr.Cells[6].Text), Seguro.ValidarDateTime(dr.Cells[7].Text), Seguro.ValidarEntero(dr.Cells[8].Text), Seguro.ValidarEntero(dr.Cells[9].Text), Seguro.ValidarEntero(dr.Cells[10].Text), Seguro.ValidarDouble(dr.Cells[11].Text), Seguro.ValidarDouble(dr.Cells[12].Text));
                    }
                }
                else
                {
                    retorno = false;
                }

                retorno = true;
            }
            else
            {
                retorno = false;
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
                    Solicitud.SolicitudId = Seguro.ValidarEntero(SolicitudIdTextBox.Text);

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
                if (Seguro.ValidarEntero(SolicitudIdTextBox.Text) > 0)
                {
                    Solicitud.SolicitudId = Seguro.ValidarEntero(SolicitudIdTextBox.Text);

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
            
            int Id = Seguro.ValidarEntero(SolicitudIdTextBox.Text);
            ValidacionLimpiar();

            if (Id > 0)
            {
                if (Solicitud.Buscar(Id))
                {
                    LlenarForm();
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
            }
        }

        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
            
        }

        protected void AgregarDetalleButton_Click(object sender, EventArgs e)
        {
            Solicitudes SolicitudDetalle;
            if (FechaInicialTextBox.Text.Length > 0 && FechaFinalTextBox.Text.Length > 0 && PrecioInicialTextBox.Text.Length > 0 && PrecioFinalTextBox.Text.Length > 0)
            {
                if (EstadoCheckBox.Checked == true)
                {
                    Eleccion = 1; // ida
                }
                else
                {
                    Eleccion = 0; // ida/vuelta
                }

                if (Session["SolicitudSession"] == null)
                {
                    Session["SolicitudSession"] = new Solicitudes();
                }

                SolicitudDetalle = (Solicitudes)Session["SolicitudSession"];

                SolicitudDetalle.AgregarSolicitud(Eleccion, Seguro.ValidarEntero(TipoSolicitudIdDropDownList.SelectedValue), Seguro.ValidarEntero(CompaniaIdDropDownList.SelectedValue), Seguro.ValidarEntero(CategoriaIdDropDownList.SelectedValue), OrigenDropDownList.SelectedItem.Text, DestinoDropDownList.SelectedItem.Text, Seguro.ValidarDateTime(FechaInicialTextBox.Text), Seguro.ValidarDateTime(FechaFinalTextBox.Text), Seguro.ValidarEntero(CantidadPersonaDropDownList.SelectedValue), Seguro.ValidarEntero(CantidadNinoDropDownList.SelectedValue), Seguro.ValidarEntero(CantidadBebeDropDownList.SelectedValue), Seguro.ValidarDouble(PrecioInicialTextBox.Text), Seguro.ValidarDouble(PrecioFinalTextBox.Text));

                SolicitudDetalle.AgregarSolicitudText(Eleccion, TipoSolicitudIdDropDownList.SelectedItem.Text, CompaniaIdDropDownList.SelectedItem.Text, CategoriaIdDropDownList.SelectedItem.Text, OrigenDropDownList.SelectedItem.Text, DestinoDropDownList.SelectedItem.Text, Seguro.ValidarDateTime(FechaInicialTextBox.Text), Seguro.ValidarDateTime(FechaFinalTextBox.Text), Seguro.ValidarEntero(CantidadPersonaDropDownList.SelectedValue), Seguro.ValidarEntero(CantidadNinoDropDownList.SelectedValue), Seguro.ValidarEntero(CantidadBebeDropDownList.SelectedValue), Seguro.ValidarDouble(PrecioInicialTextBox.Text), Seguro.ValidarDouble(PrecioFinalTextBox.Text));

                Session["SolicitudSession"] = SolicitudDetalle;

                DetalleGridView.DataSource = SolicitudDetalle.Detalle;
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
    }
}