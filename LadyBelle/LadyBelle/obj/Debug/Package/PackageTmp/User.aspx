<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="LadyBelle.WebForm1" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxPanel" Assembly="DevExpress.Web.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxCallbackPanel" Assembly="DevExpress.Web.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>




<script language="javascript">
    function confirmDelete() {
        if (confirm("Are you sure to delete this City ?")) {
            document.getElementById('<%=cmdDelete.ClientID%>').click();
        }
    }
</script>
 <dx:ASPxCallbackPanel runat="server" ID="CallbackPanel" ClientInstanceName="CallbackPanel"
    HideContentOnCallback="false" OnCallback="CallbackPanel_Callback">
    <PanelCollection>
        <dx:PanelContent>
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
                                        <asp:ButtonColumn DataTextField="UserID" HeaderText="User ID" CommandName="id">
                                            <HeaderStyle Wrap="False" />
                                            <ItemStyle Wrap="False" />
                                        </asp:ButtonColumn>
                                        <asp:BoundColumn DataField="UserName" HeaderText="User Name">
                                            <HeaderStyle Wrap="False" />
                                            <ItemStyle Wrap="False" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Password" HeaderText="Password">
                                            <HeaderStyle Wrap="False" />
                                            <ItemStyle Wrap="False" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="UserID" HeaderText="User ID" Visible="False"></asp:BoundColumn>
                                        
                                    </Columns>
                                   <PagerStyle CssClass="table_page" PrevPageText="previous ‹.." NextPageText="..› next" BackColor="#F7F7DE" ForeColor="Gray" HorizontalAlign="Right" Font-Bold="False" Font-Italic="False" Font-Names="verdana" Font-Overline="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" />
                                    <FooterStyle BackColor="#CCCC99" Font-Names="verdana" Font-Size="8pt" />
                                    <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                </asp:DataGrid>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>User ID</td>
                                        <td>:</td>
                                       <td><asp:TextBox runat="server" ID="txtUserID" width="60" 
                                               ReadOnly="True"></asp:TextBox></td>
                                       
                                    </tr>
                                    <tr>
                                        <td>User Name</td>
                                        <td>:</td>
                                        <td><asp:TextBox ReadOnly="True" ID="txtUserName" runat="server" Width="200"></asp:TextBox></td>
                                      
                                    </tr>
                                      <tr>
                                        <td>Province</td>
                                        <td>:</td>
                                        <td><asp:TextBox ReadOnly="true" ID="txtPassword" runat="server" Width="200" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                     </table>               
                </td></tr>
                
                <tr id="trCreate" runat="server"><td class="panel_button">
                    <asp:Button ID="cmdCreate" Text="Create" runat="server" Width="70px" OnClick="cmdCreate_Click" UseSubmitBehavior="false" />
                    <asp:Button ID="cmdCancel_1" Text="Cancel" runat="server" Width="70" OnClick="cmdCancel_1_Click" UseSubmitBehavior="false"/>
                </td></tr>
                <tr id="trUpdate" runat="server">
                    <td class="panel_button">
                        <asp:Button ID="cmdUpdate" Text="Update" runat="server" Width=70 OnClick="cmdUpdate_Click" ValidationGroup="city"/>
                        <input type="button" name="btnDelete" value="Delete" style="width:70px;" onclick="confirmDelete();" id="Button1" />
                        <asp:Button ID="cmdCancel_2" Text="Cancel" runat="server" Width=70 OnClick="cmdCancel_2_Click"/>
                        <span id="spnHidden" runat="server" style="display:none;">
                            <asp:Button ID="cmdDelete" Text="Delete" runat="server" Width=70 OnClick="cmdDelete_Click"/> 
                        </span>
                    </td>
                </tr>
            </table>

   </dx:PanelContent>
    </PanelCollection>
</dx:ASPxCallbackPanel>