using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;


public partial class Advisor_Form : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    private string s, gender, date;
    private int i;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            txtFName.Focus();
        }
    }
    
    // for insert values
    protected void btnRegister_Click(object sender, EventArgs e)
    {

        s = WebConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        con = new SqlConnection(s);
        con.Open();

        cmd = new SqlCommand("insert into Employee values('" + txtFName.Text + "','" + txtLName.Text + "','" + txtAdvisorID.Text + "','" + txtDept.Text + "')", con);
        cmd.ExecuteNonQuery();
        Response.Write("Information has been submitted");
        con.Close();
        clear();
    }
    // for clear textboxes
    public void clear()
    {
        txtFName.Text = "";

        txtLName.Text = "";
        txtAdvisorID.Text = "";
        
        txtDept.Text = "";
    }



    protected void txtFName_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtLName_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtAdvisorID_TextChanged(object sender, EventArgs e)
    {

    }
}