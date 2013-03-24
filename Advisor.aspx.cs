using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Unload += PageUnload;
       
        ronUtil2 get = new ronUtil2();
       
        //Dropdown list
        DropDownList1.DataSource = get.getStudentIds();
        if(!IsPostBack)
        DropDownList1.DataBind();



        


    

 


        //Tables
        //string[] days= get.DaysAvailable;
      string[] dates= get.getAdvisor2WeekSchedule();
      DateTime[] datesv2 = new DateTime[dates.Length];

      for (int i = 0; i < dates.Length; i++)
      { datesv2[i] = DateTime.Parse(dates[i]); }


        Label1.Text = datesv2[0].DayOfWeek.ToString();
        Label2.Text = datesv2[1].DayOfWeek.ToString();
        Label3.Text = datesv2[2].DayOfWeek.ToString();
        Label4.Text = datesv2[3].DayOfWeek.ToString();
        Label5.Text = datesv2[4].DayOfWeek.ToString();

        Label6.Text = datesv2[0].ToString("dd MMM yyyy");
        Label7.Text = datesv2[1].ToString("dd MMM yyyy");

        Label8.Text = datesv2[2].ToString("dd MMM yyyy");
        Label9.Text = datesv2[3].ToString("dd MMM yyyy");
        Label10.Text = datesv2[4].ToString("dd MMM yyyy");

        //Label1.Text = "1";
        //Label2.Text = "2";
        //Label3.Text = "3";
        //Label4.Text = "4";
        //Label5.Text = "5";
        //Label2.Text = get.bookingDays[1];
        //Label3.Text = get.bookingDays[2];
        //Label4.Text = get.bookingDays[3];
        //Label5.Text = get.bookingDays[4];

        int[] ID = get.getAdvisorIDs();

        //DateTime[] advisorAllSlots = get.getSlots(101, date[0]);
        //DateTime[] taken = get.getTaken(101, date[0]);
        //DateTime[] availibility = get.getAvailability(advisorAllSlots, taken);
        //HyperLink[] link2 = new HyperLink[availibility.Length];
      //  for (int i = 0; i < link2.Length; i++) { link2[i] = new HyperLink(); }

        for (int ii = 0; ii < ID.Length; ii++)
        {
            TableCell[] td = new TableCell[8];
            HyperLink link = new HyperLink();
            link.NavigateUrl = "~/Schedule.aspx?AdvisorID=" + ID[ii];
            for (int i = 0; i < 8; i++) { td[i] = new TableCell(); }

            link.Text = get.getName(ID[ii]) + "<br /> <img src='" + get.getAdvisorImage(ID[ii])+"' width='80' height='80' />";
            link.ForeColor=System.Drawing.Color.Black;
            link.Font.Underline = false;
            td[0].Controls.Add(link);            
            td[1].Text = get.getDepartment(ID[ii]).Replace("School of","");
            td[1].ForeColor = System.Drawing.Color.Black;

            for (int EachRow = 0; EachRow < 5; EachRow++)
            {
                for (int iii = 0; iii < 6; iii++)
                {
                    DateTime[] advisorAllSlots = get.getSlots(ID[ii], dates[EachRow]);
                    DateTime[] taken = get.getTaken(ID[ii], dates[EachRow]);
                    DateTime[] availibility = get.getAvailability(advisorAllSlots, taken);
                    HyperLink[] link2 = new HyperLink[availibility.Length];
                    if (availibility.Length == 0 || iii == availibility.Length)
                    { break; }

                    if (iii == 5)
                    {
                        link2[0] = new HyperLink();
                       // link2[0].NavigateUrl = "~/View2.aspx?AdvisorID=" + ID[ii] + "&bookingDate=" + dates[EachRow];
                        link2[0].NavigateUrl = "~/Confirm.aspx?AdvisorID=" + ID[ii] + "&bookingDate=" + datesv2[EachRow].ToString("MM/dd/yyyy") + "&bookingTime=" + availibility[0].ToShortTimeString();
                        link2[0].Text = "more";
                        link2[0].ForeColor = System.Drawing.Color.Black;
                        td[EachRow+2].Controls.Add(link2[0]);
                    }
                    else
                    {
                        for (int i = 0; i < link2.Length; i++) { link2[i] = new HyperLink(); }
                       // link2[iii].NavigateUrl = "~/View2.aspx?AdvisorID=" + ID[ii] + "&bookingDate=" + dates[EachRow];
//                        link2[iii].NavigateUrl = "~/Confirm.aspx?AdvisorID=" + ID[ii] + "&bookingDate=" + dates[EachRow] + "&bookingTime=" + availibility[0].ToShortTimeString();
                        link2[iii].NavigateUrl = "~/Confirm.aspx?AdvisorID=" + ID[ii] + "&bookingDate=" + datesv2[EachRow].ToString("MM/dd/yyyy") + "&bookingTime=" + availibility[iii].ToShortTimeString();

                        link2[iii].Text = availibility[iii].ToShortTimeString() + "<br />";
                        link2[iii].ForeColor = System.Drawing.Color.Black;                        
                        td[EachRow+2].Controls.Add(link2[iii]);
                    }
                }
            }

            //for (int iii = 0; iii < 6; iii++)
            //{
            //    DateTime[] advisorAllSlots = get.getSlots(ID[ii], dates[1]);
            //    DateTime[] taken = get.getTaken(ID[ii], dates[1]);
            //    DateTime[] availibility = get.getAvailability(advisorAllSlots, taken);
            //    HyperLink[] link2 = new HyperLink[availibility.Length];
            //    if (availibility.Length == 0 || iii==availibility.Length)
            //    { break; }

            //    if (iii == 5)
            //    {
            //        link2[0] = new HyperLink();
            //        link2[0].NavigateUrl = "~/Confirm.aspx?AdvisorID=" + ID[ii] + "&bookingDate=" + dates[1] + "&bookingTime=" + availibility[0].ToShortTimeString();
            //        link2[0].Text = "more";
            //        td[3].Controls.Add(link2[0]);
            //    }
            //    else
            //    {
            //        for (int i = 0; i < link2.Length; i++) { link2[i] = new HyperLink(); }
            //        link2[iii].NavigateUrl = "~/Confirm.aspx?AdvisorID=" + ID[ii] + "&bookingDate=" + dates[1] + "&bookingTime=" + availibility[iii].ToShortTimeString();
            //        link2[iii].Text = availibility[iii].ToShortTimeString() + "<br />";
            //        td[3].Controls.Add(link2[iii]);
            //    }
            //}


            //for (int iii = 0; iii < 6; iii++)
            //{
            //    DateTime[] advisorAllSlots = get.getSlots(ID[ii], dates[2]);
            //    DateTime[] taken = get.getTaken(ID[ii], dates[2]);
            //    DateTime[] availibility = get.getAvailability(advisorAllSlots, taken);
            //    HyperLink[] link2 = new HyperLink[availibility.Length];
            //    if (availibility.Length == 0 || iii == availibility.Length)
            //    { break; }

            //    if (iii == 5)
            //    {
            //        link2[0] = new HyperLink();
            //        link2[0].NavigateUrl = "~/Confirm.aspx?AdvisorID=" + ID[ii] + "&bookingDate=" + dates[2] + "&bookingTime=" + availibility[0].ToShortTimeString();
            //        link2[0].Text = "more";
            //        td[4].Controls.Add(link2[0]);
            //    }
            //    else
            //    {
            //        for (int i = 0; i < link2.Length; i++) { link2[i] = new HyperLink(); }
            //        link2[iii].NavigateUrl = "~/Confirm.aspx?AdvisorID=" + ID[ii] + "&bookingDate=" + dates[2] + "&bookingTime=" + availibility[iii].ToShortTimeString();
            //        link2[iii].Text = availibility[iii].ToShortTimeString() + "<br />";
            //        td[4].Controls.Add(link2[iii]);
            //    }
            //}


            //for (int iii = 0; iii < 6; iii++)
            //{
            //    DateTime[] advisorAllSlots = get.getSlots(ID[ii], dates[3]);
            //    DateTime[] taken = get.getTaken(ID[ii], dates[3]);
            //    DateTime[] availibility = get.getAvailability(advisorAllSlots, taken);
            //    HyperLink[] link2 = new HyperLink[availibility.Length];
            //    if (availibility.Length == 0 || iii == availibility.Length)
            //    { break; }


            //    if (iii == 5)
            //    {
            //        link2[0] = new HyperLink();
            //        link2[0].NavigateUrl = "~/Confirm.aspx?AdvisorID=" + ID[ii] + "&bookingDate=" + dates[3] + "&bookingTime=" + availibility[0].ToShortTimeString();
            //        link2[0].Text = "more";
            //        td[5].Controls.Add(link2[0]);
            //    }
            //    else
            //    {
            //        for (int i = 0; i < link2.Length; i++) { link2[i] = new HyperLink(); }
            //        link2[iii].NavigateUrl = "~/Confirm.aspx?AdvisorID=" + ID[ii] + "&bookingDate=" + dates[3] + "&bookingTime=" + availibility[iii].ToShortTimeString();
            //        link2[iii].Text = availibility[iii].ToShortTimeString() + "<br />";
            //        td[5].Controls.Add(link2[iii]);
            //    }
            //}



            //for (int iii = 0; iii < 6; iii++)
            //{
            //    DateTime[] advisorAllSlots = get.getSlots(ID[ii], dates[4]);
            //    DateTime[] taken = get.getTaken(ID[ii], dates[4]);
            //    DateTime[] availibility = get.getAvailability(advisorAllSlots, taken);
            //    HyperLink[] link2 = new HyperLink[availibility.Length];
            //    if (availibility.Length == 0 || iii == availibility.Length)
            //    { break; }


            //    if (iii == 5)
            //    {
            //        link2[0] = new HyperLink();
            //        link2[0].NavigateUrl = "~/Confirm.aspx?AdvisorID=" + ID[ii] + "&bookingDate=" + dates[4] + "&bookingTime=" + availibility[0].ToShortTimeString();
            //        link2[0].Text = "more";
            //        td[6].Controls.Add(link2[0]);
            //    }
            //    else
            //    {
            //        for (int i = 0; i < link2.Length; i++) { link2[i] = new HyperLink(); }
            //        link2[iii].NavigateUrl = "~/Confirm.aspx?AdvisorID=" + ID[ii] + "&bookingDate=" + dates[4] + "&bookingTime=" + availibility[iii].ToShortTimeString();
            //        link2[iii].Text = availibility[iii].ToShortTimeString() + "<br />";
            //        td[6].Controls.Add(link2[iii]);
            //    }
            //}
            
       //    td[3].Text = get.getTuesday(ID[ii]);
       //     td[4].Text = get.getWednesday(ID[ii]);
          //  td[5].Text = get.getThursday(ID[ii]);
          //  td[6].Text = get.getFriday(ID[ii]);
            td[0].Width = 200;
            td[1].Width = 60;
            td[2].Width = 60;
            td[3].Width = 60;
            td[4].Width = 60;
            td[5].Width = 60;
            td[6].Width = 60;

            td[2].HorizontalAlign = HorizontalAlign.Center;
            td[3].HorizontalAlign = HorizontalAlign.Center;
            td[4].HorizontalAlign = HorizontalAlign.Center;
            td[5].HorizontalAlign = HorizontalAlign.Center;
            td[6].HorizontalAlign = HorizontalAlign.Center;

            td[0].BackColor = System.Drawing.Color.White;
            td[1].BackColor = System.Drawing.Color.WhiteSmoke;
            td[2].BackColor = System.Drawing.Color.White;
            td[3].BackColor = System.Drawing.Color.WhiteSmoke;
            td[4].BackColor = System.Drawing.Color.White;
            td[5].BackColor = System.Drawing.Color.WhiteSmoke;
            td[6].BackColor = System.Drawing.Color.White;


            td[0].Height = 150;
            TableRow tRow = new TableRow();
            tRow.VerticalAlign = VerticalAlign.Top;
            myTable.Rows.Add(tRow);
            tRow.Cells.AddRange(td);
        }
    
        
    }



    protected void erow_c(object sender, GridViewRowEventArgs e)
    {
  
    }
    protected void PageUnload(object sender, EventArgs e)
    {


            Session["StudentID"] = DropDownList1.SelectedValue;
    }
}
