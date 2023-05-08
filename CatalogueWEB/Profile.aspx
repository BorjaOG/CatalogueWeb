<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="CatalogueWEB.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="Content/estilos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
    <style>
        .validation{
            color:red;
        }
    </style>
    
    <h1 style="margin-bottom:6%">Profile</h1>
    <div class="row ">
        <div class="col-4">           
            <div  class="mb-3">
                <label class="form-label">Email address</label>
                <asp:TextBox ReadOnly="true" ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Required" CssClass="validation" ControlToValidate="txtEmail" runat="server"/>
            </div>
            <div  class="mb-3">
                <label class="form-label">Name</label>
                <asp:TextBox   ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ErrorMessage="Required" CssClass="validation" ControlToValidate="txtName" runat="server" />
                <asp:Label ID="lblErrorName" runat="server" Text="Name"></asp:Label>
            </div>
             <div  class="mb-3">
                <label class="form-label">Surname</label>
                <asp:TextBox  ID="TxtSurname" CssClass="form-control" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ErrorMessage="Required" CssClass="validation" ControlToValidate="TxtSurname" runat="server" />
                 <asp:Label ID="lblErrorSur" runat="server" Text="Surname"></asp:Label>
            </div>
            <div style="margin-top:10%">
            <asp:Button  runat="server" type="submit" ID="btnSaveProfile" Onclick="btnSaveProfile_Click" class="btn btn-info" Text="Save" />          
            <a  class="btn btn-info" href="Default.aspx">Back</a>
        </div>
               <div class="mb-3">
            <asp:Label CssClass="alert alert-success" style="display: block; max-width: 300px; 
                        margin-top: 10px;" ID="lblSuccess" runat="server" Text="Changes have been saved successfully." Visible="false" ForeColor="Green"></asp:Label>
        </div>          
      </div>         
        <div class="col-4"> 
            <div class="mb-3">
                <div >   
            <asp:Label  ID="lblImagenPerfil" runat="server" Text="Profile Image"></asp:Label>  
                    
           <asp:FileUpload style="margin-top:2%"  ID="txtPhoto" class="form-control" type="file" runat="server" />
           <asp:Label ID="lblErrorPhoto" runat="server" Text="Label"></asp:Label>    
                </div>
            <asp:Image style="margin-top:10%"  ID="ImgPerfil" ImageUrl="https://upload.wikimedia.org/wikipedia/commons/8/89/Portrait_Placeholder.png" 
                CssClass="img-fluid mb-3" runat="server" Width="60%" />
        </div> 
        </div>
      </div>    
</asp:Content>
