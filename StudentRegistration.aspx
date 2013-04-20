<%@ Page Title="" Language="C#" MasterPageFile="~/LogInMasterPage.master" AutoEventWireup="true"
    CodeFile="StudentRegistration.aspx.cs" Inherits="StudentRegistration" %>

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
                            <td style="width: 278px; text-align: right" valign="middle">
                                &nbsp;
                            </td>
                            <td style="width: 152px" valign="middle">
                                &nbsp;
                            </td>
                            <td valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 278px; text-align: right" valign="middle">
                                <asp:Label ID="lblUploadPhoto" runat="server" Style="font-weight: 700" 
                                    Text="Photo" ForeColor="White"></asp:Label>
                            </td>
                            <td style="width: 152px" valign="middle">
                                <asp:FileUpload ID="PhotoUpload" runat="server" />
                            </td>
                            <td valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 278px; text-align: right" valign="middle">
                                <asp:Label ID="lblName" runat="server" Style="font-weight: 700" Text="Name" 
                                    ForeColor="White"></asp:Label>
                            </td>
                            <td style="width: 152px" valign="middle">
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
                            <td style="width: 278px" valign="middle">
                                &nbsp;
                            </td>
                            <td style="text-align: center; width: 152px" valign="middle">
                                <asp:Label ID="lblFName" runat="server" Style="font-weight: 700" Text="(First Name)"></asp:Label>
                            </td>
                            <td style="text-align: center" valign="middle">
                                <asp:Label ID="lblLName" runat="server" Style="font-weight: 700" Text="(Last Name)"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 278px; text-align: right" valign="middle">
                                <asp:Label ID="lblStudentID" runat="server" Style="font-weight: 700" 
                                    Text="Student I.D." ForeColor="White"></asp:Label>
                            </td>
                            <td style="width: 152px" valign="middle">
                                <asp:TextBox ID="txtStudentID" runat="server" Width="174px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvStudentID" runat="server" ErrorMessage="Student ID should not be blank"
                                    ControlToValidate="txtStudentID" Font-Bold="True" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rgvStudentID" runat="server" ControlToValidate="txtStudentID"
                                    ErrorMessage="Student ID must be between 1 to 999999999" ForeColor="#FF3300"
                                    MaximumValue="999999999" MinimumValue="1" Type="Integer">*</asp:RangeValidator>
                            </td>
                            <td valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 278px; text-align: right" valign="middle">
                                <asp:Label ID="lblProgramName" runat="server" Style="font-weight: 700" 
                                    Text="Program Name" ForeColor="White"></asp:Label>
                            </td>
                            <td valign="middle" colspan="2">
                                <asp:DropDownList ID="ddlProgram" runat="server" DataSourceID="ProgramSqlDataSource"
                                    DataTextField="Program_Name" DataValueField="Program_Id">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="ProgramSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:AdvisorBookingConnectionString %>"
                                    SelectCommand="SELECT [Program_Id], [Program_Name] FROM [Programs]"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 278px; text-align: right" valign="middle">
                                <asp:Label ID="lblCurrentSemester" runat="server" Style="font-weight: 700" 
                                    Text="Current Semester" ForeColor="White"></asp:Label>
                            </td>
                            <td style="width: 152px" valign="middle">
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
                            <td style="width: 278px; text-align: right;" valign="middle">
                                <asp:Label ID="lblEmailID" runat="server" Style="font-weight: 700" 
                                    Text="Email ID" ForeColor="White"></asp:Label>
                            </td>
                            <td style="width: 152px" valign="middle">
                                <asp:TextBox ID="txtEmailID" runat="server" Width="174px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmailID" runat="server" ErrorMessage="Email ID should not be blank"
                                    ControlToValidate="txtEmailID" Font-Bold="True" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailID"
                                    ErrorMessage="Email ID is not valid" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                            </td>
                            <td valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 278px; text-align: right;" valign="middle">
                                <asp:Label ID="lblPassword" runat="server" Style="font-weight: 700" 
                                    Text="Password" ForeColor="White"></asp:Label>
                            </td>
                            <td style="width: 152px" valign="middle">
                                <asp:TextBox ID="txtPassword" runat="server" Width="174px" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Password should not be blank"
                                    ControlToValidate="txtPassword" Font-Bold="True" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                            </td>
                            <td valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 278px; text-align: right;" valign="middle">
                                <asp:Label ID="lblConfirmPassword" runat="server" Style="font-weight: 700" 
                                    Text="Confirm Password" ForeColor="White"></asp:Label>
                            </td>
                            <td style="width: 152px" valign="middle">
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
                            <td style="width: 278px" valign="middle">
                                &nbsp;
                            </td>
                            <td style="width: 152px" valign="middle">
                                &nbsp;
                            </td>
                            <td valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 278px" valign="middle">
                                &nbsp;
                            </td>
                            <td style="width: 152px" valign="middle">
                                <asp:Button ID="btnRegister" runat="server" Text="Register" Width="219px" OnClick="btnRegister_Click" />
                            </td>
                            <td valign="middle" align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 278px" valign="middle">
                                &nbsp;
                            </td>
                            <td colspan="2" valign="middle">
                                <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="#FF3300"
                                    HeaderText="You must enter a value according to following criteria" />
                                <br />
                                <asp:Label ID="lblMessage" runat="server" ForeColor="#FF3300"></asp:Label>
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
