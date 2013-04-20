using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Prevent some exceptions and corruptions.

        Session["AdvisorID"] = Request.QueryString["AdvisorID"];
        Session["date"] = Request.QueryString["bookingDate"];

        if (Session["date"] == null || Session["AdvisorID"] == null)
            Server.Transfer("Advisor.aspx");
        
        try
        {
            Session["bookingTime"] = Request.QueryString["bookingTime"];
            dropdownlistTime.SelectedValue = Session["bookingTime"].ToString();
        }
        catch { }

        int studentId = Convert.ToInt32(Session["StudentID"].ToString());
        int advisorId = Convert.ToInt32(Session["AdvisorID"].ToString());
        string date = Session["date"].ToString();
        Util get = new Util(advisorId);

        btnSubmit.Visible = true;

        DateTime datev2 = DateTime.ParseExact(Session["date"].ToString(), "MM/dd/yyyy", null);
        DateTime[] advisorAllSlots = get.getSlots(advisorId, date);
        DateTime[] taken = get.getTaken(advisorId, date);
        DateTime[] availibility = get.getAvailability(advisorAllSlots, taken);

        string[] shorttime = new string[availibility.Length];
        for (int i = 0; i < availibility.Length; i++)
        { shorttime[i] = availibility[i].ToShortTimeString(); }


        txtAdvisorName.Text = get.FullName;

        txtDate.Text = datev2.ToShortDateString();


        dropdownlistTime.DataSource = shorttime;

        if (!IsPostBack)
        {
            dropdownlistTime.DataBind();
        }


        if (availibility.Length == 0)
        {
            Response.Write("<script type='text/javascript'>alert('It is fully booked.');</script>");
            Server.Transfer("ViewScheduleCalendar.aspx");
        }


    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Prevent corruption. Double check availability. Delete cookies
        if (Session["date"] != null && Session["AdvisorID"] != null)
        {

            int advisorId = Convert.ToInt32(Session["AdvisorID"].ToString());
            string date = Session["date"].ToString();
            int studentId = Convert.ToInt32(Session["StudentID"].ToString());
            Session["date"] = null;
            Session["AdvisorID"] = null;
            Util get = new Util(advisorId);
            DateTime datev2 = DateTime.ParseExact(date, "MM/dd/yyyy", null);
            DateTime[] advisorAllSlots = get.getSlots(advisorId, date);
            DateTime[] taken = get.getTaken(advisorId, date);
            DateTime[] availibility = get.getAvailability(advisorAllSlots, taken);



            bool proceed = false;
            for (int i = 0; i < availibility.Length; i++)
            {
                if (dropdownlistTime.SelectedValue.ToString() == availibility[i].ToShortTimeString())
                {
                    proceed = true;
                }
            }

            if (proceed)
            {
                DateTime picked = new DateTime();
                picked = DateTime.ParseExact(dropdownlistTime.SelectedValue.ToString(), "h:mm tt", CultureInfo.InvariantCulture);

                int Student_Id = studentId;
                int Advisor_Id = advisorId;
                string Time_Start = picked.ToString("HH:mm:ss");
                string Time_End = picked.AddMinutes(30).ToString("HH:mm:ss");
                string Date = datev2.ToString("yyyy-MM-dd");

                string Comments = TextArea1.Value.ToString();
                int AdvisorScheduleID = get.getAvailableID(dropdownlistTime.SelectedValue.ToString());

                string sqlQuery = "INSERT INTO Appointments (AdvisorScheduleID, Student_Id,Time_Start,Time_End,Date,Comment,Cancel)";
                sqlQuery += " VALUES (@AdvisorScheduleID,@Student_Id,@Time_Start,@Time_End,@Date,@Comment,@Cancel)";
                string connectionString = ConfigurationManager.ConnectionStrings["AdvisorBookingConnectionString"].ToString();
                using (SqlConnection dataConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand dataCommand = new SqlCommand(sqlQuery, dataConnection))
                    {
                        dataCommand.Parameters.AddWithValue("AdvisorScheduleID", AdvisorScheduleID);
                        dataCommand.Parameters.AddWithValue("Student_Id", studentId);
                        dataCommand.Parameters.AddWithValue("Time_Start", Time_Start);
                        dataCommand.Parameters.AddWithValue("Time_End", Time_End);
                        dataCommand.Parameters.AddWithValue("Date", Date);
                        dataCommand.Parameters.AddWithValue("Comment", Comments);
                        dataCommand.Parameters.AddWithValue("Cancel", 1);
                        dataConnection.Open();
                        dataCommand.ExecuteNonQuery();
                        dataConnection.Close();
                    }
                }


                Server.Transfer("FinishBooking.aspx");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('Something went wrong. Try again later');</script>");
                Server.Transfer("Advisor.aspx");
            }


        }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }


    public EventHandler PageUnload { get; set; }


}
