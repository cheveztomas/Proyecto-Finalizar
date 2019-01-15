using AccesoDatos;
using EntidadesDirectorio;
using System;
using System.Data;

namespace CapaLogica
{
    public class LogicaUsuario
    {


        public DataTable listaUsuarios(string condition)
        {
            AccesoDatosUsuario accesoDatosUsuario = new AccesoDatosUsuario();
            DataTable lista = null;
            try
            {
                lista = accesoDatosUsuario.listaUsuarios(condition);
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }

        //Guarda o Actualiza un usuario
        public int IngresarUsuario(ClsUsuarios pvo_Usuario)
        {
            //Variables
            int vln_Correcto = 0;

            //Inicio
            AccesoDatosUsuario vlo_ADUsuario = new AccesoDatosUsuario();

            try
            {
                vln_Correcto = vlo_ADUsuario.InsertarUsuario(pvo_Usuario);
            }
            catch (Exception)
            {

                throw;
            }

            return vln_Correcto;
        }

        //Guarda o Actualiza un usuario
        public int IngresarUsuario(int vgn_ID_Usuario, string vgc_Nombre_Profesional, string vgc_Apellido1_Profesional, string vgc_Apellido2_Profesional, string vgc_correo, string vgc_Telefono_Profesional, string vgc_Descripcion, bool vgb_Usuario_Premium, int vgn_Calif_Contador, int vgn_Calif_Suma, bool vgb_Perfil_Profesional)
        {
            //Variables
            int vln_Correcto = 0;
            ClsUsuarios pvo_Usuario = new ClsUsuarios(vgn_ID_Usuario, vgc_Nombre_Profesional, vgc_Apellido1_Profesional, vgc_Apellido2_Profesional, vgc_correo, vgc_Telefono_Profesional, vgc_Descripcion, vgb_Usuario_Premium, vgn_Calif_Contador, vgn_Calif_Suma, vgb_Perfil_Profesional);
            //Inicio
            AccesoDatosUsuario vlo_ADUsuario = new AccesoDatosUsuario();

            try
            {
                vln_Correcto = vlo_ADUsuario.InsertarUsuario(pvo_Usuario);
            }
            catch (Exception)
            {

                throw;
            }

            return vln_Correcto;
        }

        //Elimina un usuario
        public int EliminarUsuario(int id_Usuario)
        {
            //Variables
            int vln_Correcto = 0;
            //Inicio
            AccesoDatosUsuario vlo_ADUsuario = new AccesoDatosUsuario();

            try
            {
                vln_Correcto = vlo_ADUsuario.EliminarUsuario(id_Usuario);
            }
            catch (Exception)
            {

                throw;
            }

            return vln_Correcto;
        }

        public ClsUsuarios ObtenerDatosDeUsuario(int id_usuario)
        {
            AccesoDatosUsuario accesoDatosUsuario = new AccesoDatosUsuario();
            ClsUsuarios DatosUsuario;
            try
            {
                DatosUsuario = accesoDatosUsuario.ObtenerDatosDeUsuario(id_usuario);
            }
            catch (Exception)
            {

                throw;
            }

            return DatosUsuario;
        }

        //Guarda o actualiza un Usuario
        public string Guardar(ClsUsuarios pvo_EntidadUsuario)
        {
            string vlc_Mensaje = "";
            AccesoDatosUsuario vlo_AccesoDatosUsuario;

            try
            {
                vlo_AccesoDatosUsuario = new AccesoDatosUsuario();
                vlc_Mensaje = vlo_AccesoDatosUsuario.Guardar(pvo_EntidadUsuario);
            }
            catch (Exception)
            {

                throw;
            }
            return vlc_Mensaje;
        }

        //Guarda o actualiza un Usuario
        public string Guardar(int vgn_ID_Usuario, string vgc_Nombre_Profesional, string vgc_Apellido1_Profesional, string vgc_Apellido2_Profesional, string vgc_correo, string vgc_Telefono_Profesional, string vgc_Descripcion, bool vgb_Usuario_Premium, int vgn_Calif_Contador, int vgn_Calif_Suma, bool vgb_Perfil_Profesional)
        {
            string vlc_Mensaje = "";
            AccesoDatosUsuario vlo_AccesoDatosUsuario;
            ClsUsuarios pvo_EntidadUsuario = new ClsUsuarios(vgn_ID_Usuario, vgc_Nombre_Profesional, vgc_Apellido1_Profesional, vgc_Apellido2_Profesional, vgc_correo, vgc_Telefono_Profesional, vgc_Descripcion, vgb_Usuario_Premium, vgn_Calif_Contador, vgn_Calif_Suma, vgb_Perfil_Profesional);

            try
            {
                vlo_AccesoDatosUsuario = new AccesoDatosUsuario();
                vlc_Mensaje = vlo_AccesoDatosUsuario.Guardar(pvo_EntidadUsuario);
            }
            catch (Exception)
            {

                throw;
            }
            return vlc_Mensaje;
        }

        //Borra un sitio web
        public string Borrar(string pvc_Codigo)
        {
            string vlc_Mensaje = "";
            AccesoDatosWebSites vlo_AccesoDatosWebSites;

            try
            {
                vlo_AccesoDatosWebSites = new AccesoDatosWebSites();
                vlc_Mensaje = vlo_AccesoDatosWebSites.Borrar(pvc_Codigo);
            }
            catch (Exception)
            {

                throw;
            }
            return vlc_Mensaje;
        }


        //procedimiento que retorna los profecionales segun la busqueda
        public DataTable obtenerProfecionales(string pvc_profecion, string pvc_especialidad, string pvc_provincia, string pvc_canton)
        {
            try
            {
                AccesoDatosUsuario funciones = new AccesoDatosUsuario();
                DataTable lista = funciones.obtenerProfecionales(pvc_profecion, pvc_especialidad, pvc_provincia, pvc_canton);
                return lista;
            }
            catch (Exception)
            {

                throw;
            }

        }

    }//class
}//namespace
