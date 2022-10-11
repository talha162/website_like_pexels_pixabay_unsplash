<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebApplication9.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Upload File</title>
    <style>
    footer{
       position:absolute;
       bottom:0px;
    }
        </style>
    <script>
        function displayalert() {
            if (document.getElementById("<%=TextBox1.ClientID%>").value=="") {
                alert("Please Enter tag 1");
                return false;
            }
            else if (document.getElementById("<%=TextBox2.ClientID%>").value=="") {
                alert("Please Enter tag 2");
                return false;
            }
            else if (document.getElementById("<%=TextBox3.ClientID%>").value=="") {
                alert("Please Enter tag 3");
                return false;
            }
            else if (document.getElementById("<%=FileUpload1.ClientID%>").files.length==0) {
                alert("Please upload some file");
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
        

        <div>
            <label for="FileUpload1">Please upload the file</label>
            <asp:FileUpload ID="FileUpload1" runat="server" style="margin-left: 106px" />
        </div>
        <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 15px; margin-top: 51px" placeholder="tag 1" EnableViewState="False" ></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 86px" placeholder="tag 2" EnableViewState="False"></asp:TextBox >
        <asp:TextBox ID="TextBox3" runat="server" style="margin-left: 86px"  placeholder="tag 3" EnableViewState="False"></asp:TextBox >
        <p>
            <asp:Button ID="Button1"  class="text-light"  runat="server" style="margin-left: 279px;background-color:#DC143C; margin-top:5px;" Text="submit" OnClick="Button1_Click" CssClass="btn btn-danger" OnClientClick="return displayalert();" />
        </p>

       
    
    <script>
        
    </script>
</asp:Content>
