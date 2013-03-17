using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class AdvisorRegistration : System.Web.UI.Page
{
    Advisor advisor = new Advisor();


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
        bool correctExtension = false;
        advisor.Employee_ID = Convert.ToInt32(txtAdvisorID.Text);

        advisor.First_Name = txtFName.Text;
        advisor.Last_Name = txtLName.Text;
        advisor.Dept_ID = Convert.ToInt32(Dept_DropDownList.SelectedValue);
        advisor.EmailId = txtEmailID.Text;
        advisor.Password = txtPassword.Text;
        string saveFileName = "";

        if (FpImg.HasFile)
        {
            string fileName = FpImg.PostedFile.FileName;
            int fileSize = FpImg.PostedFile.ContentLength;
            string fileExtension = Path.GetExtension(fileName).ToLower();
            string saveFolder = "~/upload"; //Get Folder Path To Save Image
            string savePath = saveFolder + fileName + fileExtension;

            string[] extensionsAllowed = { ".jpg", ".png" };

            if (extensionsAllowed.Contains(fileExtension))
            {
                correctExtension = true;
            }
            if (correctExtension)
            {
                if (fileExtension == ".jpg" || fileExtension == ".png")
                {
                    try
                    {
                        string filePath = Server.MapPath("~/Files/Images/" + fileName);
                        FpImg.PostedFile.SaveAs(filePath);
                        saveFileName = fileName + fileExtension;

                    }
                    catch (Exception ex)
                    {

                    }

                }

            }

        }
        advisor.Image = saveFileName;
        try
        {

            advisor.SubmitValue();

            ScriptManager.RegisterStartupScript(
            this,
            this.GetType(),
            "MessageBox",
            "alert('Advisor File saved succesffuly');",
            true);
        }

        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
            this,
            this.GetType(),
            "MessageBox",
            "alert('File does not save successfully');",
            true);
        }



        clear();
    }


    public void clear()
    {
        txtFName.Text = "";

        txtLName.Text = "";
        txtAdvisorID.Text = "";

        Dept_DropDownList.ClearSelection();
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