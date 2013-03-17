<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 237px">
    
        <br />
        Appointment Table<asp:GridView ID="GridView1" runat="server" 
            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Appointment_ID" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Appointment_ID" HeaderText="Appointment_ID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="Appointment_ID" />
                <asp:BoundField DataField="Availability_ID" HeaderText="Availability_ID" 
                    SortExpression="Availability_ID" />
                <asp:BoundField DataField="Student_Id" HeaderText="Student_Id" 
                    SortExpression="Student_Id" />
                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time" />
                <asp:BoundField DataField="Comment" HeaderText="Comment" 
                    SortExpression="Comment" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
            SelectCommand="SELECT * FROM [Appointment]"></asp:SqlDataSource>
        <br />
        <br />
        <br />
        Availability Table<asp:GridView ID="GridView2" runat="server" 
            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Availability_ID" 
            DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Availability_ID" HeaderText="Availability_ID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="Availability_ID" />
                <asp:BoundField DataField="Employee_Id" HeaderText="Employee_Id" 
                    SortExpression="Employee_Id" />
                <asp:BoundField DataField="Date_Start" HeaderText="Date_Start" 
                    SortExpression="Date_Start" />
                <asp:BoundField DataField="Date_End" HeaderText="Date_End" 
                    SortExpression="Date_End" />
                <asp:BoundField DataField="Time_Start" HeaderText="Time_Start" 
                    SortExpression="Time_Start" />
                <asp:BoundField DataField="Time_End" HeaderText="Time_End" 
                    SortExpression="Time_End" />
                <asp:BoundField DataField="DayAvailable" HeaderText="DayAvailable" 
                    SortExpression="DayAvailable" />
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
            SelectCommand="SELECT * FROM [Availability]"></asp:SqlDataSource>
    
    </div>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        Employee Table</p>
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="Employee_ID" DataSourceID="SqlDataSource3" 
        ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="Employee_ID" HeaderText="Employee_ID" 
                ReadOnly="True" SortExpression="Employee_ID" />
            <asp:BoundField DataField="First_Name" HeaderText="First_Name" 
                SortExpression="First_Name" />
            <asp:BoundField DataField="Last_Name" HeaderText="Last_Name" 
                SortExpression="Last_Name" />
            <asp:BoundField DataField="Dept_id" HeaderText="Dept_id" 
                SortExpression="Dept_id" />
            <asp:BoundField DataField="Image" HeaderText="Image" SortExpression="Image" />
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
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        SelectCommand="SELECT * FROM [Advisor]"></asp:SqlDataSource>
    <br />
    Student Table<br />
    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="Student_ID" DataSourceID="SqlDataSource4" 
        ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="Student_ID" HeaderText="Student_ID" ReadOnly="True" 
                SortExpression="Student_ID" />
            <asp:BoundField DataField="First_Name" HeaderText="First_Name" 
                SortExpression="First_Name" />
            <asp:BoundField DataField="Last_Name" HeaderText="Last_Name" 
                SortExpression="Last_Name" />
            <asp:BoundField DataField="Program_id" HeaderText="Program_id" 
                SortExpression="Program_id" />
            <asp:BoundField DataField="Cur_Sem" HeaderText="Cur_Sem" 
                SortExpression="Cur_Sem" />
            <asp:BoundField DataField="Image" HeaderText="Image" SortExpression="Image" />
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
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        SelectCommand="SELECT * FROM [Student]"></asp:SqlDataSource>
    <br />
    Cancel<br />
    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataSourceID="SqlDataSource5" ForeColor="#333333" 
        GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="Appointment_ID" HeaderText="Appointment_ID" 
                SortExpression="Appointment_ID" />
            <asp:BoundField DataField="Availability_ID" HeaderText="Availability_ID" 
                SortExpression="Availability_ID" />
            <asp:BoundField DataField="Student_Id" HeaderText="Student_Id" 
                SortExpression="Student_Id" />
            <asp:BoundField DataField="Comment" HeaderText="Comment" 
                SortExpression="Comment" />
            <asp:BoundField DataField="cancel_request" HeaderText="cancel_request" 
                SortExpression="cancel_request" />
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
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        SelectCommand="SELECT * FROM [cancel]"></asp:SqlDataSource>
    <br />
    Department<br />
    <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="Dept_Id" DataSourceID="SqlDataSource6" 
        ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="Dept_Id" HeaderText="Dept_Id" ReadOnly="True" 
                SortExpression="Dept_Id" />
            <asp:BoundField DataField="Dept_Name" HeaderText="Dept_Name" 
                SortExpression="Dept_Name" />
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
    <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        SelectCommand="SELECT * FROM [Department]"></asp:SqlDataSource>
    <br />
    
        <br />
        Advisor Schedules<asp:GridView ID="GridView7" runat="server" 
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
    </form>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</body>
</html>
