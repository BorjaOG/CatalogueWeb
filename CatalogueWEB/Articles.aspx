<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="CatalogueWEB.Articles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/estilos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="margin-bottom: 20px">Articles</h1>

    <div class="clo-6" style="display: flex; flex-direction: column; justify-content: flex-end">
        <div class="mb-3">
            <asp:CheckBox Text="Advanced Filter" ID="chkAvanzado" runat="server" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" />
        </div>
    </div>
    <%if (FiltroAvanzado)
        { %>
    <div class="row">
        <div class="col-2">
            <div class="mb-3">
                <asp:Label ID="ddlCampo" runat="server" Text="Field"></asp:Label>
                <asp:DropDownList ID="ddField" AutoPostBack="true" CssClass="custom-dropdown" runat="server" OnSelectedIndexChanged="ddField_SelectedIndexChanged">
                    <asp:ListItem Text="" />
                    <asp:ListItem Text="Name" />
                    <asp:ListItem Text="Brand" />
                    <asp:ListItem Text="Price" />
                </asp:DropDownList>
            </div>
        </div>    
    <div class="col-2">
        <div class="mb-3">
            <asp:Label  ID="Label1" runat="server" Text="Criteria"></asp:Label>
            <asp:DropDownList  ID="ddCriteria" CssClass="custom-dropdown" runat="server">
                
            </asp:DropDownList>
        </div>
    </div>
    <div class="col-2">
        <div class="mb-3">
            <asp:Label  ID="Label2" runat="server" Text="Filter"></asp:Label>
            <asp:TextBox CssClass="custom-dropdown" ID="txtFiltroAvanzado" runat="server"></asp:TextBox>           
        </div>
      </div>
    </div>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-info" OnClick="btnSearch_Click" Text="Search" />
            </div>
        </div>
    </div>    
    <% }%>

    <asp:GridView Style="margin-top: 25px" ID="dgvArticles" runat="server" DataKeyNames="Id" CssClass="table"
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

