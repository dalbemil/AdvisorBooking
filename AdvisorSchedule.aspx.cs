using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Globalization;

public partial class AdvisorSchedule : System.Web.UI.Page
{
    #region Private
    WebService GetSchedule = new WebService();

    [Serializable]
    private class MergedColumnsInfo
    {
        public List<int> MergedColumns = new List<int>();
        public Hashtable StartColumns = new Hashtable();
        public Hashtable Titles = new Hashtable();

        public void AddMergedColumns(int[] columnsIndexes, string title)
        {
            MergedColumns.AddRange(columnsIndexes);
            StartColumns.Add(columnsIndexes[0], columnsIndexes.Length);
            Titles.Add(columnsIndexes[0], title);
        }
    }

    //property for storing of information about merged columns
    private MergedColumnsInfo info
    {
        get
        {
            if (ViewState["info"] == null)
                ViewState["info"] = new MergedColumnsInfo();
            return (MergedColumnsInfo)ViewState["info"];

        }
    }

    //method for rendering of columns's headers	
    private void RenderHeader(HtmlTextWriter output, Control container)
    {
        for (int i = 0; i < container.Controls.Count; i++)
        {
            TableCell cell = (TableCell)container.Controls[i];
            //stretch non merged columns for two rows
            if (!info.MergedColumns.Contains(i))
            {
                cell.Attributes["rowspan"] = "2";
                cell.RenderControl(output);
            }
            else //render merged columns's common title
                if (info.StartColumns.Contains(i))
                {
                    output.Write(string.Format("<th align='center' colspan='{0}'>{1}</th>",
                             info.StartColumns[i], info.Titles[i]));
                }
        }

        //close first row	
        output.RenderEndTag();
        //set attributes for second row
        gvAdvisorSchedule.HeaderStyle.AddAttributesToRender(output);
        //start second row
        output.RenderBeginTag("tr");

        //render second row (only merged columns)
        for (int i = 0; i < info.MergedColumns.Count; i++)
        {
            TableCell cell = (TableCell)container.Controls[info.MergedColumns[i]];
            cell.RenderControl(output);
        }
    }

    protected override void Render(HtmlTextWriter writer)
    {
        // The client events for gvAdvisorSchedule were created in gvAdvisorSchedule_RowDataBound
        foreach (GridViewRow r in gvAdvisorSchedule.Rows)
        {
            if (r.RowType == DataControlRowType.DataRow)
            {
                for (int columnIndex = _FirstEditCellIndex; columnIndex < r.Cells.Count; columnIndex++)
                {
                    Page.ClientScript.RegisterForEventValidation(r.UniqueID + "$ctl00", columnIndex.ToString());
                }
            }
        }

        base.Render(writer);
    }
    
    #endregion

    private const int _FirstEditCellIndex = 2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["AdvisorName"] = "Damion Mitchell";
            Session["AdvisorNumber"] = "102";

            //merge the second, third and fourth columns with common title "Subjects"
            info.AddMergedColumns(new int[] { 2, 3}, "8:00 AM");
            info.AddMergedColumns(new int[] { 4, 5 }, "9:00 AM");
            info.AddMergedColumns(new int[] { 6, 7 }, "10:00 AM");
            info.AddMergedColumns(new int[] { 8, 9 }, "11:00 AM");
            info.AddMergedColumns(new int[] { 10, 11 }, "12:00 PM");
            info.AddMergedColumns(new int[] { 12, 13 }, "1:00 PM");
            info.AddMergedColumns(new int[] { 14, 15 }, "2:00 PM");
            info.AddMergedColumns(new int[] { 16, 17 }, "3:00 PM");
            info.AddMergedColumns(new int[] { 18, 19 }, "4:00 PM");

            int WeeksInThisYear = GetSchedule.WeeksInYear(DateTime.Now.Year);
            for (int i = 1; i <= WeeksInThisYear; i++)
            {
                this.ddlWeek.Items.Add(i.ToString());
            }
            for (int i = 2013; i <= DateTime.Now.Year; i++)
            {
                this.ddlYear.Items.Add(i.ToString());
            }

            this.ddlWeek.Text = GetSchedule.WeekNumber(DateTime.Now).ToString();
            this.ddlYear.Text = DateTime.Now.Year.ToString();

            this.lblAdvisorName.Text = Session["AdvisorName"].ToString();
            this.lblAdvisorNumber.Text = Session["AdvisorNumber"].ToString();

            gvAdvisorSchedule.DataSource = DaysWithSlots;// AdvisorWeekSchedulesData;
            gvAdvisorSchedule.DataBind();
         
            //GetAdvisorSchedule(this.lblAdvisorNumber.Text);
        }
    }

    private DataTable DaysWithSlots
    {
        get
        {
            DataTable dtDaysWithSlots = new DataTable();
            dtDaysWithSlots.Columns.Add(new DataColumn("Day", typeof(string)));
            dtDaysWithSlots.Rows.Add(new object[] {"Monday"});
            dtDaysWithSlots.Rows.Add(new object[] {"Tuesday"});
            dtDaysWithSlots.Rows.Add(new object[] {"Wednesday"});
            dtDaysWithSlots.Rows.Add(new object[] {"Thursday"});
            dtDaysWithSlots.Rows.Add(new object[] {"Friday"});

            // Add the id column as a primary key
            DataColumn[] keys = new DataColumn[1];
            keys[0] = dtDaysWithSlots.Columns["Day"];
            dtDaysWithSlots.PrimaryKey = keys;

            return dtDaysWithSlots;
        }
    }

    private List<String> SlotsInDay
    {
        get
        {
            List<String> DaySlots = (List<String>)Session["SlotsInDay"];

            if (DaySlots == null)
            {
                DaySlots = new List<string>();

                DaySlots.Add("8:00 AM");
                DaySlots.Add("8:30 AM");
                DaySlots.Add("9:00 AM");
                DaySlots.Add("9:30 AM");
                DaySlots.Add("10:00 AM");
                DaySlots.Add("10:30 AM");
                DaySlots.Add("11:00 AM");
                DaySlots.Add("11:30 AM");
                DaySlots.Add("12:00 PM");
                DaySlots.Add("12:30 PM");
                DaySlots.Add("1:00 PM");
                DaySlots.Add("1:30 PM");
                DaySlots.Add("2:00 PM");
                DaySlots.Add("2:30 PM");
                DaySlots.Add("3:00 PM");
                DaySlots.Add("3:30 PM");
                DaySlots.Add("4:00 PM");
                DaySlots.Add("4:30 PM");
                DaySlots.Add("5:00 PM");

                SlotsInDay = DaySlots;
            }

            return DaySlots;
        }
        set
        {
            Session["SlotsInDay"] = value;
        }
    }

    public DataTable GetAdvisorSchedule(string AdvisorID, string WeekNumber, string Year)
    {
        SqlConnection sqlConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["AdvisorBookingConnectionString"].ConnectionString);
        DataTable dtAdvisorSchedule = new  DataTable();

        try
        {
            SqlCommand sCommand = new SqlCommand("GetAdvisorCurrentSchedule", sqlConnect);
            sCommand.CommandType = CommandType.StoredProcedure;
            sCommand.CommandTimeout = 30;

            sCommand.Parameters.AddWithValue("@AdvisorID", AdvisorID);
            sCommand.Parameters.AddWithValue("@Week", WeekNumber);
            sCommand.Parameters.AddWithValue("@Year", Year);

            SqlDataAdapter daAdvisorSchedule = new SqlDataAdapter(sCommand);
            daAdvisorSchedule.Fill(dtAdvisorSchedule);
        }
        catch (Exception)
        {
           dtAdvisorSchedule = null;
        }
        finally
        {
            if (sqlConnect != null)
            {
                if (sqlConnect.State == ConnectionState.Open)
                {
                    sqlConnect.Close();
                    sqlConnect.Dispose();
                    sqlConnect = null;
                }
            }
        }

        return dtAdvisorSchedule;
    }

    #region gvAdvisorSchedule

    protected void gvAdvisorSchedule_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton _singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
            string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "");

            if (Page.Validators.Count > 0)
                _jsSingle = _jsSingle.Insert(11, "if(Page_ClientValidate())");

            for (int columnIndex = _FirstEditCellIndex; columnIndex < e.Row.Cells.Count; columnIndex++)
            {
                string js = _jsSingle.Insert(_jsSingle.Length - 2, columnIndex.ToString());
                e.Row.Cells[columnIndex].Attributes["onclick"] = js;
                e.Row.Cells[columnIndex].Attributes["style"] += "cursor:pointer;cursor:hand;";

                string DayAvailable = (string)DataBinder.Eval(e.Row.DataItem, "Day");
                if (!(String.IsNullOrEmpty(DayAvailable.Trim())))
                {
                    e.Row.BackColor = System.Drawing.Color.Gray;
                    e.Row.Cells[1].Text = DayAvailable;
                    e.Row.Cells[1].BackColor = System.Drawing.Color.White;
                    double MinutesPerSlot = 30;
                    DataRow[] AvailableDays = AdvisorWeekSchedulesData.Select("Day='" + DayAvailable + "'");

                    if (AvailableDays != null)
                    {
                        DateTime StartTime,
                                 EndTime,
                                 CurrentTime;
                        int TimeSlotTableIndex = 0;

                        foreach (DataRow days in AvailableDays)
                        {
                            StartTime = Convert.ToDateTime(days["StartTime"].ToString());
                            EndTime = Convert.ToDateTime(days["EndTime"].ToString()).AddMinutes(-MinutesPerSlot);
                            CurrentTime = StartTime;
                            while (CurrentTime <= EndTime)
                            {
                                TimeSlotTableIndex = SlotsInDay.IndexOf(CurrentTime.ToShortTimeString());

                                if (TimeSlotTableIndex != -1)
                                {
                                    e.Row.Cells[TimeSlotTableIndex + 2].BackColor = System.Drawing.Color.Green;
                                }
                                else
                                {
                                    e.Row.Cells[TimeSlotTableIndex + 2].BackColor = System.Drawing.Color.Gray;
                                }

                                CurrentTime = CurrentTime.AddMinutes(MinutesPerSlot);
                            }
                        }
                    }
                }
            }
        }
    }

    protected void gvAdvisorSchedule_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        if (e.CommandName == "SingleClick")
        {
            int _rowIndex = int.Parse(e.CommandArgument.ToString());
            int _columnIndex = int.Parse(Request.Form["__EVENTARGUMENT"]);
            _gridView.SelectedIndex = _rowIndex;

            if ((_rowIndex > -1) && (_columnIndex > -1))
            {
                Session["DayIndex"] = _rowIndex;
                Session["TimeSlot"] = _columnIndex;
                Response.Redirect("~/AdvisorAvailability.aspx");
            }
        }
    }

    protected void gvAdvisorSchedule_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.SetRenderMethodDelegate(RenderHeader);
        }
    }

    protected void ddlWeek_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["Week"].ToString().Trim() != this.ddlWeek.SelectedValue.ToString().Trim())
        {
            Session["AdvisorSchedules"] = null;
            gvAdvisorSchedule.DataSource = DaysWithSlots;
            gvAdvisorSchedule.DataBind();
        }
    }

    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["Year"].ToString().Trim() != this.ddlYear.SelectedValue.ToString().Trim())
        {
            Session["AdvisorSchedules"] = null;
            gvAdvisorSchedule.DataSource = DaysWithSlots;
            gvAdvisorSchedule.DataBind();
        }
    }
    
    #endregion

    #region Advisor Schedule Data

    /// <summary>
    /// Property to manage data
    /// </summary>
    private DataTable AdvisorWeekSchedulesData
    {
        get
        {
            DataTable dtAdvisorSchedules = (DataTable)Session["AdvisorSchedules"];
            if (dtAdvisorSchedules == null)
            {
                //dtAdvisorSchedules = GetAdvisorSchedule(this.lblAdvisorNumber.Text, this.ddlWeek.SelectedValue.ToString(), this.ddlYear.SelectedValue.ToString());
                dtAdvisorSchedules = GetSchedule.GetAdvisorSchedule(this.lblAdvisorNumber.Text, this.ddlWeek.SelectedValue.ToString(), this.ddlYear.SelectedValue.ToString());

                DataColumn colIsDeleted = new DataColumn("IsDeleted", typeof(bool));
                colIsDeleted.DefaultValue  = false;
                dtAdvisorSchedules.Columns.Add(colIsDeleted);

                DataColumn colIsNew = new DataColumn("IsNew", typeof(bool));
                colIsDeleted.DefaultValue = false;
                dtAdvisorSchedules.Columns.Add(colIsNew);

                DataColumn colIsAltered = new DataColumn("IsAltered", typeof(bool));
                colIsDeleted.DefaultValue = false;
                dtAdvisorSchedules.Columns.Add(colIsAltered);

                foreach (DataRow drSchudule in dtAdvisorSchedules.Rows)
                {
                    drSchudule["IsDeleted"] = false;
                    drSchudule["IsNew"] = false;
                    drSchudule["IsAltered"] = false;
                    dtAdvisorSchedules.AcceptChanges();
                }

                AdvisorWeekSchedulesData = dtAdvisorSchedules;

                Session["Week"] = this.ddlWeek.SelectedValue.ToString();
                Session["Year"] = this.ddlYear.SelectedValue.ToString();
            }

            return dtAdvisorSchedules;
        }
        set
        {
            Session["AdvisorSchedules"] = value;
        }
    }

    #endregion    
}