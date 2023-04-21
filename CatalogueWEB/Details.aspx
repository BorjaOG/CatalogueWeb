<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="CatalogueWEB.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Details</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ReadOnly="true" ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Code</label>
                <asp:TextBox ReadOnly="true" ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Name</label>
                <asp:TextBox ReadOnly="true" ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label  for="txtMarca" class="form-label">Brand</label>
                <asp:DropDownList ReadOnly="true" ID="ddlMarca" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtCategoria" class="form-label">Category</label>
                <asp:DropDownList ReadOnly="true" ID="ddlCategoria" runat="server" CssClass="form-select">
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Price</label>
                <asp:TextBox ReadOnly="true" ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <a class="btn btn-info" href="Default.aspx">Back</a>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Description</label>
                <asp:TextBox ReadOnly="true" ID="txtDescripcion" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="UrlImagen" class="form-label">Image</label>
                <asp:TextBox ReadOnly="true" OnTextChanged="txtUrlImagen_TextChanged" ID="txtUrlImagen" CssClass="form-control" runat="server"
                    AutoPostBack="true"></asp:TextBox>
            </div>
            <asp:Image ImageUrl="https://worldwellnessgroup.org.au/wp-content/uploads/2020/07/placeholder.png"
                runat="server" ID="imgArticle" Width="60%" />
        </div>
    </div>
</asp:Content>
