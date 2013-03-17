<%@ Page Title="" Language="C#" MasterPageFile="~/AdvisorBookingServiceMasterPage.master"
    AutoEventWireup="true" CodeFile="AdvisorAvailability.aspx.cs" Inherits="AdvisorAvailability"
    EnableEventValidation="false" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="frmAdvisorAvailability" runat="server">
    <div class="post" id="post-5">
        <div class="post-entry">
            <div class="post-title">
                <center>
                    <h2>
                        <a href="#">Advisor Availability</a></h2>
                </center>
            </div>
            <div class="post-entry-top">
                <div class="post-entry-bottom">
                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <asp:UpdatePanel ID="upnlAdvisorSchedule" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table style="width: 100%" border="1">
                                <tr>
                                    <td align="center">
                                        Year:
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlYear" runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="center">
                                        Week
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlWeek" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlWeek_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 201px" align="right">
                                        Advisor Number:
                                    </td>
                                    <td style="width: 145px" align="left">
                                        <asp:Label ID="lblAdvisorNumber" runat="server" Text="lblAdvisorNumber"></asp:Label>
                                    </td>
                                    <td style="width: 150px" align="right">
                                        Advisor Name:
                                    </td>
                                    <td style="width: 201px" align="left">
                                        <asp:Label ID="lblAdvisorName" runat="server" Text="lblAdvisorName"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <asp:UpdatePanel ID="upnlAdvisorDailySchedule" runat="server" ChildrenAsTriggers="False"
                                            UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table style="width: 100%; height: 0px; margin-bottom: 0px;">
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvAdvisorSetSchedule" runat="server" AllowPaging="True" BackColor="#f1f1f1"
                                                                AutoGenerateColumns="false" ShowFooter="true" Font-Size="Small" Font-Names="Verdana"
                                                                GridLines="None" OnRowDataBound="gvAdvisorSetSchedule_RowDataBound" Width="100%"
                                                                BorderStyle="Outset">
                                                                <RowStyle BackColor="Gainsboro" />
                                                                <AlternatingRowStyle BackColor="White" />
                                                                <HeaderStyle BackColor="#0083C1" ForeColor="White" />
                                                                <FooterStyle BackColor="White" />
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <a href="javascript:expandcollapse('div<%# Eval("Day") %>', 'one');">
                                                                                <img id="imgdiv<%# Eval("Day") %>" alt="Click to Show/Hide Time Slots for <%# Eval("Day") %>"
                                                                                    width="9px" border="0" src="images/plus.gif" />
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Day" SortExpression="Day">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDay" Text='<%# Eval("Day") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblDay" Text='<%# Eval("Day") %>' Visible="false" runat="server"></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <div id="div<%# Eval("Day") %>" style="display: none; position: relative; left: 5px;
                                                                                overflow: auto; width: 97%">
                                                                                <table style="width: 100%;">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:GridView ID="gvTimeSlotsAvailable" AllowSorting="true" BackColor="White" DataKeyNames="AdvisorScheduleID"
                                                                                                Width="100%" Font-Size="X-Small" AutoGenerateColumns="false" Font-Names="Verdana"
                                                                                                runat="server" ShowFooter="true" GridLines="None" OnRowDataBound="gvTimeSlotsAvailable_RowDataBound"
                                                                                                BorderStyle="Double" BorderColor="#0083C1">
                                                                                                <RowStyle BackColor="Gainsboro" />
                                                                                                <AlternatingRowStyle BackColor="White" />
                                                                                                <HeaderStyle BackColor="#0083C1" ForeColor="White" />
                                                                                                <FooterStyle BackColor="White" />
                                                                                                <Columns>
                                                                                                    <asp:TemplateField>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:ImageButton ID="btnEditSchedule" runat="server" SkinID="GridEditButton" ImageUrl="~/images/btn_edit.gif"
                                                                                                                OnClick="btnEditSchedule_Click" CausesValidation="false" />
                                                                                                            <asp:ImageButton ID="btnDeleteSchedule" runat="server" SkinID="GridDeleteButton"
                                                                                                                ImageUrl="~/images/btn_delete.gif" OnClick="btnDeleteSchedule_Click" OnClientClick="javascript:return confirm('Are you sure you want to delete this Schedule?');"
                                                                                                                CausesValidation="false" />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="AdvisorScheduleID" SortExpression="AdvisorScheduleID"
                                                                                                        Visible="false" HeaderStyle-HorizontalAlign="Left">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblAdvisorScheduleID" Text='<%# Eval("AdvisorScheduleID") %>' runat="server"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <EditItemTemplate>
                                                                                                            <asp:Label ID="lblAdvisorScheduleID" Text='<%# Eval("AdvisorScheduleID") %>' runat="server"></asp:Label>
                                                                                                        </EditItemTemplate>
                                                                                                        <FooterTemplate>
                                                                                                            <asp:Label ID="lblAdvisorScheduleID" Text='<%# Eval("AdvisorScheduleID") %>' runat="server"></asp:Label>
                                                                                                        </FooterTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Start Time:" SortExpression="StartTime" HeaderStyle-HorizontalAlign="Left">
                                                                                                        <ItemTemplate>
                                                                                                            <%# Eval("StartTime") %>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="End Time:" SortExpression="EndTime" HeaderStyle-HorizontalAlign="Left">
                                                                                                        <ItemTemplate>
                                                                                                            <%# Eval("EndTime") %>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                            </asp:GridView>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center">
                                                                                            <asp:Button ID="btnNewSchedule" runat="Server" Text="New Schedule" OnClick="btnNewSchedule_Click"
                                                                                                CausesValidation="false" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:Button ID="btnHiddenPerson" runat="Server" Text="Edit Schedule" Style="display: none" />
                                                            <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
                                                            <ajaxToolkit:ModalPopupExtender ID="mpeScheduleMaintenance" runat="server" PopupControlID="pnlScheduleMaintenance"
                                                                CancelControlID="btnHiddenPerson" DropShadow="true" BackgroundCssClass="modalBackground"
                                                                TargetControlID="btnShowPopup">
                                                            </ajaxToolkit:ModalPopupExtender>
                                                            <asp:Panel ID="pnlScheduleMaintenance" runat="Server" BorderWidth="1px" CssClass="modalPopup"
                                                                BackColor="GrayText" BorderStyle="Double">
                                                                <asp:UpdatePanel ID="upnlDaySchedule" runat="server">
                                                                    <ContentTemplate>
                                                                        <table style="width: 324px;">
                                                                            <tr>
                                                                                <td colspan="3" style="font-family: Arial, Helvetica, sans-serif; font-size: 12px;
                                                                                    font-weight: bold; font-style: normal; height: 22px; font-variant: small-caps;
                                                                                    text-transform: capitalize; color: #000080;" valign="middle" align="center">
                                                                                    <asp:Panel ID="pnlCaption" runat="server">
                                                                                        Schedule Maintenance
                                                                                    </asp:Panel>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" style="font-family: Arial, Helvetica, sans-serif; font-size: 11px;
                                                                                    font-weight: bold; font-style: normal; height: 19px; color: #8b919b" colspan="3">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" style="font-family: Arial, Helvetica, sans-serif; font-size: 11px;
                                                                                    font-weight: bold; font-style: normal; height: 19px; color: #8b919b">
                                                                                    Day:
                                                                                </td>
                                                                                <td colspan="2">
                                                                                    <asp:Label ID="lblDayName" runat="server" Font-Names="Arial" Font-Size="11px" ont-Bold="True"
                                                                                        Text="Monday" Font-Bold="True" ForeColor="Black"></asp:Label>
                                                                                    <asp:Label ID="lbAdvisorScheduleID" runat="server" Font-Bold="True" Font-Names="Arial"
                                                                                        Font-Size="11px" ForeColor="Black" ont-Bold="True" Visible="False"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" style="font-family: Arial, Helvetica, sans-serif; font-size: 11px;
                                                                                    font-weight: bold; font-style: normal; height: 19px; color: #8b919b">
                                                                                    Date:
                                                                                </td>
                                                                                <td colspan="2">
                                                                                    <asp:Label ID="lblDate" runat="server" Font-Names="Arial" Font-Size="11px" ont-Bold="True"
                                                                                        Text="23-March-2013" Font-Bold="True" ForeColor="Black"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" style="font-family: Arial, Helvetica, sans-serif; font-size: 11px;
                                                                                    font-weight: bold; font-style: normal; height: 19px; color: #8b919b">
                                                                                    Start Time:
                                                                                </td>
                                                                                <td colspan="2">
                                                                                    <asp:DropDownList ID="ddlStartTime" runat="server" Width="153px" ont-Bold="True"
                                                                                        Font-Names="Arial" Font-Size="11px">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" style="font-family: Arial, Helvetica, sans-serif; font-size: 11px;
                                                                                    font-weight: bold; font-style: normal; height: 19px; color: #8b919b">
                                                                                    End Time:
                                                                                </td>
                                                                                <td class="style2" colspan="2">
                                                                                    <asp:DropDownList ID="ddlEndTime" runat="server" Width="153px" ont-Bold="True" Font-Names="Arial"
                                                                                        Font-Size="11px">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" colspan="3">
                                                                                    <asp:Button ID="btnSaveSchedule" runat="server" Text="Save Schedule" ont-Bold="True"
                                                                                        Font-Names="Arial" Font-Size="11px" Font-Bold="True" Width="105px" OnClick="btnSaveSchedule_Click" />
                                                                                    <asp:Button ID="btnCancelSchedule" runat="server" Text="Close" ont-Bold="True" Font-Names="Arial"
                                                                                        Font-Size="11px" Font-Bold="True" CausesValidation="False" Width="105px" OnClick="btnCancelSchedule_Click" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnSaveSchedule" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="8">
                                        <asp:Button ID="btnSave" runat="server" Text="Save Schedule" Width="132px" Font-Bold="True"
                                            OnClick="btnSave_Click" OnClientClick="javascript:return confirm('Are you sure you want to save this Schedule?');"/>
                                        <input id="btnReset" style="width: 124px" type="reset" value="Reset" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
