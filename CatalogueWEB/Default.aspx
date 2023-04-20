<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CatalogueWEB.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/estilos.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" integrity="sha512-3vZLgWZVL8e/F4k9z4t+QLM1WLCfx8YwAWwM71YBv7tAeW8g4GoB4X9OicSPm1CjrWm66lLwSjKzsvhz0p/GOA==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <link href="Font/css/all.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Home</h1>
    <div class="col-6">
        <h4 style="margin-bottom: 40px">Welcome to the Catalogue</h4>
        <asp:Label ID="lblFilter" runat="server" Text="Search by Name:"></asp:Label>
        <asp:TextBox Style="margin-bottom: 6%" CssClass="form-control my-textbox" ID="txtFilter" runat="server" AutoPostBack="true" OnTextChanged="txtFilter_TextChanged"></asp:TextBox>
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
                            <a id="btn-detail" class="btn btn-info" href="Details.aspx?Id=<%#Eval("Id") %>">View Details</a>

                            <button style="margin-left: 60%; display: inline-block; color:goldenrod; border-radius:50%; vertical-align: middle" type="button" class="btn-favorite"; ">
                                <span class="fa fa-star"></span>
                            </button>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

