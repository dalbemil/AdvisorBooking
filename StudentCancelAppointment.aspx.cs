using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class CancelAppointment : System.Web.UI.Page
{
    CancelledAppointment appointment = new CancelledAppointment();
    protected void Page_Load(object sender, EventArgs e)
    {
        try {
        txtStudentID.ReadOnly = true;
        txtStudentID.Text = Session["StudentId"].ToString();

        int id = Convert.ToInt32(txtStudentID.Text);
        appointment.Student_Id = id;
        DataSet ds = appointment.cancelled();
        if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(
                  this,
                  this.GetType(),
                  "MessageBox",
                  "alert('You have no appointment');",
                  true);
        }


        else
        {
            this.GridView1.DataSource = ds.Tables[0];
            this.GridView1.DataBind();
        }
        
        }
        catch { }




    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        int appointment_ID = Convert.ToInt32(row.Cells[1].Text);
        int student_ID = Convert.ToInt32(row.Cells[2].Text);
        appointment.Appointment_Id = appointment_ID;
        appointment.Student_Id = student_ID;
        appointment.Reason = txtComments.Value;
        try
        {

            appointment.updateValues();
            GridView1.DeleteRow(GridView1.SelectedIndex);
            ScriptManager.RegisterStartupScript(
              this,
              this.GetType(),
              "MessageBox",
              "alert('Appointment has been cancelled');",
              true);



        }

        catch (Exception ex)
        {
            throw new Exception(ex.ToString(), ex);
        }

        clear();

    }

    public void clear()
    {

        txtComments.Value = "";
        txtStudentID.Text = "";

    }
    protected void btnCheck_click(object sender, EventArgs e)
    {
       

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridView1.DataBind();
        // Sending Cancellation Confirmation Email To the Students for information
        try
        {
            String studentID;
            if (Session["StudentID"] == null)
            {
                studentID = "300717754";
            }
            else
            {
                studentID = Session["StudentID"].ToString();
            }
            EmailConfirmation obj = new EmailConfirmation();
            DatabaseRegistration objdb = new DatabaseRegistration();

            String emailID = objdb.getEmailID(studentID);
            String Subject = "Appointment Cancellation";
            String body = "You have Successfully Cancelled Appointment.\n Message Send from Advisor Booking Service System";

            obj.sendEmail("advisor.system@yahoo.com", "Passwordisimportant", emailID, Subject, body);
            Server.Transfer("StudentCancelAppointment.aspx");
        }
        catch {
            Server.Transfer("StudentCancelAppointment.aspx");
        }
    }
}