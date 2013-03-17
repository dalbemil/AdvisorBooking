using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

/// <summary>
/// Summary description for Student
/// </summary>
public class Student
{
    private int student_ID;
    private int currentSem;

    public int CurrentSem
    {
        get { return currentSem; }
        set { currentSem = value; }
    }

    public int Student_ID
    {
        get { return student_ID; }
        set { student_ID = value; }
    }
    private int program_id;

    public int Program_id
    {
        get { return program_id; }
        set { program_id = value; }
    }
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
    

   
    private string image;

    public string Image
    {
        get { return image; }
        set { image = value; }
    }
	public Student()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void SubmitValue()
    {

        try
        {
            string s = WebConfigurationManager.ConnectionStrings["College_MgmtConnectionString"].ToString();
            con = new SqlConnection(s);
            con.Open();
            cmd = new SqlCommand("insert into student values('" + Student_ID + "','" + First_Name + "','" + Last_Name + "','" + Program_id + "','" + CurrentSem + "','" + Image + "')", con);
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
            param3.Value = Student_ID;
            cmdIns.Parameters.Add(param3);
            SqlParameter param4 = new SqlParameter("@employee_id", SqlDbType.Int);
            param4.Value = DBNull.Value;
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