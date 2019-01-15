using CapaLogica;
using System;
using System.Web.UI;
using System.Text;
using System.Web.UI.HtmlControls;
namespace DirectorioServicios
{
    public partial class FrmIniciarSesion : System.Web.UI.Page
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
            txt_Contrasenia.Text = string.Empty;
            txt_Correo.Text = string.Empty;
            Session.Remove("ID_USUARIO_SESION");
        }

        private void IniciarSesion()
        {
            //Variables
            int vln_IDUsuario = 0;
            LogicaLogin vlo_Logica = new LogicaLogin();

            //Inicio

            try
            {
                //Se invica al metodo que inicia sesión.
                vln_IDUsuario = vlo_Logica.IniciarSesion(txt_Correo.Text, txt_Contrasenia.Text);

                if (vln_IDUsuario > 0)
                {
                    //Se guarda en un variable de sesión el id del usuario.
                    Session["ID_USUARIO_SESION"] = vln_IDUsuario;
                    Response.Redirect("FrmPerfilProfesional.aspx");
                }
                else
                {
                    vgc_Script = string.Format("javascript:MostrarMensaje('Usuario o contraseña incorrectos.');");

                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", vgc_Script, true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btn_IniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                IniciarSesion();
            }
            catch (Exception)
            {

                vgc_Script = string.Format("javascript:MostrarMensaje('Error al iniciar sesión intente más tarde');");

                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", vgc_Script, true);
            }
        }
    }
}