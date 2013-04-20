<%@ Page Title="" Language="C#" MasterPageFile="~/StudentMasterPage.master" AutoEventWireup="true"
    CodeFile="StudentCancelAppointment.aspx.cs" Inherits="CancelAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <div class="post" id="post-5">
        <div class="post-title">
            <center>
                <h2>
                    Appointment Cancellation</h2>
            </center>
        </div>
        <div class="post-entry">
            <div class="post-entry-top">
                <div class="post-entry-bottom">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                &nbsp;</td>
                            <td style="width: 221px" valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                &nbsp;</td>
                            <td style="width: 221px" valign="middle">
                               
                                 &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: left" valign="top">
                                <span style="color: #FFFFFF">Student ID: 
                                </span><br /> 
                                <asp:TextBox ID="txtStudentID" runat="server" Width="126px" 
                                    ReadOnly="True" style="color: #000000" ForeColor="Black"></asp:TextBox>
                                <br style="color: #FFFFFF" />
                                <span style="color: #FFFFFF">Reason for cancel:</span><br />
                               
                                 <textarea id="txtComments" rows="1" runat="server" name="S1" 
                                    style="width: 135px; height: 74px"></textarea></td>
                            <td style="width: 500px" valign="top">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                    SelectedIndex="0" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
                                    OnRowDeleting="GridView1_RowDeleting" Width="444px" CellPadding="4" 
                                    ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:CommandField SelectText="Delete" ShowSelectButton="True" />
                                        <asp:BoundField HeaderText="Appointment_ID" DataField="Appointment_ID" 
                                            ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Student_Id" DataField="Student_Id"/>
                                        <asp:BoundField HeaderText="Advisor" DataField="Advisor"/>
                                        <asp:BoundField HeaderText="Comment" DataField="Comment"/>
                                        <asp:TemplateField HeaderText="Date">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Date") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" 
                                                    Text='<%# Bind("Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Time_Start" DataField="Time_Start"/>
                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle/>
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px" valign="middle">
                                &nbsp;</td>
                            <td style="width: 221px" valign="middle">
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
