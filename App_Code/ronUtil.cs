using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//added
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
/// <summary>
/// Summary description for ronUtil
/// </summary>
public class ronUtil
{


    public string[] DaysAvailable { get; set; }
    public string DayStart { get; set; }
    public string DayFinish { get; set; }
    public string StartDate { get; set; }
    public string FinishDate { get; set; }
    public string FullName { get; set; }
    public ronUtil()
    { }


    public ronUtil(int id)
    {
       
        DaysAvailable = getDaysAvailable(id);

        SqlDataSource SqlDataSource2 = new SqlDataSource();
        SqlDataSource2.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();

        SqlDataSource2.SelectCommand = "Select * From AdvisorSchedule Where Advisor_Id='" + id.ToString() + "'";
        DataView view = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();
    

        DayStart = table.Rows[0][2].ToString();
        DayFinish = table.Rows[0][3].ToString();
        StartDate = table.Rows[0][4].ToString();
        FinishDate = table.Rows[0][5].ToString();
        SqlDataSource SqlDataSource3 = new SqlDataSource();
        SqlDataSource3.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        SqlDataSource3.SelectCommand = "Select * From Advisor_Master Where Advisor_Id='" + id.ToString() + "'";


        DataView view3 = (DataView)SqlDataSource3.Select(DataSourceSelectArguments.Empty);
        DataTable table3 = view3.ToTable();
        

        FullName = table3.Rows[0][1].ToString() + " " + table3.Rows[0][2].ToString();
        

    }
    public DateTime[] getAvailability(DateTime[] advisorAllSlots, DateTime[] taken)
    {


        int length = advisorAllSlots.Length - taken.Length;
        DateTime[] slots = advisorAllSlots; 
        DateTime[] available = new DateTime[length];
        
        int counter = 0; int counter1 = 0;
        if (taken.Length == 0)
        { available = advisorAllSlots; }
        else
        {
            for (int i = 0; i < advisorAllSlots.Length; i++)
            {

                for (int ii = 0; ii < taken.Length; ii++)
                {
                    if (advisorAllSlots[i].ToShortTimeString() == taken[ii].ToShortTimeString() )
                    {
                        slots[i] = DateTime.Now; 
                        
                    }

                }
            }

            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i] != DateTime.Now)
                { available[counter1] = slots[i]; counter1++; }
            }


        }
        return available;


                    
        
    }




    public DateTime[] getSlots(int advisor_Id, string date)
    { //inttime = total available time slots as int
        //doubletime = total available time slots as double
        SqlDataSource SqlDataSource = new SqlDataSource();
        SqlDataSource.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        SqlDataSource.SelectCommand = "Select DayStart,DayFinish From AdvisorSchedule Where Advisor_Id='" + advisor_Id + "'";

        DataView view = (DataView)SqlDataSource.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();


        DateTime start = DateTime.Parse(table.Rows[0][0].ToString());
        DateTime end = DateTime.Parse(table.Rows[0][1].ToString());
        double dbltime = ((end - start).TotalHours) * 2;
        
        int inttime = Convert.ToInt32(dbltime);

        DateTime[] advisorSlots = new DateTime[inttime];

        for (int i = 0; i < inttime; i++)
        {
              
            advisorSlots[i] = start;
            start = start.AddMinutes(30);
        }

        return advisorSlots;
    }


    public DateTime[] getTaken(int advisor_Id, string date)
    {
        SqlDataSource SqlDataSource3 = new SqlDataSource();
        SqlDataSource3.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        SqlDataSource3.SelectCommand = "Select Time From Scheduling  Where Advisor_Id='" + advisor_Id + "' AND Date='" + date + "'";

        DataView view = (DataView)SqlDataSource3.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();
        
        //   string[] slotsTaken = new string[table.Rows.Count];

        DateTime[] slotsTaken = new DateTime[table.Rows.Count];

            for (int ii = 0; ii < table.Rows.Count; ii++)
            { slotsTaken[ii] = DateTime.Parse(table.Rows[ii][0].ToString()); }

        

        //  Label1.Text = slotsTaken[0].ToShortTimeString();
        return slotsTaken;
    }



    //-------------------------------------Get Advisors By Date -----------------------------------------------------------
    public string[] getAdvisorNames(DateTime date)
    {


        SqlDataSource SqlDataSource2 = new SqlDataSource();
        SqlDataSource2.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();

        SqlDataSource2.SelectCommand = "Select Dept_Name,(Last_Name+', ' + First_Name) As Advisors From AdvisorSchedule,Advisor_Master,Department_Master Where AdvisorSchedule.Advisor_Id=Advisor_Master.Advisor_Id AND Advisor_Master.Dept_Id=Department_Master.Dept_Id AND StartDate < '" + date.ToShortDateString() + "' AND FinishDate > '" + date.ToShortDateString() + "' AND DaysAvailable Like '%" + date.DayOfWeek.ToString() + "%'";
        DataView view = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

        string[] advisorNames = new string[table.Rows.Count];
        for (int i = 0; i < table.Rows.Count; i++)
        {
            advisorNames[i] = table.Rows[i][0].ToString();
        }

        return advisorNames;
        //Label1.Text = Session["date"].ToString();
    }

    public int[] getAdvisorId(DateTime date)
    {

        string container;
        SqlDataSource SqlDataSource2 = new SqlDataSource();
        SqlDataSource2.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();

        SqlDataSource2.SelectCommand = "Select AdvisorSchedule.Advisor_Id From AdvisorSchedule,Advisor_Master Where AdvisorSchedule.Advisor_Id=Advisor_Master.Advisor_Id AND StartDate < '" + date.ToShortDateString() + "' AND FinishDate > '" + date.ToShortDateString() + "' AND DaysAvailable Like '%" + date.DayOfWeek.ToString() + "%'";
        DataView view = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

        int[] advisorId = new int[table.Rows.Count];
        for (int i = 0; i < table.Rows.Count; i++)
        {
            container = table.Rows[i][0].ToString();
            advisorId[i] = Convert.ToInt16(container);
        }

        return advisorId;
        //Label1.Text = Session["date"].ToString();
    }


    //-------------------------------------Get Advisors 2 Wees Schedule By ID AND NOW--------------------------------------------------------

    public string[] getAdvisor2WeekSchedule(int id)
    {
        DateTime now = DateTime.Today;
        DateTime last = now.AddDays(8);
        DateTime[] allDays = new DateTime[8];

        for (int i = 0; i < allDays.Length; i++)
        {
            allDays[i] = now.AddDays(i);
        }


        ronUtil get = new ronUtil(id);

        string date = null;
        for (int i = 0; i < allDays.Length; i++)
        {
            for (int ii = 0; ii < get.DaysAvailable.Length; ii++)
            {
                if (allDays[i].DayOfWeek.ToString() == get.DaysAvailable[ii])
                {

                    date = allDays[i].ToShortDateString() + "," + date;
                }
            }
        }

        Char[] splitChars = new Char[] { ',' };
        string[] splitdate = date.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
        return splitdate;
    }




    //----------------------------------------Basics-----------------------------


    public string[] getDaysAvailable(int id)
    {
        SqlDataSource SqlDataSource2 = new SqlDataSource();
        SqlDataSource2.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();

        SqlDataSource2.SelectCommand = "Select DaysAvailable From AdvisorSchedule Where Advisor_Id='" + id + "'";
        DataView view = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

      

            string days = table.Rows[0][0].ToString();
            string[] splitDays = days.Split(',');
            return splitDays;
     

        return splitDays;

    }



    public bool getCheck(string stID)
    {
        int Student_Id = Convert.ToInt32(stID);
        DateTime date = DateTime.Now;
        SqlDataSource SqlDataSource3 = new SqlDataSource();
        SqlDataSource3.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        SqlDataSource3.SelectCommand = "Select Time From Scheduling  Where Student_Id='" + Student_Id + "' AND Date>'" + date + "'";

        DataView view = (DataView)SqlDataSource3.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

        //   string[] slotsTaken = new string[table.Rows.Count];
        bool check=false;
        if (table.Rows.Count==0)
        {check=true;}
        
        return check;
    }



    public DataTable loadAdvisorsToGrid()
    {
        DateTime date = new DateTime();
        date = DateTime.Now;
        SqlDataSource SqlDataSource2 = new SqlDataSource();
        SqlDataSource2.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        SqlDataSource2.SelectCommand = "Select (Last_Name+', ' + First_Name) As Advisors,Dept_Name As Department,DaysAvailable As Avalability, (CONVERT(varchar, DayStart, 100)+ '-'+CONVERT(varchar, DayFinish, 100)) As Time, Advisor_Master.Advisor_Id As ID From AdvisorSchedule,Advisor_Master,Department_Master Where AdvisorSchedule.Advisor_Id=Advisor_Master.Advisor_Id AND Advisor_Master.Dept_Id=Department_Master.Dept_Id AND StartDate < '" + date.ToShortDateString() + "' AND FinishDate > '" + date.ToShortDateString() + "'";
        DataView view = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();
        return table;
    }
}