<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ArticlesForm.aspx.cs" Inherits="CatalogueWEB.ArticlesForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Form</h1>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Name</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Code</label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Description</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtMarca" class="form-label">Brand</label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select"></asp:DropDownList>
            </div><div class="mb-3">
                <label for="txtCategoria" class="form-label">Category</label>
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select">
                <asp:ListItem text="Cell-Phone" />
                <asp:ListItem text="Media" />
                <asp:ListItem text="TV" />
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Price</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-info" Text="Aceptar" />
                <a href="Articles.aspx">Cancelar</a>
            </div>
        </div>
    </div>
</asp:Content>
