using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Advisor
/// </summary>
public class Advisor
{
    private int employee_ID;
    SqlConnection con;
    SqlCommand cmd;
    SqlCommand cmd_login;
    private string emailId;

    public string EmailId
    {
        get { return emailId; }
        set { emailId = value; }
    }
    private string password;

    public string Password
    {
        get { return password; }
        set { password = value; }
    }

    public int Employee_ID
    {
        get { return employee_ID; }
        set { employee_ID = value; }
    }
    private string first_Name;

    public string First_Name
    {
        get { return first_Name; }
        set { first_Name = value; }
    }
    private string last_Name;

    public string Last_Name
    {
        get { return last_Name; }
        set { last_Name = value; }
    }
    private int dept_ID;

    public int Dept_ID
    {
        get { return dept_ID; }
        set { dept_ID = value; }
    }
    private string image;

    public string Image
    {
        get { return image; }
        set { image = value; }
    }

    public Advisor(int employee_Id, string first_Name,string last_Name, int dept_ID,string Image)
	{
        this.employee_ID = employee_Id;
        this.first_Name = first_Name;
        this.last_Name = last_Name;
        this.dept_ID = dept_ID;
        this.image = Image;
	}
    public Advisor(int employee_Id, string first_Name, string last_Name, int dept_ID)
    {
        this.employee_ID = employee_Id;
        this.first_Name = first_Name;
        this.last_Name = last_Name;
        this.dept_ID = dept_ID;
      }
    public Advisor()
    {

    }
    public void SubmitValue()
    {

        try
        {
            string s = WebConfigurationManager.ConnectionStrings["College_MgmtConnectionString"].ToString();
            con = new SqlConnection(s);
            con.Open();
            cmd = new SqlCommand("insert into Advisor values('" + Employee_ID + "','" + First_Name + "','" + Last_Name + "','" + Dept_ID + "','" + Image + "')", con);
            cmd.ExecuteNonQuery();
        string sqlIns = "INSERT INTO  login_Details (Email_ID, Password, Student_Id,Employee_Id) VALUES (@email_id, @password, @student_id, @employee_id)";

    SqlCommand cmdIns = new SqlCommand(sqlIns, con);
    SqlParameter param1 = new SqlParameter("@email_id", SqlDbType.VarChar);
     param1.Value = EmailId;
    cmdIns.Parameters.Add(param1);
    SqlParameter param2 = new SqlParameter("@password", SqlDbType.VarChar);
    param2.Value = Password;
    cmdIns.Parameters.Add(param2);
    SqlParameter param3 = new SqlParameter("@student_id", SqlDbType.Int);
    param3.Value = DBNull.Value;
    cmdIns.Parameters.Add(param3);
    SqlParameter param4 = new SqlParameter("@employee_id", SqlDbType.Int);
    param4.Value = Employee_ID;
    cmdIns.Parameters.Add(param4);
    cmdIns.ExecuteNonQuery();
     con.Close();
            
        }
           

        
        catch (Exception ex)
        {
            throw new Exception(ex.ToString(), ex);
        }

        
    }
   
}