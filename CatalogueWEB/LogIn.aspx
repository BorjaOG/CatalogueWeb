<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="CatalogueWEB.LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style= margin-bottom:40px>Log In</h1>
<div class="row">
        <div class="col-4">           
            <div style= "margin-top:20px" class="mb-3">
                <label class="form-label">Email address</label>
              <asp:TextBox placeholder="example@mail.com" ID="txtEmailLogin" CssClass="form-control" runat="server" OnTextChanged="txtEmailLogin_TextChanged"></asp:TextBox>

                 <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
            </div>
            <div style= "margin-top:20px" class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox  placeholder="******" TextMode="password" ID="txtPassLogin" CssClass="form-control" runat="server"></asp:TextBox>
             <asp:Label ID="lblMessage1" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <asp:Button style= "margin-top:10px" runat="server" type="submit" ID="btnlogIn" Onclick="btnlogIn_Click" class="btn btn-info" Text="Log In" />          
            <a style= "margin-top:10px" class="btn btn-info" href="SignIn.aspx">Register</a>
            <a style= "margin-top:10px" class="btn btn-primary" href="Default.aspx">Back</a>
            
        </div> 
    </div><asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    <script>
        function validateForm() {
            var email = document.getElementById("txtEmailLogin").value;
            var pass = document.getElementById("txtPassLogin").value;

            if (email === "" || pass === "") {
                alert("Please enter required fields (*)");
                return false;
            }

            document.getElementById("lblMessage").style.display = "none";
            return true;
        }
    </script>
</asp:Content>
