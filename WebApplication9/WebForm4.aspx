<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="WebApplication9.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"><title>image</title>
<style>
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="container-sm container-fluid mt-1 "> 
            <div class="row">
    <asp:Image ID="Image1" runat="server" CssClass="img-fluid" />
             <asp:Button ID="Button3" runat="server" Text="Download"    class="btn btn-danger btn-floating mt-1 fas fa-download" OnClick="Button3_Click" />
                <br />
            </div>
        </div>
       
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="delete" style="background-color:#DC143C;"   class=" col-12 mt-1 text-light" />
       
<br /><br />
    
    <script>
        
    </script>
</asp:Content>
