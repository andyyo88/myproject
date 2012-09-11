<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminStock.aspx.cs" Inherits="LadyBelle.AdminStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <table><tr><th colspan="3">Stock Management</th></tr>
<tr><td>Sub Product ID</td><td>:</td><td><asp:Label ID="lbProductDetID" runat="server"></asp:Label></td></tr>
<tr><td>Product Name</td><td>:</td><td><asp:Label ID="lbProductName" runat="server"></asp:Label></td></tr>
<tr><td>Long</td><td>:</td><td><asp:TextBox ID="txLong" runat="server" Text="0"></asp:TextBox></td></tr>
<tr><td>Short</td><td>:</td><td><asp:TextBox ID="txShort" runat="server" Text="0"></asp:TextBox></td></tr>
<tr><td>Note</td><td>:</td><td><asp:TextBox ID="txNote" TextMode="MultiLine" runat="server" Text=""></asp:TextBox></td></tr></table>
<tr><td></td><td></td>
    <td><asp:Button ID="btAdd" runat="server" UseSubmitBehavior="false" Text="Add" 
        onclick="btAdd_Click" /><asp:Button ID="btnBack" runat="server" 
    UseSubmitBehavior="false" Text="Back" onclick="btnBack_Click" 
        /></td></tr>
</table>
</asp:Content>
