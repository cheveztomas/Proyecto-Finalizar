using System;
using EntidadesDirectorio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogica;

namespace DirectorioServicios
{
    public partial class FrmRegistroDeUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //se llaman los procedimientos para llenar los ddl
                llenarProvincias();
                llenarCantones();
                llenarOcupaciones();
                llenarEspecialidades();
            }
        }

        protected void drpdlProvincia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarCantones();
        }


        #region llenarddl
        //procedimiento para llenar las provincias 
        public void llenarProvincias()
        {
            try
            {
                //se crea una instancia de las funciones de logica
                LogicaUbicacion funciones = new LogicaUbicacion();
                drpdlProvincia1.DataTextField = "PROVINCIA";//se le dice que en el texto ponga lo que venga en el campo de datos
                drpdlProvincia1.DataSource = funciones.obtenerProvincias();
                drpdlProvincia1.DataBind();//se le agrega el sourse a el dropdownlist 
            }
            catch (Exception)
            {

                throw;
            }


        }
        //procedimiento para llenar el dropdown de cantones 
        public void llenarCantones()
        {
            try
            {
                //se crea una instancia de las funciones de logica
                LogicaUbicacion funciones = new LogicaUbicacion();
                drpdlCanton1.DataTextField = "CANTON";//se le dice que en el texto ponga lo que venga en el campo de datos
                drpdlCanton1.DataSource = funciones.obtenerCantones(drpdlProvincia1.Text);
                drpdlCanton1.DataBind();//se le agrega el sourse a el dropdownlist 
            }
            catch (Exception)
            {

                throw;
            }


        }

        public void llenarOcupaciones()
        {//se crea una instancia de las funciones de logica
            LogicaOcupaciones funciones = new LogicaOcupaciones();
            drpdlProfesion1.DataTextField = "NOMBRE_OCUPACION";//se le dice que en el texto ponga lo que venga en el campo de datos
            drpdlProfesion1.DataSource = funciones.obtenerOcupaciones();
            drpdlProfesion1.DataBind();//se le agrega el sourse a el dropdownlist 
        }

        public void llenarEspecialidades()
        {
            //se crea una instancia de las funciones de logica
            LogicaOcupaciones funciones = new LogicaOcupaciones();
            drpdlProfesion2.DataTextField = "ESPACIALIDAD_OCUPACION";//se le dice que en el texto ponga lo que venga en el campo de datos
            drpdlProfesion2.DataSource = funciones.obtenerEspecialidades(drpdlProfesion1.Text);
            drpdlProfesion2.DataBind();//se le agrega el sourse a el dropdownlist 


        }
        #endregion

        protected void drpdlProfesion1_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarEspecialidades();
        }
    }
}