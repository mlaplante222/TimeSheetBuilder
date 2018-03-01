using System;
using System.Windows.Forms;

namespace TimeSheetBuilder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadDefaultValues();
        }

        private DateTime getThisMonday()
        {
            var today = DateTime.Today;
            var numberOfDaysBack = 0;
            switch (today.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    numberOfDaysBack = -4;
                    break;
                case DayOfWeek.Thursday:
                    numberOfDaysBack = -3;
                    break;
                case DayOfWeek.Wednesday:
                    numberOfDaysBack = -2;
                    break;
                case DayOfWeek.Tuesday:
                    numberOfDaysBack = -1;
                    break;
            }

            return today.AddDays(numberOfDaysBack);
        }

        private void btnBuildTimeSheet_Click(object sender, EventArgs e)
        {
            try
            {
                btnBuildTimeSheet.Enabled = false;
                saveProperties();

                var tsb = new TimeSheetBuilder();
                tsb.UpdateProgress += handleUpdateProgress;
                tsb.BuildTimeSheet(dtpPerodStart.Value.ToUniversalTime(), dtpPeriodEnd.Value.AddDays(1).AddSeconds(-1).ToUniversalTime(), txtMemberID.Text, txtStartTime.Text, txtEndTime.Text, txtLunch.Text, txtAdminCode.Text);
            }
            catch (Exception ex)
            {
                handleUpdateProgress(ex.Message);
            }
            finally
            {
                btnBuildTimeSheet.Enabled = true;
            }
        }

        private void loadDefaultValues()
        {
            dtpPerodStart.Value = DateTime.Today;
            dtpPeriodEnd.Value = DateTime.Today;
            txtMemberID.Text = Properties.Settings.Default["memberid"].ToString();
            txtStartTime.Text = Properties.Settings.Default["starttime"].ToString();
            txtEndTime.Text = Properties.Settings.Default["endtime"].ToString();
            txtAdminCode.Text = Properties.Settings.Default["adminchargecode"].ToString();
            txtLunch.Text = Properties.Settings.Default["lunchdeduct"].ToString();
        }

        private void saveProperties()
        {
            //if the charge code was changed, reset the recid to force it to be updated
            var currentCode = Properties.Settings.Default["adminchargecode"].ToString();
            if (txtAdminCode.Text == null || txtAdminCode.Text != currentCode)
                Properties.Settings.Default["adminchargecodeid"] = "0";

            Properties.Settings.Default["memberid"] = txtMemberID.Text;
            Properties.Settings.Default["starttime"] = txtStartTime.Text;
            Properties.Settings.Default["endtime"] = txtEndTime.Text;
            Properties.Settings.Default["adminchargecode"] = txtAdminCode.Text;
            Properties.Settings.Default["lunchdeduct"] = txtLunch.Text;
            Properties.Settings.Default.Save();
        }

        private void handleUpdateProgress(string message)
        {
            lblProgress.Text = message;
            Application.DoEvents();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpPerodStart.Value = DateTime.Today;
            dtpPeriodEnd.Value = DateTime.Today;
        }

        private void btnThisWeek_Click(object sender, EventArgs e)
        {
            dtpPerodStart.Value = getThisMonday();
            dtpPeriodEnd.Value = dtpPerodStart.Value.AddDays(4);
        }

        private void btnLastWeek_Click(object sender, EventArgs e)
        {
            dtpPerodStart.Value = getThisMonday().AddDays(-7);
            dtpPeriodEnd.Value = dtpPerodStart.Value.AddDays(4);
        }

        private void btnYesterday_Click(object sender, EventArgs e)
        {
            dtpPerodStart.Value = DateTime.Today.AddDays(-1);
            dtpPeriodEnd.Value = dtpPerodStart.Value;
        }
    }
}
