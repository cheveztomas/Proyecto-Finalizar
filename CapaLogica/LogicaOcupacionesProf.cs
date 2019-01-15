using System;
using System.Collections.Generic;
using System.Text;
using AccesoDatos;

namespace CapaLogica
{
    public class LogicaOcupacionesProf
    {
        public string agregarOcupacion(int id_usuario, int id_ocupacion)
        {
            string msj = "";
            try
            {
                AccesoDatosOcupacionesProf ubicacionesP = new AccesoDatosOcupacionesProf();
                msj = ubicacionesP.Guardarprof(id_usuario, id_ocupacion);
            }
            catch (Exception)
            {

                throw;
            }

            return msj;
        }


    }
}