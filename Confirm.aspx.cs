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
        //Prevent exceptions,corruptions.

        
        if (Session["date"] == null || Session["AdvisorID"] == null)
            {
                Server.Transfer("Advisor.aspx");
            }

        int studentId = Convert.ToInt32(Session["StudentID"].ToString());
        int advisorId = Convert.ToInt32(Session["AdvisorID"].ToString());
        string date = Session["date"].ToString();
        ronUtil2 get = new ronUtil2(advisorId);

        Submit.Visible = true;
        //if (get.getCheck(studentId) == true)
        //{ Submit.Visible = true; }
        //else
        //{ Cancel.Visible = true; }

        DateTime datev2 = DateTime.ParseExact(Session["date"].ToString(), "MM/dd/yyyy", null);
        DateTime[] advisorAllSlots = get.getSlots(advisorId, date);
        DateTime[] taken = get.getTaken(advisorId, date);
        DateTime[] availibility = get.getAvailability(advisorAllSlots, taken);
        
        string[] shorttime = new string[availibility.Length];
        for (int i = 0; i < availibility.Length; i++)
        { shorttime[i] = availibility[i].ToShortTimeString(); }


        txtAdvisorName.Text = get.FullName;

        //Label1.Text = "Date : " + datev2.ToLongDateString();
        txtDate.Text = datev2.ToShortDateString();

        
            DropDownList1.DataSource = shorttime;
         //   DropDownList1.DataBind();
          if (!IsPostBack)
           { 
                DropDownList1.DataBind();
           }

            
            if (availibility.Length==0)
            {Response.Write("<script type='text/javascript'>alert('It is fully booked.');</script>");
                Server.Transfer("Schedule.aspx");}
            

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
            ronUtil2 get = new ronUtil2(advisorId);
            DateTime datev2 = DateTime.ParseExact(date, "MM/dd/yyyy", null);
            DateTime[] advisorAllSlots = get.getSlots(advisorId, date);
            DateTime[] taken = get.getTaken(advisorId, date);
            DateTime[] availibility = get.getAvailability(advisorAllSlots, taken);

            

            bool proceed = false;
            for (int i = 0; i < availibility.Length; i++)
            {
                if (DropDownList1.SelectedValue.ToString() == availibility[i].ToShortTimeString())
                {
                    proceed = true;
                }
            }

            if (proceed)
            {
                DateTime picked = new DateTime();
                picked = DateTime.ParseExact(DropDownList1.SelectedValue.ToString(), "h:mm tt", CultureInfo.InvariantCulture);

                int Student_Id = studentId;
                int Advisor_Id = advisorId;
                string Time = picked.ToString("HH:mm:ss");
                string Date = datev2.ToString("yyyy-MM-dd");
                Label1.Text = Time;
                string Comments = TextArea1.Value.ToString();
                int Availability_ID= get.getAvailableID(Advisor_Id, date);

                string sqlQuery = "INSERT INTO Appointment (Availability_ID, Student_Id,Time,Date,Comment,Cancel)";
                sqlQuery += " VALUES (@Availability_ID,@Student_Id,@Time,@Date,@Comment,@Cancel)";
                string connectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
                using (SqlConnection dataConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand dataCommand = new SqlCommand(sqlQuery, dataConnection))
                    {
                        dataCommand.Parameters.AddWithValue("Availability_ID", Availability_ID);
                        dataCommand.Parameters.AddWithValue("Student_Id", studentId);
                        dataCommand.Parameters.AddWithValue("Time", Time);
                        dataCommand.Parameters.AddWithValue("Date", Date);
                        dataCommand.Parameters.AddWithValue("Comment", Comments);
                        dataCommand.Parameters.AddWithValue("Cancel",1 );
                        dataConnection.Open();
                        dataCommand.ExecuteNonQuery();
                        dataConnection.Close();
                    }
                }

                Response.Write("<script type='text/javascript'>alert('You are booked');</script>");
                Server.Transfer("Advisor.aspx");
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

}
