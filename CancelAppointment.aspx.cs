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
        try { txtStudentID.Text = Session["StudentId"].ToString(); }
        catch { }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
     }

    public void clear()
    {
       	
        txtComments.Value = "";	
      
        txtStudentID.Text = "";
      

    }
    protected void btnCheck_click(object sender, EventArgs e)
    {
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
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       
        

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ronUtil2 get = new ronUtil2();
        get.CancelAppointment(Session["StudentID"].ToString());


        if (Request.QueryString["AdvisorID"]!=null)
            Server.Transfer("Schedule.aspx");
        else
            Server.Transfer("Advisor.aspx");

        
    }
}