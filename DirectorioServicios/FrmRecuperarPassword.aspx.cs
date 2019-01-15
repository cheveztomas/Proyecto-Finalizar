using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogica;

namespace DirectorioServicios
{
    public partial class FrmRecuerarContraseña : System.Web.UI.Page
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
            txt_Correo.Text = string.Empty;
        }

        protected void btn_Recuperar_Click(object sender, EventArgs e)
        {
            LogicaLogin Logica;
            int vln_Correcto = 0;

            //Inicio
            try
            {
                Logica = new LogicaLogin();
                vln_Correcto=Logica.EnviarContrasenia(txt_Correo.Text);
                if (vln_Correcto > 0)
                {
                    vgc_Script = string.Format("javascript:MostrarMensaje('Correo electrónico enviado de forma correcta. Revise la bandeja de entrada de su correo electrónico.');");

                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", vgc_Script, true);
                }
                else
                {
                    vgc_Script = string.Format("javascript:MostrarMensaje('Lo sentimos, pero ocurrió un error inesperado. No se ha podido enviar el correo electrónico con la contraseña intenta más tarde.');");

                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", vgc_Script, true);
                }
            }
            catch (Exception)
            {

                vgc_Script = string.Format("javascript:MostrarMensaje('Lo sentimos, pero ocurrió un error inesperado. No se ha podido enviar el correo electrónico con la contraseña intenta más tarde.');");

                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", vgc_Script, true);
            }
        }
    }
}