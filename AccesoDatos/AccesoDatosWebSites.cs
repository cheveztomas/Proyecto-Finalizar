using System;
using System.Collections.Generic;
using System.Data;

using Configuracion;
using EntidadesDirectorio;
using MySql.Data.MySqlClient;

namespace AccesoDatos
{
    public class AccesoDatosWebSites
    {
        #region Atributos
        string vgc_CadenaConexion;
        #endregion

        #region Constructores
        public AccesoDatosWebSites()
        {
            //vgc_CadenaConexion = string.Empty;
            vgc_CadenaConexion = ClsConfiguracion.getConnectionString();
        }
        // Constructor que recibe la cadena como parametro
        public AccesoDatosWebSites(string pvc_CadenaConeccion)
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

            vlc_Sentencia = "SELECT COD_SITIO,URL_SITIO,NOMBRE_SITIO FROM WEBSITES";
            if (!string.IsNullOrEmpty(pvc_Condicion))
            {
                vlc_Sentencia = string.Format("{0} WHERE {1}", vlc_Sentencia, pvc_Condicion);
            }

            try
            {
                vlo_DataAdapter = new MySqlDataAdapter(vlc_Sentencia, vlo_Conexion);
                vlo_DataAdapter.Fill(vlo_DataSet, "WebSites"); // nombre de la tabla encontrada
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

        public string Guardar(ClsWebSites pvo_EntidadWebSite)
        {
            MySqlConnection vlo_sqlConexion = new MySqlConnection(vgc_CadenaConexion);
            MySqlCommand vlo_sqlCommand = new MySqlCommand();
            //int vln_resultado = 0;
            string vlc_Mensaje = "";
            string vlc_Sentencia = string.Empty; //tambien puede usar ""
            vlo_sqlCommand.Connection = vlo_sqlConexion;

            vlc_Sentencia = "SP_AgregarSitioWeb";
            vlo_sqlCommand.CommandType = CommandType.StoredProcedure;
            vlo_sqlCommand.Parameters.AddWithValue("@_cod_sitio", pvo_EntidadWebSite.Cod_Sitio);
            vlo_sqlCommand.Parameters["@_cod_sitio"].Direction = ParameterDirection.InputOutput;
            vlo_sqlCommand.Parameters.AddWithValue("@_id", pvo_EntidadWebSite.ID_Usuario);
            vlo_sqlCommand.Parameters.AddWithValue("@_url", pvo_EntidadWebSite.URL_Sitio);
            vlo_sqlCommand.Parameters.AddWithValue("@_nombre", pvo_EntidadWebSite.Nombre_Sitio);
            vlo_sqlCommand.Parameters.Add("@_msj", MySqlDbType.VarChar, 100);
            vlo_sqlCommand.Parameters["@_msj"].Direction = ParameterDirection.Output;

            vlo_sqlCommand.CommandText = vlc_Sentencia;

            try
            {
                vlo_sqlConexion.Open();
                vlo_sqlCommand.ExecuteNonQuery();
                pvo_EntidadWebSite.Cod_Sitio = Convert.ToInt32(vlo_sqlCommand.Parameters["@_cod_sitio"].Value);
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

        public string Borrar(string pvc_Codigo)
        {
            MySqlConnection vlo_sqlConexion = new MySqlConnection(vgc_CadenaConexion);
            MySqlCommand vlo_sqlCommand = new MySqlCommand();
            string vlc_Mensaje = "";
            string vlc_Sentencia = string.Empty;
            vlo_sqlCommand.Connection = vlo_sqlConexion;

            vlc_Sentencia = "SP_EliminarSitioWeb";
            vlo_sqlCommand.CommandType = CommandType.StoredProcedure;
            vlo_sqlCommand.Parameters.AddWithValue("@_cod_sitio", pvc_Codigo);
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

        public DataTable ObtenerDatosDeUsuarioPaginasWeb(int id_usuario)
        {
            //Se establese una variable para retornar una tabla.
            DataTable vlo_DatosUsuarioWebsites = new DataTable();

            //Se establese una variable de conexión instanciando la conexion de MySQL
            MySqlConnection conexion = new MySqlConnection();

            //Se establese la cadena de conexión obteniendola de la configuración.
            conexion.ConnectionString = ClsConfiguracion.getConnectionString();

            //Se establese una variable de comandos.
            MySqlCommand command;

            //Se establese una variable de tipo data adapter.
            MySqlDataAdapter vlo_DA;

            try
            {
                //Se abre la conexión.
                conexion.Open();

                //Se instancia el comando con la sentencia.
                command = new MySqlCommand("SELECT * FROM WEBSITES WHERE ID_USUARIO=" + id_usuario);

                //Se establese la conexión.
                command.Connection = conexion;

                //Se instancia el data adpter con el comando.
                vlo_DA = new MySqlDataAdapter(command);

                //Se rellena la tabla 
                vlo_DA.Fill(vlo_DatosUsuarioWebsites);

                vlo_DA.Dispose();
                conexion.Close();
                command.Dispose();
                conexion.Dispose();
            }
            catch (MySqlException ex)
            {

                Console.WriteLine("error, " + ex.Message.ToString());
            }

            return vlo_DatosUsuarioWebsites;
        }

        #endregion
    }
}
