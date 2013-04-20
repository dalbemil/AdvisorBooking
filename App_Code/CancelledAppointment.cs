using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

/// <summary>
/// Summary description for CancelledAppointment
/// </summary>
public class CancelledAppointment
{
    SqlConnection con;
    SqlCommand cmd, cmd_cancel, cmd_cancelRequest, cmd_delete_request;
    private int student_Id;
    private int appointment_Id;

    public int Appointment_Id
    {
        get { return appointment_Id; }
        set { appointment_Id = value; }
    }

    public int Student_Id
    {
        get { return student_Id; }
        set { student_Id = value; }
    }

    private String reason;

    public String Reason
    {
        get { return reason; }
        set { reason = value; }
    }

    public CancelledAppointment()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void updateValues()
    {
        try
        {
            string s = WebConfigurationManager.ConnectionStrings["AdvisorBookingConnectionString"].ToString();
            con = new SqlConnection(s);
            con.Open();
            string query = "Update Appointments Set Cancel =('1') Where Student_Id =('" + Student_Id + "') and Appointment_ID=('" + Appointment_Id + "')";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            string updatequery = " INSERT INTO Cancel (Appointment_ID, AdvisorScheduleID,Student_id,comment)  select Appointment_ID,AdvisorScheduleID,Student_Id,comment from Appointments where cancel='" + 1 + "'";
            cmd_cancel = new SqlCommand(updatequery, con);
            cmd_cancel.ExecuteNonQuery();
            string insertquery = "Update Cancel set cancel_request='" + Reason + "' where Appointment_ID=('" + Appointment_Id + "')";
            cmd_cancelRequest = new SqlCommand(insertquery, con);
            cmd_cancelRequest.ExecuteNonQuery();
            string deletequery = "DELETE from Appointments Where Student_Id =('" + Student_Id + "') and Appointment_ID=('" + Appointment_Id + "')";
           cmd_delete_request = new SqlCommand(deletequery, con);
            cmd_delete_request.ExecuteNonQuery();

            con.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString(), ex);
        }
    }

    public DataSet cancelled()
    {
        DateTime date = DateTime.Today.AddDays(1);
        
        string s = WebConfigurationManager.ConnectionStrings["AdvisorBookingConnectionString"].ToString();
        SqlConnection con = new SqlConnection(s); ;

        con.Open();
        string select = "SELECT     Appointment_ID,Advisors.First_Name + ' ' +  Advisors.Last_Name As Advisor, Appointments.Time_Start, Appointments.Time_End, Appointments.Date,Comment,Student_ID FROM Advisors INNER JOIN AdvisorSchedules ON Advisors.Advisor_ID = AdvisorSchedules.Advisor_ID INNER JOIN Appointments ON AdvisorSchedules.AdvisorScheduleID = Appointments.AdvisorScheduleID WHERE Appointments.Student_Id='" + Student_Id + "'";
        SqlDataAdapter sadp = new SqlDataAdapter(select, con);
        DataSet ds = new DataSet();
        sadp.Fill(ds);
        con.Close();
        
        //DataRow dr = ds.Tables[0].Rows[0];
        //foreach (DataRow row in ds.Tables[0].Rows)
        //{
        //if (row["Date_Start"] ==(Object) date )
        //{

        //}
        return ds;
        //}
    }
}