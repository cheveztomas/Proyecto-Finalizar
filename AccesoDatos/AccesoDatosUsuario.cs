using Configuracion;
using EntidadesDirectorio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace AccesoDatos
{
    public class AccesoDatosUsuario
    {
        //Este metodo retorna una lista de usuarios.
        public DataTable listaUsuarios(string condition)
        {
            //Se establese una variable para retornar una tabla.
            DataTable vlo_ListaUsuarios = new DataTable();

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
                command = new MySqlCommand("SELECT ID_USUARIO, NOMBRE_PROFESIONAL, APELLIDO1_PROFESIONAL, APELLIDO2_PROFESIONAL, CORREO_PROFESIONAL, TELEFONO_PROFESIONAL, DESCRIPCION, USUARIO_PREMIUM, CALIFIC_CONTADOR, CALIFIC_SUMA, PERFIL_PROFESIONAL FROM PAGINA_WEB.USUARIOS;");

                //Se establese la conexión.
                command.Connection = conexion;
                //command.CommandType = System.Data.CommandType.Text;
                //command.CommandText = "SELECT * FROM USUARIOS";

                //Se instancia el data adpter con el comando.
                vlo_DA = new MySqlDataAdapter(command);

                //Se rellena la tabla 
                vlo_DA.Fill(vlo_ListaUsuarios);

                vlo_DA.Dispose();
                conexion.Close();
                command.Dispose();
                conexion.Dispose();
            }
            catch (MySqlException ex)
            {

                Console.WriteLine("error, " + ex.Message.ToString());
            }

            return vlo_ListaUsuarios;
        }


        public DataTable obtenerProfecionales(string pvc_profecion, string pvc_especialidad, string pvc_provincia, string pvc_canton)
        {
            DataTable vlo_profecionales = new DataTable();
            //se crea el objeto conection y se establece la conexion 
            MySqlConnection conection = new MySqlConnection();
            conection.ConnectionString = ClsConfiguracion.getConnectionString();
            MySqlDataAdapter dataAdapter;
            try
            {
                //se solicitan los nombres de la base de datos 
                MySqlCommand sentencia = new MySqlCommand("	SELECT  USUARIOS.ID_USUARIO,USUARIOS.CORREO_PROFESIONAL,USUARIOS.NOMBRE_PROFESIONAL, USUARIOS.APELLIDO1_PROFESIONAL,USUARIOS.APELLIDO2_PROFESIONAL,USUARIOS.TELEFONO_PROFESIONAL,OCUPACIONES.NOMBRE_OCUPACION,OCUPACIONES.ESPACIALIDAD_OCUPACION,UBICACIONES.PROVINCIA,UBICACIONES.CANTON,USUARIOS.CALIFIC_SUMA FROM USUARIOS LEFT OUTER JOIN OCUPACIONES_PROFESIONALES on USUARIOS.ID_USUARIO = OCUPACIONES_PROFESIONALES.ID_USUARIO LEFT OUTER JOIN OCUPACIONES on OCUPACIONES.ID_OCUPACION = OCUPACIONES_PROFESIONALES.ID_OCUPACION LEFT OUTER JOIN UBICACIONES_PROFESIONALES on USUARIOS.ID_USUARIO = UBICACIONES_PROFESIONALES.ID_USUARIO LEFT OUTER JOIN UBICACIONES on UBICACIONES.ID_UBICACION = UBICACIONES_PROFESIONALES.ID_UBICACION WHERE UBICACIONES.PROVINCIA = \"" + pvc_provincia + "\" and UBICACIONES.CANTON = \"" + pvc_canton + "\" and OCUPACIONES.NOMBRE_OCUPACION = \"" + pvc_profecion + "\" and OCUPACIONES.ESPACIALIDAD_OCUPACION = \"" + pvc_especialidad + "\"");









                conection.Open();
                sentencia.Connection = conection;
                //se llena la tabla local con los datos obtenidos
                dataAdapter = new MySqlDataAdapter(sentencia);

                dataAdapter.Fill(vlo_profecionales);
                //se cierra la coneccion y sew destrullen los objetos 
                conection.Close();
                dataAdapter.Dispose();
                sentencia.Dispose();
                conection.Dispose();
                //se retornan las provincias 
                return vlo_profecionales;
            }
            catch (Exception)
            {

                throw;
            }
        }//obtenerProfecionales



        public int InsertarUsuario(ClsUsuarios pvo_Usuario)
        {
            //Variables
            int vln_Correcta = 0;
            string NombreSP = string.Empty;

            //Se instancia la conexión.
            MySqlConnection Conexion = new MySqlConnection();
            Conexion.ConnectionString = ClsConfiguracion.getConnectionString();

            //Se declara el command
            MySqlCommand Command;

            //Inicio
            try
            {
                //Se llama el procedimiento almacenado.
                NombreSP = "call pagina_web.SP_REGISTRAR_Y_ACTUALIZAR_USUARIO(?,?,?,?,?,?,?,?,?);";

                //Se abre la conexión
                Conexion.Open();

                //Se termina de instanciar el command con el procedimiento almacenado
                Command = new MySqlCommand(NombreSP);

                //Se establese la conexión.
                Command.Connection = Conexion;

                //Parametros necesarios de la aplicación.
                Command.Parameters["_ID_USUARIO"].Direction = ParameterDirection.InputOutput;
                Command.Parameters.AddWithValue("_ID_USUARIO", pvo_Usuario.ID_Usuario);
                Command.Parameters.AddWithValue("_NOMBRE", pvo_Usuario.Nombre_Profesional);
                Command.Parameters.AddWithValue("_APELLIDO1", pvo_Usuario.Apellido1_Profesional);
                Command.Parameters.AddWithValue("_APELLIDO2",pvo_Usuario.Apellido2_Profesional);
                Command.Parameters.AddWithValue("_CORREO",pvo_Usuario.Telefono_Profesional);
                Command.Parameters.AddWithValue("_TELEFONO",pvo_Usuario.Telefono_Profesional);
                Command.Parameters.AddWithValue("_DESCIRPCION",pvo_Usuario.Descripcion);
                Command.Parameters.AddWithValue("_USUARIO_PREMIUM",pvo_Usuario.Usuario_Premium);
                Command.Parameters.AddWithValue("_ES_PROFESIONAL",pvo_Usuario.Perfil_Profesional);
                Command.Parameters.Add("@_MSJ", MySqlDbType.VarChar, 100);
                Command.Parameters["@_MSJ"].Direction = ParameterDirection.Output;

                vln_Correcta = Command.ExecuteNonQuery();
                pvo_Usuario.ID_Usuario = Convert.ToInt32(Command.Parameters["_ID_USUARIO"].Value);
                Conexion.Close();
                Conexion.Dispose();
                Command.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return vln_Correcta;
        }

        //Guarda o actualiza un usuario
        public string Guardar(ClsUsuarios pvo_EntidadUsuario)
        {
            string vgc_CadenaConexion = ClsConfiguracion.getConnectionString();
            MySqlConnection vlo_sqlConexion = new MySqlConnection(vgc_CadenaConexion);
            MySqlCommand vlo_sqlCommand = new MySqlCommand();
            string vlc_Mensaje = "";
            string vlc_Sentencia = string.Empty; //tambien puede usar ""
            vlo_sqlCommand.Connection = vlo_sqlConexion;

            vlc_Sentencia = "SP_REGISTRAR_Y_ACTUALIZAR_USUARIO";
            vlo_sqlCommand.CommandType = CommandType.StoredProcedure;
            vlo_sqlCommand.Parameters["@_ID_USUARIO"].Direction = ParameterDirection.InputOutput;
            vlo_sqlCommand.Parameters.AddWithValue("@_ID_USUARIO", pvo_EntidadUsuario.ID_Usuario);
            vlo_sqlCommand.Parameters.AddWithValue("@_NOMBRE", pvo_EntidadUsuario.Nombre_Profesional);
            vlo_sqlCommand.Parameters.AddWithValue("@_APELLIDO1", pvo_EntidadUsuario.Apellido1_Profesional);
            vlo_sqlCommand.Parameters.AddWithValue("@_APELLIDO2", pvo_EntidadUsuario.Apellido2_Profesional);
            vlo_sqlCommand.Parameters.AddWithValue("@_CORREO", pvo_EntidadUsuario.Telefono_Profesional);
            vlo_sqlCommand.Parameters.AddWithValue("@_TELEFONO", pvo_EntidadUsuario.Telefono_Profesional);
            vlo_sqlCommand.Parameters.AddWithValue("@_DESCIRPCION", pvo_EntidadUsuario.Descripcion);
            vlo_sqlCommand.Parameters.AddWithValue("@_USUARIO_PREMIUM", pvo_EntidadUsuario.Usuario_Premium);
            vlo_sqlCommand.Parameters.AddWithValue("@_ES_PROFESIONAL", pvo_EntidadUsuario.Perfil_Profesional);
            vlo_sqlCommand.Parameters.Add("@_MSJ", MySqlDbType.VarChar, 100);
            vlo_sqlCommand.Parameters["@_MSJ"].Direction = ParameterDirection.Output;

            vlo_sqlCommand.CommandText = vlc_Sentencia;

            try
            {
                vlo_sqlConexion.Open();
                vlo_sqlCommand.ExecuteNonQuery();
                pvo_EntidadUsuario.ID_Usuario = Convert.ToInt32(vlo_sqlCommand.Parameters["@_cod_sitio"].Value);
                vlc_Mensaje = Convert.ToString(vlo_sqlCommand.Parameters["@_MSJ"].Value);
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

        //proceso para eliminar usuario de la base de datos
        public int EliminarUsuario(int id_usuario)
        {
            //Variables
            int vln_Correcta = 0;
            string NombreSP = string.Empty;
            string Msg = string.Empty;

            //Se instancia la conexión.
            MySqlConnection Conexion = new MySqlConnection();
            Conexion.ConnectionString = ClsConfiguracion.getConnectionString();

            //Se declara el command
            MySqlCommand Command;

            //Inicio
            try
            {
                //Se llama el procedimiento almacenado.
                NombreSP = "call pagina_web.SP_EliminarUsuario(?,?);";

                //Se abre la conexión
                Conexion.Open();

                //Se termina de instanciar el command con el procedimiento almacenado
                Command = new MySqlCommand(NombreSP);

                //Se establese la conexión.
                Command.Connection = Conexion;

                //Parametros necesarios de la aplicación.
                Command.Parameters.AddWithValue("_ID", id_usuario);
                Command.Parameters.AddWithValue("_MSJ", Msg);

                vln_Correcta = Command.ExecuteNonQuery();
                Conexion.Close();
                Conexion.Dispose();
                Command.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return vln_Correcta;
        }

        //Borrar el Usuario indicado
        public string Borrar(string pvc_IdUsuario)
        {
            string vgc_CadenaConexion = ClsConfiguracion.getConnectionString();
            MySqlConnection vlo_sqlConexion = new MySqlConnection(vgc_CadenaConexion);
            MySqlCommand vlo_sqlCommand = new MySqlCommand();
            string vlc_Mensaje = "";
            string vlc_Sentencia = string.Empty;
            vlo_sqlCommand.Connection = vlo_sqlConexion;

            vlc_Sentencia = "SP_EliminarUsuario";
            vlo_sqlCommand.CommandType = CommandType.StoredProcedure;
            vlo_sqlCommand.Parameters.AddWithValue("@_ID", pvc_IdUsuario);
            vlo_sqlCommand.Parameters.Add("@_MSJ", MySqlDbType.VarChar, 100);
            vlo_sqlCommand.Parameters["@_MSJ"].Direction = ParameterDirection.Output;

            vlo_sqlCommand.CommandText = vlc_Sentencia;

            try
            {
                vlo_sqlConexion.Open();
                vlo_sqlCommand.ExecuteNonQuery();
                vlc_Mensaje = Convert.ToString(vlo_sqlCommand.Parameters["@_MSJ"].Value);
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

        //funcion para obtener datos de la tabla usuario
        public ClsUsuarios ObtenerDatosDeUsuario(int id_usuario)
        {
            MySqlConnection conexion = new MySqlConnection();
            conexion.ConnectionString = ClsConfiguracion.getConnectionString();
            MySqlCommand command= new MySqlCommand();
            MySqlDataReader vlo_RD;
            ClsUsuarios vlo_usuario = new ClsUsuarios();

            try
            {
                //Se establese la conexión.
                command.Connection = conexion;
                command.CommandText = "SELECT NOMBRE_PROFESIONAL,APELLIDO1_PROFESIONAL,APELLIDO2_PROFESIONAL,CORREO_PROFESIONAL,TELEFONO_PROFESIONAL,DESCRIPCION,USUARIO_PREMIUM,CALIFIC_CONTADOR,CALIFIC_SUMA,PERFIL_PROFESIONAL FROM USUARIOS WHERE ID_USUARIO=" + id_usuario;
                conexion.Open();
                vlo_RD = command.ExecuteReader();

                if (vlo_RD.HasRows)
                {
                    vlo_RD.Read();
                    vlo_usuario.Nombre_Profesional= vlo_RD.GetString(0);
                    vlo_usuario.Apellido1_Profesional = vlo_RD.GetString(1);
                    vlo_usuario.Usuario_Premium = vlo_RD.GetBoolean(6);
                    vlo_usuario.Perfil_Profesional = vlo_RD.GetBoolean(9);
                    vlo_usuario.Telefono_Profesional = vlo_RD.GetString(4);
                    if (!vlo_RD.IsDBNull(2))
                    {
                        vlo_usuario.Apellido2_Profesional = vlo_RD.GetString(2);
                    }
                    if (!vlo_RD.IsDBNull(3))
                    {
                        vlo_usuario.Correo = vlo_RD.GetString(3);
                    }
                    if (!vlo_RD.IsDBNull(5))
                    {
                        vlo_usuario.Descripcion = vlo_RD.GetString(5);
                    }
                    if (!vlo_RD.IsDBNull(7))
                    {
                        vlo_usuario.Calif_Contador = vlo_RD.GetInt32(7);
                    }
                    if (!vlo_RD.IsDBNull(8))
                    {
                        vlo_usuario.Calif_Suma = vlo_RD.GetInt32(8);
                    }
                }
                vlo_RD.Dispose();
                conexion.Close();
                command.Dispose();
                conexion.Dispose();
            }
            catch (MySqlException ex)
            {

                Console.WriteLine("error, " + ex.Message.ToString());
            }

            return vlo_usuario;
        }
    }//class
}//namespace
