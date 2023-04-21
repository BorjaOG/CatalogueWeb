<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favorites.aspx.cs" Inherits="CatalogueWEB.Favorites" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Favorites</h1>
    <asp:GridView ID="dgvArticles" CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id"
       OnSelectedIndexChanged="dgvArticles_SelectedIndexChanged"  runat="server"
        OnPageIndexChanging="dgvArticles_PageIndexChanging"  AllowPaging="true" PageSize="10" >
         <Columns>
           <asp:TemplateField HeaderText="Favoritos">
            <ItemTemplate>
                <asp:CheckBox ID="chkFavorite" runat="server" />
                <asp:LinkButton ID="lbFavorite" runat="server" CommandName="Select" Text="⭐" />
            </ItemTemplate>
        </asp:TemplateField>
            
            <asp:BoundField HeaderText="Código" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:BoundField HeaderText="Brand" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Category" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Price" DataField="Precio" />
        </Columns>
    </asp:GridView>
        <a href="Default.aspx">Back</a>
</asp:Content>
