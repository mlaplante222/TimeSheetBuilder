namespace TimeSheetBuilder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.dtpPerodStart = new System.Windows.Forms.DateTimePicker();
            this.dtpPeriodEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuildTimeSheet = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMemberID = new System.Windows.Forms.TextBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.MaskedTextBox();
            this.txtEndTime = new System.Windows.Forms.MaskedTextBox();
            this.txtAdminCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtLunch = new System.Windows.Forms.MaskedTextBox();
            this.btnLastWeek = new System.Windows.Forms.Button();
            this.btnToday = new System.Windows.Forms.Button();
            this.btnThisWeek = new System.Windows.Forms.Button();
            this.btnYesterday = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Period Start";
            // 
            // dtpPerodStart
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.dtpPerodStart, 3);
            this.dtpPerodStart.Location = new System.Drawing.Point(77, 34);
            this.dtpPerodStart.Name = "dtpPerodStart";
            this.dtpPerodStart.Size = new System.Drawing.Size(216, 20);
            this.dtpPerodStart.TabIndex = 5;
            // 
            // dtpPeriodEnd
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.dtpPeriodEnd, 3);
            this.dtpPeriodEnd.Location = new System.Drawing.Point(77, 58);
            this.dtpPeriodEnd.Name = "dtpPeriodEnd";
            this.dtpPeriodEnd.Size = new System.Drawing.Size(216, 20);
            this.dtpPeriodEnd.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Period End";
            // 
            // btnBuildTimeSheet
            // 
            this.btnBuildTimeSheet.Location = new System.Drawing.Point(224, 195);
            this.btnBuildTimeSheet.Name = "btnBuildTimeSheet";
            this.btnBuildTimeSheet.Size = new System.Drawing.Size(69, 23);
            this.btnBuildTimeSheet.TabIndex = 12;
            this.btnBuildTimeSheet.Text = "Enter Time";
            this.btnBuildTimeSheet.UseVisualStyleBackColor = true;
            this.btnBuildTimeSheet.Click += new System.EventHandler(this.btnBuildTimeSheet_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Member ID";
            // 
            // txtMemberID
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtMemberID, 3);
            this.txtMemberID.Location = new System.Drawing.Point(77, 86);
            this.txtMemberID.Name = "txtMemberID";
            this.txtMemberID.Size = new System.Drawing.Size(216, 20);
            this.txtMemberID.TabIndex = 7;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblProgress, 3);
            this.lblProgress.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblProgress.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblProgress.Location = new System.Drawing.Point(3, 192);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 30);
            this.lblProgress.TabIndex = 7;
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Start time";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "End time";
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(77, 114);
            this.txtStartTime.Mask = "00:00";
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(68, 20);
            this.txtStartTime.TabIndex = 8;
            this.txtStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStartTime.ValidatingType = typeof(System.DateTime);
            // 
            // txtEndTime
            // 
            this.txtEndTime.Location = new System.Drawing.Point(224, 114);
            this.txtEndTime.Mask = "00:00";
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(69, 20);
            this.txtEndTime.TabIndex = 9;
            this.txtEndTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEndTime.ValidatingType = typeof(System.DateTime);
            // 
            // txtAdminCode
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtAdminCode, 3);
            this.txtAdminCode.Location = new System.Drawing.Point(77, 170);
            this.txtAdminCode.Name = "txtAdminCode";
            this.txtAdminCode.Size = new System.Drawing.Size(216, 20);
            this.txtAdminCode.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Admin Code";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.58472F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.5814F));
            this.tableLayoutPanel1.Controls.Add(this.txtLunch, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpPerodStart, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtpPeriodEnd, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtMemberID, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtStartTime, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnBuildTimeSheet, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnLastWeek, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnToday, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnThisWeek, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnYesterday, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtAdminCode, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblProgress, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtEndTime, 3, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.46789F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.76147F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(298, 225);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // txtLunch
            // 
            this.txtLunch.Location = new System.Drawing.Point(77, 142);
            this.txtLunch.Mask = "00:00";
            this.txtLunch.Name = "txtLunch";
            this.txtLunch.Size = new System.Drawing.Size(68, 20);
            this.txtLunch.TabIndex = 10;
            this.txtLunch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLunch.ValidatingType = typeof(System.DateTime);
            // 
            // btnLastWeek
            // 
            this.btnLastWeek.Location = new System.Drawing.Point(3, 3);
            this.btnLastWeek.Name = "btnLastWeek";
            this.btnLastWeek.Size = new System.Drawing.Size(68, 25);
            this.btnLastWeek.TabIndex = 1;
            this.btnLastWeek.Text = "Last Week";
            this.btnLastWeek.UseVisualStyleBackColor = true;
            this.btnLastWeek.Click += new System.EventHandler(this.btnLastWeek_Click);
            // 
            // btnToday
            // 
            this.btnToday.Location = new System.Drawing.Point(151, 3);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(67, 25);
            this.btnToday.TabIndex = 3;
            this.btnToday.Text = "Today";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // btnThisWeek
            // 
            this.btnThisWeek.Location = new System.Drawing.Point(224, 3);
            this.btnThisWeek.Name = "btnThisWeek";
            this.btnThisWeek.Size = new System.Drawing.Size(70, 25);
            this.btnThisWeek.TabIndex = 4;
            this.btnThisWeek.Text = "This Week";
            this.btnThisWeek.UseVisualStyleBackColor = true;
            this.btnThisWeek.Click += new System.EventHandler(this.btnThisWeek_Click);
            // 
            // btnYesterday
            // 
            this.btnYesterday.Location = new System.Drawing.Point(77, 3);
            this.btnYesterday.Name = "btnYesterday";
            this.btnYesterday.Size = new System.Drawing.Size(68, 25);
            this.btnYesterday.TabIndex = 2;
            this.btnYesterday.Text = "Yesterday";
            this.btnYesterday.UseVisualStyleBackColor = true;
            this.btnYesterday.Click += new System.EventHandler(this.btnYesterday_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Lunch";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnBuildTimeSheet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 225);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Timesheet Builder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpPerodStart;
        private System.Windows.Forms.DateTimePicker dtpPeriodEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuildTimeSheet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMemberID;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtStartTime;
        private System.Windows.Forms.MaskedTextBox txtEndTime;
        private System.Windows.Forms.TextBox txtAdminCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnLastWeek;
        private System.Windows.Forms.Button btnThisWeek;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Button btnYesterday;
        private System.Windows.Forms.MaskedTextBox txtLunch;
        private System.Windows.Forms.Label label7;
    }
}

