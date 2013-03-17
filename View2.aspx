<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View2.aspx.cs" Inherits="View2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
    <div style="height: 237px">
    
        <br />
        Advisor Schedules<asp:GridView ID="GridView1" runat="server" 
            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="AdvisorScheduleID" 
            DataSourceID="SqlDataSource7" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="AdvisorScheduleID" HeaderText="AdvisorScheduleID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="AdvisorScheduleID" />
                <asp:BoundField DataField="Advisor_ID" HeaderText="Advisor_ID" 
                    SortExpression="Advisor_ID" />
                <asp:BoundField DataField="Day" HeaderText="Day" 
                    SortExpression="Day" />
                <asp:BoundField DataField="StartTime" HeaderText="StartTime" 
                    SortExpression="StartTime" />
                <asp:BoundField DataField="EndTime" HeaderText="EndTime" 
                    SortExpression="EndTime" />
                <asp:BoundField DataField="Year" HeaderText="Year" 
                    SortExpression="Year" />
                <asp:BoundField DataField="Week" HeaderText="Week" SortExpression="Week" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource7" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AdvisorBookingConnectionString %>" 
            SelectCommand="SELECT * FROM [AdvisorSchedules]"></asp:SqlDataSource>
        <br />
    
    </div>
    </form>
</body>
</html>
