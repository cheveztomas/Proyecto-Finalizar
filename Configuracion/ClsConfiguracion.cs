using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Configuracion
{
    public class ClsConfiguracion
    {
        public static string getConnectionString()
        {

           string conexion = "Data Source = 35.232.173.205; Initial Catalog = PAGINA_WEB; User Id = todos; Password = 1234";
            //string conexion = "Server=localhost;Database=pagina_web; Uid=root;Pwd=1234;";

            return conexion;
        }

        public static string GetLoginString()
        {

            string conexionLog = "Data Source = 35.232.173.205; Initial Catalog = LOGIN_PAGINA_WEB; User Id = todos; Password = 1234";

            return conexionLog;
        }
    }
}
