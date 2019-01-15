using Configuracion;
using EntidadesDirectorio;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Net;
using System.Net.Mail;

namespace AccesoDatos
{
    public class AccesoDatosLogin
    {
        public int IniciarSesion(string pvc_Correo, string pvc_Password)
        {
            //Variables
            int vln_ID = -1;
            MySqlDataReader vlo_DataReader;
            MySqlConnection Conexion = new MySqlConnection
            {
                ConnectionString = ClsConfiguracion.GetLoginString()
            };
            MySqlCommand Command;
            string vlc_SentenciaSQL = string.Empty;
            //Inicio
            try
            {
                Command = new MySqlCommand
                {
                    Connection = Conexion
                };
                vlc_SentenciaSQL = "SELECT CORREO, cast(AES_DECRYPT(CONTRASENIA,'Directorio2019')as char(16)) AS CONSTRASENIA, ID_USUARIO FROM LOGIN_PAGINA_WEB.LOGIN WHERE CORREO='"+pvc_Correo+"' AND AES_DECRYPT(CONTRASENIA,'Directorio2019') LIKE binary '"+pvc_Password+"';";
                Command.CommandText = vlc_SentenciaSQL;

                Conexion.Open();
                vlo_DataReader = Command.ExecuteReader();

                if (vlo_DataReader.HasRows)
                {
                    vlo_DataReader.Read();
                    vln_ID = vlo_DataReader.GetInt32(2);
                }
                Conexion.Close();
                Command.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Conexion.Dispose();
            }
            return vln_ID;
        }

        private int IngresarUsuario(ClsUsuarios pvo_Usuario)
        {
            int vln_IDUsuario = 0;
            MySqlConnection ConexionOagina;
            MySqlCommand CommandPagina;
            int vln_Correcto = 0;

            try
            {
                ConexionOagina = new MySqlConnection
                {
                    ConnectionString = ClsConfiguracion.getConnectionString()
                };
                CommandPagina = new MySqlCommand
                {
                    Connection = ConexionOagina
                };
                string vlc_SentenciaPagina = string.Empty;

                vlc_SentenciaPagina = "SP_REGISTRAR_Y_ACTUALIZAR_USUARIO";

                CommandPagina.CommandType = CommandType.StoredProcedure;
                CommandPagina.Parameters.AddWithValue("@_ID_USUARIO", pvo_Usuario.ID_Usuario);
                CommandPagina.Parameters["@_ID_USUARIO"].Direction = ParameterDirection.InputOutput;
                CommandPagina.Parameters.AddWithValue("@_NOMBRE", pvo_Usuario.Nombre_Profesional);
                CommandPagina.Parameters.AddWithValue("@_APELLIDO1", pvo_Usuario.Apellido1_Profesional);
                CommandPagina.Parameters.AddWithValue("@_APELLIDO2", pvo_Usuario.Apellido2_Profesional);
                CommandPagina.Parameters.AddWithValue("@_CORREO", pvo_Usuario.Correo);
                CommandPagina.Parameters.AddWithValue("@_TELEFONO", pvo_Usuario.Telefono_Profesional);
                CommandPagina.Parameters.AddWithValue("@_DESCRIPCION", pvo_Usuario.Descripcion);
                CommandPagina.Parameters.AddWithValue("@_USUARIO_PREMIUM", pvo_Usuario.Usuario_Premium);
                CommandPagina.Parameters.AddWithValue("@_ES_PROFESIONAL", pvo_Usuario.Perfil_Profesional);
                CommandPagina.Parameters.Add("@_MSJ", MySqlDbType.VarChar, 100);
                CommandPagina.Parameters["@_MSJ"].Direction = ParameterDirection.Output;
                CommandPagina.CommandText = vlc_SentenciaPagina;

                ConexionOagina.Open();
                vln_Correcto = CommandPagina.ExecuteNonQuery();
                vln_IDUsuario = Convert.ToInt32(CommandPagina.Parameters["@_ID_USUARIO"].Value);
                //if (vln_Correcto>0)
                //{
                //    vlc_SentenciaPagina = "SELECT ID_USUARIO FROM PAGINA_WEB.USUARIOS ORDER by ID_USUARIO DESC LIMIT 1";
                //    CommandPagina.CommandText = vlc_SentenciaPagina;
                //    ReaderPagina = CommandPagina.ExecuteReader();

                //    ReaderPagina.Read();
                //    vln_IDUsuario = ReaderPagina.GetInt32(0);
                //    ReaderPagina.Close();
                //    ReaderPagina.Dispose();
                //}


                ConexionOagina.Close();
                ConexionOagina.Dispose();
                CommandPagina.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            if (vln_Correcto == 0)
            {
                vln_IDUsuario = -3;
            }

            return vln_IDUsuario;
        }

        public int InsertarLogin(int pvn_ID, ClsUsuarios pvo_Usuarios, string pvc_Password)
        {
            //Variables
            int vln_Correct = 0;
            MySqlConnection ConexionLogin;
            MySqlCommand CommandLogin;
            string vlc_SentenciaLogin = string.Empty;

            //Inicio
            try
            {
                ConexionLogin = new MySqlConnection
                {
                    ConnectionString = ClsConfiguracion.GetLoginString()
                };
                CommandLogin = new MySqlCommand
                {
                    Connection = ConexionLogin
                };

                vlc_SentenciaLogin = "INSERT INTO LOGIN_PAGINA_WEB.LOGIN(CORREO, CONTRASENIA, ID_USUARIO) VALUES('"+pvo_Usuarios.Correo+"',AES_ENCRYPT('"+pvc_Password+"','Directorio2019'),'"+pvn_ID+"');";
                ConexionLogin.Open();
                CommandLogin.CommandText = vlc_SentenciaLogin;
                vln_Correct = CommandLogin.ExecuteNonQuery();

                ConexionLogin.Close();
                CommandLogin.Dispose();

                EnviarContrasenia(pvo_Usuarios.Correo);
            }
            catch (Exception)
            {

                throw;
            }

            return vln_Correct;
        }

        public int Registrar(string pvc_Password, ClsUsuarios pvo_Usuario)
        {
            //Variables
            int vln_ID = 0;
            int vln_Correcto = 0;
            int Filas = 0;
            MySqlConnection ConexionLogin;
            MySqlCommand CommandLogin;
            MySqlDataReader ReaderLogin;
            string vlc_SentenciaLogin = string.Empty;
            //Inicio
            try
            {
                ConexionLogin = new MySqlConnection
                {
                    ConnectionString = ClsConfiguracion.GetLoginString()
                };
                CommandLogin = new MySqlCommand
                {
                    Connection = ConexionLogin
                };

                vlc_SentenciaLogin = "SELECT CORREO, cast(AES_DECRYPT(CONTRASENIA,'Directorio2019')as char(16)) AS CONSTRASENIA, ID_USUARIO FROM LOGIN_PAGINA_WEB.LOGIN WHERE CORREO='" + pvo_Usuario.Correo + "';";
                CommandLogin.CommandText = vlc_SentenciaLogin;

                ConexionLogin.Open();
                ReaderLogin = CommandLogin.ExecuteReader();
                ReaderLogin.Read();
                if (ReaderLogin.HasRows)
                {
                    Filas = ReaderLogin.GetInt32(2);
                    ConexionLogin.Close();
                }
                CommandLogin.Dispose();
                ConexionLogin.Dispose();
                if (Filas == 0)
                {
                    try
                    {
                        vln_ID = IngresarUsuario(pvo_Usuario);

                        if (vln_ID > 0)
                        {
                            vln_Correcto = InsertarLogin(vln_ID, pvo_Usuario, pvc_Password);

                            if (vln_Correcto == 0)
                            {
                                vln_ID = -4;
                            }
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    try
                    {

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else
                {
                    vln_ID = -2;
                }
                ReaderLogin.Close();
                ReaderLogin.Dispose();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
            return vln_ID;
        }

        public int EnviarCorreo(string pvc_Correo, string pvc_NombreDestinatario, string pvc_Mensaje, string pvc_Asunto)
        {
            //Variables
            int vln_Correcto = 0;
            MailAddress fromAddress = new MailAddress("directorioservicioscr@gmail.com", "Directorio de Servicios");
            MailAddress toAddress = new MailAddress(pvc_Correo, pvc_NombreDestinatario);
            const string fromPassword = "Direc2019";
            string subject = pvc_Asunto;
            string body = pvc_Mensaje;

            //Inicio

            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (MailMessage message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

                vln_Correcto = 1;
            }
            catch (Exception)
            {
                vln_Correcto = -2;
                throw;
            }
            return vln_Correcto;
        }

        //-1 Correo no existe. -2 Ocurrio un error. 1 Todo correcto. 0 no se envio el correo.
        public int EnviarContrasenia(string pvc_Correo)
        {
            int vln_Correcto = 0;
            string vlc_Correo = string.Empty;
            string vlc_Pass = string.Empty;
            string vlc_Mensaje = string.Empty;
            string vlc_NombreDestinatario = string.Empty;
            string vlc_Asunto = string.Empty;
            MySqlConnection ConexionLogin;
            MySqlCommand CommandLogin;
            MySqlDataReader ReaderLogin;
            string vlc_SentenciaLogin = string.Empty;
            //Inicio
            try
            {
                ConexionLogin = new MySqlConnection
                {
                    ConnectionString = ClsConfiguracion.GetLoginString()
                };
                CommandLogin = new MySqlCommand
                {
                    Connection = ConexionLogin
                };

                vlc_SentenciaLogin = "SELECT CORREO, cast(AES_DECRYPT(CONTRASENIA,'Directorio2019')as char(16)) AS CONSTRASENIA, ID_USUARIO FROM LOGIN_PAGINA_WEB.LOGIN WHERE CORREO='"+pvc_Correo+"';";
                CommandLogin.CommandText = vlc_SentenciaLogin;

                ConexionLogin.Open();
                ReaderLogin = CommandLogin.ExecuteReader();
                ReaderLogin.Read();
                if (ReaderLogin.HasRows)
                {
                    vlc_Correo = ReaderLogin.GetString(0);
                    vlc_Pass = ReaderLogin.GetString(1);
                }
                else
                {
                    vln_Correcto = -1;
                }
                ConexionLogin.Close();
                CommandLogin.Dispose();
                ConexionLogin.Dispose();
                ReaderLogin.Close();
                ReaderLogin.Dispose();

                if (vlc_Correo!=string.Empty && vlc_Pass!=string.Empty)
                {
                    try
                    {
                        vlc_Mensaje = "Querido usuario de la aplicación Directorio de Servicios.\n \n \nSu contraseña es: "+vlc_Pass+ "\n \n \n Muchas gracias por preferirnos. \n http://directorioservicios.somee.com/";
                        vlc_NombreDestinatario = "Usuario de directorio de servicios.";
                        vlc_Asunto = "Reenvio de la contraseña.";
                        vln_Correcto = EnviarCorreo(vlc_Correo, vlc_NombreDestinatario, vlc_Mensaje, vlc_Asunto);
                    }
                    catch (Exception)
                    {
                        vln_Correcto = -2;
                        throw;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }

            return vln_Correcto;
        }

        public int ActualizarContrasenia(string pvc_contrasenia, int pvn_ID)
        {
            //Variables
            int vln_Correcto = 0;
            string vlc_Sentencia = string.Empty;
            MySqlConnection vlo_Conexion;
            MySqlCommand vlo_Comando;
            MySqlDataReader vlo_DR;
            string vlc_Correo = string.Empty;

            //Inicio
            try
            {
                vlo_Conexion = new MySqlConnection();
                vlo_Conexion.ConnectionString = ClsConfiguracion.GetLoginString();
                vlo_Comando = new MySqlCommand();

                vlo_Comando.Connection = vlo_Conexion;

                vlc_Sentencia = "UPDATE `LOGIN_PAGINA_WEB`.`LOGIN` SET CONTRASENIA=AES_ENCRYPT('"+pvc_contrasenia+"','Directorio2019') WHERE (`ID_USUARIO` = '"+pvn_ID+"');";
                vlo_Comando.CommandText = vlc_Sentencia;
                vlo_Conexion.Open();
                vln_Correcto=vlo_Comando.ExecuteNonQuery();

                if (vln_Correcto > 0)
                {
                    try
                    {
                        vlc_Sentencia = "SELECT CORREO, cast(AES_DECRYPT(CONTRASENIA,'Directorio2019')as char(16)) AS CONSTRASENIA, ID_USUARIO FROM LOGIN_PAGINA_WEB.LOGIN WHERE ID_USUARIO='" + pvn_ID + "';";
                        vlo_Comando.CommandText = vlc_Sentencia;
                        vlo_DR = vlo_Comando.ExecuteReader();
                        if (vlo_DR.HasRows)
                        {
                            vlo_DR.Read();
                            vlc_Correo = vlo_DR.GetString(0);
                        }
                        else
                        {
                            vln_Correcto = -1;
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }

                vlo_Conexion.Close();
                vlo_Comando.Dispose();
                vlo_Conexion.Close();

                try
                {
                    if (vln_Correcto>0)
                    {
                        EnviarContrasenia(vlc_Correo);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch (Exception)
            {
                vln_Correcto = -1;
                throw;
            }
            return vln_Correcto;
        }
    }
}
