<%@ Page Title="" Language="C#" MasterPageFile="~/StudentMasterPage.master" AutoEventWireup="true"
    CodeFile="StudentProfileUpdate.aspx.cs" Inherits="StudentProfileUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <div class="post" id="post-5">
        <div class="post-title">
            <center>
                <h2>
                    <a href="#">Student Registration</a></h2>
            </center>
        </div>
        <div class="post-entry">
            <div class="post-entry-top">
                <div class="post-entry-bottom">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                <asp:Label ID="lblName0" runat="server" Style="font-weight: 700" Text="Photo"></asp:Label>
                            </td>
                            <td style="width: 221px" valign="middle">
                                <asp:Image ID="imgPhoto" runat="server" AlternateText="This is not working" Height="100px"
                                    Width="100px" />
                                <br />
                                <asp:FileUpload ID="imgUpload" runat="server" />
                            </td>
                            <td valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                <asp:Label ID="lblName" runat="server" Style="font-weight: 700" Text="Name"></asp:Label>
                            </td>
                            <td style="width: 221px" valign="middle">
                                <asp:TextBox ID="txtFName" runat="server" Width="174px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvFName" runat="server" ErrorMessage="First Name should not be blank"
                                    ControlToValidate="txtFName" Font-Bold="True" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rgvFName" runat="server" ControlToValidate="txtFName" ErrorMessage="First Name must contain characters only"
                                    ForeColor="#FF3300" MaximumValue="z" MinimumValue="A">*</asp:RangeValidator>
                            </td>
                            <td valign="middle">
                                <asp:TextBox ID="txtLName" runat="server" Width="174px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvLName" runat="server" ErrorMessage="Last Name should not be blank"
                                    ControlToValidate="txtLName" Font-Bold="True" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rgvLName" runat="server" ControlToValidate="txtLName" ErrorMessage="Last Name must contain characters only"
                                    ForeColor="#FF3300" MaximumValue="z" MinimumValue="A">*</asp:RangeValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px" valign="middle">
                                &nbsp;
                            </td>
                            <td style="text-align: center; width: 221px" valign="middle">
                                <asp:Label ID="lblFName" runat="server" Style="font-weight: 700" Text="(First Name)"></asp:Label>
                            </td>
                            <td style="text-align: center" valign="middle">
                                <asp:Label ID="lblLName" runat="server" Style="font-weight: 700" Text="(Last Name)"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                <asp:Label ID="lblStudentID" runat="server" Style="font-weight: 700" Text="Student I.D."></asp:Label>
                            </td>
                            <td style="width: 221px" valign="middle">
                                <asp:Label ID="lblStudentIDValue" runat="server"></asp:Label>
                            </td>
                            <td valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                <asp:Label ID="lblProgramName" runat="server" Style="font-weight: 700" Text="Program Name"></asp:Label>
                            </td>
                            <td valign="middle" colspan="2">
                                <asp:DropDownList ID="ddlProgramName" runat="server" DataSourceID="StudentSqlDataSource"
                                    DataTextField="Program_Name" DataValueField="Program_Id">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="StudentSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:AdvisorBookingConnectionString %>"
                                    SelectCommand="SELECT [Program_Id], [Program_Name] FROM [Programs]" 
                                    ProviderName="<%$ ConnectionStrings:AdvisorBookingConnectionString.ProviderName %>"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                <asp:Label ID="lblCurrentSemester" runat="server" Style="font-weight: 700" Text="Current Semester"></asp:Label>
                            </td>
                            <td style="width: 221px" valign="middle">
                                <asp:TextBox ID="txtCurrentSemester" runat="server" Width="79px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCurrentSemester" runat="server" ErrorMessage="CurrentSemester should not be blank"
                                    ControlToValidate="txtCurrentSemester" Font-Bold="True" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rgvCurrentSemester" runat="server" ControlToValidate="txtCurrentSemester"
                                    ErrorMessage="CurrentSemester must be between 1 to 8 only" ForeColor="#FF3300"
                                    MaximumValue="8" MinimumValue="1" Type="Integer">*</asp:RangeValidator>
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
                                <asp:Button ID="btnUpdate" runat="server" Text="Update Profile" Width="219px" OnClick="btnUpdate_Click" />
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
