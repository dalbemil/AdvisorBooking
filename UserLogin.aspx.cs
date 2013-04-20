using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserLogin : System.Web.UI.Page
{
    WebService GetSchedule = new WebService();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.lblMessage.Text = "";
            this.txtUserName.Text = "sweetkenlee@gmail.com";
            this.txtPassword.Text = "cdklmps93";
            SetFocus(this.txtUserName);
        }
    }

    bool ValidateUserInput()
    {
        if (this.txtUserName.Text.Trim().Length == 0)
        {
            this.lblMessage.Text = "Email Address is Missing.";
            return false;
        }

        if (this.txtPassword.Text.Trim().Length == 0)
        {
            this.lblMessage.Text = "User Password is Missing.";
            return false;
        }

        return true;
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        this.txtUserName.Text = "";
        this.txtPassword.Text = "";
        this.lblMessage.Text = "";
        SetFocus(this.txtUserName);
    }

    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidateUserInput())
            {
                if (GetSchedule.ValidateLoginUser(this.txtUserName.Text, this.txtPassword.Text))
                {
                    this.lblMessage.Text = "";
                    Session["LoggedIn"] = "1";

                    switch (GetSchedule.LogInUser.Type)
                    {
                        case LogInType.Student:
                            Session["StudentName"] = GetSchedule.LogInUser.FirstName + ' ' + GetSchedule.LogInUser.LastName;
                            Session["StudentID"] = GetSchedule.LogInUser.IDNumber;
                            Response.Redirect("~/ViewStudentAppointment.aspx");
                            break;

                        case LogInType.Advisor:
                            Session["AdvisorName"] = GetSchedule.LogInUser.FirstName + ' ' + GetSchedule.LogInUser.LastName;
                            Session["AdvisorID"] = GetSchedule.LogInUser.IDNumber;
                            Response.Redirect("~/AdvisorSchedule.aspx");
                            break;
                    }
                }
                else
                {
                    this.lblMessage.Text = "Authentication Failed. Check EMail Address (UserName) and Password.";
                    SetFocus(txtUserName);
                }
            }
        }
        catch (Exception ex)
        {
            this.lblMessage.Text = "Error authenticating. " + ex.Message;
        }
    }
}