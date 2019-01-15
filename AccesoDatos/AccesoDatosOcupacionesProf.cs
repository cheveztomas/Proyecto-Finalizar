﻿using Configuracion;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AccesoDatos
{
    public class AccesoDatosOcupacionesProf
    {
        // asignar  ubicación

        public string Guardarprof(int id_usuario, int id_ocupacion)
        {


            MySqlConnection vlo_sqlConexion = new MySqlConnection();
            vlo_sqlConexion.ConnectionString = ClsConfiguracion.getConnectionString();

            MySqlCommand vlo_sqlCommand = new MySqlCommand();
            //int vln_resultado = 0;
            string vlc_Mensaje = "";
            string vlc_Sentencia = string.Empty; //tambien puede usar ""
            vlo_sqlCommand.Connection = vlo_sqlConexion;

            vlc_Sentencia = "SP_INSERTAR_OCUPACION_DE_USUARIO";
            vlo_sqlCommand.CommandType = CommandType.StoredProcedure;
            vlo_sqlCommand.Parameters.AddWithValue("@_ID_USUARIO", id_usuario);
            vlo_sqlCommand.Parameters.AddWithValue("@_ID_OCUPACION", id_ocupacion);
            vlo_sqlCommand.Parameters.Add("@_msg", MySqlDbType.VarChar, 500);
            vlo_sqlCommand.Parameters["@_msg"].Direction = ParameterDirection.Output;

            vlo_sqlCommand.CommandText = vlc_Sentencia;

            try
            {
                vlo_sqlConexion.Open();
                vlo_sqlCommand.ExecuteNonQuery();
                vlc_Mensaje = Convert.ToString(vlo_sqlCommand.Parameters["@_msg"].Value);
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






    }
}