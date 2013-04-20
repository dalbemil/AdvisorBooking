<%@ Page Title="" Language="C#" MasterPageFile="~/StudentMasterPage.master" AutoEventWireup="true"
    CodeFile="StudentPasswordUpdate.aspx.cs" Inherits="PasswordUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <div class="post" id="post-5">
        <div class="post-title">
            <center>
                <h2>
                    <a href="#">Update Password</a></h2>
            </center>
        </div>
        <div class="post-entry">
            <div class="post-entry-top">
                <div class="post-entry-bottom">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                &nbsp;
                            </td>
                            <td style="width: 221px" valign="middle">
                                &nbsp;
                            </td>
                            <td valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                <asp:Label ID="lblOldPassword" runat="server" Style="font-weight: 700" Text="Old Password"></asp:Label>
                            </td>
                            <td style="width: 221px" valign="middle">
                                <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" Width="172px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvOldPassword" runat="server" ErrorMessage="Password should not be blank"
                                    ControlToValidate="txtOldPassword" Font-Bold="True" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                            </td>
                            <td valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right;" valign="middle">
                                <asp:Label ID="lblPassword" runat="server" Style="font-weight: 700" Text="Password"></asp:Label>
                            </td>
                            <td style="width: 221px" valign="middle">
                                <asp:TextBox ID="txtPassword" runat="server" Width="174px" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Password should not be blank"
                                    ControlToValidate="txtPassword" Font-Bold="True" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="text-align: center" valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right;" valign="middle">
                                <asp:Label ID="lblConfirmPassword" runat="server" Style="font-weight: 700" Text="Confirm Password"></asp:Label>
                            </td>
                            <td style="width: 221px" valign="middle">
                                <asp:TextBox ID="txtConfirmPassword" runat="server" Width="174px" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ErrorMessage="Confirm Password should not be blank"
                                    ControlToValidate="txtConfirmPassword" Font-Bold="True" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cmpvConfirmPassword" runat="server" ControlToCompare="txtPassword"
                                    ControlToValidate="txtConfirmPassword" ErrorMessage="Password and Confirm Password does not match"
                                    ForeColor="#FF3300">*</asp:CompareValidator>
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
                                &nbsp;
                            </td>
                            <td valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right;" valign="middle">
                                &nbsp;
                            </td>
                            <td style="width: 221px" valign="middle">
                                <asp:Button ID="btnUpdatePassword" runat="server" Text="Update Password" Width="219px"
                                    OnClick="btnUpdate_Click" />
                            </td>
                            <td valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right;" valign="middle">
                                &nbsp;
                            </td>
                            <td style="width: 221px" valign="middle">
                                &nbsp;
                            </td>
                            <td valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right;" valign="middle">
                                &nbsp;
                            </td>
                            <td style="width: 221px" valign="middle">
                                <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="#FF3300"
                                    HeaderText="You must enter a value according to following criteria" />
                            </td>
                            <td valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right;" valign="middle">
                                &nbsp;
                            </td>
                            <td style="width: 221px" valign="middle">
                                <asp:Label ID="lblMessage" runat="server" ForeColor="#FF3300"></asp:Label>
                            </td>
                            <td valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="navigation">
        <div class="navigation-previous">
        </div>
        <div class="navigation-next">
        </div>
    </div>
    <div class="clear">
    </div>
    </form>
</asp:Content>
