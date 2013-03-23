<%@ Page Title="" Language="C#" MasterPageFile="~/AdvisorBookingServiceMasterPage.master" AutoEventWireup="true" CodeFile="ViewStudentAppointment.aspx.cs" Inherits="ViewStudentAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        
          <div class="post" id="post-5">
            <div class="post-title">
               <center><h2><a href="#">My Appoint</a>ment</h2></center>
            </div>
            <div class="post-entry">
              <div class="post-entry-top">
                <div class="post-entry-bottom">
             

             <!--Content goes in this below table -->

                    <table style="width: 100%">
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                &nbsp;</td>
                            <td style="width: 221px" valign="middle">
                                <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" 
                                    DataKeyNames="Appointment_ID">
                                    <AlternatingItemTemplate>
                                        <tr style="background-color:#FFF8DC;">
                                            <td>
                                                <asp:Label ID="Appointment_IDLabel" runat="server" 
                                                    Text='<%# Eval("Appointment_ID") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="Student_IdLabel" runat="server" 
                                                    Text='<%# Eval("Student_Id") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="CommentLabel" runat="server" Text='<%# Eval("Comment") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="Booked_timeLabel" runat="server" 
                                                    Text='<%# Eval("Booked_time") %>' />
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                    <EditItemTemplate>
                                        <tr style="background-color:#008A8C;color: #FFFFFF;">
                                            <td>
                                                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                                                    Text="Update" />
                                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                                    Text="Cancel" />
                                            </td>
                                            <td>
                                                <asp:Label ID="Appointment_IDLabel1" runat="server" 
                                                    Text='<%# Eval("Appointment_ID") %>' />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Student_IdTextBox" runat="server" 
                                                    Text='<%# Bind("Student_Id") %>' />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="CommentTextBox" runat="server" Text='<%# Bind("Comment") %>' />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Booked_timeTextBox" runat="server" 
                                                    Text='<%# Bind("Booked_time") %>' />
                                            </td>
                                        </tr>
                                    </EditItemTemplate>
                                    <EmptyDataTemplate>
                                        <table runat="server" 
                                            style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                                            <tr>
                                                <td>
                                                    No data was returned.</td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                    <InsertItemTemplate>
                                        <tr style="">
                                            <td>
                                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                                                    Text="Insert" />
                                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                                    Text="Clear" />
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:TextBox ID="Student_IdTextBox" runat="server" 
                                                    Text='<%# Bind("Student_Id") %>' />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="CommentTextBox" runat="server" Text='<%# Bind("Comment") %>' />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Booked_timeTextBox" runat="server" 
                                                    Text='<%# Bind("Booked_time") %>' />
                                            </td>
                                        </tr>
                                    </InsertItemTemplate>
                                    <ItemTemplate>
                                        <tr style="background-color:#DCDCDC;color: #000000;">
                                            <td>
                                                <asp:Label ID="Appointment_IDLabel" runat="server" 
                                                    Text='<%# Eval("Appointment_ID") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="Student_IdLabel" runat="server" 
                                                    Text='<%# Eval("Student_Id") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="CommentLabel" runat="server" Text='<%# Eval("Comment") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="Booked_timeLabel" runat="server" 
                                                    Text='<%# Eval("Booked_time") %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table runat="server">
                                            <tr runat="server">
                                                <td runat="server">
                                                    <table ID="itemPlaceholderContainer" runat="server" border="1" 
                                                        style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                        <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                                            <th runat="server">
                                                                Appointment_ID</th>
                                                            <th runat="server">
                                                                Student_Id</th>
                                                            <th runat="server">
                                                                Comment</th>
                                                            <th runat="server">
                                                                Booked_time</th>
                                                        </tr>
                                                        <tr ID="itemPlaceholder" runat="server">
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td runat="server" 
                                                    style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                                                </td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                    <SelectedItemTemplate>
                                        <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                                            <td>
                                                <asp:Label ID="Appointment_IDLabel" runat="server" 
                                                    Text='<%# Eval("Appointment_ID") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="Student_IdLabel" runat="server" 
                                                    Text='<%# Eval("Student_Id") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="CommentLabel" runat="server" Text='<%# Eval("Comment") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="Booked_timeLabel" runat="server" 
                                                    Text='<%# Eval("Booked_time") %>' />
                                            </td>
                                        </tr>
                                    </SelectedItemTemplate>
                                </asp:ListView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:College_MgmtConnectionString %>" 
                                    SelectCommand="SELECT [Appointment_ID], [Student_Id], [Comment], [Booked_time] FROM [Appointment] WHERE ([Student_Id] = @Student_Id)">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="300556849" Name="Student_Id" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
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

