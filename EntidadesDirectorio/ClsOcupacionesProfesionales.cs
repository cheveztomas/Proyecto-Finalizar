using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDirectorio
{
    public class ClsOcupacionesProfesionales
    {
        private int vgn_ID_Usuario, vgn_ID_Ocupacion;
        private string vgc_Detalles;

        public ClsOcupacionesProfesionales()
        {
            vgn_ID_Ocupacion = 0;
            vgn_ID_Usuario = 0;
            vgc_Detalles = string.Empty;
        }

        public ClsOcupacionesProfesionales(int vgn_ID_Usuario, int vgn_ID_Ocupacion, string vgc_Detalles)
        {
            this.vgn_ID_Usuario = vgn_ID_Usuario;
            this.vgn_ID_Ocupacion = vgn_ID_Ocupacion;
            this.vgc_Detalles = vgc_Detalles;
        }

        public int ID_Usuario { get => vgn_ID_Usuario; set => vgn_ID_Usuario = value; }
        public int ID_Ocupacion { get => vgn_ID_Ocupacion; set => vgn_ID_Ocupacion = value; }
        public string Detalles { get => vgc_Detalles; set => vgc_Detalles = value; }
    }
}
