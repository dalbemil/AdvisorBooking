<%@ Page Title="" Language="C#" MasterPageFile="~/StudentMasterPage.master" AutoEventWireup="true"
    CodeFile="ViewStudentAppointment.aspx.cs" Inherits="ViewStudentAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <div class="post" id="post-5">
        <div class="post-title">
            <center>
                <h2>
                    My Appointment</h2>
            </center>
        </div>
        <div class="post-entry">
            <div class="post-entry-top">
                <div class="post-entry-bottom">
                    <!--Content goes in this below table -->
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                &nbsp;
                            </td>
                            <td style="width: 221px" valign="middle">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    DataSourceID="SqlDataSource1" BackColor="LightGoldenrodYellow" 
                                    BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
                                    GridLines="None" Width="587px">
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                    <Columns>
                                        <asp:BoundField DataField="Student_Id" HeaderText="Student_Id" 
                                            SortExpression="Student_Id" />
                                             <asp:BoundField DataField="Advisor" HeaderText="Advisor" 
                                            SortExpression="Student_Id" />
                                        <asp:TemplateField HeaderText="Date" SortExpression="Date">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Date") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" 
                                                    Text='<%# Bind("Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Time_Start" HeaderText="Time_Start" 
                                            SortExpression="Time_Start" />
                                        <asp:BoundField DataField="Time_End" HeaderText="Time_End" 
                                            SortExpression="Time_End" />
                                        <asp:BoundField DataField="Comment" HeaderText="Comment" 
                                            SortExpression="Comment" />
                                    </Columns>
                                    <FooterStyle BackColor="Tan" />
                                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                                        HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    <SortedAscendingCellStyle BackColor="#FAFAE7" />
                                    <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                                    <SortedDescendingCellStyle BackColor="#E1DB9C" />
                                    <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:AdvisorBookingConnectionString %>" 
                                    SelectCommand="SELECT     Appointment_ID,Advisors.First_Name + ' ' +  Advisors.Last_Name As Advisor, Appointments.Time_Start, Appointments.Time_End, Appointments.Date,Comment,Student_ID FROM Advisors INNER JOIN AdvisorSchedules ON Advisors.Advisor_ID = AdvisorSchedules.Advisor_ID INNER JOIN Appointments ON AdvisorSchedules.AdvisorScheduleID = Appointments.AdvisorScheduleID WHERE ([Student_Id] = @Student_Id)">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="Student_Id" SessionField="StudentID" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
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
