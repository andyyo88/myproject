<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SaveText.ascx.cs" Inherits="LadyBelle.SaveText" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<table>
<tr><th><%= HeaderTextString %></th></tr>
<tr><td style="padding:0 0 0 30px"><FTB:FreeTextBox ToolbarStyleConfiguration="OfficeXP"  BackColor="Transparent" EnableHtmlMode="false" toolbarlayout="Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent|ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker" Width="550px" Height="300px" ID="ftb1" runat="server"></FTB:FreeTextBox></td></tr>
<tr><td>
    <asp:Button ID="btConfirm" runat="server" Text="Button" 
        onclick="btConfirm_Click" UseSubmitBehavior="False" 
        ViewStateMode="Disabled" /><asp:Button ID="btCancel"
        runat="server" Text="Cancel" 
        onclick="btCancel_Click" CausesValidation="False" 
        PostBackUrl="~/Home.aspx" UseSubmitBehavior="False" ViewStateMode="Disabled" /></td></tr>
</table>