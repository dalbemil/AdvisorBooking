<%@ Page Title="" Language="C#" MasterPageFile="~/StudentMasterPage.master" AutoEventWireup="true"
    CodeFile="MakeAppointment.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="post" id="post-5">
        <div class="post-title">
            <center>
                <h2>
                    Book An Appointment</h2>
            </center>
            <p>
                &nbsp;</p>
        </div>
        <div class="post-entry">
            <div class="post-entry-top">
                <div class="post-entry-bottom">
                    <br />
                    <!--Content goes in this below table -->
                    <table style="width: 98%; height: 228px;">
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                &nbsp;
                            </td>
                            <td style="width: 221px" valign="middle">
                                <asp:Label ID="lvlAdvisorName" runat="server" ForeColor="#CCCCCC" Text="Advisor Name"
                                    Style="font-weight: 700"></asp:Label>
                            </td>
                            <td valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                &nbsp;
                            </td>
                            <td style="width: 221px" valign="middle">
                                <asp:TextBox ID="txtAdvisorName" runat="server" Width="202px" ReadOnly="True" />
                            </td>
                            <td valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                &nbsp;
                            </td>
                            <td style="width: 221px" valign="middle">
                                <asp:Label ID="lblAppointmentDate" runat="server" ForeColor="#CCCCCC" Text="Appointment Date"
                                    Style="font-weight: 700"></asp:Label>
                            </td>
                            <td valign="middle">
                                <asp:Label ID="lvlTime" runat="server" ForeColor="#CCCCCC" Text="Time" Style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                &nbsp;
                            </td>
                            <td style="width: 221px" valign="middle">
                                <asp:TextBox ID="txtDate" runat="server" Width="202px" onclick="popupCalendar()"
                                    ReadOnly="True" />
                            </td>
                            <td valign="middle">
                                <div style="position: absolute">
                                    <div id="dateField" style="display: none; position: relative; left: -15px; top: 20px;
                                        height: 189px; width: 232px;">
                                        <%@ register tagprefix="uc1" tagname="ctlCalendar" src="UserControls/ctlCalendar.ascx" %>
                                        <uc1:ctlCalendar ID="ctlCalendar1" runat="server"></uc1:ctlCalendar>
                                    </div>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="dropdownlistTime" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                                            BackColor="White" ForeColor="Black" Style="border-style: none; border-color: inherit;
                                            border-width: 0px; line-height: 8px; font-size: 9px; margin-bottom: 0px;" Height="18px"
                                            Width="202px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                &nbsp;
                            </td>
                            <td valign="middle" colspan="2">
                                <asp:Label ID="lblDescription" runat="server" ForeColor="#CCCCCC" Text="Description"
                                    Style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                &nbsp;
                            </td>
                            <td valign="middle" colspan="2">
                                <textarea id="TextArea1" name="S1" style="height: 99px; width: 292px" runat="server"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                &nbsp;
                            </td>
                            <td valign="middle" colspan="2">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="Button1_Click" Visible="False" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
                function popupCalendar() {
                    var dateField = document.getElementById('dateField'); // toggle the div 
                    if (dateField.style.display == 'none') dateField.style.display = 'block';
                    else dateField.style.display = 'none';
                }
    </script>
    </form>
</asp:Content>
