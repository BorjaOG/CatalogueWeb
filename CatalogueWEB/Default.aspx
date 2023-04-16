<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CatalogueWEB.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/estilos.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Home</h1>
    <div class="col-6">
    <h4 style="margin-bottom:40px">Welcome to the Catalogue</h4>
    <asp:Label ID="lblFilter" runat="server" Text="Search by Name"></asp:Label>
    <asp:TextBox style="margin-bottom:20px" CssClass="form-control" ID="txtFilter" runat="server" AutoPostBack="true" OnTextChanged="txtFilter_TextChanged"></asp:TextBox>
    </div>
    <div class="row row-cols-1 row-cols-md-3 g-4">       
        <asp:Repeater ID="RepeaterArticles" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("UrlImagen") %>" alt="..." class="card-img-top" />
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <a href="Details.aspx?Id=<%#Eval("Id") %>">View Details</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

