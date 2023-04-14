<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CatalogueWEB.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/estilos.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Home</h1>
    <p>Welcome to the Catalogue</p>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <% foreach (Domain.Articulo arti in ListaArticulos) { %>
        <div class="col">
            <div class="card">
                <img src="<%: arti.UrlImagen %>" alt="<%: arti.Nombre %>" class="card-img-top" />
                <div class="card-body">
                    <h5 class="card-title"><%: arti.Nombre %></h5>
                    <p class="card-text"><%: arti.Descripcion %></p>
                    <a href="Details.aspx?Id=<%:arti.Id %>">View Details</a>
                </div>
            </div>
        </div>
        <% } %>
    </div>
</asp:Content>

