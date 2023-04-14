<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="CatalogueWEB.Articles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/estilos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Articles</h1>
    <asp:GridView ID="dgvArticles" runat="server" CssClass="table" AutoGenerateColumns="false">  
   <columns> 
       <asp:Boundfield HeaderText ="Codigo" DataField="Codigo" />
       <asp:Boundfield HeaderText ="Nombre" DataField="Nombre" />
       <asp:Boundfield HeaderText="Descripcion" DataField="Descripcion" />
        <asp:Boundfield HeaderText="Marca" DataField="Marca.Descripcion" />
       <asp:Boundfield HeaderText="Categoria" DataField="Categoria.Descripcion" />
       <asp:Boundfield HeaderText ="Precio" DataField="Precio" />
    </columns>
    </asp:GridView> 
</asp:Content>
