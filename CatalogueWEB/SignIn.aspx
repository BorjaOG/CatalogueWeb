<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="CatalogueWEB.SignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style= margin-bottom:40px>Sing In</h1>
    <div class="row">
        <div class="col-4">           
            <div style= "margin-top:20px" class="mb-3">
                <label class="form-label">Email address</label>
                <asp:TextBox class="form-text" ID="txtEmail" CssClass="form-control" placeholder="example@mail.com" runat="server"></asp:TextBox>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

                <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
            </div>
            <div style= "margin-top:20px" class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox placeholder="******" TextMode="password" ID="txtPass" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <asp:Button style= "margin-top:10px" runat="server" type="submit" ID="btnSignIn" OnClick="btnSignIn_Click" class="btn btn-info" Text="Sign In" />          
            <a style= "margin-top:10px" class="btn btn-info" href="Default.aspx">Back</a>
        </div> 
    </div>
</asp:Content>
