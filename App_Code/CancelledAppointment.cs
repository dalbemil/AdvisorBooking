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
    SqlCommand cmd, cmd_cancel,cmd_cancelRequest,cmd_delete_request;
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
            string s = WebConfigurationManager.ConnectionStrings["College_MgmtConnectionString"].ToString();
            con = new SqlConnection(s);
            con.Open();
            string query = "Update Appointment Set Cancel =('1') Where student_id =('" + Student_Id + "') and Appointment_ID=('" + Appointment_Id + "')";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            string updatequery=" INSERT INTO  cancel (Appointment_ID,Availability_ID,Student_id,comment)  select Appointment_ID,Availability_ID,Student_id,comment from Appointment where cancel='"+1+"'";
            cmd_cancel = new SqlCommand(updatequery, con);
            cmd_cancel.ExecuteNonQuery();
            string insertquery = "update cancel set cancel_request='" + Reason + "' where Appointment_ID=('" + Appointment_Id + "')";
            cmd_cancelRequest = new SqlCommand(insertquery, con);
            cmd_cancelRequest.ExecuteNonQuery();
            string deletequery = "delete from Appointment Where student_id =('" + Student_Id + "') and Appointment_ID=('"+Appointment_Id+"')";
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
        string s = WebConfigurationManager.ConnectionStrings["College_MgmtConnectionString"].ToString();
        SqlConnection con = new SqlConnection(s); ;

        con.Open();
        string select = "SELECT Appointment_ID,Student_Id,Comment,Date_Start,Time_Start FROM Appointment x,Availability b WHERE x.Availability_ID=b.Availability_ID and x.student_id=('" + Student_Id + "')";
        SqlDataAdapter sadp = new SqlDataAdapter(select, con);
        DataSet ds = new DataSet();
        sadp.Fill(ds);
        con.Close();
        return ds;
    }



}