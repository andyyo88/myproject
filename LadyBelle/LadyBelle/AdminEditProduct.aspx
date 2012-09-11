<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminEditProduct.aspx.cs" Inherits="LadyBelle.AdminEditProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <table><tr><th>Product Management</th></tr>
<tr><td>
<table>
<tr><td>Product ID</td><td>:</td><td>
    <asp:Label ID="lbProductID" runat="server" Text=""></asp:Label></td></tr>
    <tr><td>Product Code</td><td>:</td><td>
        <asp:TextBox ID="txProductCode" MaxLength="8" runat="server"></asp:TextBox></td></tr>
    <tr><td>Product Name</td><td>:</td><td>
        <asp:TextBox ID="txProductName" MaxLength="50" runat="server"></asp:TextBox></td></tr>    
    <tr><td>Product Description</td><td>:</td><td>
        <asp:TextBox ID="txShortDesc" TextMode="MultiLine" runat="server"></asp:TextBox></td></tr>
    <tr><td>Parent Category</td><td>:</td><td>
        <asp:DropDownList ID="ddlParentCat" runat="server" AutoPostBack="True" 
            ontextchanged="ddlParentCat_TextChanged">
        </asp:DropDownList>
    </td></tr>
    <tr><td>Sub Category</td><td>:</td><td>
        <asp:DropDownList ID="ddlSubCategory" runat="server" AutoPostBack="True" 
            ontextchanged="ddlSubCategory_TextChanged">
        </asp:DropDownList>
    </td></tr>
    <tr><td>Category</td><td>:</td><td>
        <asp:DropDownList ID="ddlCategory" runat="server">
        </asp:DropDownList>
    </td></tr>
    <tr runat="server" id="trUpdate"><td colspan="3">
        <asp:Button ID="btEdit" UseSubmitBehavior="false" runat="server" Text="Edit" 
            onclick="btEdit_Click" />
        <input type="submit" onclick="confirmDelete()" id="btDel" value="Delete" /><span style="display:none;"><asp:Button 
            ID="btDelete" UseSubmitBehavior="false" runat="server" Text="Delete" 
            onclick="btDelete_Click" /></span>
        <asp:Button ID="btCancel" UseSubmitBehavior="false" runat="server" 
            Text="Cancel" onclick="btCancel_Click" /></td></tr>
    
    <tr runat="server" id="trCreate"><td colspan="3">
        <asp:Button ID="btAdd" UseSubmitBehavior="false" runat="server" Text="Add" 
            onclick="btAdd_Click" />
        <asp:Button ID="btCancel2" UseSubmitBehavior="false" runat="server" Text="Back" 
            onclick="btCancel2_Click" /></td></tr></table>
</td></tr>
<tr><td>
<asp:HyperLink ID="hyNewSubProduct" runat="server" Text="Add Sub Product"></asp:HyperLink>
<asp:DataGrid ID="dgList" Width="590px" runat="server"  AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" CellPadding="4" ForeColor="Black" GridLines="None">
                                    <ItemStyle CssClass="mainItemList" Font-Names="Verdana" Font-Size="8pt" />
                                    <Columns>
                                        <asp:TemplateColumn ItemStyle-CssClass="mainTemplateProductList"><ItemTemplate>
                                        <asp:Image ID="imgGrid" BorderColor="black" BorderStyle="solid" BorderWidth="1px" ImageUrl='<%# getLogoURL(DataBinder.Eval(Container.DataItem,"Image").ToString())  %>' Width="90px" Height="90px" runat="server" />  
                                        <div id="listHeader"><asp:HyperLink href='<%# "AdminEditProductDetails.aspx?productid=" + DataBinder.Eval(Container.DataItem,"ProductID").ToString().TrimEnd() + "&productdetid=" + DataBinder.Eval(Container.DataItem,"ProductDetID").ToString().TrimEnd() %>' runat="server" ID="Hyper1"><%# DataBinder.Eval(Container.DataItem,"ProductDetName").ToString().TrimEnd() %> </asp:HyperLink> (<%# DataBinder.Eval(Container.DataItem,"ProductDetCode").ToString().TrimEnd().TrimStart() %>)</div>
                                        <br /><div id="listIsi">IDR. <%# decimal.Parse(DataBinder.Eval(Container.DataItem,"Price").ToString().TrimEnd()).ToString("#,###.##") %>
                                        </div>
                                        </ItemTemplate>
                                        </asp:TemplateColumn>
                                      </Columns>
                                      <PagerStyle Position="TopAndBottom" PrevPageText="<..prev" NextPageText="next..>" HorizontalAlign="right" />
                                </asp:DataGrid></td></tr>
</table>
</asp:Content>
