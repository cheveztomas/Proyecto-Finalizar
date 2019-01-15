using CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesDirectorio;
using System.Data;

namespace DirectorioServicios
{
    public partial class FrmPerfilProf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                cargarUsuario(id);
            }

        }

        protected void btnProfesion_Click(object sender, EventArgs e)
        {

        }

        //public void cargarUsuario(string id)
        //{
        //    try
        //    {

        //        //----------------------> OCUPACIONES
        //        LogicaOcupaciones list_Ocupaciones = new LogicaOcupaciones();
        //        grd_Ocupaciones.DataSource = list_Ocupaciones.Lg_listaOcupaciones(int.Parse(id));
        //        grd_Ocupaciones.DataBind();
        //        //----------------------> UBICACIONES

        //        LogicaUbicacionProf lista_Ubicaciones = new LogicaUbicacionProf();
        //        grd_Ubicacion.DataSource = lista_Ubicaciones.ListarUbicacionesProf(int.Parse(id));
        //        grd_Ubicacion.DataBind();
        //        //----------------------> SITIO WEB

        //        LogicaWebSites lista_WebSites = new LogicaWebSites();
        //        grd_websites.DataSource = lista_WebSites.ListarWebSites(int.Parse(id));
        //        grd_websites.DataBind();


        //        LogicaUsuario user = new LogicaUsuario();
        //        ClsUsuarios usuarioObtenido;
        //        usuarioObtenido = user.ObtenerDatosDeUsuario(int.Parse(id));
        //        lblUser.Text = usuarioObtenido.Nombre_Profesional + ' ' + usuarioObtenido.Apellido1_Profesional + ' ' + usuarioObtenido.Apellido2_Profesional;
        //        lblCorreo.Text = usuarioObtenido.Correo;
        //        lblTelefono.Text = usuarioObtenido.Telefono_Profesional;
        //        lblDescripcion.Text = usuarioObtenido.Descripcion;



        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}






        public void cargarUsuario(string id)
        {
            string ocupaciones = "", ubicaciones = "", wsites = "", nombre = "", correo = "", telefono = "", descripcion = "", Query = "";
            try
            {

                //----------------------> OCUPACIONES
                LogicaOcupaciones list_Ocupaciones = new LogicaOcupaciones();
                DataTable lista_Ocupaciones;
                lista_Ocupaciones = list_Ocupaciones.Lg_listaOcupaciones(int.Parse(id));

                foreach (DataRow item in lista_Ocupaciones.Rows)
                {
                    ocupaciones += "<li class=" + "'nodecoracion'" + ">" + item["PROFESION"].ToString() + "</li>";
                }
                //<---------------------- OCUPACIONES



                //----------------------> UBICACIONES
                LogicaUbicacionProf list_Ubicaciones = new LogicaUbicacionProf();
                DataTable lista_ubicaciones;
                lista_ubicaciones = list_Ubicaciones.ObtenerDatosDeUsuarioUbicaciones(int.Parse(id));

                foreach (DataRow item in lista_ubicaciones.Rows)
                {
                    ubicaciones += "<li class=" + "'nodecoracion'" + ">" + item["PROVINCIA"].ToString() + " " + item["CANTON"].ToString() + "</li>";
                }

                //<---------------------- UBICACIONES


                //----------------------> SITIO WEB

                LogicaWebSites list_WebSites = new LogicaWebSites();
                DataTable lista_Websites;
                lista_Websites = list_WebSites.ObtenerDatosDeUsuarioPaginasWeb(int.Parse(id));

                string titulo = "<h3 id='contenedor' class='text-info'>Perfil Profesional:</h3>";
                contenedor.InnerHtml += titulo;
                foreach (DataRow item in lista_Websites.Rows)
                {
                    wsites += "<a href=" + item["URL_SITIO"].ToString() + ">" + item["NOMBRE_SITIO"].ToString() + "</a><br>";
                }
                //<----------------------- SITIOS WEB

                //----------------------->USUARIO
                LogicaUsuario user = new LogicaUsuario();
                ClsUsuarios usuarioObtenido;
                usuarioObtenido = user.ObtenerDatosDeUsuario(int.Parse(id));
                nombre = usuarioObtenido.Nombre_Profesional + ' ' + usuarioObtenido.Apellido1_Profesional + ' ' + usuarioObtenido.Apellido2_Profesional;
                correo = usuarioObtenido.Correo;
                telefono = usuarioObtenido.Telefono_Profesional;
                descripcion = usuarioObtenido.Descripcion;
                //<----------------------- USUARIO

                Query =
                    "<div id='lista' runat='server'>" +
                    "<div class='row'>" +
                    "<div class='col-sm-6'>" +
                    "<div class='card'>" +
                    "<div class='card-body'>" +
                    "   <h3 class='card-title'>" + nombre + "</h3>" +
                    "   <h4 class='card-title'>" + "Profesión:</h4>" +
                    "   <ul>" + ocupaciones +"</ul>"+
                    "   <h4 class='card-title'>" + "Teléfono: " + telefono + " </h4>" +
                    "   <p class='card-text'><h4>Correo: " + correo + " </h4></p>" +
                    "   <h4 class='card-title'>Brindo servicios en:</h4>" +
                    "   <ul> " + ubicaciones + "</ul>" +
                    "   <h4 class=" + "'card-title'>Descripción:</h4>" +
                    "   <p class='card-text'>" + descripcion + "</p>" +
                    "   <h4 class='text-info'>Redes Sociales</h4>" +
                    "   " + wsites + "<br /><br />" +
                    "<a href = " + "'index.aspx'" + " class=" + "'btn btn-primary'" + ">Regresar</a>" +
                    "</div></div></div></div></div>";
                contenedor.InnerHtml = Query;


            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}