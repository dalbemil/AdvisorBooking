using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdvisorAvailability : System.Web.UI.Page
{
    //private const int _FirstEditCellIndex = 1;
    string gvUniqueID = String.Empty;
    //string SelectedDay = String.Empty;
    int gvEditIndex = -1;
    WebService GetSchedule = new WebService();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.lblAdvisorName.Text = Session["AdvisorName"].ToString();
            this.lblAdvisorNumber.Text = Session["AdvisorNumber"].ToString();

            int WeeksInThisYear = GetSchedule.WeeksInYear(DateTime.Now.Year);
            for (int i = 1; i <= WeeksInThisYear; i++)
            {
                this.ddlWeek.Items.Add(i.ToString());
            }
            for (int i = 2013; i <= DateTime.Now.Year; i++)
            {
                this.ddlYear.Items.Add(i.ToString());
            }

            this.ddlWeek.Text = Session["Week"].ToString();
            this.ddlYear.Text = Session["Year"].ToString();
        }

        gvAdvisorSetSchedule.DataSource = DaysWithSlots;
        gvAdvisorSetSchedule.DataBind();

    }

    #region gvAdvisorSchedule

    protected void gvAdvisorSetSchedule_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string SelectedDay = (string)DataBinder.Eval(e.Row.DataItem, "Day");


            if (!(String.IsNullOrEmpty(SelectedDay.Trim())))
            {
                GridViewRow row = e.Row;
                string strSort = string.Empty;

                // Make sure we aren't in header/footer rows
                if (row.DataItem == null)
                {
                    return;
                }

                //Find Child GridView control
                GridView gv = new GridView();
                gv = (GridView)row.FindControl("gvTimeSlotsAvailable");

                //Check if any additional conditions (Paging, Sorting, Editing, etc) to be applied on child GridView
                if (gv.UniqueID == gvUniqueID)
                {
                    gv.EditIndex = gvEditIndex;
                    ClientScript.RegisterStartupScript(GetType(), "Expand", "<SCRIPT LANGUAGE='javascript'>expandcollapse('div" + ((DataRowView)e.Row.DataItem)["Day"].ToString() + "','one');</script>");
                }

                DataTable dtDaySchedules = GetDailyAdvisorSchedule(SelectedDay);
                gv.DataSource = GetDailyAdvisorSchedule(SelectedDay);
                gv.DataBind();

                //double MinutesPerSlot = 30;
                //DataRow[] AvailableDays = (dtDaySchedules != null) ? dtDaySchedules.Copy().Select("Day='" + SelectedDay + "' AND IsDeleted=0") : null;

                //foreach (GridViewRow gvr in gv.Rows)
                //{
                //    if (AvailableDays != null)
                //    {
                //        DateTime StartTime,
                //                 EndTime,
                //                 CurrentTime;
                //        int TimeSlotTableIndex = 0;

                //        foreach (DataRow days in AvailableDays)
                //        {
                //            List<String> lstAdvisorTimeSlots = new List<string>();
                //            StartTime = Convert.ToDateTime(days["StartTime"].ToString());
                //            EndTime = Convert.ToDateTime(days["EndTime"].ToString()).AddMinutes(-MinutesPerSlot);

                //            CurrentTime = StartTime;
                //            while (CurrentTime <= EndTime)
                //            {
                //                lstAdvisorTimeSlots.Add(CurrentTime.ToString("hh:mm tt"));
                //                CurrentTime = CurrentTime.AddMinutes(MinutesPerSlot);
                //            }

                //            DateTime DayStartTime = Convert.ToDateTime("8:00 AM");
                //            DateTime DayEndTime = Convert.ToDateTime("5:00 PM");
                //            DayEndTime = DayEndTime.AddMinutes(-MinutesPerSlot);

                //            CurrentTime = DayStartTime;
                //            while (CurrentTime <= DayEndTime)
                //            {
                //                ListItem timeSlot = new ListItem(CurrentTime.ToString("hh:mm tt"));
                //                ListItem timeEndSlot = new ListItem(CurrentTime.ToString("hh:mm tt"));

                //                //if (ddtStartTime != null && ddtEndTime != null)
                //                //{
                //                //    if (!(ddtStartTime.Items.Contains(timeSlot)))
                //                //    {
                //                //        ddtStartTime.Items.Add(timeSlot);
                //                //        ddtEndTime.Items.Add(timeEndSlot);
                //                //    }
                //                //}

                //                TimeSlotTableIndex = lstAdvisorTimeSlots.IndexOf(CurrentTime.ToShortTimeString());
                //                if (TimeSlotTableIndex == -1)
                //                {
                //                    //ListItem timeFooterSlot = new ListItem(CurrentTime.ToString("hh:mm tt"));
                //                    //ListItem timeFooterEndSlot = new ListItem(CurrentTime.ToString("hh:mm tt"));

                //                    //if (!(ddlFooterStartTime.Items.Contains(timeSlot)))
                //                    //{
                //                    //    ddlFooterStartTime.Items.Add(timeFooterSlot);
                //                    //    ddlFooterEndTime.Items.Add(timeFooterEndSlot);
                //                    //}
                //                }

                //                CurrentTime = CurrentTime.AddMinutes(MinutesPerSlot);
                //            }
                //        }

                //        //if (ddtStartTime != null && ddtEndTime != null)
                //        //{
                //        //    string AdvisorScheduleID = ((Label)gv.Rows[gvEditIndex].Cells[1].FindControl("lblAdvisorScheduleID")).Text;
                //        //    DataRow[] getScheduleTimes = dtSampleData.Copy().Select("AdvisorScheduleID=" + AdvisorScheduleID + "");

                //        //    if (getScheduleTimes != null)
                //        //    {
                //        //        ddtStartTime.Text = Convert.ToDateTime(getScheduleTimes[0]["StartTime"].ToString()).ToString("hh:mm tt");
                //        //        ddtEndTime.Text = Convert.ToDateTime(getScheduleTimes[0]["EndTime"].ToString()).ToString("hh:mm tt");
                //        //    }
                //        //}
                //    }
                //}
            }
        }
    }

    private DataTable GetDailyAdvisorSchedule(string Day)
    {
        DataTable dtDaySchedule = null;

        try
        {
            dtDaySchedule = AdvisorWeekSchedulesData.Select("Day='" + Day + "' AND IsDeleted=0").CopyToDataTable();
        }
        catch (Exception)
        {
            dtDaySchedule = null;
        }

        return dtDaySchedule;
    }

    protected void gvTimeSlotsAvailable_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((DataRowView)e.Row.DataItem)["Day"].ToString() == String.Empty)
            {
                e.Row.Visible = false;
            }
        }
    }

    protected void btnEditSchedule_Click(object sender, EventArgs e)
    {
        ImageButton btnEditSchedule = sender as ImageButton;
        GridViewRow row = (GridViewRow)btnEditSchedule.NamingContainer;

        GridViewRow gvMasterRow = (GridViewRow)row.Parent.Parent.Parent.Parent;
        gvUniqueID = row.UniqueID;

        string DaySelected = ((Label)(gvAdvisorSetSchedule.Rows[gvMasterRow.RowIndex].FindControl("lblDay"))).Text;
        string AdvisorScheduleID = ((Label)row.FindControl("lblAdvisorScheduleID")).Text;

        double MinutesPerSlot = 30;
        DataRow[] getScheduleTimes = AdvisorWeekSchedulesData.Copy().Select("AdvisorScheduleID=" + AdvisorScheduleID + "");

        List<String> lstAdvisorTimeSlots = new List<string>();
        DateTime StartTime = Convert.ToDateTime(getScheduleTimes[0]["StartTime"].ToString());
        DateTime EndTime = Convert.ToDateTime(getScheduleTimes[0]["EndTime"].ToString()).AddMinutes(-MinutesPerSlot);

        DateTime CurrentTime = StartTime;

        DateTime DayStartTime = Convert.ToDateTime("8:00 AM");
        DateTime DayEndTime = Convert.ToDateTime("5:00 PM");
        DayEndTime = DayEndTime.AddMinutes(-MinutesPerSlot);

        CurrentTime = DayStartTime;
        ddlStartTime.Items.Clear();
        ddlEndTime.Items.Clear();

        while (CurrentTime <= DayEndTime)
        {
            ListItem timeSlot = new ListItem(CurrentTime.ToString("hh:mm tt"));
            ListItem timeEndSlot = new ListItem(CurrentTime.ToString("hh:mm tt"));

            if (!(ddlStartTime.Items.Contains(timeSlot)))
            {
                ddlStartTime.Items.Add(timeSlot);
                ddlEndTime.Items.Add(timeEndSlot);
            }

            CurrentTime = CurrentTime.AddMinutes(MinutesPerSlot);
        }

        if (getScheduleTimes != null)
        {
            this.ddlStartTime.Text = StartTime.ToString("hh:mm tt");
            this.ddlEndTime.Text = EndTime.AddMinutes(MinutesPerSlot).ToString("hh:mm tt");
        }

        this.lbAdvisorScheduleID.Text = AdvisorScheduleID;
        lblDayName.Text = DaySelected;
        this.lblDate.Text = GetSchedule.DayInWeekDate(DaySelected, Convert.ToInt32(ddlWeek.Text.ToString()), Convert.ToInt32(ddlYear.Text.ToString())).ToString("dd-MMM-yyyy");

        this.btnSave.Visible = (Convert.ToInt32(GetSchedule.WeekNumber(DateTime.Now).ToString()) > Convert.ToInt32(this.ddlWeek.SelectedValue.ToString().Trim())) ? true : false;
        if (this.btnSave.Visible == true)
        {
            this.btnSave.Visible = (DateTime.Now.Year >= Convert.ToInt32(this.ddlYear.SelectedValue.ToString().Trim())) ? false : true;
        }

        mpeScheduleMaintenance.Show(); //show the modal popup extender
    }

    protected void btnNewSchedule_Click(object sender, EventArgs e)
    {
        Button btnNewSchedule = sender as Button;
        GridViewRow row = (GridViewRow)btnNewSchedule.NamingContainer;
        gvUniqueID = row.UniqueID;

        GridViewRow gvMasterRow = (GridViewRow)row.Parent.Parent;
        string DaySelected = ((Label)(gvAdvisorSetSchedule.Rows[row.RowIndex].FindControl("lblDay"))).Text;

        double MinutesPerSlot = 30;
        DateTime CurrentTime;
        DataRow[] AvailableDays = AdvisorWeekSchedulesData.Copy().Select("Day='" + DaySelected + "'");

        List<String> lstAdvisorTimeSlots = new List<string>();

        foreach (DataRow days in AvailableDays)
        {
            DateTime StartTime = Convert.ToDateTime(days["StartTime"].ToString());
            DateTime EndTime = Convert.ToDateTime(days["EndTime"].ToString()).AddMinutes(-MinutesPerSlot);

            CurrentTime = StartTime;
            while (CurrentTime <= EndTime)
            {
                lstAdvisorTimeSlots.Add(CurrentTime.ToString("hh:mm tt"));
                CurrentTime = CurrentTime.AddMinutes(MinutesPerSlot);
            }
        }

        DateTime DayStartTime = Convert.ToDateTime("8:00 AM");
        DateTime DayEndTime = Convert.ToDateTime("5:00 PM");
        DayEndTime = DayEndTime.AddMinutes(-MinutesPerSlot);

        CurrentTime = DayStartTime;
        ddlStartTime.Items.Clear();
        ddlEndTime.Items.Clear();

        while (CurrentTime <= DayEndTime)
        {
            if ((lstAdvisorTimeSlots.IndexOf(CurrentTime.ToShortTimeString())) == -1)
            {
                ListItem timeSlot = new ListItem(CurrentTime.ToString("hh:mm tt"));
                ListItem timeEndSlot = new ListItem(CurrentTime.ToString("hh:mm tt"));

                if (!(ddlStartTime.Items.Contains(timeSlot)))
                {
                    ddlStartTime.Items.Add(timeSlot);
                    ddlEndTime.Items.Add(timeEndSlot);
                }
            }

            CurrentTime = CurrentTime.AddMinutes(MinutesPerSlot);
        }

        this.lbAdvisorScheduleID.Text = "-1"; ;
        lblDayName.Text = DaySelected;
        this.lblDate.Text = GetSchedule.DayInWeekDate(DaySelected, Convert.ToInt32(ddlWeek.Text.ToString()), Convert.ToInt32(ddlYear.Text.ToString())).ToString("dd-MMM-yyyy");

        this.btnSave.Visible = (Convert.ToInt32(GetSchedule.WeekNumber(DateTime.Now).ToString()) > Convert.ToInt32(this.ddlWeek.SelectedValue.ToString().Trim())) ? false : true;
        if (this.btnSave.Visible == true)
        {
            this.btnSave.Visible = (DateTime.Now.Year >= Convert.ToInt32(this.ddlYear.SelectedValue.ToString().Trim())) ? true : false;
        }

        mpeScheduleMaintenance.Show(); //show the modal popup extender
    }

    protected void btnDeleteSchedule_Click(object sender, EventArgs e)
    {
        try
        {
            ImageButton btnDeleteSchedule = sender as ImageButton;
            GridViewRow row = (GridViewRow)btnDeleteSchedule.NamingContainer;
            gvUniqueID = row.UniqueID;

            GridViewRow gvMasterRow = (GridViewRow)row.Parent.Parent.Parent.Parent;
            string DaySelected = ((Label)(gvAdvisorSetSchedule.Rows[gvMasterRow.RowIndex].FindControl("lblDay"))).Text;
            Int32 AdvisorScheduleID = Convert.ToInt32(((Label)row.FindControl("lblAdvisorScheduleID")).Text);

            DataTable AdvisorScheduleTable = AdvisorWeekSchedulesData;

            foreach (DataRow drSchudule in AdvisorScheduleTable.Rows)
            {
                if (((Int32)drSchudule["AdvisorScheduleID"] == AdvisorScheduleID) && (drSchudule["Day"].ToString() == DaySelected))
                {
                    // drSchudule.Delete();
                    drSchudule["IsDeleted"] = true;
                    drSchudule["IsNew"] = false;
                    drSchudule["IsAltered"] = false;
                    AdvisorWeekSchedulesData.AcceptChanges();
                    break;
                }
            }

            mpeScheduleMaintenance.Hide();
            gvAdvisorSetSchedule.DataSource = DaysWithSlots;
            gvAdvisorSetSchedule.DataBind();

            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Time Slots added Successfully');</script>");
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
        }
    }

    protected void btnSaveSchedule_Click(object sender, EventArgs e)
    {
        try
        {
            string AdvisorScheduleID = lbAdvisorScheduleID.Text;
            string StartTime = ddlStartTime.Text;
            string EndTime = ddlEndTime.Text;

            if (Convert.ToInt32(this.lbAdvisorScheduleID.Text) != -1)
            {
                DataRow[] dtSampleData = AdvisorWeekSchedulesData.Select("AdvisorScheduleID='" + AdvisorScheduleID + "'");
                dtSampleData[0]["Day"] = this.lblDayName.Text;
                dtSampleData[0]["StartTime"] = Convert.ToDateTime(StartTime).ToString("H:mm:ss");
                dtSampleData[0]["EndTime"] = Convert.ToDateTime(EndTime).ToString("H:mm:ss");
                dtSampleData[0]["IsDeleted"] = false;
                dtSampleData[0]["IsNew"] = false;
                dtSampleData[0]["IsAltered"] = true;
                AdvisorWeekSchedulesData.AcceptChanges();
            }
            else
            {
                DataRow newAdvisorSchedule = AdvisorWeekSchedulesData.NewRow();
                newAdvisorSchedule["Day"] = this.lblDayName.Text;
                newAdvisorSchedule["StartTime"] = Convert.ToDateTime(StartTime).ToString("H:mm:ss");
                newAdvisorSchedule["EndTime"] = Convert.ToDateTime(EndTime).ToString("H:mm:ss");
                newAdvisorSchedule["Week"] = this.ddlWeek.Text;
                newAdvisorSchedule["Year"] = this.ddlYear.Text;
                newAdvisorSchedule["AdvisorScheduleID"] = "-1";
                newAdvisorSchedule["IsDeleted"] = false;
                newAdvisorSchedule["IsNew"] = true;
                newAdvisorSchedule["IsAltered"] = false;
                AdvisorWeekSchedulesData.Rows.Add(newAdvisorSchedule);
            }

            mpeScheduleMaintenance.Hide();
            gvAdvisorSetSchedule.DataSource = DaysWithSlots;
            gvAdvisorSetSchedule.DataBind();

            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Time Slots added Successfully');</script>");
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
        }
    }

    protected void btnCancelSchedule_Click(object sender, EventArgs e)
    {
        mpeScheduleMaintenance.Hide();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection sqlConnect = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AdvisorBookingConnectionString"].ConnectionString);
        System.Data.DataSet ds = new System.Data.DataSet();

        try
        {
            DataTable AdvisorScheduleTable = AdvisorWeekSchedulesData;
            sqlConnect.Open();

            System.Data.SqlClient.SqlCommand sCommand = new System.Data.SqlClient.SqlCommand("SaveAdvisorSchedule", sqlConnect);
            sCommand.CommandType = CommandType.StoredProcedure;
            sCommand.CommandTimeout = 30;

            sCommand.Parameters.AddWithValue("@AdvisorNumber", this.lblAdvisorNumber.Text);
            System.Data.SqlClient.SqlParameter pAdvisorScheduleDetails = sCommand.Parameters.AddWithValue("@SaveAdvisorSchedule", AdvisorScheduleTable);
            pAdvisorScheduleDetails.SqlDbType = SqlDbType.Structured;
            pAdvisorScheduleDetails.TypeName = "dbo.AdvisorSchedulesType";

            sCommand.ExecuteNonQuery();

            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Advisor Schedules saved successfully');</script>");
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
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
    }

    #endregion

    private DataTable DaysWithSlots
    {
        get
        {
            DataTable dtDaysWithSlots = new DataTable();
            dtDaysWithSlots.Columns.Add(new DataColumn("Day", typeof(string)));
            dtDaysWithSlots.Rows.Add(new object[] { "Monday" });
            dtDaysWithSlots.Rows.Add(new object[] { "Tuesday" });
            dtDaysWithSlots.Rows.Add(new object[] { "Wednesday" });
            dtDaysWithSlots.Rows.Add(new object[] { "Thursday" });
            dtDaysWithSlots.Rows.Add(new object[] { "Friday" });

            // Add the id column as a primary key
            DataColumn[] keys = new DataColumn[1];
            keys[0] = dtDaysWithSlots.Columns["Day"];
            dtDaysWithSlots.PrimaryKey = keys;

            return dtDaysWithSlots;
        }
    }

    public DataTable DaysInWeek()
    {
        DataTable dtDaysWithSlots = new DataTable();
        dtDaysWithSlots.Columns.Add(new DataColumn("Day", typeof(string)));
        dtDaysWithSlots.Rows.Add(new object[] { "Monday" });
        dtDaysWithSlots.Rows.Add(new object[] { "Tuesday" });
        dtDaysWithSlots.Rows.Add(new object[] { "Wednesday" });
        dtDaysWithSlots.Rows.Add(new object[] { "Thursday" });
        dtDaysWithSlots.Rows.Add(new object[] { "Friday" });

        // Add the id column as a primary key
        DataColumn[] keys = new DataColumn[1];
        keys[0] = dtDaysWithSlots.Columns["Day"];
        dtDaysWithSlots.PrimaryKey = keys;

        return dtDaysWithSlots;
    }

    #region Sample Data

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
                colIsDeleted.DefaultValue = false;
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

    protected void ddlWeek_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["Week"].ToString().Trim() != this.ddlWeek.SelectedValue.ToString().Trim())
        {
            Session["AdvisorSchedules"] = null;
            this.gvAdvisorSetSchedule.DataSource = DaysWithSlots;
            gvAdvisorSetSchedule.DataBind();

            if (Convert.ToInt32(GetSchedule.WeekNumber(DateTime.Now).ToString()) >= Convert.ToInt32(this.ddlWeek.SelectedValue.ToString().Trim()))
            {
                ControlsVisible(false);
            }
            else
            {
                ControlsVisible(true);
            }
        }
    }

    private void ControlsVisible(bool isEnabled)
    {
        foreach (GridViewRow row in gvAdvisorSetSchedule.Rows)
        {
            ((Button)row.FindControl("btnNewSchedule")).Visible = isEnabled;

            //Find Child GridView control
            GridView gv = new GridView();
            gv = (GridView)row.FindControl("gvTimeSlotsAvailable");

            foreach (GridViewRow gvr in gv.Rows)
            {
                // Selects the text from the TextBox which is inside the GridView control
                ((ImageButton)gvr.FindControl("btnEditSchedule")).Visible = isEnabled;
                ((ImageButton)gvr.FindControl("btnDeleteSchedule")).Visible = isEnabled;
            }
        }
    }

    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["Year"].ToString().Trim() != this.ddlYear.SelectedValue.ToString().Trim())
        {
            Session["AdvisorSchedules"] = null;
            gvAdvisorSetSchedule.DataSource = DaysWithSlots;
            gvAdvisorSetSchedule.DataBind();
        }
    }


    #endregion

}