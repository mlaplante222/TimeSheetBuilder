using System;
using System.Diagnostics;
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
            Cryptography.CheckConfigEncryption();
            checkApiKeys();
            loadDefaultValues();
        }

        private DateTime getThisMonday()
        {
            var today = DateTime.Today;
            while (today.DayOfWeek != DayOfWeek.Monday)
            {
                today = today.AddDays(-1);
            }

            return today;
        }

        private void btnBuildTimeSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkRequiredFields())
                    return;

                btnBuildTimeSheet.Enabled = false;
                saveProperties();

                var tsb = new TimeSheetBuilder();
                tsb.ShowMessage += handleShowMessage;
                tsb.BuildTimeSheet(dtpPeriodStart.Value.ToUniversalTime(), dtpPeriodEnd.Value.AddDays(1).AddSeconds(-1).ToUniversalTime(), txtMemberID.Text, txtStartTime.Text, txtEndTime.Text, txtLunch.Text, txtAdminCode.Text);
            }
            catch (Exception ex)
            {
                handleShowMessage(ex.Message, true);
            }
            finally
            {
                btnBuildTimeSheet.Enabled = true;
            }
        }

        private bool checkRequiredFields()
        {
            if (string.IsNullOrEmpty(txtMemberID.Text))
            {
                handleShowMessage("Member ID is required.", true);
                return false;
            }
            if (dtpPeriodStart.Value <= DateTime.MinValue)
            {
                handleShowMessage("Period Start is required.", true);
                return false;
            }
            if (dtpPeriodEnd.Value <= DateTime.MinValue)
            {
                handleShowMessage("Period End is required.", true);
                return false;
            }
            if (dtpPeriodEnd.Value < dtpPeriodStart.Value)
            {
                handleShowMessage("Start Date must be before End Date.", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtAdminCode.Text))
            {
                handleShowMessage("Admin Code is required.", true);
                return false;
            }
            if (txtStartTime.Text == "  :")
            {
                handleShowMessage("Start Time is required.", true);
                return false;
            }
            if (txtEndTime.Text == "  :")
            {
                handleShowMessage("End Time is required.", true);
                return false;
            }

            return true;
        }

        private void checkApiKeys()
        {
            try
            {
                var hVUKBayRaFJRSjL = ConfigSettings.GetValue("hVUKBayRaFJRSjL");
                var XmgJQbghcPMmtta = ConfigSettings.GetValue("XmgJQbghcPMmtta");
                if (string.IsNullOrEmpty(hVUKBayRaFJRSjL) || string.IsNullOrEmpty(XmgJQbghcPMmtta))
                {
                    tableLayoutPanel2.BringToFront();
                }    
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }
        }

        private void loadDefaultValues()
        {
            dtpPeriodStart.Value = DateTime.Today;
            dtpPeriodEnd.Value = DateTime.Today;
            txtMemberID.Text = ConfigSettings.GetValue("memberid");
            txtStartTime.Text = ConfigSettings.GetValue("starttime");
            txtEndTime.Text = ConfigSettings.GetValue("endtime");
            txtAdminCode.Text = ConfigSettings.GetValue("adminchargecode");
            txtLunch.Text = ConfigSettings.GetValue("lunchdeduct");
        }

        private void saveProperties()
        {
            //if the charge code was changed, reset the recid to force it to be updated
            var currentCode = ConfigSettings.GetValue("adminchargecode");
            if (txtAdminCode.Text == null || txtAdminCode.Text != currentCode)
                ConfigSettings.SetValue("adminchargecodeid", "0");

            ConfigSettings.SetValue("memberid", txtMemberID.Text);
            ConfigSettings.SetValue("starttime", txtStartTime.Text);
            ConfigSettings.SetValue("endtime", txtEndTime.Text);
            ConfigSettings.SetValue("adminchargecode", txtAdminCode.Text);
            ConfigSettings.SetValue("lunchdeduct", txtLunch.Text);
            ConfigSettings.Save();
        }

        private void handleShowMessage(string message, bool isError)
        {
            lblProgress.ForeColor = isError ? Color.Red : Color.Green;

            lblProgress.Text = message;
            Application.DoEvents();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpPeriodStart.Value = DateTime.Today;
            dtpPeriodEnd.Value = DateTime.Today;
        }

        private void btnThisWeek_Click(object sender, EventArgs e)
        {
            dtpPeriodStart.Value = getThisMonday();
            dtpPeriodEnd.Value = dtpPeriodStart.Value.AddDays(4);
        }

        private void btnLastWeek_Click(object sender, EventArgs e)
        {
            dtpPeriodStart.Value = getThisMonday().AddDays(-7);
            dtpPeriodEnd.Value = dtpPeriodStart.Value.AddDays(4);
        }

        private void btnYesterday_Click(object sender, EventArgs e)
        {
            dtpPeriodStart.Value = DateTime.Today.AddDays(-1);
            dtpPeriodEnd.Value = dtpPeriodStart.Value;
        }

        private void btnUpdateKeys_Click(object sender, EventArgs e)
        {
            ConfigSettings.SetValue("XmgJQbghcPMmtta", txtXmgJQbghcPMmtta.Text.Trim() == string.Empty ? ConfigSettings.GetValue("XmgJQbghcPMmtta") : txtXmgJQbghcPMmtta.Text);
            ConfigSettings.SetValue("hVUKBayRaFJRSjL", txthVUKBayRaFJRSjL.Text.Trim() == string.Empty ? ConfigSettings.GetValue("hVUKBayRaFJRSjL") : txthVUKBayRaFJRSjL.Text);
            ConfigSettings.Save();

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
            var hVUKBayRaFJRSjL = ConfigSettings.GetValue("hVUKBayRaFJRSjL");

            txthVUKBayRaFJRSjL.Text = hVUKBayRaFJRSjL;
            txtXmgJQbghcPMmtta.Text = "          ";
            if (!string.IsNullOrEmpty(ConfigSettings.GetValue("XmgJQbghcPMmtta").Trim()) && !string.IsNullOrEmpty(hVUKBayRaFJRSjL.Trim()))
                btnCancelKeys.Enabled = true;

            tableLayoutPanel2.BringToFront();
        }

        private void btnCancelKeys_Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.SendToBack();
        }
    }
}
