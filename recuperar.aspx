<%@ Page Title="Recuperar acceso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="recuperar.aspx.cs" Inherits="Parcial_Policaro.recuperar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container d-flex align-items-center justify-content-center" style="min-height:80vh;">
        <div class="card shadow p-4" style="max-width:400px;width:100%; border-radius: 16px;">
            <h2 class="text-center mb-4" style="font-weight: 600;">Recuperar Contraseña</h2>
            <div class="mb-3">
                <label for="TxEmail" class="form-label">Ingrese su email:</label>
                <asp:TextBox ID="TxEmail" CssClass="form-control" runat="server" placeholder="ejemplo@email.com"></asp:TextBox>
            </div>
            <div class="d-grid mb-3">
                <asp:Button ID="BtRecuperar" runat="server" Text="Enviar enlace" CssClass="btn btn-primary w-100" OnClick="BtRecuperar_Click" />
            </div>
            <div class="text-center">
                <asp:Literal ID="lb_mensaje" runat="server" Visible="false"></asp:Literal>
            </div>
            <div class="text-center mt-3">
                <a href="Default.aspx" class="small">Volver al inicio de sesión</a>
            </div>
        </div>
    </div>
</asp:Content>