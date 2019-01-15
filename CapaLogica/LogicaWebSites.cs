using System;
using System.Collections.Generic;
using System.Data;

using AccesoDatos;
using EntidadesDirectorio;

namespace CapaLogica
{
    public class LogicaWebSites
    {
        #region Constructor
        // Constructor vacío
        #endregion

        #region Metodos
        
        //Lista los sitios web, pvc_Condicion es para filtrar los resultados
        public DataSet ListarWebSites(string pvc_Condicion)
        {
            DataSet vlo_DSWebSites;
            AccesoDatosWebSites vlo_AccesoDatosWebSites;
            try
            {
                vlo_AccesoDatosWebSites = new AccesoDatosWebSites();
                vlo_DSWebSites = vlo_AccesoDatosWebSites.ListarRegistros(pvc_Condicion);
            }
            catch (Exception)
            {
                throw;
            }
            return vlo_DSWebSites;
        }

        //Lista los sitios web, pvn_IdUsuario es para filtrar por el ID
        public DataSet ListarWebSites(int pvn_IdUsuario = 0)
        {
            DataSet vlo_DSWebSites;
            try
            {
                if (pvn_IdUsuario != 0)
                    vlo_DSWebSites = ListarWebSites("ID_USUARIO=" + pvn_IdUsuario);
                else
                    vlo_DSWebSites = ListarWebSites();
            }
            catch (Exception)
            {
                throw;
            }
            return vlo_DSWebSites;
        }

        //Lista los sitios web, pvn_ClsUsuario es para filtrar por el ID del usuario
        public DataSet ListarWebSites(ClsUsuarios pvn_ClsUsuario)
        {
            DataSet vlo_DSWebSites;
            try
            {
                vlo_DSWebSites = ListarWebSites(pvn_ClsUsuario.ID_Usuario);
            }
            catch (Exception)
            {
                throw;
            }
            return vlo_DSWebSites;
        }

        //Guarda o actualiza un sitio web
        public string Guardar(ClsWebSites pvo_EntidadWebSite)
        {
            string vlc_Mensaje = "";
            AccesoDatosWebSites vlo_AccesoDatosWebSites;

            try
            {
                vlo_AccesoDatosWebSites = new AccesoDatosWebSites();
                vlc_Mensaje = vlo_AccesoDatosWebSites.Guardar(pvo_EntidadWebSite);
            }
            catch (Exception)
            {

                throw;
            }
            return vlc_Mensaje;
        }

        //Guarda o actualiza un sitio web
        public string Guardar(int Cod_Sitio, int ID_Usuario, string URL_Sitio, string Nombre_Sitio)
        {
            string vlc_Mensaje = "";
            AccesoDatosWebSites vlo_AccesoDatosWebSites;
            ClsWebSites pvo_EntidadWebSite = new ClsWebSites(Cod_Sitio, ID_Usuario, URL_Sitio, Nombre_Sitio);

            try
            {
                vlo_AccesoDatosWebSites = new AccesoDatosWebSites();
                vlc_Mensaje = vlo_AccesoDatosWebSites.Guardar(pvo_EntidadWebSite);
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

        public DataTable ObtenerDatosDeUsuarioPaginasWeb(int id_usuario)
        {
            AccesoDatosWebSites AccesoDatosWebsites = new AccesoDatosWebSites();
            DataTable DatosDeUsuarioWebsites = null;
            try
            {
                DatosDeUsuarioWebsites = AccesoDatosWebsites.ObtenerDatosDeUsuarioPaginasWeb(id_usuario);
            }
            catch (Exception)
            {

                throw;
            }

            return DatosDeUsuarioWebsites;
        }
        #endregion
    }
}
