using CapaLogica;
using System;
using System.Web.UI;

namespace DirectorioServicios
{
    public partial class FrmCambiarPass : System.Web.UI.Page
    {
        private int vgn_ID = 0;
        string vgc_Script = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            vgn_ID = int.Parse(Session["ID_USUARIO_SESION"].ToString());
            if (!Page.IsPostBack)
            {
                Limpiar();
               
            }
        }

        private void Limpiar()
        {
            txt_Conrteasenia.Text = string.Empty;
            txt_ConrteaseniaConfir.Text = string.Empty;
        }

        private int CambiarContrasenia()
        {
            //Variables
            int vln_Correcto = 0;
            LogicaLogin vlo_Login;

            //Inicio
            try
            {
                vlo_Login = new LogicaLogin();
                vln_Correcto = vlo_Login.CambiarContrasenia(txt_Conrteasenia.Text, vgn_ID);
            }
            catch (Exception)
            {

                throw;
            }

            return vln_Correcto;
        }

        protected void btn_Registrar_Click(object sender, EventArgs e)
        {
            //Variables
            int vlc_Correcto = 0;
            try
            {
                vlc_Correcto = CambiarContrasenia();

                if (vlc_Correcto < 0)
                {
                    vgc_Script = string.Format("javascript:MostrarMensaje('Contraseña no se ha podido cambiar');");

                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", vgc_Script, true);
                }
                else
                {
                    if (vlc_Correcto>0)
                    {
                        vgc_Script = string.Format("javascript:MostrarMensaje('Contraseña guardada de forma correcta.');");

                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", vgc_Script, true);
                    }

                }
            }
            catch (Exception)
            {

                vgc_Script = string.Format("javascript:MostrarMensaje('Error al cambiar la contraseña.');");

                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", vgc_Script, true);
            }
        }
    }
}