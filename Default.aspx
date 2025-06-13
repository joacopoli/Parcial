<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Parcial_Policaro.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container d-flex align-items-center justify-content-center" style="min-height: 90vh;">
        <div class="card shadow p-4" style="width: 100%; max-width: 400px;">
            <h2 class="text-center mb-4">Iniciar Sesión</h2>
            <div class="mb-3">
                <label for="Txusuario" class="form-label">Usuario</label>
                <asp:TextBox ID="Txusuario" runat="server" CssClass="form-control" placeholder="Ingrese su usuario"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="TxPassword" class="form-label">Contraseña</label>
                <asp:TextBox ID="TxPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Ingrese su contraseña"></asp:TextBox>
            </div>
            <div class="mb-3 d-grid">
                <asp:Button ID="BtLogin" runat="server" Text="Ingresar" CssClass="btn btn-primary w-100" OnClick="BtLogin_Click" />
            </div>
            <div class="row mb-3">
                <div class="col-6 text-start">
                    <a href="registrese.aspx">Registrarse</a>
                </div>
                <div class="col-6 text-end">
                    <a href="recuperar.aspx">¿Olvidó su contraseña?</a>
                </div>
            </div>
            <div>
                <asp:Literal ID="lt_mensaje" runat="server" Visible="false"></asp:Literal>
            </div>
        </div>
    </div>
</asp:Content>