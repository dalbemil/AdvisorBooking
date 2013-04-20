<%@ Page Title="Advisor Booking LogIn" Language="C#" MasterPageFile="~/LogInMasterPage.master"
    AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="UserLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="frmLogInUser" runat="server" style="height: 210px; width: 984px">
    <div class="postlogin" id="post-5">
        <div class="postlogin-title">
            <center>
                <h2 style="color: #4c576a">
                    User LogIn</h2>
            </center>
        </div>
        <div class="postlogin-entry">
            <div class="postlogin-entry-top" align="center">
                <div class="postlogin-entry-bottom">
                    <asp:UpdatePanel ID="upnlLogInUser" runat="server">
                        <ContentTemplate>
                            <table width="250" border="0" style="height: 120px; width: 308px; vertical-align: middle;
                                text-align: center;" align="left">
                                <tr>
                                    <td align="right" class="style1">
                                        &nbsp;
                                    </td>
                                    <td style="width: 195px">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="style1">
                                        <span class="style3">Email Address:</span>
                                    </td>
                                    <td style="width: 195px">
                                        <asp:TextBox ID="txtUserName" runat="server" Font-Bold="True" Font-Names="Arial"
                                            MaxLength="50" Width="184px" Font-Size="Small"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="style1">
                                        <span class="style3">Password:</span>
                                    </td>
                                    <td style="width: 195px">
                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="184px" Font-Size="Small"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="height: 34px">
                                        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="10px"
                                            ForeColor="#C00000" Height="20px" Text="lblMessage" Width="99%"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 15px" align="right">
                                        <asp:Button ID="btnSignIn" runat="server" OnClick="btnSignIn_Click" Text="Sign In..."
                                            Font-Bold="True" Font-Names="Arial" Font-Size="11px" Height="25px" Width="90px" />
                                        <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reset..."
                                            Font-Bold="False" Font-Names="Arial" Font-Size="11px" Height="25px" Width="90px" />
                                        <asp:ScriptManager ID="ScriptManager1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="style1">
                                        &nbsp;
                                    </td>
                                    <td style="width: 195px">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="height: 15px">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <asp:HyperLink ID="hlkNewAdvisor" runat="server" Font-Bold="True" Font-Underline="False"
                                                        NavigateUrl="~/AdvisorRegistration.aspx">New Advisor Register</asp:HyperLink>
                                                </td>
                                                <td>
                                                    <asp:HyperLink ID="hlkStudentRegister" runat="server" Font-Bold="True" Font-Underline="False"
                                                        NavigateUrl="~/StudentRegistration.aspx">New Student Register</asp:HyperLink>
                                                </td>
                                            </tr>
                                        </table>
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
