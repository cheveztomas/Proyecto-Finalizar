using System;
using System.Collections.Generic;
using System.Data;

using AccesoDatos;
using EntidadesDirectorio;

namespace CapaLogica
{
    public class LogicaUbicacionProf
    {
        #region Constructor
        // Constructor vacío
        #endregion

        #region Metodos
        public DataSet ListarUbicacionesProf(string pvc_Condicion)
        {
            DataSet vlo_DSUbicaciones;
            AccesoDatosUbicacionesProf vlo_AccesoDatosUbicaciones;
            try
            {
                vlo_AccesoDatosUbicaciones = new AccesoDatosUbicacionesProf();
                vlo_DSUbicaciones = vlo_AccesoDatosUbicaciones.ListarRegistros(pvc_Condicion);
            }
            catch (Exception)
            {
                throw;
            }
            return vlo_DSUbicaciones;
        }

        //Lista las UbicacionesProf, pvn_IdUsuario es para filtrar por el ID
        public DataSet ListarUbicacionesProf(int pvn_IdUsuario = 0)
        {
            DataSet vlo_DSUbicaciones;
            try
            {
                if (pvn_IdUsuario != 0)
                    vlo_DSUbicaciones = ListarUbicacionesProf("ID_USUARIO=" + pvn_IdUsuario);
                else
                    vlo_DSUbicaciones = ListarUbicacionesProf();
            }
            catch (Exception)
            {
                throw;
            }
            return vlo_DSUbicaciones;
        }

        //Lista las UbicacionesProf, pvn_IdUsuario es para filtrar por el ID del usuario
        public DataSet ListarUbicacionesProf(ClsUsuarios pvn_ClsUsuario)
        {
            DataSet vlo_DSUbicaciones;
            try
            {
                vlo_DSUbicaciones = ListarUbicacionesProf(pvn_ClsUsuario.ID_Usuario);
            }
            catch (Exception)
            {
                throw;
            }
            return vlo_DSUbicaciones;
        }

        public DataTable ObtenerDatosDeUsuarioUbicaciones(int id_usuario)
        {
            AccesoDatosUbicacionesProf AccesoDatosUbicaciones = new AccesoDatosUbicacionesProf();
            DataTable DatosDeUsuarioUbicaciones = null;
            try
            {
                DatosDeUsuarioUbicaciones = AccesoDatosUbicaciones.ObtenerDatosDeUsuarioUbicaciones(id_usuario);
                return DatosDeUsuarioUbicaciones;
            }
            catch
            {
                throw;
            }


        }
        //Guarda una ubicacionProf
        public string Guardar(ClsUbicacionesProfesionales pvo_EntidadUbicacionProf)
        {
            string vlc_Mensaje = "";
            AccesoDatosUbicacionesProf vlo_AccesoUbicacionProf;

            try
            {
                vlo_AccesoUbicacionProf = new AccesoDatosUbicacionesProf();
                vlc_Mensaje = vlo_AccesoUbicacionProf.Guardar(pvo_EntidadUbicacionProf);
            }
            catch (Exception)
            {

                throw;
            }
            return vlc_Mensaje;
        }
            //Guarda una ubicacionProf
            public string Guardar(int ID_Usuario, int ID_Ubicacion, string DETALLES)
            {
                string vlc_Mensaje = "";
                AccesoDatosUbicacionesProf vlo_AccesoUbicacionProf;
                ClsUbicacionesProfesionales pvo_EntidadUbicacionProf = new ClsUbicacionesProfesionales(ID_Usuario, ID_Ubicacion, DETALLES);
                try
                {
                    vlo_AccesoUbicacionProf = new AccesoDatosUbicacionesProf();
                    vlc_Mensaje = vlo_AccesoUbicacionProf.Guardar(pvo_EntidadUbicacionProf);
                }
                catch (Exception)
                {

                    throw;
                }
                return vlc_Mensaje;
            }
            //Borra una UbicacionProf
            public string Borrar(ClsUbicacionesProfesionales pvo_EntidadUbicacionProf)
        {
            string vlc_Mensaje = "";
            AccesoDatosUbicacionesProf vlo_AccesoDatosUbicacionesProf;

            try
            {
                vlo_AccesoDatosUbicacionesProf = new AccesoDatosUbicacionesProf();
                vlc_Mensaje = vlo_AccesoDatosUbicacionesProf.Borrar(pvo_EntidadUbicacionProf);
            }
            catch (Exception)
            {

                throw;
            }
            return vlc_Mensaje;
        }

        public string Borrar(int ID_Usuario, int ID_Ubicacion)
        {
            string vlc_Mensaje = "";
            AccesoDatosUbicacionesProf vlo_AccesoDatosUbicacionesProf;
            ClsUbicacionesProfesionales pvo_EntidadUbicacionProf = new ClsUbicacionesProfesionales(ID_Usuario, ID_Ubicacion, string.Empty);

            try
            {
                vlo_AccesoDatosUbicacionesProf = new AccesoDatosUbicacionesProf();
                vlc_Mensaje = vlo_AccesoDatosUbicacionesProf.Borrar(pvo_EntidadUbicacionProf);
            }
            catch (Exception)
            {

                throw;
            }
            return vlc_Mensaje;
        }
            #endregion
    }
}
