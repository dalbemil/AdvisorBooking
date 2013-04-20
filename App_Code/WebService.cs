using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Text;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public User LogInUser = new User();
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
    public bool ValidateLoginUser(string LogInUserName, string LogInUserPassword)
    {
        SqlConnection sqlConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["AdvisorBookingConnectionString"].ConnectionString);
        System.Data.DataSet ds = new System.Data.DataSet();
        Boolean IsSuccessful = false;

        try
        {
            SqlCommand sCommand = new SqlCommand("ValidateUserName", sqlConnect);
            sCommand.CommandType = CommandType.StoredProcedure;
            sCommand.CommandTimeout = 30;

            sCommand.Parameters.AddWithValue("@UserName", LogInUserName);
            SqlDataAdapter daLogInUser = new SqlDataAdapter(sCommand);
            daLogInUser.Fill(ds, "LogInUser");

            //Check UserPassword, Case sensitive
            if (string.Compare(ds.Tables["LogInUser"].Rows[0]["UserPassword"].ToString(), LogInUserPassword, false) == 0)
            {
                switch (string.IsNullOrEmpty(ds.Tables["LogInUser"].Rows[0]["LogInType"].ToString()) ? "" : ds.Tables["LogInUser"].Rows[0]["LogInType"].ToString())
                {
                    case "Student":
                        IsSuccessful = true;
                        LogInUser.Type = LogInType.Student;
                        LogInUser.IDNumber = Convert.ToInt32(string.IsNullOrEmpty(ds.Tables["LogInUser"].Rows[0]["IDNumber"].ToString()) ? "0" : ds.Tables["LogInUser"].Rows[0]["IDNumber"].ToString());
                        LogInUser.FirstName = string.IsNullOrEmpty(ds.Tables["LogInUser"].Rows[0]["FirstName"].ToString()) ? "" : ds.Tables["LogInUser"].Rows[0]["FirstName"].ToString();
                        LogInUser.LastName = string.IsNullOrEmpty(ds.Tables["LogInUser"].Rows[0]["LastName"].ToString()) ? "" : ds.Tables["LogInUser"].Rows[0]["LastName"].ToString();
                        break;

                    case "Advisor":
                        IsSuccessful = true;
                        LogInUser.Type = LogInType.Advisor;
                        LogInUser.IDNumber = Convert.ToInt32(string.IsNullOrEmpty(ds.Tables["LogInUser"].Rows[0]["IDNumber"].ToString()) ? "0" : ds.Tables["LogInUser"].Rows[0]["IDNumber"].ToString());
                        LogInUser.FirstName = string.IsNullOrEmpty(ds.Tables["LogInUser"].Rows[0]["FirstName"].ToString()) ? "" : ds.Tables["LogInUser"].Rows[0]["FirstName"].ToString();
                        LogInUser.LastName = string.IsNullOrEmpty(ds.Tables["LogInUser"].Rows[0]["LastName"].ToString()) ? "" : ds.Tables["LogInUser"].Rows[0]["LastName"].ToString();
                        break;

                    default:
                        IsSuccessful = false;
                        LogInUser.IDNumber = 0;
                        LogInUser.Type = LogInType.None;
                        LogInUser.FirstName = "";
                        LogInUser.LastName = "";
                        break;
                }
            }
        }
        catch (Exception)
        {
            return false;
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

        return IsSuccessful;
    }

    [WebMethod]
    public String ValidateLoginUserFromMobile(string LogInUserName, string LogInUserPassword)
    {
        SqlConnection sqlConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["AdvisorBookingConnectionString"].ConnectionString);
        System.Data.DataSet ds = new System.Data.DataSet();
        StringBuilder Users = new StringBuilder();

        try
        {
            SqlCommand sCommand = new SqlCommand("ValidateUserName", sqlConnect);
            sCommand.CommandType = CommandType.StoredProcedure;
            sCommand.CommandTimeout = 30;

            sCommand.Parameters.AddWithValue("@UserName", LogInUserName);
            SqlDataAdapter daLogInUser = new SqlDataAdapter(sCommand);
            daLogInUser.Fill(ds, "LogInUser");

            if (string.Compare(ds.Tables["LogInUser"].Rows[0]["UserPassword"].ToString(), LogInUserPassword, false) == 0)
            {
                switch (string.IsNullOrEmpty(ds.Tables["LogInUser"].Rows[0]["LogInType"].ToString()) ? "" : ds.Tables["LogInUser"].Rows[0]["LogInType"].ToString())
                {
                    case "Student":
                        Users.Append("Student,");
                        Users.Append(string.IsNullOrEmpty(ds.Tables["LogInUser"].Rows[0]["IDNumber"].ToString()) ? "" : ds.Tables["LogInUser"].Rows[0]["IDNumber"].ToString() + ",");
                        Users.Append(string.IsNullOrEmpty(ds.Tables["LogInUser"].Rows[0]["FirstName"].ToString()) ? "" : ds.Tables["LogInUser"].Rows[0]["FirstName"].ToString() + ",");
                        Users.Append(string.IsNullOrEmpty(ds.Tables["LogInUser"].Rows[0]["LastName"].ToString()) ? "" : ds.Tables["LogInUser"].Rows[0]["LastName"].ToString());
                        break;

                    case "Advisor":
                        Users.Append("Advisor,");
                        Users.Append(string.IsNullOrEmpty(ds.Tables["LogInUser"].Rows[0]["IDNumber"].ToString()) ? "" : ds.Tables["LogInUser"].Rows[0]["IDNumber"].ToString() + ",");
                        Users.Append(string.IsNullOrEmpty(ds.Tables["LogInUser"].Rows[0]["FirstName"].ToString()) ? "" : ds.Tables["LogInUser"].Rows[0]["FirstName"].ToString() + ",");
                        Users.Append(string.IsNullOrEmpty(ds.Tables["LogInUser"].Rows[0]["LastName"].ToString()) ? "" : ds.Tables["LogInUser"].Rows[0]["LastName"].ToString());
                        break;

                    default:
                         Users.Append("None,0,,");
                        break;
                }
            }
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

        return Users.ToString();
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
