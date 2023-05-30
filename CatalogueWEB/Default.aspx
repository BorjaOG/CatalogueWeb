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
       <p>Search Item:</p>
    <div class="input-group">
        <asp:TextBox CssClass="form-control my-textbox" ID="txtFilter" runat="server" AutoPostBack="true" OnTextChanged="txtFilter_TextChanged" style="width: 75%;"></asp:TextBox>
        <span class="input-group-btn">
            <asp:Button style="margin-left:4%" ID="Button1" runat="server" Text="Search" CssClass="btn btn-info" />
        </span>
    </div>
</div>
        <h5 style="margin-bottom:3%">
  <asp:Label ID="lblfav" runat="server" Visible="false" style="color:darkgoldenrod" Text="">
    <a href="Favorites.aspx" style="text-decoration: none; color: darkgoldenrod;">Article added to Favorites ⭐</a>
  </asp:Label>
</h5>
    <div class="row row-cols-1 row-cols-md-3 row-cols-sm-2 g-4">
    <asp:Repeater ID="RepeaterArticles" runat="server">
        <ItemTemplate>
            <div class="col-md-4 col-6">
                <div class="card" runat="server">
                    <img src="<%#Eval("UrlImagen") %>" alt="..." class="card-img-top" onerror="this.src='https://www.mansor.com.uy/wp-content/uploads/2020/06/imagen-no-disponible2.jpg'" />
                    <div class="card-body">
                        <h5 class="card-title"><%#Eval("Nombre") %></h5>
                        <p class="card-text"><%#Eval("Descripcion") %></p>
                        <p class="card-text">$<%# string.Format("{0:0.00}", Eval("Precio")) %></p>
                        <a id="btn-detail" class="btn btn-info" href="Details.aspx?Id=<%#Eval("Id") %>">View Details</a>
                        <asp:Button Style="margin-left: 5%; border-radius: 50%; background: transparent"
                           CssClass="btn btn-info btn-fav" ID="btnFav" OnClick="btnFav_Click" runat="server" Text="⭐"
                            CommandArgument='<%#Eval("Id") %>' />
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
</asp:Content>

