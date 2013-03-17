<%@ Page Title="" Language="C#" MasterPageFile="~/AdvisorBookingServiceMasterPage.master"
    AutoEventWireup="true" CodeFile="BookSchedules2.aspx.cs" Inherits="TemplateForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <div class="post" id="post-5">
        <div class="post-title">
            <center>
                <h2>
                    <a href="#">Booked Schedule</a></h2>
            </center>
        </div>
        <div class="post-entry">
            <div class="post-entry-top">
                <div class="post-entry-bottom">
                    <!--Content goes in this below table -->
                    <table style="width: 104%; height: 145px;">
                        <tr>
                            <td valign="middle">
                                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                                    AllowSorting="True" BackColor="White" 
                                    BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
                                    DataKeyNames="Employee ID" DataSourceID="SqlDataSource1" 
                                    EmptyDataText="There are no data records to display." GridLines="Horizontal" 
                                    Height="16px" onselectedindexchanged="GridView2_SelectedIndexChanged" 
                                    style="font-size: x-small" Width="594px" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                        <asp:BoundField DataField="Employee ID" HeaderText="Employee ID" 
                                            ReadOnly="True" SortExpression="Employee ID" />
                                        <asp:BoundField DataField="Advisor First Name" HeaderText="Advisor First Name" 
                                            SortExpression="Advisor First Name" />
                                        <asp:BoundField DataField="Advisor Last Name" HeaderText="Advisor Last Name" 
                                            SortExpression="Advisor Last Name" />
                                        <asp:BoundField DataField="Student ID" HeaderText="Student ID" 
                                            SortExpression="Student ID" />
                                        <asp:BoundField DataField="Student First Name" HeaderText="Student First Name" 
                                            SortExpression="Student First Name" />
                                        <asp:BoundField DataField="Student Last Name" HeaderText="Student Last Name" 
                                            SortExpression="Student Last Name" />
                                        <asp:BoundField DataField="Program ID" HeaderText="Program ID" 
                                            SortExpression="Program ID" />
                                        <asp:BoundField DataField="Semister" HeaderText="Semister" 
                                            SortExpression="Semister" />
                                        <asp:BoundField DataField="Appoinment Date" HeaderText="Appoinment Date" 
                                            SortExpression="Appoinment Date" />
                                        <asp:BoundField DataField="Time Start" HeaderText="Time Start" 
                                            SortExpression="Time Start" />
                                        <asp:BoundField DataField="Time End" HeaderText="Time End" 
                                            SortExpression="Time End" />
                                        <asp:BoundField DataField="Comment" HeaderText="Comment" 
                                            SortExpression="Comment" />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="White" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                    <SortedAscendingHeaderStyle BackColor="#487575" />
                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                    <SortedDescendingHeaderStyle BackColor="#275353" />
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:COLLEGE_MGMT.MDFConnectionString %>" 
                                    SelectCommand="SELECT Advisor.Employee_ID AS [Employee ID], Advisor.First_Name AS [Advisor First Name], Advisor.Last_Name AS [Advisor Last Name], 
                  Appointment.Student_Id AS [Student ID], Student.First_Name AS [Student First Name], Student.Last_Name AS [Student Last Name], 
                  Student.Program_id AS [Program ID], Student.Cur_Sem AS Semister, Availability.Date_Start AS [Appoinment Date], Availability.Time_Start AS [Time Start], 
                  Availability.Time_End AS [Time End], Appointment.Comment
FROM     Advisor INNER JOIN
                  Availability ON Advisor.Employee_ID = Availability.Employee_Id INNER JOIN
                  Appointment ON Availability.Availability_ID = Appointment.Availability_ID INNER JOIN
                  Student ON Appointment.Student_Id = Student.Student_ID ">
                                </asp:SqlDataSource>
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