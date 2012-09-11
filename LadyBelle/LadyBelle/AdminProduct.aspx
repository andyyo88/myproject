<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminProduct.aspx.cs" Inherits="LadyBelle.AdminProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <table><tr><th>Product Management</th></tr>
<tr><td><asp:HyperLink ID="hyAdd" runat="server" NavigateUrl="~/AdminEditProduct.aspx">Add Product</asp:HyperLink></td></tr><tr><td><asp:DataGrid ID="dgList" Width="590px" AllowPaging="true" PageSize="10" runat="server"  AutoGenerateColumns="False"    BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" CellPadding="4" ForeColor="Black" GridLines="None">
                                        <ItemStyle CssClass="mainItemList" Font-Names="Verdana" Font-Size="8pt" />
                                    <Columns>
                                        <asp:TemplateColumn ItemStyle-CssClass="mainTemplateProductList"><ItemTemplate>
                                        <table><tr> <td><asp:Image ID="imgGrid" BorderColor="black" BorderStyle="solid" BorderWidth="1px" ImageUrl='<%# getLogoURL(DataBinder.Eval(Container.DataItem,"Image").ToString())  %>' Width="90px" Height="90px" runat="server" /></td>
                                        <td><div id="listHeader"><asp:HyperLink href='<%# "AdminEditProduct.aspx?productid=" + DataBinder.Eval(Container.DataItem,"ProductID").ToString().TrimEnd() %>' runat="server" ID="Hyper1"><%# DataBinder.Eval(Container.DataItem,"ProductName").ToString().TrimEnd() %> (<%# DataBinder.Eval(Container.DataItem,"ProductCode").ToString().TrimEnd().TrimStart() %>)</asp:HyperLink> | <span style="font-size:9px"><asp:HyperLink href='<%# "AdminEditProductDetails.aspx?productid=" + DataBinder.Eval(Container.DataItem,"ProductID").ToString().TrimEnd() %>' runat="server" ID="HyperLink1">Tambah Sub Produk</asp:HyperLink></span>  </div>
                                        <br /><div id="listIsi"><%# DataBinder.Eval(Container.DataItem,"ProductDesc").ToString().TrimEnd() %>
                                        </div></td></tr></table>
                                        </ItemTemplate>
                                        </asp:TemplateColumn>
                                      </Columns>
                                      <PagerStyle Position="TopAndBottom" PrevPageText="<..prev" NextPageText="next..>" HorizontalAlign="right" />
                                </asp:DataGrid>	</td></tr></table>
</asp:Content>
