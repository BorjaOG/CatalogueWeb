<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="CatalogueWEB.Articles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/estilos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="">Articles</h1>
    <asp:GridView ID="dgvArticles" runat="server" DataKeyNames="Id" CssClass="table"
        AutoGenerateColumns="false" OnSelectedIndexChanged="dgvArticles_SelectedIndexChanged"
        OnPageIndexChanging="dgvArticles_PageIndexChanging" 
        AllowPaging="true" PageSize="10">
        <Columns>
            <asp:BoundField HeaderText="Name" DataField="Nombre" />
            <asp:BoundField HeaderText="Brand" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Category" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Price" DataField="Precio" />
            <asp:CommandField HeaderText="Action" ShowSelectButton="true" SelectText="✍️" />
        </Columns>
    </asp:GridView>
    <a href="ArticlesForm.aspx" class="btn btn-info">Add Article</a>
</asp:Content>

