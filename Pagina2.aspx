<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pagina2.aspx.cs" Inherits="Parcial_Policaro.Pagina2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Bienvenido, usuario</h2>
    <asp:Label ID="lblSaludo" runat="server" Font-Size="Large" ForeColor="Blue" />
    <br /><br />
    <asp:Button ID="btnLogout" runat="server" Text="Cerrar sesión" OnClick="btnLogout_Click" />
    <asp:HyperLink ID="lnkModificarPerfil" runat="server" NavigateUrl="ModificarPerfil.aspx">Modificar perfil</asp:HyperLink>
</asp:Content>
