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

/// <summary>
/// Summary description for DatabaseRegistration
/// </summary>
public class DatabaseRegistration
{
    SqlConnection con;
    SqlCommand cmd;
    String str;
    SqlDataReader dr;


    public DatabaseRegistration()
    {

        con = new SqlConnection();
        cmd = new SqlCommand();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["AdvisorBookingConnectionString"].ConnectionString;
        //con.ConnectionString = "Data Source=SHREEJI-PC\\SQLSERVER2008;Initial Catalog=College_Mgmt;Integrated Security=True";
    }

    public void insert_Student_Info(String studentID, String firstName, String lastName, String program, String currSem, String photoURL)
    {
        con.Open();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        str = "insert into Students Values(@p1,@p2,@p3,@p4,@p5,@p6);";
        cmd.Parameters.AddWithValue("@p1", Convert.ToInt64(studentID));
        cmd.Parameters.AddWithValue("@p2", firstName);
        cmd.Parameters.AddWithValue("@p3", lastName);
        cmd.Parameters.AddWithValue("@p4", program);
        cmd.Parameters.AddWithValue("@p5", currSem);
        cmd.Parameters.AddWithValue("@p6", photoURL);
        cmd.CommandText = str;
        cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        con.Close();
    }

    public void insert_Student_Login_Info(String emailID, String password, String studentID)
    {
        con.Open();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        str = "insert into Login_Details(Email_ID, Password, Student_Id) Values(@p1,@p2,@p3);";
        cmd.Parameters.AddWithValue("@p1", emailID);
        cmd.Parameters.AddWithValue("@p2", password);
        cmd.Parameters.AddWithValue("@p3", studentID);
        cmd.CommandText = str;
        cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        con.Close();
    }

    public void update_Student_Info(String studentID, String firstName, String lastName, String program, String currSem, String photoURL)
    {
        con.Open();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        str = "update Students Set First_Name=@p1, Last_Name=@p2,Program_Id=@p3, Cur_Sem=@p4,Image=@p5 where Student_ID=@p6";
        cmd.Parameters.AddWithValue("@p1", firstName);
        cmd.Parameters.AddWithValue("@p2", lastName);
        cmd.Parameters.AddWithValue("@p3", program);
        cmd.Parameters.AddWithValue("@p4", Convert.ToInt16(currSem));
        cmd.Parameters.AddWithValue("@p5", photoURL);
        cmd.Parameters.AddWithValue("@p6", Convert.ToInt64(studentID));
        cmd.CommandText = str;
        cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        con.Close();
    }
    public String getEmailID(String studentID)
    {
        String emailID = "";
        con.Open();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select  Email_ID from Login_Details where Student_Id=@p1";
        cmd.Parameters.Add("@p1", studentID);
        dr = cmd.ExecuteReader();
        cmd.Parameters.Clear();
        if (dr.HasRows)
        {
            dr.Read();
            emailID = dr["Email_ID"].ToString();
            dr.Close();
            con.Close();

        }

        return emailID;
    }
    public void update_Account_Info(String studentID, String emailID, String password)
    {
        con.Open();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        str = "update Login_Details Set Email_ID=@p1, Password=@p2 where Student_ID=@p3";
        cmd.Parameters.AddWithValue("@p1", emailID);
        cmd.Parameters.AddWithValue("@p2", password);
        cmd.Parameters.AddWithValue("@p3", Convert.ToInt64(studentID));
        cmd.CommandText = str;
        cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        con.Close();
    }

    public Boolean isStudentIDAvailable(String studentID)
    {
        con.Open();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from Login_Details where Student_Id=@p1";
        cmd.Parameters.Add("@p1", Convert.ToInt64(studentID));
        dr = cmd.ExecuteReader();
        cmd.Parameters.Clear();
        if (dr.HasRows)
        {
            dr.Close();
            con.Close();
            return false;
        }
        else
        {
            dr.Close();
            con.Close();
            return true;

        }
    }

    public Boolean isEmailIDAvailable(String emailID)
    {
        con.Open();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from Login_Details where Email_Id=@p1";
        cmd.Parameters.Add("@p1", emailID);
        dr = cmd.ExecuteReader();
        cmd.Parameters.Clear();
        if (dr.HasRows)
        {
            dr.Close();
            con.Close();
            return false;
        }
        else
        {
            dr.Close();
            con.Close();
            return true;

        }
    }

    public Boolean update_Password(String studentID, String oldPassword, String newPassword)
    {
        con.Open();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        String oldp = "";
        cmd.CommandText = "select Password from Login_Details where Student_Id=@p1";
        cmd.Parameters.Add("@p1", Convert.ToInt64(studentID));
        dr = cmd.ExecuteReader();
        cmd.Parameters.Clear();

        if (dr.Read())
        {
            oldp = dr[0].ToString();
        }
        dr.Close();
        if (oldPassword.Equals(oldp))
        {
            cmd.CommandText = "update Login_Details Set Password=@p1 where Student_ID=@p2";
            cmd.Parameters.AddWithValue("@p1", newPassword);
            cmd.Parameters.AddWithValue("@p2", studentID);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        else
        {
            con.Close();
            return false;
        }
    }
}