<%@ Page Title="" Language="C#" MasterPageFile="~/App/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="prueba.aspx.cs" Inherits="DirectorioServicios.prueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        #contenedor, #lista{
            width: 85%;
            margin: 0 auto;
        }

        .col-sm-6{
            margin: 0 auto;
        }

        label, select, button{
            padding-right: 5px;
            padding-left: 2px;
        }

        a i{
            font-size: 2em;
            margin: 10px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="lista" runat="server">
        <div class="row">
            <div class="col-sm-6">
                <div class="card">
                    <div class="card-body">
                        <h3 class="card-title">Juan Castro</h3>
                        <h5 class="card-title">Jardinero</h5>
                        <h5 class="card-title">70113556</h5>
                        <p class="card-text">juan.castro@outlook.com</p>
                        <h4 class="card-text">Brindo servicios en:</h4>
                        <ul>
                            <li class="card-title">Palmares</li>
                            <li class="card-title">San Ramón</li>
                            <li class="card-title">Atenas</li>
                            <li class="card-title">Naranjo</li>
                            <li class="card-title">Grecia</li>
                        </ul>
                        <h4 class="card-title">Descripción:</h4>
                        <p class="card-text">Diseñador de jardines con amplia experiencia en jardines residenciales y empresariales</p>
                        <h4 class="text-info">Redes Sociales</h4>
                        <a href="www.facebook.com"><i class="fab fa-facebook-square"></i></a>
                        <a href="www.twitter.com"><i class="fab fa-twitter"></i></a>
                        <a href="www.youtube.com"><i class="fab fa-youtube"></i></a>
                        <a href="www.instagram.com"><i class="fab fa-instagram"></i></a>
                        <br />
                        <br />
                        <a href="index.aspx" class="btn btn-primary">Regresar</a>
                    </div>
                </div>  
            </div>
        </div>
    </div>
</asp:Content>
