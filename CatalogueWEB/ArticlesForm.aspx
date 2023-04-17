<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ArticlesForm.aspx.cs" Inherits="CatalogueWEB.ArticlesForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Content/estilos.css" rel="stylesheet" />
    <asp:ScriptManager runat="server" ID="ScriptManager1" />
    <h1>Form</h1>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Code</label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Name</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtMarca" class="form-label">Brand</label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtCategoria" class="form-label">Category</label>
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select">
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Price</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="button-container mb-3">
                        <asp:Button ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" CssClass="btn btn-info" Text="Save" />
                        <a class="btn btn-info" href="Articles.aspx">Back</a>
                        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" CssClass="btn btn-danger" Text="Delete" />      
                        <div class="mb-3" style="margin-top:10px ">
                            <%if (ConfirmaEliminacion)
                            {%>
                            <asp:CheckBox Text="Confirm to delete" ID="chkConfirmDelete" runat="server"  />
                            <asp:Button ID="btnConfirmDelete" runat="server" OnClick="btnConfirmDelete_Click" CssClass="btn btn-outline-danger ms-2" Text="Delete" />
                            <% } %>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Description</label>
                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="UrlImagen" class="form-label">Image URL</label>
                        <asp:TextBox ID="txtUrlImagen" CssClass="form-control" runat="server"
                            AutoPostBack="true" OnTextChanged="txtUrlImagen_TextChanged"></asp:TextBox>
                    </div>
                    <asp:Image ImageUrl="https://worldwellnessgroup.org.au/wp-content/uploads/2020/07/placeholder.png"
                        runat="server" ID="imgArticle" Width="60%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
