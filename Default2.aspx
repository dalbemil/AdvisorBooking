<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        
        .style2
        {
            height: 25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Panel ID="pnlScheduleMaintenance" runat="Server" BorderWidth="1px" CssClass="modalPopup" BackColor="GrayText" BorderStyle="Double" >
        <table style="width: 324px;">
            <tr>
                <td colspan="3" style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold;
                                            font-style: normal; height: 22px; font-variant: small-caps; text-transform: capitalize;
                                            color: #000080;" valign="middle" align="center">
                    <asp:Panel ID="pnlCaption" runat="server">
                    Schedule Maintenance
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="right"  style="font-family: Arial, Helvetica, sans-serif; font-size: 11px; font-weight: bold;
                                            font-style: normal;  height: 19px; color: #8b919b" 
                    colspan="3" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="font-family: Arial, Helvetica, sans-serif; font-size: 11px; font-weight: bold;
                                            font-style: normal;  height: 19px; color: #8b919b">
                    Day</td>
                <td colspan="2">
                    <asp:Label ID="lblDayName" runat="server" Font-Names="Arial" Font-Size="11px" 
                        ont-Bold="True" Text="Monday"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="font-family: Arial, Helvetica, sans-serif; font-size: 11px; font-weight: bold;
                                            font-style: normal;  height: 19px; color: #8b919b">
                    Date</td>
                <td colspan="2">
                    <asp:Label ID="lblDate" runat="server" Font-Names="Arial" Font-Size="11px" 
                        ont-Bold="True" Text="23-March-2013"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td align="right"  style="font-family: Arial, Helvetica, sans-serif; font-size: 11px; font-weight: bold;
                                            font-style: normal;  height: 19px; color: #8b919b">
                    Start Time:</td>
                <td colspan="2">
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="153px" ont-Bold="True" Font-Names="Arial"
                                                    Font-Size="11px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right"  style="font-family: Arial, Helvetica, sans-serif; font-size: 11px; font-weight: bold;
                                            font-style: normal;  height: 19px; color: #8b919b">
                    End Time:</td>
                <td class="style2" colspan="2">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="153px" ont-Bold="True" Font-Names="Arial"
                                                    Font-Size="11px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="style1" colspan="3">
                    <asp:Button ID="btnSaveSchedule" runat="server" Text="Save Schedule" 
                        ont-Bold="True" Font-Names="Arial"
                                                    Font-Size="11px" Font-Bold="True" />
                    <asp:Button ID="btnCancelSchedule" runat="server" Text="Cancel Schedule" 
                        ont-Bold="True" Font-Names="Arial"
                                                    Font-Size="11px" Font-Bold="True" />
                </td>
            </tr>
        </table>
        </asp:Panel>
        <asp:Button ID="btnHiddenPerson" runat="Server" Text ="Edit Schedule" />
        <ajaxToolkit:ModalPopupExtender ID="mpeScheduleMaintenance" runat="server" TargetControlID="btnHiddenPerson"
            PopupControlID="pnlScheduleMaintenance" CancelControlID="btnCancelSchedule" BackgroundCssClass="modalBackground"
            PopupDragHandleControlID="pnlCaption" Drag="true">
        </ajaxToolkit:ModalPopupExtender>
    </form>
</body>
</html>
