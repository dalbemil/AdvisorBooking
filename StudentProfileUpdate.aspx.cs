using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Configuration;

public partial class StudentProfileUpdate : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader dr;
    String studentID;
    String path;
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["StudentID"] == null)) studentID = "300717754";
        else studentID = Session["StudentID"].ToString();

        con = new SqlConnection();
        cmd = new SqlCommand();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["AdvisorBookingConnectionString"].ConnectionString;
        //con.ConnectionString = "Data Source=SHREEJI-PC\\SQLSERVER2008;Initial Catalog=College_Mgmt;Integrated Security=True";

        con.Open();
        cmd.Connection = con;

        if (!IsPostBack)
        {

            lblStudentIDValue.Text = studentID;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select First_Name,Last_Name,Program_id,Cur_Sem,Image from Students where Student_ID='" + studentID + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtFName.Text = dr[0].ToString();
                txtLName.Text = dr[1].ToString();
                ddlProgramName.SelectedValue = dr[2].ToString();
                txtCurrentSemester.Text = dr[3].ToString();
                imgPhoto.ImageUrl = "~/Files/Images/Students/" + dr[4].ToString();
                path = dr[4].ToString();
                Session["Path"] = path;
            }
            dr.Close();
        }
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            DatabaseRegistration objdb = new DatabaseRegistration();
            if (imgUpload.HasFile)
            {
                imgUpload.SaveAs(MapPath("~\\Files\\Images\\Students\\" + imgUpload.FileName));
                path = imgUpload.FileName;
            }
            else
            {
                path = Session["Path"].ToString();
            }
            objdb.update_Student_Info(lblStudentIDValue.Text, txtFName.Text, txtLName.Text, ddlProgramName.SelectedValue, txtCurrentSemester.Text, path);
            lblMessage.Text = "Profile updated Successfully";
        }
        catch  
        { 
            lblMessage.Text = "Profile is not updated Successfully. Database Error"; 
        }
    }
}