<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="CatalogueWEB.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/estilos.css" rel="stylesheet" />
    <script src="Scripts/JavaScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="margin-bottom:2.5%">Contac Us</h1>
   
    <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                <label for="name">Name (*)</label>
                <input type="text" class="form-control" id="name" name="name" placeholder="Enter you Name" >
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label for="surname">Surname</label>
                <input type="text" class="form-control" id="surname" name="surname" placeholder="Enter you Surname" >
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label style="margin-top:3.5%" for="phone">Phone Number</label>
                <input type="text" class="form-control" id="phone" name="phone" placeholder="Enter your phone number" >
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label style="margin-top:3.5%" for="email">Email (*)</label>
                <input type="email" class="form-control" id="email" name="email" placeholder="Enter your email">
            </div>
        </div>
        <div class="col-md-12">
            <div class="form-group">
                <label style="margin-top:1.5%" for="message">Message (*)</label>
                <textarea style="margin-top:0.4%" class="form-control" id="message" name="message" placeholder="Enter you message" rows="8" ></textarea>
            </div>
        </div>
        <div class="col-md-12">
            <asp:Button OnClientClick="return validateForm();" onclick="btnEnviar_Click" style="margin-top:3%" ID="btnEnviar" 
                class="btn btn-info" runat="server" Text="Send" />
            <asp:Button style="margin-top:3%" class="btn btn-primary" ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back"  />
            </div>
            <asp:Label style="display: block; max-width: 300px; margin-top: 10px;" ID="lblMessage" runat="server" Visible="false" CssClass="alert alert-success"></asp:Label>
        <script>
            function validateForm() {
                var email = document.getElementById("email").value;
                var message = document.getElementById("message").value;

                if (email === "" || message === "") {
                    alert("Please enter required fields (*)");
                    return false;
                }
                document.getElementById("lblMessage").innerHTML = "Message sent successfully!";
                document.getElementById("lblMessage").style.display = "block";
                return true;
            }
        </script>
        </div>
    
    


</asp:Content>
