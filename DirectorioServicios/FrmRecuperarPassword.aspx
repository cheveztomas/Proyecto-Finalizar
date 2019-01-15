<%@ Page Title="" Language="C#" MasterPageFile="~/App/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="FrmRecuperarPassword.aspx.cs" Inherits="DirectorioServicios.FrmRecuerarContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #contenedor{
            width: 80%;
            margin: 0 auto;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contenedor" class="DivSesion">
        <h2>Recupere su contraseña</h2>
        <form class="px-4 py-3">
            <div class="form-group" id="txt_Correo">
                <label for="exampleDropdownFormEmail1">Ingrese su correo electrónico</label>
                <asp:TextBox type="email" class="form-control" placeholder="email@example.com" ID="txt_Correo" runat="server" MaxLength="30" ValidationGroup="IniciarSesion"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_Correo" Display="Dynamic" ErrorMessage="* Correo incorrecto." ForeColor="Red" ValidationExpression="^[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$" ValidationGroup="IniciarSesion"></asp:RegularExpressionValidator>
            </div>
            <asp:Button type="submit" class="btn btn-primary" runat="server" ID="btn_Recuperar" Text="Recuperar Contraseña" OnClick="btn_Recuperar_Click" ValidationGroup="IniciarSesion" />
        </form>
</asp:Content>
