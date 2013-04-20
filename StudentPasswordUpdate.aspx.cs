using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PasswordUpdate : System.Web.UI.Page
{
    String studentID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["StudentID"] == null)) studentID = "300717754";
        else studentID = Session["StudentID"].ToString();

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            DatabaseRegistration objdb = new DatabaseRegistration();
            if (objdb.update_Password(studentID, txtOldPassword.Text, txtPassword.Text))
            {
                lblMessage.Text = "Password updated Successfully";
            }
            else
            {
                lblMessage.Text = "Enter Correct Old Password";
            }
        }
        catch (Exception obj)
        {
            lblMessage.Text = " Password is not updated Successfully. Database Error";
        }
    }
}