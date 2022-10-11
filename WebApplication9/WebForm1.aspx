<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication9.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Search</title>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        

        <div class="img-search">
                <div class="container">
                    <h1>Stunning free images & royalty free stock</h1>
                    <h2>High quality stock Images shared by our talented community.</h2>
                </div>
                <div class="container">
                    <div class="row height d-flex justify-content-center align-items-center">
                        <div class="col-md-8">
                            <div class="search"> <i class="fa fa-search"></i> 
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:Button ID="Button2" runat="server" Text="search"  class="btn text-light" OnClientClick="return search();"  style="position: absolute;top:0px;right:0px;background-color:#DC143C; " OnClick="Button2_Click"   />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                <div class="container-fluid">
                <div class="row">
          
       <asp:Panel ID="Panel1" runat="server" >
</asp:Panel>
                    </div>
       </div>

        
        <br />
    
    <script>
       function search() {
           var t1 = document.getElementById("<%=TextBox4.ClientID%>");
           if (t1.value == "") {
               alert("Please Enter something to search");
               return false;
           }
        }
   </script>
    </asp:Content>

