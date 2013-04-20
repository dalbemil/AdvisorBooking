<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctlCalendar.ascx.cs" Inherits="WebUserControl" %>
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {

        Session["AdvisorID"] = Request.QueryString["AdvisorID"];
        Util get = new Util(Convert.ToInt16(Request.QueryString["AdvisorID"]));
       // Session["StudentID"] = 822459053;
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {

    }
    
</script>
<div style="margin: 0 auto; text-align: center; width: 201px; height: 150px;">
    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black"
        Font-Names="Times New Roman" Font-Size="8pt" ForeColor="Black" Height="23px"
        NextPrevFormat="FullMonth" Width="201px" OnDayRender="Calendar1_DayRender" OnPreRender="Calendar1_SelectionChanged"
        OnSelectionChanged="cmd" DayNameFormat="Shortest" ShowNextPrevMonth="False" Style="margin: 0 auto;
        text-align: center;" OnInit="Page_Load">
        <DayHeaderStyle Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt"
            BackColor="#EEEEEE" />
        <DayStyle Width="14%" />
        <NextPrevStyle Font-Size="8pt" ForeColor="White" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#EEEEEE" ForeColor="White" />
        <SelectorStyle BackColor="#5D7B9D" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
            ForeColor="#333333" Width="1%" BorderColor="#CCCCCC" />
        <TitleStyle BackColor="#214183" Font-Bold="True" Font-Size="10pt" ForeColor="White"
            Height="11pt" />
        <TodayDayStyle BackColor="#FFFFCC" />
    </asp:Calendar>
</div>
