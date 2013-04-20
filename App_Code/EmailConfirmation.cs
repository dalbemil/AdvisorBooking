using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.ComponentModel;
using System.Drawing;
using System.Text;


/// <summary>
/// Summary description for EmailConfirmation
/// </summary>
public class EmailConfirmation
{
	public EmailConfirmation()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void sendEmail(String from, String fromPwd, String to, String Subject, String Body)
    {
        String str = "";
        Boolean state = false;
        str = "smtp.mail.yahoo.com";
        state = false;
        System.Net.Mail.MailAddress From = new System.Net.Mail.MailAddress(from);
        System.Net.Mail.MailAddress To = new System.Net.Mail.MailAddress(to);
        System.Net.Mail.MailMessage Message = new System.Net.Mail.MailMessage(From, To);
        Message.Subject = Subject;
        Message.Body = Body;
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(str);
        client.EnableSsl = Convert.ToBoolean(state);
        client.Credentials = new System.Net.NetworkCredential(from, fromPwd);
        client.Send(Message);
    }
}