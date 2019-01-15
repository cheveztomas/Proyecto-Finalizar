<%@ Page Title="" Language="C#" MasterPageFile="~/App/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DirectorioServicios.FrmBuscador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style>
        #contenedor, #lista{
            width: 80%;
            margin: 0 auto;
        }

        .col-sm-6{
            margin: 0 auto;
        }

        label, select, button{
            padding-right: 5px;
            padding-left: 2px;
        }

    </style>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contenedor" class="DivSesion">
        <h2>Seleccione</h2>
       <div class="form-inline">
            <label for="sel1">Servicio:</label>
           <asp:DropDownList ID="ddlProfecion" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlProfecion_SelectedIndexChanged"></asp:DropDownList>
            
           <label for="sel1">Especialidad:</label>
           <asp:DropDownList ID="ddlEspecialidad" runat="server" class="form-control"></asp:DropDownList>

           <label for="sel1">Provincia:</label>
           <asp:DropDownList ID="ddlProvincia" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>
           
           <label for="sel1">Cantón:</label>
           <asp:DropDownList ID="ddlCanton" runat="server" class="form-control"></asp:DropDownList>
           <br />
            &nbsp;<asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click" />
    <!--<button type="submit" class="btn btn-primary" id="btnBuscar">Buscar</button>-->
        </div>
    </div>

    <br />
    <hr />
    <br />
    <div id="div_test" runat="server"> </div>
    <br />
    <br />


   <%-- <div id="lista" runat="server">
        <div class="row">
            <div class="col-sm-6">
                <div class="card">
                    <div class="card-body">
                        <h3 class="card-title">Juan Castro</h3>
                        <h5 class="card-title">Jardinero</h5>
                        <h5 class="card-title">70113556</h5>
                        <p class="card-text">juan.castro@outlook.com</p>
                        <p class="card-title">Descripción</p>
                        <p class="card-text"></p>
                        <a href="www.facebook.com">Facebook</a>
                        <a href="www.twitter.com">Twitter</a>
                        <a href="www.youtube.com">YouTube</a>
                        <a href="www.instagram.com">Instragram</a>
                        <a href="index.aspx" class="btn btn-primary">Regresar</a>
                    </div>
                </div>  
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-6">
                <div class="card">
                    <div class="card-body">
                        <h3 class="card-title">Juan Castro</h3>
                        <h5 class="card-title">Jardinero</h5>
                        <h5 class="card-title">70113556</h5>
                        <p class="card-text">juan.castro@outlook.com</p>
                        <a href="#" class="btn btn-primary">Ver más</a>
                    </div>
                </div>  
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-6">
                <div class="card">
                    <div class="card-body">
                        <h3 class="card-title">Juan Castro</h3>
                        <h5 class="card-title">Jardinero</h5>
                        <h5 class="card-title">70113556</h5>
                        <p class="card-text">juan.castro@outlook.com</p>
                        <a href="#" class="btn btn-primary">Ver más</a>
                    </div>
                </div>  
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-6">
                <div class="card">
                    <div class="card-body">
                        <h3 class="card-title">Juan Castro</h3>
                        <h5 class="card-title">Jardinero</h5>
                        <h5 class="card-title">70113556</h5>
                        <p class="card-text">juan.castro@outlook.com</p>
                        <a href="#" class="btn btn-primary">Ver más</a>
                    </div>
                </div>  
            </div>
        </div>
        <br />
        <br />
    </div>--%>

 


</asp:Content>
