<%@ Page Title="Advisor Schedule" Language="C#" MasterPageFile="~/AdvisorBookingServiceMasterPage.master"
    AutoEventWireup="true" CodeFile="AdvisorSchedule.aspx.cs" Inherits="AdvisorSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="frmAdvisorSchedule" runat="server">
    <div class="post" id="post-5">
        <div class="post-title">
            <center>
                <h2>
                    <a href="#">Advisor Schedule</a></h2>
            </center>
        </div>
        <div class="post-entry">
            <div class="post-entry-top">
                <div class="post-entry-bottom">
                    <table style="width: 100%" border="1">
                        <tr>
                            <td align="center">
                                Year:</td>
                            <td align="left">
                                <asp:DropDownList ID="ddlYear" runat="server" 
                                    onselectedindexchanged="ddlYear_SelectedIndexChanged" AutoPostBack="true" >
                                </asp:DropDownList>
                            </td>
                            <td align="center">
                                Week 
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlWeek" runat="server"  AutoPostBack="true"
                                    onselectedindexchanged="ddlWeek_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 201px" align="right">
                                Advisor Number:
                            </td>
                            <td style="width: 145px" align="left">
                                <asp:Label ID="lblAdvisorNumber" runat="server" Text="lblAdvisorNumber"></asp:Label>
                            </td>
                            <td style="width: 150px" align="right">
                                Advisor Name:
                            </td>
                            <td style="width: 201px" align="left">
                                <asp:Label ID="lblAdvisorName" runat="server" Text="lblAdvisorName"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8">
                                <table style="width: 100%; height: 45px; margin-bottom: 0px;">
                                    <tr>
                                        <td align="left" style="height: 99px" valign="top">
                                            <asp:GridView ID="gvAdvisorSchedule" runat="server" BackColor="White" BorderColor="#E9ECEF"
                                                AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" CellPadding="4"
                                                ForeColor="Black" GridLines="Vertical" OnRowDataBound="gvAdvisorSchedule_RowDataBound"
                                                OnRowCommand="gvAdvisorSchedule_RowCommand" OnRowCreated="gvAdvisorSchedule_RowCreated"
                                                ShowFooter="True" Width="739px" Height="75px" Style="margin-left: 0px">
                                                <Columns>
                                                    <asp:ButtonField Text="SingleClick" CommandName="SingleClick" Visible="False" />
                                                    <asp:TemplateField HeaderText="Days">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="350px" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="8:00">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="8:30">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="9:00">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="9:30">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="10:00">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="10:30">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="11:00">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="11:30">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="12:00">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="12:30">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="1:00">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="1:30">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="2:00">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="2:30">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="3:00">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="3:30">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="4:00">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="4:30">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="headerStyle" ForeColor="White" />
                                                <RowStyle CssClass="rowStyle" />
                                                <AlternatingRowStyle CssClass="alternatingRowStyle" />
                                                <FooterStyle CssClass="footerStyle" />
                                                <PagerStyle CssClass="pagerStyle" ForeColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
