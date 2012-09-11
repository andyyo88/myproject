<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminStockList.aspx.cs" Inherits="LadyBelle.AdminStockList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <table><tr><th>Stock Management</th></tr>
<tr><td>
    <asp:TextBox ID="txSearch" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" UseSubmitBehavior="false" runat="server" 
        Text="Search" onclick="btnSearch_Click" /></td></tr>
<tr><td>
    
<% for (int i = 0; i < dtProduct.Rows.Count; i++)
   { %>
<div style="float:left"><%= dtProduct.Rows[i].ItemArray[2].ToString() %></div>
<% dtProductDet = getProduct(dtProduct.Rows[i].ItemArray[0].ToString()); %>
<ul>
<% for (int z = 0; z < dtProductDet.Rows.Count; z++)
   { %>
    <li><a href=<%= "AdminStock.aspx?productdetid=" + dtProductDet.Rows[z].ItemArray[0].ToString() %>><%= dtProductDet.Rows[z].ItemArray[4].ToString() + " (" + stockCount(dtProductDet.Rows[z].ItemArray[0].ToString()) + ")"%></a></li>
    <% } %>
</ul>
<% } %>
</td></tr>
</table>
</asp:Content>
