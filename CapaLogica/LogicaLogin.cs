using System;
using System.Collections.Generic;
using System.Text;
using AccesoDatos;
using EntidadesDirectorio;

namespace CapaLogica
{
    public class LogicaLogin
    {
        string vgc_Script = string.Empty;
        public int IniciarSesion(string pvc_Correo, string pvc_Password)
        {
            //Variables
            int vln_ID=0;
            AccesoDatosLogin vlo_Login;

            //Inicio
            try
            {
                vlo_Login = new AccesoDatosLogin();
                vln_ID = vlo_Login.IniciarSesion(pvc_Correo, pvc_Password);
            }
            catch (Exception)
            {

                throw;
            }

            return vln_ID;
        }

        public int RegistrarUsuario(string pvc_Password, ClsUsuarios pvo_Usuario)
        {
            //Variables
            int vln_ID=0;
            AccesoDatosLogin Login;

            //Inicio
            try
            {
                Login = new AccesoDatosLogin();
                vln_ID=Login.Registrar(pvc_Password, pvo_Usuario);
            }
            catch (Exception)
            {

                throw;
            }
            return vln_ID;
        }

        public int EnviarContrasenia(string pvc_Correo)
        {
            //Variables
            int vln_Correcto=0;
            AccesoDatosLogin Login = new AccesoDatosLogin();

            //Inicio
            try
            {
                vln_Correcto = Login.EnviarContrasenia(pvc_Correo);
            }
            catch (Exception)
            {

                throw;
            }
            return vln_Correcto;
        }

        public int CambiarContrasenia(string pvc_Contrasenia, int pvn_ID)
        {
            //Variables
            int vln_Correcto = 0;
            AccesoDatosLogin Login;

            //Inicio
            try
            {
                Login = new AccesoDatosLogin();
                vln_Correcto=Login.ActualizarContrasenia(pvc_Contrasenia, pvn_ID);
            }
            catch (Exception)
            {

                throw;
            }
            return vln_Correcto;
        }

        public int eliminarOcupacion(int pvn_idOcupacion, int pvn_idUsuario)
        {

            AccesoDatosOcupaciones accesoDatosOcupaciones = new AccesoDatosOcupaciones();
            int correcto = -1; // variable que obtiene el valor devuelto por la consulta

            try
            {
                correcto = accesoDatosOcupaciones.eliminarOcupacion(pvn_idOcupacion, pvn_idUsuario);
            }
            catch (Exception)
            {

                throw;
            }

            return correcto;

        }
    }
}
