<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="CatalogueWEB.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <h1 style= margin-bottom:40px>Profile</h1>
    <div class="row">
        <div class="col-4">           
            <div style= "margin-top:22px" class="mb-3">
                <label class="form-label">Email address</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
            </div>
            <div style= "margin-top:30px" class="mb-3">
                <label class="form-label">Name</label>
                <asp:TextBox  ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
             <div style= "margin-top:30px" class="mb-3">
                <label class="form-label">Surname</label>
                <asp:TextBox  ID="TxtSurname" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div style= "margin-top:6%">
            <asp:Button style= "margin-top:4%" runat="server" type="submit" ID="btnSaveProfile" Onclick="btnSaveProfile_Click" class="btn btn-info" Text="Save" />          
            <a style= "margin-top:4%" class="btn btn-info" href="Default.aspx">Back</a>
        </div>
      </div>         
        <div class="col-4"> 
            <div class="mb-3">
                <div style= "margin-top:4.5%">   
            <asp:Label  ID="lblImagenPerfil" runat="server" Text="Profile Image"></asp:Label>           
           <asp:FileUpload style= "margin-top: 2.5%" ID="txtPhoto" class="form-control" type="file" runat="server" />
           </div>
            <asp:Image style= "margin-top:6%" ID="ImgPerfil" ImageUrl="https://upload.wikimedia.org/wikipedia/commons/8/89/Portrait_Placeholder.png" 
                CssClass="img-fluid mb-3" runat="server" Width="60%" />
        </div> 
        </div>
      </div>    
</asp:Content>
