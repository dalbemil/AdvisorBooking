using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public enum LogInType
{
    Advisor = 1,
    Student,
    None
}

public interface IUser
{
    // Properties
    int IDNumber { get; set; }
    String FirstName { get; set; }
    String LastName { get; set; }
    LogInType Type { get; set; }
}

[Serializable]
public class User : IUser
{
    private LogInType lInType;
    private int idNumber;
    private String lname;
    private String fname;

    public User()
    {
        this.idNumber = 0;
        this.lInType = LogInType.None;
        this.fname = "";
        this.lname = "";
    }

    public LogInType Type
    {
        get
        {
            return lInType;
        }
        set
        {
            lInType = value;
        }
    }

    public int IDNumber
    {
        get
        {
            return idNumber;
        }
        set
        {
            idNumber = value;
        }
    }

    public String FirstName
    {
        get
        {
            return fname;
        }
        set
        {
            fname = value;
        }
    }

    public String LastName
    {
        get
        {
            return lname;
        }
        set
        {
            lname = value;
        }
    }
}
