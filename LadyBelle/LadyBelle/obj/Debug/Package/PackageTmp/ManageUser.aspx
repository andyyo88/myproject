<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ManageUser.aspx.cs" Inherits="LadyBelle.ManageUser" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxPanel" Assembly="DevExpress.Web.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxCallbackPanel" Assembly="DevExpress.Web.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

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
                    Manage User</td></tr>
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
                                       <%-- <asp:ButtonColumn DataTextField="UserID" HeaderText="User ID" CommandName="id">
                                            <HeaderStyle Wrap="False" />
                                            <ItemStyle Wrap="False" />
                                        </asp:ButtonColumn>--%>
                                        <asp:ButtonColumn DataTextField="UserName" HeaderText="User Name" CommandName="id">
                                            <HeaderStyle Wrap="False" />
                                            <ItemStyle Wrap="False" />
                                        </asp:ButtonColumn>
                                        <asp:BoundColumn DataField="Password" HeaderText="Password">
                                            <HeaderStyle Wrap="False" />
                                            <ItemStyle Wrap="False" />
                                        </asp:BoundColumn>
                                         <asp:BoundColumn DataField="LevelName" HeaderText="User Level">
                                            <HeaderStyle Wrap="False" />
                                            <ItemStyle Wrap="False" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="UserID" HeaderText="User ID" Visible="False"></asp:BoundColumn>
                                         <asp:BoundColumn DataField="UserName" HeaderText="UserName" Visible="False"></asp:BoundColumn>
                                          <asp:BoundColumn DataField="UserLevel" HeaderText="UserLevel" Visible="False"></asp:BoundColumn>
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
                                        <td style="width: 100px">User ID</td>
                                        <td>:</td>
                                       <td style="width: 210px"><asp:TextBox runat="server" ID="txtUserID" width="60" 
                                               ReadOnly="True"></asp:TextBox></td>
                                       
                                    </tr>
                                    <tr>
                                        <td>User Name</td>
                                        <td style="width: 10px">:</td>
                                        <td><asp:TextBox ID="txtUserName" runat="server" Width="200"></asp:TextBox></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                ErrorMessage="*" ForeColor="Red" ControlToValidate="txtUserName" 
                                                ValidationGroup="user"></asp:RequiredFieldValidator></td>
                                    </tr>
                                      <tr>
                                        <td>Password</td>
                                        <td>:</td>
                                        <td><asp:TextBox ID="txtPassword" runat="server" Width="200" /></td>
                                        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPassword" 
                                                ValidationGroup="user"></asp:RequiredFieldValidator></td>
                                    </tr>
                                      <tr>
                                        <td>User Level</td>
                                        <td style="width: 10px">:</td>
                                        <td><asp:DropDownList ID="cmbUserLevel" runat="server" Width="200"></asp:DropDownList></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                ErrorMessage="*" ForeColor="Red" ControlToValidate="cmbUserLevel" 
                                                ValidationGroup="province"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                    <td colspan="4">
                                    <table>
                                    <tr id="trCreate" runat="server"><td class="panel_button">
                    <asp:Button ID="cmdCreate" Text="Create" runat="server" Width="70px" 
                        OnClick="cmdCreate_Click" UseSubmitBehavior="false" ValidationGroup="user" />
                    <asp:Button ID="cmdCancel_1" Text="Cancel" runat="server" Width="70" OnClick="cmdCancel_1_Click" UseSubmitBehavior="false"/>
                </td></tr>
                <tr id="trUpdate" runat="server">
                    <td class="panel_button">
                          <asp:Button ID="cmbUpdateUser" Text="Update" runat="server" Width="70px" 
                       UseSubmitBehavior="false" ValidationGroup="user" onclick="cmbUpdateUser_Click" />
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
