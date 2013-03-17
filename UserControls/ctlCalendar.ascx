<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctlCalendar.ascx.cs" Inherits="WebUserControl" %>


<script runat=server>
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.QueryString["ID"] == null)
        //{
        //    Server.Transfer("Advisor.aspx");
        //}
        Session["AdvisorID"] = Request.QueryString["AdvisorID"];
        ronUtil2 get = new ronUtil2(Convert.ToInt16(Request.QueryString["AdvisorID"]));
    //    DateTime listofDates= get.getAdvisor2WeekSchedule();
       //Label1.Text = "Advisor:" + get.FullName ;
     //   string[] dates = get.getAdvisor2WeekSchedule(Convert.ToInt16(Request.QueryString["AdvisorID"]));
    //    Calendar1.SelectedDate = DateTime.Parse(dates[dates.Length-2]);
        Session["Student"] = 822459053;

        

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
            
    }
    
    </script>

    
  

      <div style="margin:0 auto; text-align:center; Width:201px; height: 150px;">
  <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
            BorderColor="Black" Font-Names="Times New Roman" 
            Font-Size="8pt" ForeColor="Black" Height="23px" NextPrevFormat="FullMonth" 
            Width="201px" ondayrender="Calendar1_DayRender" onprerender="Calendar1_SelectionChanged" 
            onselectionchanged="cmd" DayNameFormat="Shortest" 
              ShowNextPrevMonth="False" style="margin:0 auto; text-align:center;">
            <DayHeaderStyle Font-Bold="True" Font-Size="7pt" ForeColor="#333333" 
                Height="10pt" BackColor="#EEEEEE" />
            <DayStyle Width="14%" />
            <NextPrevStyle Font-Size="8pt" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#EEEEEE" ForeColor="White" />
            <SelectorStyle BackColor="#5D7B9D" Font-Bold="True" Font-Names="Verdana" 
                Font-Size="8pt" ForeColor="#333333" Width="1%" BorderColor="#CCCCCC" />
            <TitleStyle BackColor="#214183" Font-Bold="True" 
                Font-Size="10pt" ForeColor="White" Height="11pt" />
            <TodayDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>

    

    
           </div>
      