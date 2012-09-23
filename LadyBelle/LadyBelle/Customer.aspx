<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="LadyBelle.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script language="javascript">
    function confirmDelete() {
        if (confirm("Are you sure to delete this User ?")) {
            document.getElementById('<%=cmdDelete.ClientID%>').click();
        }
    }
</script>

            <table id="pnl_0" runat="server"  border=0 class="tabel">
                <tr><td style="font-size: 10pt; color: saddlebrown; font-family: verdana; text-decoration: underline; font-weight: bold;">
                    Manage Customer</td></tr>
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
                                        <asp:ButtonColumn DataTextField="ClientID" HeaderText="Customer ID" CommandName="id">
                                            <HeaderStyle Wrap="False" />
                                            <ItemStyle Wrap="False" />
                                        </asp:ButtonColumn>
                                        <asp:BoundColumn DataField="ClName" HeaderText="Customer Name">
                                            <HeaderStyle Wrap="False" />
                                            <ItemStyle Wrap="False" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="UserName" HeaderText="Username">
                                            <HeaderStyle Wrap="False" />
                                            <ItemStyle Wrap="False" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="LevelName" HeaderText="Customer Level">
                                            <HeaderStyle Wrap="False" />
                                            <ItemStyle Wrap="False" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="ClientID" HeaderText="CityID" Visible="False"></asp:BoundColumn>
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
                                        <td style="width: 100px">Customer ID</td>
                                        <td>:</td>
                                       <td style="width: 210px"><asp:TextBox runat="server" ID="txtCustID" width="60" 
                                               ReadOnly="True"></asp:TextBox></td>
                                       
                                    </tr>
                                    <tr>
                                        <td>Customer Name</td>
                                        <td style="width: 10px">:</td>
                                        <td><asp:TextBox ID="txtCustName" runat="server" Width="200"></asp:TextBox></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCustName" 
                                                ValidationGroup="customer"></asp:RequiredFieldValidator></td>
                                    </tr>
                                     <tr>
                                        <td>Username</td>
                                        <td style="width: 10px">:</td>
                                        <td><asp:TextBox ID="txtUsername" runat="server" Width="200"></asp:TextBox></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                ErrorMessage="*" ForeColor="Red" ControlToValidate="txtUsername" 
                                                ValidationGroup="customer"></asp:RequiredFieldValidator></td>
                                    </tr>
                                     <tr>
                                        <td>Email</td>
                                        <td style="width: 10px">:</td>
                                        <td><asp:TextBox ID="txtEmail" runat="server" Width="200"></asp:TextBox></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmail" 
                                                ValidationGroup="customer"></asp:RequiredFieldValidator></td>
                                    </tr>
                                      <tr>
                                        <td valign="top">Address</td>
                                        <td style="width: 10px" valign="top">:</td>
                                        <td><asp:TextBox ID="txtAddress" runat="server" Width="200" Height="75px" 
                                                TextMode="MultiLine"></asp:TextBox></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                ErrorMessage="*" ForeColor="Red" ControlToValidate="txtAddress" 
                                                ValidationGroup="customer"></asp:RequiredFieldValidator></td>
                                    </tr>
                                      <tr>
                                        <td>Province</td>
                                        <td style="width: 10px">:</td>
                                        <td><asp:TextBox ID="txtProvince" runat="server" Width="200"></asp:TextBox></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                ErrorMessage="*" ForeColor="Red" ControlToValidate="txtProvince" 
                                                ValidationGroup="customer"></asp:RequiredFieldValidator></td>
                                    </tr>
                                      <tr>
                                        <td>City</td>
                                        <td style="width: 10px">:</td>
                                        <td><asp:TextBox ID="txtCity" runat="server" Width="200"></asp:TextBox></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCity" 
                                                ValidationGroup="customer"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td>Postal Code</td>
                                        <td style="width: 10px">:</td>
                                        <td><asp:TextBox ID="txtPostalCode" runat="server" Width="200"></asp:TextBox></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPostalCode" 
                                                ValidationGroup="customer"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td>Phone Number</td>
                                        <td style="width: 10px">:</td>
                                        <td><asp:TextBox ID="txtPhone" runat="server" Width="200"></asp:TextBox></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPhone" 
                                                ValidationGroup="customer"></asp:RequiredFieldValidator></td>
                                    </tr>
                                       <tr>
                                        <td>Customer Level</td>
                                        <td style="width: 10px">:</td>
                                        <td><asp:DropDownList ID="cmbCustomerLevel" runat="server" Width="200"></asp:DropDownList></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                ErrorMessage="*" ForeColor="Red" ControlToValidate="cmbCustomerLevel" 
                                                ValidationGroup="customer"></asp:RequiredFieldValidator></td>
                                    </tr>
                                     <tr>
                                        <td>Status</td>
                                        <td style="width: 10px">:</td>
                                        <td><asp:DropDownList ID="cmbStatus" runat="server" Width="200">
                                            <asp:ListItem Value="True">Yes</asp:ListItem>
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                ErrorMessage="*" ForeColor="Red" ControlToValidate="cmbStatus" 
                                                ValidationGroup="customer"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                    <td colspan="4">
                                    <table>
                                    <tr id="trCreate" runat="server"><td class="panel_button">
                    <asp:Button ID="cmdCreate" Text="Create" runat="server" Width="70px" 
                        OnClick="cmdCreate_Click" UseSubmitBehavior="false" ValidationGroup="province" />
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
