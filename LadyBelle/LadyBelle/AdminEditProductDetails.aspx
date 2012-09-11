<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminEditProductDetails.aspx.cs" Inherits="LadyBelle.AdminEditProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<div>
<table><tr><th colspan="3">Product Details Management</th></tr>
<asp:Label ID="lbProductID" Visible="false" runat="server" Text="Label"></asp:Label>
<tr><td>Product Name</td><td>:</td><td><asp:Label ID="lbProductName" runat="server" Text="Label"></asp:Label></td></tr>
<tr><td>Sub Product ID</td><td>:</td><td><asp:Label ID="lbProductDetID" runat="server" Text=""></asp:Label></td></tr>
<tr><td>Sub Product Code</td><td>:</td><td><asp:TextBox ID="txSubProductCode" runat="server" Text=""></asp:TextBox></td></tr>
<tr><td>Sub Product Name</td><td>:</td><td><asp:TextBox ID="txSubProductName" runat="server" Text=""></asp:TextBox></td></tr>
<tr><td>Price</td><td>:</td><td><asp:TextBox ID="txPrice" runat="server" Text="0"></asp:TextBox></td></tr>
<tr><td>Status</td><td>:</td><td><asp:DropDownList ID="ddlStatus" runat="server">
    <asp:ListItem Selected="True" Value="-1">Select Status</asp:ListItem>
    <asp:ListItem Value="1">Active</asp:ListItem>
    <asp:ListItem Value="0">Disabled</asp:ListItem>
    <asp:ListItem Value="2">Promo</asp:ListItem>
    <asp:ListItem Value="3">Cannot Preorder</asp:ListItem>
    </asp:DropDownList></td></tr>
<tr><td>Weight</td><td>:</td><td><asp:TextBox ID="txWeight" runat="server" Text="0"></asp:TextBox></td></tr>
<tr><td>Size</td><td>:</td><td><asp:TextBox ID="txSize" runat="server" Text="0"></asp:TextBox></td></tr>
<tr><td>Measurement</td><td>:</td><td><asp:TextBox ID="txSatuan" runat="server" Text=""></asp:TextBox></td></tr>
<tr><td>Discount (%)</td><td>:</td><td><asp:TextBox ID="txDiscount" runat="server" Text="0"></asp:TextBox></td></tr>
 <tr runat="server" id="trUpdate"><td colspan="3">
        <asp:Button ID="btEdit" UseSubmitBehavior="false" runat="server" Text="Edit" 
            onclick="btEdit_Click" />
        <input type="submit" onclick="confirmDelete()" id="btDel" value="Delete" /><span style="display:none;"><asp:Button ID="btDelete" UseSubmitBehavior="false" runat="server" Text="Delete" /></span>
        <asp:Button ID="btCancel" UseSubmitBehavior="false" runat="server" 
            Text="Cancel" onclick="btCancel_Click" /></td></tr>
    
    <tr runat="server" id="trCreate"><td colspan="3">
        <asp:Button ID="btAdd" UseSubmitBehavior="false" runat="server" Text="Add" 
            onclick="btAdd_Click" />
        <asp:Button ID="btCancel2" UseSubmitBehavior="false" runat="server" Text="Back" 
            onclick="btCancel2_Click" /></td></tr>

</table>
<table>
<tr><td>
<asp:HyperLink ID="hyImage" runat="server" Text="Edit Product Image"></asp:HyperLink>
<asp:DataGrid ID="dgList" Width="590px" runat="server"  AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" CellPadding="4" ForeColor="Black" GridLines="None">
                                    <ItemStyle CssClass="mainItemList" Font-Names="Verdana" Font-Size="8pt" />
                                    <Columns>
                                        <asp:TemplateColumn ItemStyle-CssClass="mainTemplateProductList"><ItemTemplate>
                                        <asp:Image ID="imgGrid" BorderColor="black" BorderStyle="solid" BorderWidth="1px" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"PictureURL").ToString()  %>' Width="90px" Height="90px" runat="server" />  
                                        </ItemTemplate>
                                        </asp:TemplateColumn>
                                      </Columns>
                                      <PagerStyle Position="TopAndBottom" PrevPageText="<..prev" NextPageText="next..>" HorizontalAlign="right" />
                                </asp:DataGrid></td></tr></table>

</div>
</asp:Content>
