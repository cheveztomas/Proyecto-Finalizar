<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmRegistroDeUsuarios.aspx.cs" Inherits="DirectorioServicios.FrmRegistroDeUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0"/>
    <title>Registro de Usuarios</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <br />
            <br />
            <a href="FrmBuscador.aspx">Inicio</a>
            <br />

            <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
&nbsp;<br />
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblApellido1" runat="server" Text="Apellido 1"></asp:Label>
            <br />
            <asp:TextBox ID="txtApellido1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblApellido2" runat="server" Text="Apellido 2"></asp:Label>
            <br />
            <asp:TextBox ID="txtApellido2" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblTelefono" runat="server" Text="Teléfono"></asp:Label>
            <br />
            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblCorreo" runat="server" Text="Correo"></asp:Label>
            <br />
            <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblUserProfesional" runat="server" Text="Marcar si eres un profesional"></asp:Label>
            <br />
            <asp:CheckBox ID="chkProfesional" runat="server" />
            <br />
            <br />
            <asp:Label ID="lblProfesion" runat="server" Text="Profesión 1"></asp:Label>
            <br />
            <asp:DropDownList ID="drpdlProfesion1" runat="server" OnSelectedIndexChanged="drpdlProfesion1_SelectedIndexChanged">
                <asp:ListItem Selected="True">Electricista</asp:ListItem>
                <asp:ListItem>Albañil</asp:ListItem>
                <asp:ListItem>Plomero</asp:ListItem>
                <asp:ListItem>Pintor</asp:ListItem>
                <asp:ListItem>Jardinero</asp:ListItem>
                <asp:ListItem>Carpintero</asp:ListItem>
                <asp:ListItem>Soldador</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
&nbsp;<asp:Label ID="lblProfesion2" runat="server" Text="Especialidad 1"></asp:Label>
            <br />
            <asp:DropDownList ID="drpdlProfesion2" runat="server">
                <asp:ListItem Selected="True">Electricista</asp:ListItem>
                <asp:ListItem>Albañil</asp:ListItem>
                <asp:ListItem>Plomero</asp:ListItem>
                <asp:ListItem>Pintor</asp:ListItem>
                <asp:ListItem>Jardinero</asp:ListItem>
                <asp:ListItem>Carpintero</asp:ListItem>
                <asp:ListItem>Soldador</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblProfesion1" runat="server" Text="Profesión 3"></asp:Label>
            <br />
            <asp:DropDownList ID="drpdlProfesion3" runat="server">
                <asp:ListItem Selected="True">Electricista</asp:ListItem>
                <asp:ListItem>Albañil</asp:ListItem>
                <asp:ListItem>Plomero</asp:ListItem>
                <asp:ListItem>Pintor</asp:ListItem>
                <asp:ListItem>Jardinero</asp:ListItem>
                <asp:ListItem>Carpintero</asp:ListItem>
                <asp:ListItem>Soldador</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblDescripcion" runat="server" Text="Descripción"></asp:Label>
            <br />
            <textarea id="txtAreaDescripcion" cols="20" name="S1" rows="2"></textarea><br />
            <br />
            <asp:Label ID="lblDireccion" runat="server" Text="Donde puede brindar el servicio?"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblProvincia" runat="server" Text="Provincia 1"></asp:Label>
            <br />
            <asp:DropDownList ID="drpdlProvincia1" runat="server" OnSelectedIndexChanged="drpdlProvincia1_SelectedIndexChanged">
                <asp:ListItem Selected="True">ALAJUELA</asp:ListItem>
                <asp:ListItem>HEREDIA</asp:ListItem>
                <asp:ListItem>LIMÓN</asp:ListItem>
                <asp:ListItem>SAN JOSÉ</asp:ListItem>
                <asp:ListItem>PUNTARENAS</asp:ListItem>
                <asp:ListItem>GUANACASTE</asp:ListItem>
                <asp:ListItem>CARTAGO</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Cantón 1"></asp:Label>
            <br />
            <asp:DropDownList ID="drpdlCanton1" runat="server">
                <asp:ListItem Selected="True">ALAJUELA</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Provincia 2"></asp:Label>
            <br />
            <asp:DropDownList ID="drpdlProvincia2" runat="server">
                <asp:ListItem Selected="True">ALAJUELA</asp:ListItem>
                <asp:ListItem>HEREDIA</asp:ListItem>
                <asp:ListItem>LIMÓN</asp:ListItem>
                <asp:ListItem>SAN JOSÉ</asp:ListItem>
                <asp:ListItem>PUNTARENAS</asp:ListItem>
                <asp:ListItem>GUANACASTE</asp:ListItem>
                <asp:ListItem>CARTAGO</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Cantón 2"></asp:Label>
            <br />
            <asp:DropDownList ID="drpdlCanton2" runat="server">
                <asp:ListItem>ALAJUELA</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Provincia 3"></asp:Label>
            <br />
            <asp:DropDownList ID="drpdlProvincia3" runat="server">
                <asp:ListItem Selected="True">ALAJUELA</asp:ListItem>
                <asp:ListItem>HEREDIA</asp:ListItem>
                <asp:ListItem>LIMÓN</asp:ListItem>
                <asp:ListItem>SAN JOSÉ</asp:ListItem>
                <asp:ListItem>PUNTARENAS</asp:ListItem>
                <asp:ListItem>GUANACASTE</asp:ListItem>
                <asp:ListItem>CARTAGO</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblCanton" runat="server" Text="Cantón 3"></asp:Label>
            <br />
            <asp:DropDownList ID="drpdlCanton3" runat="server">
                <asp:ListItem>ALAJUELA</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblDireccion0" runat="server" Text="Detalles"></asp:Label>
            <br />
            <textarea id="txtAreaDetalles" cols="20" name="S2" rows="2"></textarea><br />
            <br />
            <asp:Label ID="lblRedesSociales" runat="server" Text="Redes Socales"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Facebook: "></asp:Label>
&nbsp;<asp:TextBox ID="txtFacebook" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Twiter:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtTwitter" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label8" runat="server" Text="Youtube:"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label9" runat="server" Text="Instagram:"></asp:Label>
&nbsp;
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblDireccion1" runat="server" Text="Contraseña"></asp:Label>
            <br />
            <asp:TextBox ID="txtContraseña" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblDireccion2" runat="server" Text="Confirmar Contraseña"></asp:Label>
            <br />
            <asp:TextBox ID="txtConfirmarContraseña" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
&nbsp;&nbsp;
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" />
            <br />

        </div>
    </form>
</body>
</html>
