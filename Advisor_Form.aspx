
<%@ Page Title="" Language="C#" MasterPageFile="~/AdvisorBookingServiceMasterPage.master" AutoEventWireup="true" CodeFile="Advisor_Form.aspx.cs"  Inherits="Advisor_Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        
          <div class="post" id="post-5">
            <div class="post-title">
              <center><h2><a href="#">Advisor Registration</a></h2></center>
            </div>
            <div class="post-entry">
              <div class="post-entry-top">
                <div class="post-entry-bottom">
             




                    <table style="width: 100%">
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                &nbsp;</td>
                            <td style="width: 221px" valign="middle">
                                &nbsp;</td>
                            <td valign="middle">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                <asp:Label ID="lblName" runat="server" style="font-weight: 700" Text="Name"></asp:Label>
                            </td>
                            <td style="width: 221px" valign="middle">
                                <asp:TextBox ID="txtFName" runat="server" Width="174px" 
                                    ontextchanged="txtFName_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvFName" runat="server" 
                                    ErrorMessage="First Name should not be blank" ControlToValidate="txtFName" 
                                    Font-Bold="True" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rgvFName" runat="server" ControlToValidate="txtFName" 
                                    ErrorMessage="First Name must contain characters only" ForeColor="#FF3300" 
                                    MaximumValue="z" MinimumValue="a">*</asp:RangeValidator>
                            </td>
                            <td valign="middle">
                                <asp:TextBox ID="txtLName" runat="server" Width="174px" 
                                    ontextchanged="txtLName_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvLName" runat="server" 
                                    ErrorMessage="Last Name should not be blank" ControlToValidate="txtLName" 
                                    Font-Bold="True" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rgvLName" runat="server" ControlToValidate="txtLName" 
                                    ErrorMessage="Last Name must contain characters only" ForeColor="#FF3300" 
                                    MaximumValue="z" MinimumValue="a">*</asp:RangeValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px" valign="middle">
                                &nbsp;</td>
                            <td style="text-align: center; width: 221px" valign="middle">
                                <asp:Label ID="lblFName" runat="server" style="font-weight: 700" 
                                    Text="(First Name)"></asp:Label>
                            </td>
                            <td style="text-align: center" valign="middle">
                                <asp:Label ID="lblLName" runat="server" style="font-weight: 700" 
                                    Text="(Last Name)"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                <asp:Label ID="lblStudentID" runat="server" style="font-weight: 700" 
                                    Text="Employee I.D."></asp:Label>
                            </td>
                            <td style="width: 221px" valign="middle">
                                <asp:TextBox ID="txtAdvisorID" runat="server" Width="174px" 
                                    ontextchanged="txtAdvisorID_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvAdvisorID" runat="server" 
                                    ErrorMessage="Advisor ID should not be blank" ControlToValidate="txtAdvisorID" 
                                    Font-Bold="True" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rgvAdvisorID" runat="server" ControlToValidate="txtAdvisorID" 
                                    ErrorMessage="Advisor ID must be between 1 to 999999999" ForeColor="#FF3300" 
                                    MaximumValue="999999999" MinimumValue="1" Type="Integer">*</asp:RangeValidator>
                            </td>
                            <td valign="middle">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                <asp:Label ID="Dept_ID" runat="server" style="font-weight: 700" 
                                    Text="Department Name"></asp:Label>
                            </td>
                             <td style="width: 221px" valign="middle">
                            <asp:TextBox ID="txtDept" runat="server" Width="174px" 
                                    ontextchanged="txtFName_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="Department Name should not be blank" ControlToValidate="txtDept" 
                                    Font-Bold="True" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDept" 
                                    ErrorMessage="Department Name must contain characters only" ForeColor="#FF3300" 
                                    MaximumValue="z" MinimumValue="a">*</asp:RangeValidator>
                            </td>
                            </tr>

                        <tr>
                            <td style="width: 137px" valign="middle">
                                &nbsp;</td>
                            <td style="width: 221px" valign="middle">
                                &nbsp;</td>
                            <td valign="middle">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 137px" valign="middle">
                                &nbsp;</td>
                            <td style="width: 221px" valign="middle">
                                <asp:Button ID="btnRegister" runat="server" Text="Register" 
                                    Width="219px" onclick="btnRegister_Click" />
                            </td>
                            <td valign="middle">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 137px" valign="middle">
                                &nbsp;</td>
                            <td colspan="2" valign="middle">
                                <asp:ValidationSummary ID="ValidationSummary" runat="server" 
                                    ForeColor="#FF3300" 
                                    HeaderText="You must enter a value according to following criteria" />
                            </td>
                        </tr>
                    </table>
             




                </div>
              </div>
            </div>
          </div>
          <div class="navigation">
            <div class="navigation-previous"></div>
            <div class="navigation-next"></div>
          </div>
          <div class="clear"></div>
        
    
</form>
</asp:Content>


