using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Globalization;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    public DataTable GetAdvisorSchedule(string AdvisorID, string WeekNumber, string Year)
    {
        SqlConnection sqlConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["AdvisorBookingConnectionString"].ConnectionString);
        System.Data.DataSet ds = new System.Data.DataSet();

        try
        {
            SqlCommand sCommand = new SqlCommand("GetAdvisorCurrentSchedule", sqlConnect);
            sCommand.CommandType = CommandType.StoredProcedure;
            sCommand.CommandTimeout = 30;

            sCommand.Parameters.AddWithValue("@AdvisorID", AdvisorID);
            sCommand.Parameters.AddWithValue("@Week", WeekNumber);
            sCommand.Parameters.AddWithValue("@Year", Year);

            SqlDataAdapter daAdvisorSchedule = new SqlDataAdapter(sCommand);
            daAdvisorSchedule.Fill(ds, "AdvisorSchedules");
        }
        catch (Exception)
        {
            return null;
        }
        finally
        {
            if (sqlConnect != null)
            {
                if (sqlConnect.State == ConnectionState.Open)
                {
                    sqlConnect.Close();
                    sqlConnect.Dispose();
                    sqlConnect = null;
                }
            }
        }

        return ds.Tables["AdvisorSchedules"];
    }

    [WebMethod]
    public int WeeksInYear(int year)
    {
        GregorianCalendar cal = new GregorianCalendar(GregorianCalendarTypes.Localized);
        return cal.GetWeekOfYear(new DateTime(year, 12, 31), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }

    [WebMethod]
    public int WeekNumber(DateTime date)
    {
        GregorianCalendar cal = new GregorianCalendar(GregorianCalendarTypes.Localized);
        return cal.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }

     [WebMethod]
    public DateTime DayInWeekDate(string day, int Week, int Year)
    {
         DateTime DayDate = DateTime.Now;
        // set date to the first day of the year
        DateTime dt = new DateTime(Year, 1, 1);
        int weekNumber = Week;
        int days = (weekNumber - 1) * 7;
        DateTime dt1 = dt.AddDays(days);
        DayOfWeek dow = dt1.DayOfWeek;
        DateTime startDateOfWeek = dt1.AddDays(-(int)dow);
        DateTime EndDateOfWeek = startDateOfWeek.AddDays(6);

        DateTime CurrentDate = startDateOfWeek;
        while (CurrentDate <= EndDateOfWeek)
        {
            if (CurrentDate.ToString("dddd") == day)
            {
                DayDate = CurrentDate;
                break;
            }

            CurrentDate = CurrentDate.AddDays(1);
        }

        return DayDate;
    }
}
