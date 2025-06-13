<%@ Page Title="Cambiar contraseña" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="Parcial_Policaro.CambiarPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container d-flex align-items-center justify-content-center" style="min-height:80vh;">
        <div class="card shadow p-4" style="max-width:430px;width:100%;">
            <h2 class="text-center mb-4">Elegir nueva contraseña</h2>
            <asp:Literal ID="ltMensaje" runat="server"></asp:Literal>
            <asp:Panel ID="panelCambio" runat="server">
                <div class="mb-3">
                    <label for="txtPassword1" class="form-label">Nueva contraseña:</label>
                    <asp:TextBox ID="txtPassword1" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txtPassword2" class="form-label">Repetir contraseña:</label>
                    <asp:TextBox ID="txtPassword2" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
                <div class="d-grid mb-3">
                    <asp:Button ID="btnCambiar" runat="server" Text="Cambiar" CssClass="btn btn-primary w-100" OnClick="btnCambiar_Click" />
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>