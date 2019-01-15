using System;
using System.Collections.Generic;
using System.Data;

using Configuracion;
using EntidadesDirectorio;
using MySql.Data.MySqlClient;

namespace AccesoDatos
{
    public class AccesoDatosUbicacionesProf
    {
        #region Atributos
        string vgc_CadenaConexion;
        #endregion

        #region Constructores
        public AccesoDatosUbicacionesProf()
        {
            //vgc_CadenaConexion = string.Empty;
            vgc_CadenaConexion = ClsConfiguracion.getConnectionString();
        }
        // Constructor que recibe la cadena como parametro
        public AccesoDatosUbicacionesProf(string pvc_CadenaConeccion)
        {
            vgc_CadenaConexion = pvc_CadenaConeccion;
        }
        #endregion

        #region Metodos
        public DataSet ListarRegistros(string pvc_Condicion)
        {
            DataSet vlo_DataSet = new DataSet();
            MySqlConnection vlo_Conexion = new MySqlConnection(vgc_CadenaConexion);
            MySqlDataAdapter vlo_DataAdapter;
            string vlc_Sentencia = string.Empty;

            vlc_Sentencia = "SELECT UBICACIONES.ID_UBICACION,ID_USUARIO,PROVINCIA,CANTON,DETALLES FROM UBICACIONES_PROFESIONALES" +
                " INNER JOIN UBICACIONES ON UBICACIONES_PROFESIONALES.ID_UBICACION=UBICACIONES.ID_UBICACION";
            if (!string.IsNullOrEmpty(pvc_Condicion))
            {
                vlc_Sentencia = string.Format("{0} WHERE {1}", vlc_Sentencia, pvc_Condicion);
            }

            try
            {
                vlo_DataAdapter = new MySqlDataAdapter(vlc_Sentencia, vlo_Conexion);
                vlo_DataAdapter.Fill(vlo_DataSet, "UbicacionesProf"); // nombre de la tabla encontrada
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                vlo_Conexion.Dispose();
            }
            return vlo_DataSet;
        }

        public DataTable ObtenerDatosDeUsuarioUbicaciones(int id_usuario)
        {
            MySqlCommand command;
            MySqlDataAdapter vlo_DA;
            DataTable vlo_DatosUsuarioUbicaciones = new DataTable();
            MySqlConnection conexion = new MySqlConnection();
            conexion.ConnectionString = ClsConfiguracion.getConnectionString();

            try
            {
                //Se abre la conexión.
                conexion.Open();

                //Se instancia el comando con la sentencia.
                command = new MySqlCommand("SELECT UBICACIONES_PROFESIONALES.ID_USUARIO,UBICACIONES_PROFESIONALES.ID_UBICACION,PROVINCIA,CANTON,DETALLES FROM UBICACIONES INNER JOIN UBICACIONES_PROFESIONALES ON UBICACIONES.ID_UBICACION=UBICACIONES_PROFESIONALES.ID_UBICACION WHERE UBICACIONES_PROFESIONALES.ID_USUARIO=" + id_usuario);
                //
                //Se establese la conexión.
                command.Connection = conexion;

                //Se instancia el data adpter con el comando.
                vlo_DA = new MySqlDataAdapter(command);

                //Se rellena la tabla 
                vlo_DA.Fill(vlo_DatosUsuarioUbicaciones);

                vlo_DA.Dispose();
                conexion.Close();
                command.Dispose();
                conexion.Dispose();
            }
            catch (MySqlException ex)
            {

                Console.WriteLine("error, " + ex.Message.ToString());
            }

            return vlo_DatosUsuarioUbicaciones;
        }

        public string Guardar(ClsUbicacionesProfesionales pvo_EntidadUbicacionProf)
        {
            MySqlConnection vlo_sqlConexion = new MySqlConnection(vgc_CadenaConexion);
            MySqlCommand vlo_sqlCommand = new MySqlCommand();
            //int vln_resultado = 0;
            string vlc_Mensaje = "";
            string vlc_Sentencia = string.Empty; //tambien puede usar ""
            vlo_sqlCommand.Connection = vlo_sqlConexion;

            vlc_Sentencia = "SP_AgregarUbicacionProfecional";
            vlo_sqlCommand.CommandType = CommandType.StoredProcedure;
            vlo_sqlCommand.Parameters.AddWithValue("@_ID_USUARIO", pvo_EntidadUbicacionProf.ID_Usuario);
            //vlo_sqlCommand.Parameters["@_cod_sitio"].Direction = ParameterDirection.InputOutput;
            vlo_sqlCommand.Parameters.AddWithValue("@_ID_UBICACION", pvo_EntidadUbicacionProf.ID_Ubicacion1);
            vlo_sqlCommand.Parameters.AddWithValue("@_DETALLES", pvo_EntidadUbicacionProf.Detalles);
            vlo_sqlCommand.Parameters.Add("@_msj", MySqlDbType.VarChar, 100);
            vlo_sqlCommand.Parameters["@_msj"].Direction = ParameterDirection.Output;

            vlo_sqlCommand.CommandText = vlc_Sentencia;

            try
            {
                vlo_sqlConexion.Open();
                vlo_sqlCommand.ExecuteNonQuery();
                //pvo_EntidadWebSite.Cod_Sitio = Convert.ToInt32(vlo_sqlCommand.Parameters["@_cod_sitio"].Value);
                vlc_Mensaje = Convert.ToString(vlo_sqlCommand.Parameters["@_msj"].Value);
                vlo_sqlConexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                vlo_sqlConexion.Dispose();
                vlo_sqlCommand.Dispose();
            }
            return vlc_Mensaje;
        }

        public string Borrar(ClsUbicacionesProfesionales pvo_EntidadUbicacionProf)
        {
            MySqlConnection vlo_sqlConexion = new MySqlConnection(vgc_CadenaConexion);
            MySqlCommand vlo_sqlCommand = new MySqlCommand();
            string vlc_Mensaje = "";
            string vlc_Sentencia = string.Empty;
            vlo_sqlCommand.Connection = vlo_sqlConexion;

            vlc_Sentencia = "SP_EliminarUbicacionProfecional";
            vlo_sqlCommand.CommandType = CommandType.StoredProcedure;
            vlo_sqlCommand.Parameters.AddWithValue("@_ID_USUARIO", pvo_EntidadUbicacionProf.ID_Usuario);
            vlo_sqlCommand.Parameters.AddWithValue("@_ID_UBICACION", pvo_EntidadUbicacionProf.ID_Ubicacion1);
            vlo_sqlCommand.Parameters.Add("@_msj", MySqlDbType.VarChar, 100);
            vlo_sqlCommand.Parameters["@_msj"].Direction = ParameterDirection.Output;

            vlo_sqlCommand.CommandText = vlc_Sentencia;

            try
            {
                vlo_sqlConexion.Open();
                vlo_sqlCommand.ExecuteNonQuery();
                vlc_Mensaje = Convert.ToString(vlo_sqlCommand.Parameters["@_msj"].Value);
                vlo_sqlConexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                vlo_sqlConexion.Dispose();
                vlo_sqlCommand.Dispose();
            }
            return vlc_Mensaje;
        }
        #endregion


    }//class
}//namesace
