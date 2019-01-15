using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Configuracion;
using EntidadesDirectorio;
using MySql.Data.MySqlClient;

namespace AccesoDatos
{
    public class AccesoDatosOcupaciones
    {

        public DataTable obteberOcupaciones()
        {
            DataTable ocupaciones = new DataTable();
            //se crea el objeto conection y se establece la conexion 
            MySqlConnection conection = new MySqlConnection();
            conection.ConnectionString = ClsConfiguracion.getConnectionString();
            MySqlDataAdapter dataAdapter;
            try
            {
                //se solicitan los nombres de ocupacion de la base de datos 
                MySqlCommand sentencia = new MySqlCommand("SELECT NOMBRE_OCUPACION FROM OCUPACIONES GROUP BY NOMBRE_OCUPACION");

                conection.Open();
                sentencia.Connection = conection;
                //se llena la tabla local con los datos obtenidos
                dataAdapter = new MySqlDataAdapter(sentencia);

                dataAdapter.Fill(ocupaciones);
                //se cierra la coneccion y sew destrullen los objetos 
                conection.Close();
                dataAdapter.Dispose();
                sentencia.Dispose();
                conection.Dispose();
                //se retornan las provincias 
                return ocupaciones;
            }
            catch (Exception)
            {

                throw;
            }
        }//obtener ocupaciones 

        public DataTable obtenerEspecialidad(string ocupacion)
        {

            DataTable especialidades = new DataTable();
            //se crea el objeto conection y se establece la conexion 
            MySqlConnection conection = new MySqlConnection();
            conection.ConnectionString = ClsConfiguracion.getConnectionString();
            MySqlDataAdapter dataAdapter;
            try
            {
                //se solicitan las especialidades de la base de datos 
                MySqlCommand sentencia = new MySqlCommand("SELECT ID_OCUPACION, ESPACIALIDAD_OCUPACION FROM OCUPACIONES WHERE NOMBRE_OCUPACION = " + "\"" + ocupacion + "\"");

                conection.Open();
                sentencia.Connection = conection;

                dataAdapter = new MySqlDataAdapter(sentencia);

                dataAdapter.Fill(especialidades);
                //se cierra la coneccion y sew destrullen los objetos 
                conection.Close();
                dataAdapter.Dispose();
                sentencia.Dispose();
                conection.Dispose();
                //se retornan las especialidades 
                return especialidades;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable listaOcupaciones(int id)
        {

            DataTable list_Ocupaciones = new DataTable();
            //Se establece el objeto conexión
            MySqlConnection conexion = new MySqlConnection();
            //Captura la cadena de conexión
            conexion.ConnectionString = ClsConfiguracion.getConnectionString();
            MySqlDataAdapter dataAdapter;

            try
            {
                conexion.Open();
                MySqlCommand sentencia = new MySqlCommand("select OCUPACIONES.ID_OCUPACION, concat(OCUPACIONES.NOMBRE_OCUPACION,' ',OCUPACIONES.ESPACIALIDAD_OCUPACION) as PROFESION from OCUPACIONES inner join OCUPACIONES_PROFESIONALES on OCUPACIONES.ID_OCUPACION = OCUPACIONES_PROFESIONALES.ID_OCUPACION where OCUPACIONES_PROFESIONALES.ID_USUARIO = " + id + ";");
                sentencia.Connection = conexion;

                dataAdapter = new MySqlDataAdapter(sentencia);

                //se guarda el resultado de la sentencia en la tabla list_Ocupaciones
                dataAdapter.Fill(list_Ocupaciones);

                //cerrar conexión
                conexion.Close();
                dataAdapter.Dispose();
                sentencia.Dispose();
                conexion.Dispose();

                //Retorna la lista de ocupaciones 
                
            }
            catch (Exception)
            {

                throw;
            }
            return list_Ocupaciones;
        }

        public DataTable ObtenerDatosDeUsuarioOcupaciones(int id_usuario)
        {
            //Se establese una variable para retornar una tabla.
            DataTable vlo_DatosUsuarioOcupaciones = new DataTable();

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
                command = new MySqlCommand("SELECT OCUPACIONES_PROFESIONALES.ID_USUARIO, OCUPACIONES_PROFESIONALES.ID_OCUPACION,NOMBRE_OCUPACION,ESPACIALIDAD_OCUPACION FROM OCUPACIONES INNER JOIN OCUPACIONES_PROFESIONALES ON OCUPACIONES.ID_OCUPACION=OCUPACIONES_PROFESIONALES.ID_OCUPACION WHERE OCUPACIONES_PROFESIONALES.ID_USUARIO=" + id_usuario);
                //Se establese la conexión.
                command.Connection = conexion;
                //Se instancia el data adpter con el comando.
                vlo_DA = new MySqlDataAdapter(command);

                //Se rellena la tabla 
                vlo_DA.Fill(vlo_DatosUsuarioOcupaciones);

                vlo_DA.Dispose();
                conexion.Close();
                command.Dispose();
                conexion.Dispose();
            }
            catch (MySqlException ex)
            {

                Console.WriteLine("error, " + ex.Message.ToString());
            }

            return vlo_DatosUsuarioOcupaciones;
        }

        public int eliminarOcupacion(int pvn_idOcupacion, int pvn_idUsuario)
        {

            int correcto = -1;

            string respueta = null; // variable que tiene el mensaje devuelto por el procedimiento almacenado despues de intentar eliminar la ocupacion

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
                command = new MySqlCommand("DELETE FROM OCUPACIONES_PROFESIONALES WHERE ID_OCUPACION = " + pvn_idOcupacion + " AND ID_USUARIO =" + pvn_idUsuario);
                //Se establese la conexión.
                command.Connection = conexion;

                // obteniendo el valor que devuelve la consulta
                correcto = command.ExecuteNonQuery();


                conexion.Close();
                command.Dispose();
                conexion.Dispose();
            }
            catch (MySqlException ex)
            {

                throw;
            }

            return correcto;

        }

    }//class
}//namespace
