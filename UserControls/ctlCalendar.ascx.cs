using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUserControl : System.Web.UI.UserControl
{


    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
      
    }

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {



        int id = Convert.ToInt16(Request.QueryString["AdvisorID"]);
        ronUtil2 get = new ronUtil2(id);
        int length = get.DaysAvailable.Length;
        DayOfWeek[] days = new DayOfWeek[length];

        for (int i = 0; i < length; i++)
        {
            days[i] = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), get.DaysAvailable[i]);
        }

        e.Day.IsSelectable = false;
        e.Cell.ForeColor = System.Drawing.Color.Gray;
        DateTime stratDate = DateTime.Today;
        DateTime endDate = stratDate.AddDays(8);


        if (e.Day.Date > stratDate && e.Day.Date < endDate)
        {


            if (e.Day.IsWeekend)
            {
                e.Day.IsSelectable = false;

            }
            else
            {
                e.Day.IsSelectable = true;
                //   e.Cell.ForeColor = System.Drawing.Color.Black;
                e.Cell.Font.Strikeout = false;
                e.Cell.ForeColor = System.Drawing.Color.OrangeRed;
                e.Cell.Font.Size = 9;

                if (length == 1)
                {
                    if (e.Day.Date.DayOfWeek != days[0])
                    {
                        e.Day.IsSelectable = false;
                        e.Cell.ForeColor = System.Drawing.Color.Gray;
                        e.Cell.Font.Size = 8;
                    }
                }



                if (length == 2)
                {
                    if (e.Day.Date.DayOfWeek != days[0] && e.Day.Date.DayOfWeek != days[1])
                    {
                        e.Day.IsSelectable = false;
                        e.Cell.ForeColor = System.Drawing.Color.Gray;
                        e.Cell.Font.Size = 8;
                    }
                }



                if (length == 3)
                {
                    if (e.Day.Date.DayOfWeek != days[0] && e.Day.Date.DayOfWeek != days[1] && e.Day.Date.DayOfWeek != days[2])
                    {
                        e.Day.IsSelectable = false;
                        e.Cell.ForeColor = System.Drawing.Color.Gray;
                        e.Cell.Font.Size = 8;
                    }
                }


                if (length == 4)
                {
                    if (e.Day.Date.DayOfWeek != days[0] && e.Day.Date.DayOfWeek != days[1] && e.Day.Date.DayOfWeek != days[2] && e.Day.Date.DayOfWeek != days[3])
                    {
                        e.Day.IsSelectable = false;
                        e.Cell.ForeColor = System.Drawing.Color.Gray;
                        e.Cell.Font.Size = 8;
                    }
                }


                if (length == 5)
                {
                    if (e.Day.Date.DayOfWeek != days[0] && e.Day.Date.DayOfWeek != days[1] && e.Day.Date.DayOfWeek != days[2] && e.Day.Date.DayOfWeek != days[3] && e.Day.Date.DayOfWeek != days[4])
                    {
                        e.Day.IsSelectable = false;
                        e.Cell.ForeColor = System.Drawing.Color.Gray;
                        e.Cell.Font.Size = 8;
                    }
                }




            }
        }

    }











    protected void cmd(object sender, EventArgs e)
    {

        Session["date"] = Calendar1.SelectedDate.ToString("MM/dd/yyyy");
        if (Calendar1.SelectedDate.Date < DateTime.Now)
        { Server.Transfer("Schedule.aspx"); }
        else
        {
            Server.Transfer("Confirm.aspx");
        }

    }
    protected void Calendar1_DayRender(object sender, EventArgs e)
    {

    }

}