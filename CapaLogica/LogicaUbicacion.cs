using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AccesoDatos;

namespace CapaLogica
{
    public class LogicaUbicacion
    {
        public DataTable obtenerProvincias()
        {
            //se crea un objeto tabla
            DataTable provincias = new DataTable();
            //se crea una referencia a el acceso a datos de las ubicaciones  
            AccesoDatosUbicacion funciones = new AccesoDatosUbicacion();
            //se obtienen las provincias 
            provincias = funciones.devolverProvincias();
            return provincias;//se retornan las provincias 
        }

        public DataTable obtenerCantones(string canton)
        {
            //se crea un objeto tabla
            DataTable provincias = new DataTable();
            //se crea una referencia a el acceso a datos de las ubicaciones  
            AccesoDatosUbicacion funciones = new AccesoDatosUbicacion();
            //se obtienen las provincias 
            provincias = funciones.devolverCantones(canton);
            return provincias;//se retornan las provincias 
        }
    }
}
