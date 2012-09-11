<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LadyBelle.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<div class="adminTemplate" align="center">
    <div class="loginMenu">
        <table class="tabel">
            <tr>
                <td colspan="3" valign="middle">
                    <h3>                   
                        Login to LadyBelle Admin</h3>
                </td>	
            </tr>
            <tr>
                <td style="width: 75px">Username
                </td>
                <td style="width: 10px">:
                </td>
                <td><asp:TextBox id="txtUserID" runat="server" Width="119px" CssClass="txtbox" MaxLength="15" EnableViewState="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password
                </td>
                <td>:
                </td>
                <td><asp:TextBox id="txtPassword" runat="server" Width="119px" CssClass="txtbox" TextMode="Password" MaxLength="15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="right">
                    <asp:Button id="Button1" runat="server" Width="56px" CssClass="btncmd" Text="Login" OnClick="cmdLogin_Click" UseSubmitBehavior="false"></asp:Button>&nbsp;&nbsp;&nbsp;
                </td>			
		    </tr>
        </table>
    </div>
    <asp:Label ID="txtMessage" runat="server" Visible=False ForeColor="Red" Font-Names="Verdana" Font-Size="10pt" />
</div>
</asp:Content>
