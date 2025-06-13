<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="registrese.aspx.cs" Inherits="Parcial_Policaro.registrese" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container d-flex align-items-center justify-content-center"style="min-height:80vh;">
        <div class="card shadow modern-registro p-4" style="width:100%;max-width:600px;border-radius:16px;">
            <h2 class="text-center mb-4" style="font-weight:600;">Regístrate fácilmente</h2>
            <div class="row mb-3">
                <div class="col-6">
                    <label for="Txname" class="form-label">Nombre</label>
                    <asp:TextBox ID="Txname" CssClass="form-control" runat="server" placeholder="Ej: Juan"></asp:TextBox>
                </div>
                <div class="col-6">
                    <label for="Txapellido" class="form-label">Apellido</label>
                    <asp:TextBox ID="Txapellido" CssClass="form-control" runat="server" placeholder="Ej: Pérez"></asp:TextBox>
                </div>
            </div>
            <div class="mb-3">
                <label for="Txemail" class="form-label">Email</label>
                <asp:TextBox ID="Txemail" CssClass="form-control" runat="server" placeholder="ejemplo@email.com"></asp:TextBox>
            </div>
            <div class="row mb-3">
                <div class="col-6">
                    <label for="TxPassword" class="form-label">Contraseña</label>
                    <asp:TextBox ID="TxPassword" TextMode="Password" CssClass="form-control" runat="server" placeholder="Ingrese una contraseña"></asp:TextBox>
                </div>
                <div class="col-6">
                    <label for="TxPassword2" class="form-label">Repetir contraseña</label>
                    <asp:TextBox ID="TxPassword2" TextMode="Password" CssClass="form-control" runat="server" placeholder="Repita la contraseña"></asp:TextBox>
                </div>
            </div>
            <div class="text-center mb-2">
                <asp:Button ID="BtRegistrarse" runat="server" Text="Registrarse" CssClass="btn btn-primary w-100" OnClick="BtRegistrarse_Click" />
            </div>
            <div class="text-center mb-2">
                <asp:Literal ID="lblMensaje" runat="server" Visible="false"></asp:Literal>
            </div>
            <div class="text-center">
                <a href="Default.aspx" class="small">¿Ya tienes cuenta? Inicia sesión</a>
            </div>
        </div>
    </div>
</asp:Content>