using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogica;
using EntidadesDirectorio;

namespace DirectorioServicios
{
    public partial class FrmRegistrar : System.Web.UI.Page
    {
        string vgc_Script = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Limpiar();
            }
        }
        private void Limpiar()
        {
            Txt_Apellido1.Text = string.Empty;
            Txt_Apellido2.Text = string.Empty;
            txt_ConrteaseniaConfir.Text = string.Empty;
            txt_Conrteasenia.Text = string.Empty;
            txt_Correo.Text = string.Empty;
            Txt_Descipcion.Text = string.Empty;
            txt_Nombre.Text = string.Empty;
            Txt_Telefono.Text = string.Empty;
        }
        private void Registro()
        {
            //Varaibles
            int vln_ID = 0;
            string Contrasenia=string.Empty;
            LogicaLogin LogicaLog = new LogicaLogin();
            ClsUsuarios Usuario = new ClsUsuarios();

            //Inicio
            try
            {
                Usuario.Apellido1_Profesional = Txt_Apellido1.Text;
                Usuario.Apellido2_Profesional = Txt_Apellido2.Text;
                Usuario.Calif_Contador = 0;
                Usuario.Calif_Suma = 0;
                Usuario.Correo = txt_Correo.Text;
                Usuario.Descripcion = Txt_Descipcion.Text;
                Usuario.ID_Usuario = -1;
                Usuario.Nombre_Profesional = txt_Nombre.Text;
                Usuario.Perfil_Profesional = true;
                Usuario.Telefono_Profesional = Txt_Telefono.Text;
                Usuario.Usuario_Premium = false;
                Contrasenia = txt_Conrteasenia.Text;

                vln_ID=LogicaLog.RegistrarUsuario(Contrasenia, Usuario);

                if (vln_ID == -2)
                {
                    vgc_Script = string.Format("javascript:MostrarMensaje('Correo ya se encuantra registrado. Inicie sesión.');");

                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", vgc_Script, true);

                }
                else
                {
                    if (vln_ID>0)
                    {
                        vgc_Script = string.Format("javascript:MostrarMensaje('Registro realizado de forma correcta. Inicie sesión.');");

                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", vgc_Script, true);

                        Limpiar();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btn_Registrar_Click(object sender, EventArgs e)
        {
            try
            {
                Registro();
            }
            catch (Exception ex)
            {

                vgc_Script = string.Format("javascript:MostrarMensaje('Error al tratar de registrarse intente más tarde.');");

                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", vgc_Script, true);
            }

        }

        protected void btn_InSec_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmIniciarSesion.aspx");
        }
    }
}