using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//added
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data.SqlClient;
using System.Globalization;
/// <summary>
/// Summary description for Util
/// </summary>
public class Util
{


    public string[] DaysAvailable { get; set; }
    public string FullName { get; set; }
    public string[] bookingDays { get; set; }
    public string[] bookingDates { get; set; }
    public string First_Name { get; set; }
    public string Last_Name { get; set; }
    public string Employee_ID { get; set; }
    public string Image  { get; set; }
    public string Dept_id { get; set; }

    public Util()
    {
     
    }

    public Util(int id)
    {
        DaysAvailable = getDaysAvailable(id);

        SqlDataSource SqlDataSource3 = new SqlDataSource();
        SqlDataSource3.ConnectionString = ConfigurationManager.ConnectionStrings["AdvisorBookingConnectionString"].ToString();
        SqlDataSource3.SelectCommand = "Select First_Name,Last_Name,Advisor_ID,Dept_id,Image From Advisors Where Advisor_ID='" + id.ToString() + "'";


        DataView view3 = (DataView)SqlDataSource3.Select(DataSourceSelectArguments.Empty);
        DataTable table3 = view3.ToTable();

        if (table3.Rows.Count > 0)
            FullName = table3.Rows[0][0].ToString() + " " + table3.Rows[0][1].ToString();
        First_Name = table3.Rows[0][0].ToString();
        Last_Name = table3.Rows[0][1].ToString();
        Employee_ID = table3.Rows[0][2].ToString();
        Dept_id = table3.Rows[0][2].ToString();
        Image = table3.Rows[0][3].ToString();

    }


    public int[] getAdvisorIDs()
    {

        SqlDataSource SqlDataSource3 = new SqlDataSource();
        SqlDataSource3.ConnectionString = ConfigurationManager.ConnectionStrings["AdvisorBookingConnectionString"].ToString();
        SqlDataSource3.SelectCommand = "Select Distinct(Advisor_ID) From AdvisorSchedules";

        DataView view = (DataView)SqlDataSource3.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

        //   string[] slotsTaken = new string[table.Rows.Count];

        int[] Employee_ID = new int[table.Rows.Count];

        for (int ii = 0; ii < table.Rows.Count; ii++)
        { Employee_ID[ii] = Convert.ToInt32(table.Rows[ii][0].ToString()); }
        return Employee_ID;
    }

    public string getAdvisorImage(int advisor_Id)
    {
        SqlDataSource SqlDataSource3 = new SqlDataSource();
        SqlDataSource3.ConnectionString = ConfigurationManager.ConnectionStrings["AdvisorBookingConnectionString"].ToString();
        SqlDataSource3.SelectCommand = "Select Image From Advisors Where Advisor_ID='" + advisor_Id + "'";


        DataView view = (DataView)SqlDataSource3.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

        //   string[] slotsTaken = new string[table.Rows.Count];


        string Employee_Image = "";
        if (table.Rows.Count > 0)
            Employee_Image = table.Rows[0][0].ToString();
        return Employee_Image;
    }

    public string getName(int advisor_Id)
    {
        string advisorNames = "-";
        SqlDataSource SqlDataSource2 = new SqlDataSource();
        SqlDataSource2.ConnectionString = ConfigurationManager.ConnectionStrings["AdvisorBookingConnectionString"].ToString();

        SqlDataSource2.SelectCommand = "Select (Last_Name+', ' + First_Name) As Name From Advisors Where Advisor_ID='" + advisor_Id + "'";
        DataView view = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

        if (table.Rows.Count > 0)
        { advisorNames = table.Rows[0][0].ToString(); }
        return advisorNames;
    }
    public string getDepartment(int advisor_Id)
    {
        string department = "-";
        SqlDataSource SqlDataSource2 = new SqlDataSource();
        SqlDataSource2.ConnectionString = ConfigurationManager.ConnectionStrings["AdvisorBookingConnectionString"].ToString();
        SqlDataSource2.SelectCommand = "Select Dept_Name  From Advisors,Departments Where Advisors.Dept_Id=Departments.Dept_Id AND Advisor_ID='" + advisor_Id + "'";


        DataView view = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

        if (table.Rows.Count > 0)
        { department = table.Rows[0][0].ToString(); }

        return department;
    }
    //    public string getMonday(int advisor_Id)
    //    public string getTuesday(int advisor_Id)
    //    public string getWednesday(int advisor_Id)
    //    public string getThursday(int advisor_Id)
    //    public string getFriday(int advisor_Id)
    public DateTime[] getSlots(int advisor_Id, string date)
    {

        DateTime advisorDateDateTime = DateTime.Parse(date);
        int week = GetWeekNumber(advisorDateDateTime); string day = advisorDateDateTime.DayOfWeek.ToString();
        SqlDataSource SqlDataSource = new SqlDataSource();
        SqlDataSource.ConnectionString = ConfigurationManager.ConnectionStrings["AdvisorBookingConnectionString"].ToString();
        SqlDataSource.SelectCommand = "Select StartTime,EndTime,AdvisorScheduleID From AdvisorSchedules Where  Advisor_ID='" + advisor_Id + "' AND Day='" + day + "' And Week='" + week + "'";
        DataView view = (DataView)SqlDataSource.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

        DateTime[][] Slots = new DateTime[table.Rows.Count + 1][];

        int[][] advisorSlotsAvailabilityID = new int[table.Rows.Count + 1][];


        if (table.Rows.Count > 0)
        {
            for (int ii = 0; ii < table.Rows.Count; ii++)
            {
                DateTime start = DateTime.ParseExact(table.Rows[ii][0].ToString(), "HH:mm:ss", null);
                DateTime end = DateTime.Parse(table.Rows[ii][1].ToString());

                double dbltime = ((end - start).TotalHours) * 2;
                int inttime = Convert.ToInt32(dbltime);

                DateTime[] advisorSlots = new DateTime[inttime];
                int[] SlotsScheduleID = new int[inttime];

                for (int i = 0; i < inttime; i++)
                {

                    advisorSlots[i] = start;
                    start = start.AddMinutes(30);
                    SlotsScheduleID[i] = Convert.ToInt32(table.Rows[ii][2].ToString());


                }

                Slots[ii] = advisorSlots;
                advisorSlotsAvailabilityID[ii] = SlotsScheduleID;

            }
        }
        Slots[table.Rows.Count] = new DateTime[0];
        Slots[table.Rows.Count] = Slots[0];
        advisorSlotsAvailabilityID[table.Rows.Count] = advisorSlotsAvailabilityID[0];

        for (int i = 1; i < table.Rows.Count; i++)
        {
            if (table.Rows.Count > i)
            {
                Slots[table.Rows.Count] = Slots[table.Rows.Count].Concat(Slots[i]).ToArray();
                advisorSlotsAvailabilityID[table.Rows.Count] = advisorSlotsAvailabilityID[table.Rows.Count].Concat(advisorSlotsAvailabilityID[i]).ToArray();
            }
        }


        AllSlotsID = advisorSlotsAvailabilityID[table.Rows.Count];
        AllSlots = Slots[table.Rows.Count];
        Array.Sort(Slots[table.Rows.Count]);

        return Slots[table.Rows.Count];
    }


    public DateTime[] getTaken(int advisor_Id, string date)
    {
        DateTime advisorDateDateTime = DateTime.Parse(date);
        int week = GetWeekNumber(advisorDateDateTime); string day = advisorDateDateTime.DayOfWeek.ToString();

        //---------------------------------------
        SqlDataSource SqlDataSource2 = new SqlDataSource();
        SqlDataSource2.ConnectionString = ConfigurationManager.ConnectionStrings["AdvisorBookingConnectionString"].ToString();
        SqlDataSource2.SelectCommand = "Select Appointments.Time_Start From Appointments,AdvisorSchedules  Where Appointments.AdvisorScheduleID=AdvisorSchedules.AdvisorScheduleID AND Advisor_ID='" + advisor_Id + "'  AND Day='" + day + "' And Week='" + week + "'";


        DataView view2 = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        DataTable table2 = view2.ToTable();


        DateTime[] slotsTaken = new DateTime[table2.Rows.Count];


        for (int ii = 0; ii < table2.Rows.Count; ii++)
        { slotsTaken[ii] = DateTime.Parse(table2.Rows[ii][0].ToString()); }


        Array.Sort(slotsTaken);
        return slotsTaken;
    }



    public DateTime[] getAvailability(DateTime[] advisorAllSlots, DateTime[] taken)
    {
        int length = advisorAllSlots.Length - taken.Length;
        DateTime[] slots = advisorAllSlots;
        DateTime[] available = new DateTime[length];

        int counter = 0;
        if (taken.Length == 0)
        { available = advisorAllSlots; }
        else
        {
            for (int i = 0; i < advisorAllSlots.Length; i++)
            {

                for (int ii = 0; ii < taken.Length; ii++)
                {
                    if (advisorAllSlots[i].ToShortTimeString() == taken[ii].ToShortTimeString())
                    {
                        slots[i] = DateTime.Now.AddYears(-10);

                    }

                }
            }

            for (int i = 0; i < slots.Length; i++)
            {
                try
                {
                    if (slots[i] != DateTime.Now.AddYears(-10))
                    { available[counter] = slots[i]; counter++; }
                }
                catch { }
            }


        }

        Array.Sort(available);
        return available;
    }



    public string[] getDaysAvailable(int id)
    {
        string[] dates = getAdvisor2WeekSchedule();
        string DaysAvailable2 = "";
        for (int i = 0; i < 5; i++)
        {
            DateTime[] advisorAllSlots = getSlots(id, dates[i]);
            DateTime[] taken = getTaken(id, dates[i]);
            DateTime[] availibility = getAvailability(advisorAllSlots, taken);
            if (availibility.Length > 0)
            { DaysAvailable2 = DaysAvailable2 + "," + DateTime.Parse(dates[i]).DayOfWeek.ToString(); }
        }

        Char[] splitChars = new Char[] { ',' };
        string[] splitdate = DaysAvailable2.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
        return splitdate;

    }

    //public int getAvailableID(int advisor_Id, string date)
    public int getAvailableID(string time)
    {
        int AvailabilityID = 0;
        for (int i = 0; i < AllSlots.Length; i++)
        {
            if (AllSlots[i].ToShortTimeString() == time)
                AvailabilityID = AllSlotsID[i];
        }
        return AvailabilityID;
    }

    public bool getCheck(string stID)
    {
        int Student_Id = Convert.ToInt32(stID);
        DateTime date = DateTime.Now;
        SqlDataSource SqlDataSource3 = new SqlDataSource();
        SqlDataSource3.ConnectionString = ConfigurationManager.ConnectionStrings["AdvisorBookingConnectionString"].ToString();
        SqlDataSource3.SelectCommand = "Select Time_Start From Appointments  Where Student_Id='" + Student_Id + "' AND Date>'" + date + "'";

        DataView view = (DataView)SqlDataSource3.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

        //   string[] slotsTaken = new string[table.Rows.Count];
        bool check = false;
        if (table.Rows.Count == 0)
        { check = true; }

        return check;
    }


    public string[] getAdvisor2WeekSchedule()
    {

        string[] DaysAvailable2 = new string[5];
        DaysAvailable2[0] = "Monday";
        DaysAvailable2[1] = "Tuesday";
        DaysAvailable2[2] = "Wednesday";
        DaysAvailable2[3] = "Thursday";
        DaysAvailable2[4] = "Friday";




        DateTime now = DateTime.Today.AddDays(1);
        DateTime last = now.AddDays(7);
        DateTime[] allDays = new DateTime[7];

        for (int i = 0; i < allDays.Length; i++)
        {
            allDays[i] = now.AddDays(i);
        }


        string date = null;
        for (int i = 0; i < allDays.Length; i++)
        {
            for (int ii = 0; ii < DaysAvailable2.Length; ii++)
            {
                if (allDays[i].DayOfWeek.ToString() == DaysAvailable2[ii])
                {

                    date = allDays[i].ToShortDateString() + "," + date;
                }
            }
        }


        Char[] splitChars = new Char[] { ',' };
        string[] splitdate = date.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
        Array.Sort(splitdate);
        return splitdate;
    }



    public string[] getAdvisor2WeekSchedule(int id)
    {
        DateTime now = DateTime.Today;
        DateTime last = now.AddDays(8);
        DateTime[] allDays = new DateTime[8];

        for (int i = 0; i < allDays.Length; i++)
        {
            allDays[i] = now.AddDays(i);
        }


        string date = null;
        for (int i = 0; i < allDays.Length; i++)
        {
            for (int ii = 0; ii < DaysAvailable.Length; ii++)
            {
                if (allDays[i].DayOfWeek.ToString() == DaysAvailable[ii])
                {

                    date = allDays[i].ToShortDateString() + "," + date;
                }
            }
        }


        Char[] splitChars = new Char[] { ',' };
        string[] splitdate = date.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
        return splitdate;
    }


    public int[] getStudentIds()
    {
        SqlDataSource SqlDataSource2 = new SqlDataSource();
        SqlDataSource2.ConnectionString = ConfigurationManager.ConnectionStrings["AdvisorBookingConnectionString"].ToString();
        SqlDataSource2.SelectCommand = "Select Student_ID From Students";

        DataView view = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

        //   string[] slotsTaken = new string[table.Rows.Count];

        int[] Student_ID = new int[table.Rows.Count];

        for (int ii = 0; ii < table.Rows.Count; ii++)
        { Student_ID[ii] = Convert.ToInt32(table.Rows[ii][0].ToString()); }
        return Student_ID;
    }

    public void CancelAppointment(string stID)
    {
        int Student_Id = Convert.ToInt32(stID);
        DateTime date = DateTime.Now;

        SqlConnection objconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString());
        SqlCommand objcommand = new SqlCommand();
        objcommand.Connection = objconnection;
        objcommand.CommandType = CommandType.Text;
        objcommand.CommandText = "DELETE FROM Appointment  Where Student_Id='" + Student_Id + "' AND Date>'" + date + "'";
        objconnection.Open();
        objcommand.ExecuteNonQuery();
        objconnection.Close();
    }







    public static int GetWeekNumber(DateTime dtPassed)
    {
        CultureInfo ciCurr = CultureInfo.CurrentCulture;
        int weekNum = ciCurr.Calendar.GetWeekOfYear(dtPassed, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        return weekNum;
    }

   

    public DateTime[] AllSlots { get; set; }
    public int[] AllSlotsID { get; set; }
    public int[] weekNumbersx { get; set; }
    public string[] datesx { get; set; }
}