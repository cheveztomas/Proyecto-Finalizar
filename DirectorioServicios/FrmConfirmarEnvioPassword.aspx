<%@ Page Title="" Language="C#" MasterPageFile="~/App/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="FrmConfirmarEnvioPassword.aspx.cs" Inherits="DirectorioServicios.FrmConfirmarEnvioPassword" %>
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

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contenedor">
        <h2 class="text-success text-uppercase text-center">Su contraseña ha sido enviada a su correo</h2>
        <h3 class="text-success text-uppercase text-center">Gracias</h3>
    </div>
</asp:Content>
