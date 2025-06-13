<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarPerfil.aspx.cs" Inherits="Parcial_Policaro.ModificarPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h2>Modificar Perfil</h2>
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
    <br />
    <asp:Label ID="lblNombre" runat="server" Text="Nombre:" />
    <asp:TextBox ID="txtNombre" runat="server" />
    <br /><br />
    <asp:Label ID="lblApellido" runat="server" Text="Apellido:" />
    <asp:TextBox ID="txtApellido" runat="server" />
    <br /><br />
    <asp:Label ID="lblPassword" runat="server" Text="Nueva contraseña:" />
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
    <br /><br />
    <asp:Label ID="lblPassword2" runat="server" Text="Repetir contraseña:" />
    <asp:TextBox ID="txtPassword2" runat="server" TextMode="Password" />
    <br /><br />
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" OnClick="btnGuardar_Click" />
    <br /><br />
</asp:Content>
