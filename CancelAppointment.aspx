<%@ Page Title="" Language="C#" MasterPageFile="~/AdvisorBookingServiceMasterPage.master" AutoEventWireup="true" CodeFile="CancelAppointment.aspx.cs" Inherits="CancelAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        
          <div class="post" id="post-5">
            <div class="post-title">
              <center><h2><a href="#">Appointment Cancellation</a></h2></center>
            </div>
            <div class="post-entry">
              <div class="post-entry-top">
                <div class="post-entry-bottom">
                
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                &nbsp;</td>
                            <td style="width: 543px" valign="middle">
                                &nbsp;</td>
                            <td valign="middle">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                <asp:Label ID="lblStudentID" runat="server" style="font-weight: 700" 
                                    Text="Student I.D."></asp:Label>
                            </td>
                            <td style="width: 543px" valign="middle">
                                <asp:TextBox ID="txtStudentID" runat="server" Width="272px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvStudentID" runat="server" 
                                    ErrorMessage="Student ID should not be blank" ControlToValidate="txtStudentID" 
                                    Font-Bold="True" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rgvStudentID" runat="server" ControlToValidate="txtStudentID" 
                                    ErrorMessage="Student ID must be between 1 to 999999999" ForeColor="#FF3300" 
                                    MaximumValue="999999999" MinimumValue="1" Type="Integer">*</asp:RangeValidator>
                            </td>
                            <td valign="middle">
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 24px;" valign="top" align="right">
                                <asp:Label ID="Llbcomment" runat="server" style="font-weight: 700" 
                                    Text="Reason for cancel"></asp:Label>
                                </td>
                            <td style="width: 543px; height: 24px;" valign="top">
                                <textarea ID="txtComments" runat="server" style="height: 79px; width: 270px" ></textarea>
                            </td>
                            <td valign="middle" style="height: 24px">
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 24px;" valign="middle">
                                &nbsp;</td>
                            <td style="width: 543px; height: 24px;" valign="top">
                                                          <asp:Button ID="btncheck" runat="server" Text="View appointment" 
                                    Width="134px" onclick="btnCheck_click" />     
                             
                            </td>
                            <td valign="middle" style="height: 24px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                        <td style="width: 137px; text-align: right" valign="middle">
                                &nbsp;</td>
                            <td style="width: 543px" valign="middle">
                                &nbsp;</td>

                        </tr>

                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                &nbsp;</td>
                            <td style="width:543px" valign="middle">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                     autogenerateselectbutton="True" selectedindex="0" 
                                    onselectedindexchanged="GridView1_SelectedIndexChanged" 
                                    onrowdeleting="GridView1_RowDeleting" CellPadding="4" ForeColor="#333333" 
                                    GridLines="None" Width="540px" HorizontalAlign="Center">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                    <asp:BoundField DataField="Appointment_ID" HeaderText="Appointment ID" 
                                            SortExpression="Appointment_ID" />
                                        <asp:BoundField DataField="Student_Id" HeaderText="Student Id" 
                                            SortExpression="Student_Id" />
                                            <asp:BoundField DataField="Comment" HeaderText="Comment" 
                                            SortExpression="Comment" />
                                            <asp:BoundField DataField="Date_Start" HeaderText="Date Start" 
                                            SortExpression="Date_Start" />
                                            <asp:BoundField DataField="Time_Start" HeaderText="Time Start" 
                                            SortExpression="Time_Start" />
                                    </Columns>
                                     <EditRowStyle BackColor="#999999"/>
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                     <selectedrowstyle backcolor="#E2DED6"
                                        forecolor="#333333"
                                    font-bold="true" HorizontalAlign="Center"/> 
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                                
                            </td>
                            <td valign="middle">
                                &nbsp;</td>
                        </tr>
                         <tr>
                            <td style="width: 137px" valign="middle">
                                &nbsp;</td>
                            <td style="width: 543px" valign="middle">
                                &nbsp;</td>
                            <td valign="middle">
                                &nbsp;</td>
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