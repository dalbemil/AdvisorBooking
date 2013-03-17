<%@ Page Title="" Language="C#" MasterPageFile="~/AdvisorBookingServiceMasterPage.master" AutoEventWireup="true" CodeFile="Schedule.aspx.cs" Inherits="Default3" %>


<script runat=server>
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
        ronUtil2 get = new ronUtil2(Convert.ToInt32(Request.QueryString["AdvisorID"]));
        if (!get.getCheck(Session["StudentID"].ToString())) { Server.Transfer("CancelAppointment.aspx"); }
        string[] dates = get.getAdvisor2WeekSchedule(Convert.ToInt32(Request.QueryString["AdvisorID"]));
        Calendar1.SelectedDate = DateTime.Parse(dates[dates.Length - 2]);
        lblAdvisorName.Text = get.FullName;              
    }
    
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        Session["date"] = Calendar1.SelectedDate.ToString("MM/dd/yyyy"); 
    }
    
    </script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
   <% Session["AdvisorID"] = Request.QueryString["AdvisorID"]; %>
    
        <div class="post" id="post-5">
    <div class="post-title">
            <center>
                <h2>
                    <asp:Label ID="lblAdvisorName" runat="server" Text="Advisor Name"></asp:Label>  </h2>
            </center>
        </div>
        <div class="post-entry">
            <div class="post-entry-top">
                <div class="post-entry-bottom">
  

      <div style="margin:0 auto; text-align:center; Width:201px">
      Choose a date for your appointment
    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
            BorderColor="Black" Font-Names="Times New Roman" 
            Font-Size="8pt" ForeColor="Black" Height="23px" NextPrevFormat="FullMonth" 
            Width="201px" ondayrender="Calendar1_DayRender" onprerender="Calendar1_SelectionChanged" 
            onselectionchanged="Calendar1_SelectionChanged" DayNameFormat="Shortest" 
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
      <div style="margin:0 auto; text-align:left; Width:196px">
          <asp:Button  ID="Button2" runat="server" Text="Continue" CausesValidation="false" OnClick="cmd" Width="81px" />
             
             




   

    
           </div>
           <br />

    </div></div></div></div>
    </form>

</asp:Content>

