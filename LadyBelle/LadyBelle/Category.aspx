<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="LadyBelle.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript">
    function confirmDelete() {
        if (confirm("Are you sure to delete this Category ?")) {
            document.getElementById('<%=cmdDelete.ClientID%>').click();
        }
    }
</script>

            <table id="pnl_0" runat="server"  border=0 class="tabel">
                <tr><td style="font-size: 10pt; color: saddlebrown; font-family: verdana; text-decoration: underline; font-weight: bold;">
                    Manage Category</td></tr>
                 <tr>
                <td>
                <br />
                </td>
                </tr>
                <tr><td class="panel_form">
                     <table>
                        <tr>
                            <td>
                                <asp:DataGrid ID="dgList" runat="server" BorderWidth="1px" CssClass="table_grid" AutoGenerateColumns="false" AllowPaging="True" PageSize="10" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnItemCommand="dgList_ItemCommand" OnPageIndexChanged="dgList_PageIndexChanged">
                                    <HeaderStyle CssClass="table_hdr" BackColor="#6B696B" Font-Bold="True" ForeColor="White" Font-Names="Verdana" Font-Size="9pt" />
                                    <ItemStyle CssClass="table_itm" BackColor="#F7F7DE" Font-Names="Verdana" Font-Size="8pt" />
                                    <AlternatingItemStyle CssClass="table_alt" BackColor="White" />
                                    <Columns>
                                        <asp:ButtonColumn DataTextField="CategoryID" HeaderText="Category ID" CommandName="id">
                                            <HeaderStyle Wrap="False" />
                                            <ItemStyle Wrap="False" />
                                        </asp:ButtonColumn>
                                        <asp:BoundColumn DataField="CategoryName" HeaderText="Category Name">
                                            <HeaderStyle Wrap="False" />
                                            <ItemStyle Wrap="False" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="CategoryType" HeaderText="Category Type">
                                            <HeaderStyle Wrap="False" />
                                            <ItemStyle Wrap="False" />
                                        </asp:BoundColumn>
                                          <asp:BoundColumn DataField="ParentName" HeaderText="Parent">
                                            <HeaderStyle Wrap="False" />
                                            <ItemStyle Wrap="False" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="CategoryID" HeaderText="CategoryID" Visible="False"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="ParentID" HeaderText="ParentID" Visible="False"></asp:BoundColumn>
                                    </Columns>
                                   <PagerStyle CssClass="table_page" PrevPageText="previous ‹.." NextPageText="..› next" BackColor="#F7F7DE" ForeColor="Gray" HorizontalAlign="Right" Font-Bold="False" Font-Italic="False" Font-Names="verdana" Font-Overline="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" />
                                    <FooterStyle BackColor="#CCCC99" Font-Names="verdana" Font-Size="8pt" />
                                    <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                </asp:DataGrid>
                            </td>
                        </tr>
                    
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td style="width: 100px">Category ID</td>
                                        <td>:</td>
                                       <td style="width: 210px"><asp:TextBox runat="server" ID="txtCategoryID" width="60" 
                                               ReadOnly="True"></asp:TextBox></td>
                                       
                                    </tr>
                                    <tr>
                                        <td>Category Name</td>
                                        <td style="width: 10px">:</td>
                                        <td><asp:TextBox ID="txtCategoryName" runat="server" Width="200"></asp:TextBox></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCategoryName" 
                                                ValidationGroup="category"></asp:RequiredFieldValidator></td>
                                    </tr>
                                       <tr>
                                        <td>Category Type</td>
                                        <td style="width: 10px">:</td>
                                        <td><asp:DropDownList ID="cmbCategoryType" runat="server" Width="200" 
                                                AutoPostBack="True" 
                                                onselectedindexchanged="cmbCategoryType_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Parent</asp:ListItem>
                                        <asp:ListItem Value="1">Child</asp:ListItem>
                                        </asp:DropDownList></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                ErrorMessage="*" ForeColor="Red" ControlToValidate="cmbCategoryType" 
                                                ValidationGroup="category"></asp:RequiredFieldValidator></td>
                                    </tr>
                                     <tr>
                                        <td>Parent</td>
                                        <td style="width: 10px">:</td>
                                        <td><asp:DropDownList ID="cmbParent" runat="server" Width="200"></asp:DropDownList></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                ErrorMessage="*" ForeColor="Red" ControlToValidate="cmbParent" 
                                                ValidationGroup="category"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                    <td colspan="4">
                                    <table>
                                    <tr id="trCreate" runat="server"><td class="panel_button">
                    <asp:Button ID="cmdCreate" Text="Create" runat="server" Width="70px" 
                        OnClick="cmdCreate_Click" UseSubmitBehavior="false" ValidationGroup="category" />
                    <asp:Button ID="cmdCancel_1" Text="Cancel" runat="server" Width="70" OnClick="cmdCancel_1_Click" UseSubmitBehavior="false"/>
                </td></tr>
                <tr id="trUpdate" runat="server">
                    <td class="panel_button">
                          <asp:Button ID="cmdUpdate" Text="Update" runat="server" Width="70px" 
                       UseSubmitBehavior="false" ValidationGroup="province" onclick="cmdUpdate_Click" />
                        <input type="button" name="btnDelete" value="Delete" style="width:70px;" onclick="confirmDelete();" id="Button1" />
                         <asp:Button ID="cmdCancelUpdate" Text="Cancel" runat="server" Width="70px" 
                        OnClick="cmdCancelUpdate_Click" UseSubmitBehavior="false"/>
                        <span id="spnHidden" runat="server" style="display:none;">
                            <asp:Button ID="cmdDelete" Text="Delete" runat="server" Width="70" UseSubmitBehavior="false" OnClick="cmdDelete_Click"/> 
                        </span>
                    </td>
                </tr>
                                    </table>
                                    </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                     </table>               
                </td></tr>
            </table>
</asp:Content>

