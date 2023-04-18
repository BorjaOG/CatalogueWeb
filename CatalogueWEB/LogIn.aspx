<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="CatalogueWEB.LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style= margin-bottom:40px>Log In</h1>
<div class="row">
        <div class="col-4">           
            <div style= "margin-top:20px" class="mb-3">
                <label class="form-label">Email address</label>
                <asp:TextBox ID="txtEmailLogin" CssClass="form-control" runat="server"></asp:TextBox>
                <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
            </div>
            <div style= "margin-top:20px" class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox TextMode="password" ID="txtPassLogin" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <asp:Button style= "margin-top:10px" runat="server" type="submit" ID="btnlogIn" Onclick="btnlogIn_Click" class="btn btn-info" Text="Log In" />          
            <a style= "margin-top:10px" class="btn btn-info" href="Default.aspx">Back</a>
        </div> 
    </div>
</asp:Content>
