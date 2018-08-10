using System;
using System.Drawing;
using System.Windows.Forms;

namespace TimeSheetBuilder
{
    public partial class Form1 : Form
    {
        private bool drag = false;
        private Point startPoint = new Point(0, 0);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkApiKeys();
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

        private void checkApiKeys()
        {
            var hVUKBayRaFJRSjL = Properties.Settings.Default["hVUKBayRaFJRSjL"].ToString();
            var XmgJQbghcPMmtta = Properties.Settings.Default["XmgJQbghcPMmtta"].ToString();
            if(string.IsNullOrEmpty(hVUKBayRaFJRSjL) || string.IsNullOrEmpty(XmgJQbghcPMmtta))
            {
                tableLayoutPanel2.BringToFront();
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

        private void btnUpdateKeys_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["XmgJQbghcPMmtta"] = txtXmgJQbghcPMmtta.Text;
            Properties.Settings.Default["hVUKBayRaFJRSjL"] = txthVUKBayRaFJRSjL.Text;
            Properties.Settings.Default.Save();
            tableLayoutPanel2.SendToBack();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void pnlTop_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var XmgJQbghcPMmtta = Properties.Settings.Default["XmgJQbghcPMmtta"].ToString();
            var hVUKBayRaFJRSjL = Properties.Settings.Default["hVUKBayRaFJRSjL"].ToString();

            txthVUKBayRaFJRSjL.Text = hVUKBayRaFJRSjL;
            txtXmgJQbghcPMmtta.Text = XmgJQbghcPMmtta;
            if (!string.IsNullOrEmpty(XmgJQbghcPMmtta) && !string.IsNullOrEmpty(hVUKBayRaFJRSjL))
                btnCancelKeys.Enabled = true;

            tableLayoutPanel2.BringToFront();
        }

        private void btnCancelKeys_Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.SendToBack();
        }
    }
}
