<%@ Page Title="" Language="C#" MasterPageFile="~/App/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="FrmPerfilProfesional.aspx.cs" Inherits="DirectorioServicios.FrmPerfilProfesional" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #contenedor{
            width: 85%;
            margin: 0 auto;
        }

        .btnCerrar{
            text-align: right;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div id="contenedor" class="DivSesion">
&nbsp;&nbsp;
            
&nbsp;<div class="btnCerrar"><asp:LinkButton ID="lnkCerrarSesion"  runat="server" OnClick="lnkCerrarSesion_Click">Cerrar Sesión</asp:LinkButton></div>
                <br />
                <h2 class="text-info">Perfil Profesional</h2>
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblApellido1" runat="server" Text="Primer Apellido:"></asp:Label>
                <asp:TextBox ID="txtApellido1" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblApellido2" runat="server" Text="Segundo Apellido:"></asp:Label>
                <asp:TextBox ID="txtApellido2" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label>
                <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblCorreo" runat="server" Text="Correo Electrónico:"></asp:Label>
                <asp:TextBox ID="txtCorreo" runat="server" ReadOnly="True"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblAcercaDeMi" runat="server" Text="Acerca de mi:"></asp:Label>
                <asp:TextBox ID="txtDescripcion" class="form-control" runat="server" TextMode="MultiLine" Width="50%"></asp:TextBox>
                <br />
                <a href="FrmCambiarPass.aspx" class="text-info">Cambiar Contraseña</a>
                <br />
                <br />
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-info" />

                <br />

                <br />

                <asp:GridView ID="grd_Ocupaciones" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay ubicaciones registradas." Width="100%">
                    <Columns>
                        <asp:BoundField DataField="ID_OCUPACION" ShowHeader="False" Visible="False" />
                        <asp:BoundField DataField="PROFESION" HeaderText="Profesión" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnk_eliminarProfesion" runat="server" CommandArgument='<%# Eval("ID_OCUPACION").ToString() %>' OnCommand="lnk_eliminarProfesion_Command">Eliminar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <br />
                <div class="form-inline">
                    <asp:Label ID="lblProfesion1" runat="server" Text="Profesión:"></asp:Label>
                    <asp:DropDownList ID="ddlProfesion" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlProfesion_SelectedIndexChanged"></asp:DropDownList>

                    <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad:"></asp:Label>
                    <asp:DropDownList ID="ddlEspecialidad" class="form-control" runat="server"></asp:DropDownList>

                    <asp:Button ID="btnGuardarProfesion" runat="server" Text="Agregar" CssClass="btn btn-info" OnClick="btnGuardarProfesion_Click" />
                </div>
                <br />
                <br />
                <asp:GridView ID="grd_Ubicacion" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay Ubicaciones" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="ID_UBICACION" HeaderText="Id Ubicación" ShowHeader="False" Visible="False" />
                        <asp:BoundField DataField="PROVINCIA" HeaderText="Provincia" />
                        <asp:BoundField DataField="CANTON" HeaderText="Cantón" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="Lnk_EliminarUbicacion" runat="server" CommandArgument='<%# Eval("ID_UBICACION").ToString() %>' OnCommand="lkn_EliminarUbicacion_Command">Eliminar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <br />
                <div class="form-inline">
                    <asp:Label ID="lblProvincia" runat="server" Text="Provincia:"></asp:Label>
                    <asp:DropDownList ID="ddlProvincia" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>

                    <asp:Label ID="lblCanton" runat="server" Text="Cantón:"></asp:Label>
                    <asp:DropDownList ID="ddlCanton" class="form-control" runat="server"></asp:DropDownList>

                    <asp:Label ID="lblDetalleDireccion" runat="server" Text="Dirección detallada:"></asp:Label>
                    <asp:TextBox ID="txtDetalleDireccion" runat="server"></asp:TextBox>

                    <asp:Button ID="btnGuardarUbicacion" runat="server" Text="Agregar" CssClass="btn btn-info" OnClick="btnGuardarUbicacion_Click" />
                </div>
                <br />
                <br />
                <asp:GridView ID="grd_websites" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="COD_SITIO" HeaderText="COD_SITIO" ShowHeader="False" Visible="False" />
                        <asp:BoundField DataField="URL_SITIO" HeaderText="Dirección Web" />
                        <asp:BoundField DataField="NOMBRE_SITIO" HeaderText="Nombre del Sitio Web" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("COD_SITIO").ToString() %>' OnCommand="lnkEliminar_Command1">Eliminar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                   
                </asp:GridView>
                <br />
                <asp:Label ID="lblWebsites" runat="server" Text="Redes Sociales:"></asp:Label>
                <br />
                <div class="form-inline">
                    <asp:Label ID="lblUrl" runat="server" Text="Dirección Web:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtURL" runat="server"></asp:TextBox>
                    &nbsp;
                    <asp:Label ID="lblNombreSitio" runat="server" Text="Nombre del Sitio Web:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtNombreSitio" runat="server"></asp:TextBox>
                    &nbsp;
                    &nbsp;
                    <asp:Button ID="btnGuardarSitiosWeb" runat="server" Text="Agregar" CssClass="btn btn-info" OnClick="btnGuardarSitiosWeb_Click" />
                </div>
             
                <br />
                <br />
                
                <br />
         </div>
</asp:Content>
