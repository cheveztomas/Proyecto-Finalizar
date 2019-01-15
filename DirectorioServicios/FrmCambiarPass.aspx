<%@ Page Title="" Language="C#" MasterPageFile="~/App/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="FrmCambiarPass.aspx.cs" Inherits="DirectorioServicios.FrmCambiarPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #contenedor{
            width: 85%;
            margin: 0 auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contenedor">
        <h2>Cambie su contraseña aquí</h2>
            <form class="px-4 py-3">
                <div class="form-group">
                    <label for="exampleDropdownFormPassword1">Contraseña Nueva</label>
                    <asp:TextBox class="form-control" id="txt_Conrteasenia" placeholder="Password" runat="server" TextMode="Password" MaxLength="16" ValidationGroup="Registrar"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Conrteasenia" ErrorMessage="*Contraseña requerido." ForeColor="Red" ValidationGroup="Registrar" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ClientIDMode="AutoID" ControlToValidate="txt_Conrteasenia" Display="Dynamic" ErrorMessage="* La contraseña debe tener al entre 8 y 16 caracteres, al menos un dígito, al menos una minúscula y al menos una mayúscula." Font-Size="Small" ForeColor="Red" ValidationExpression="^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])\S{8,16}$" ValidationGroup="Registrar"></asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                    <label for="exampleDropdownFormPassword1">Confirmar Contraseña</label>
                    <asp:TextBox class="form-control" id="txt_ConrteaseniaConfir" placeholder="Password" runat="server" TextMode="Password" MaxLength="16" ValidationGroup="Registrar"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" BackColor="White" ControlToCompare="txt_Conrteasenia" ControlToValidate="txt_ConrteaseniaConfir" ErrorMessage="* Contraseña no coincide." ForeColor="Red" ValidationGroup="Registrar" Display="Dynamic"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_ConrteaseniaConfir" ErrorMessage="*Confirmar contraseña raquerido." ForeColor="Red" ValidationGroup="Registrar" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <asp:Button ID="btn_Registrar" runat="server" class="btn btn-primary" Text="Cambiar Contraseña" OnClick="btn_Registrar_Click" ValidationGroup="Registrar" />
            </form>
            <div class="dropdown-divider"></div>
    </div>
</asp:Content>
