using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Configuracion;
using EntidadesDirectorio;
using MySql.Data.MySqlClient;

namespace AccesoDatos
{
    public class AccesoDatosUbicacion
    {
        //procedimiento almacenado que me retorna las provincias
        public DataTable devolverProvincias()
        {

            DataTable provincias = new DataTable();
            //se crea el objeto conection y se establece la conexion 
            MySqlConnection conection = new MySqlConnection();
            conection.ConnectionString = ClsConfiguracion.getConnectionString();
            MySqlDataAdapter dataAdapter;
            try
            {
                //se solicitan las provincias de la base de datos 
                MySqlCommand sentencia = new MySqlCommand("SELECT PROVINCIA FROM UBICACIONES GROUP BY PROVINCIA");

                conection.Open();
                sentencia.Connection = conection;

                dataAdapter = new MySqlDataAdapter(sentencia);

                dataAdapter.Fill(provincias);
                //se cierra la coneccion y sew destrullen los objetos 
                conection.Close();
                dataAdapter.Dispose();
                sentencia.Dispose();
                conection.Dispose();
                //se retornan las provincias 
                return provincias;
            }
            catch (Exception)
            {

                throw;
            }





        }

        public DataTable devolverCantones(string provincia)
        {

            DataTable cantones = new DataTable();
            //se crea el objeto conection y se establece la conexion 
            MySqlConnection conection = new MySqlConnection();
            conection.ConnectionString = ClsConfiguracion.getConnectionString();
            MySqlDataAdapter dataAdapter;
            try
            {
                //se solicitan las provincias de la base de datos 
                MySqlCommand sentencia = new MySqlCommand("SELECT ID_UBICACION, CANTON FROM UBICACIONES WHERE PROVINCIA = " + "\"" + provincia + "\"");

                conection.Open();
                sentencia.Connection = conection;

                dataAdapter = new MySqlDataAdapter(sentencia);

                dataAdapter.Fill(cantones);
                //se cierra la coneccion y sew destrullen los objetos 
                conection.Close();
                dataAdapter.Dispose();
                sentencia.Dispose();
                conection.Dispose();
                //se retornan las provincias 
                return cantones;
            }
            catch (Exception)
            {

                throw;
            }





        }

    }
}
