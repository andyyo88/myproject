<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminEditImage.aspx.cs" Inherits="LadyBelle.AdminEditImage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<table>
<tr><td><asp:Image Width="125px" Height="125px" runat="server" ID="img1"  /></td><td>
    <asp:TextBox ID="tx1" runat="server" Text="1"></asp:TextBox></td><td>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btch1" runat="server"
            Text="Change" onclick="btch1_Click"  UseSubmitBehavior="False"  /></td><td><asp:Button ID="Button4" runat="server"
            Text="Delete" /></td></tr>
            <tr><td><asp:Image Width="125px" Height="125px" runat="server" ID="img2"  /></td><td>
    <asp:TextBox ID="tx2" runat="server" Text="2"></asp:TextBox></td><td>
        <asp:FileUpload ID="FileUpload2" runat="server" />
                    <asp:Button ID="Button1"  UseSubmitBehavior="False"  runat="server"
            Text="Change" onclick="Button1_Click" /></td><td><asp:Button ID="Button5" runat="server"
            Text="Delete" /></td></tr>
            <tr><td><asp:Image Width="125px" Height="125px" runat="server" ID="img3"  /></td><td>
    <asp:TextBox ID="tx3" runat="server" Text="3"></asp:TextBox></td><td>
        <asp:FileUpload ID="FileUpload3" runat="server" />
                    <asp:Button ID="Button2" runat="server"
            Text="Change" onclick="Button2_Click"  UseSubmitBehavior="False"  /></td><td><asp:Button ID="Button6" runat="server"
            Text="Delete" /></td></tr>
            <tr><td><asp:Image Width="125px" Height="125px" runat="server" ID="img4"  /></td><td>
    <asp:TextBox ID="tx4" runat="server" Text="4"></asp:TextBox></td><td>
        <asp:FileUpload ID="FileUpload4" runat="server" />
                    <asp:Button ID="Button3" runat="server"
            Text="Change" onclick="Button3_Click" UseSubmitBehavior="False" /></td><td><asp:Button ID="Button7" runat="server"
            Text="Delete" UseSubmitBehavior="False" /></td></tr>
            <tr><td></td><td></td><td>
                <asp:Button ID="btSave0" runat="server" Text="Change Order" 
                    onclick="btSave_Click" UseSubmitBehavior="False" />
                <asp:Button ID="btSave" runat="server" Text="Back" 
                   UseSubmitBehavior="False" onclick="btSave_Click1" /></td></tr>
</table>
</asp:Content>
