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

public partial class StudentRegistration : System.Web.UI.Page
{
    String studentID;
    public void clear_Fields()
    {
        txtStudentID.Text = "";
        txtPassword.Text = "";
        txtLName.Text = "";
        txtFName.Text = "";
        txtEmailID.Text = "";
        txtCurrentSemester.Text = "";
        txtConfirmPassword.Text = "";
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {String path;
            studentID = txtStudentID.Text;
            EmailConfirmation obj = new EmailConfirmation();
            DatabaseRegistration objdb = new DatabaseRegistration();

            if (objdb.isStudentIDAvailable(studentID) && objdb.isEmailIDAvailable(txtEmailID.Text))
            {
                if (PhotoUpload.HasFile)
                {
                    PhotoUpload.SaveAs(MapPath("~/Files/Images/Students/" + PhotoUpload.FileName));
                    path = PhotoUpload.FileName; ;
                }
                else
                {
                    path = " ";
                }
                objdb.insert_Student_Info(txtStudentID.Text, txtFName.Text, txtLName.Text, ddlProgram.SelectedValue, txtCurrentSemester.Text, path);
                objdb.insert_Student_Login_Info(txtEmailID.Text, txtPassword.Text, txtStudentID.Text);
                String Subject = "Registration Confirmation Email";
                String body = "You are Successfully registered with Advisor Booking Service.";
                body = body + "\n Now You can make an appointment with the advisor";
                body = body + "\n Your User Name is =" + txtEmailID.Text;
                body = body + "\n Your Password is =" + txtPassword.Text;
                obj.sendEmail("advisor.system@yahoo.com", "Passwordisimportant", txtEmailID.Text, Subject, body);
                lblMessage.Text = "Successfully Registered";
                /// clear_Fields();
                Response.Redirect("UserLogin.aspx");
            }
            else
            {
                lblMessage.Text = "StudentID or Email ID is already registered";
                clear_Fields();
            }
        }
        catch (Exception obj)
        {
            lblMessage.Text = "Error in Registeration. Please try again";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      

    }
}