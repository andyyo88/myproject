<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminAboutUs.aspx.cs" Inherits="LadyBelle.AdminAboutUs" %>
<%@ Register TagPrefix="st" tagname="SaveText" 
    Src="~/SaveText.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <st:SaveText runat="server" id="SaveText1" tipe="AboutUs" HeaderText="About Us"></st:SaveText>
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
</asp:Content>
