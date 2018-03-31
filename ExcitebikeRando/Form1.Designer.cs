namespace ExcitebikeRando
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
            this.cmdRandomize = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.chkColors = new System.Windows.Forms.CheckBox();
            this.lblFlags = new System.Windows.Forms.Label();
            this.txtFlags = new System.Windows.Forms.TextBox();
            this.btnNewSeed = new System.Windows.Forms.Button();
            this.lblSeed = new System.Windows.Forms.Label();
            this.txtSeed = new System.Windows.Forms.TextBox();
            this.btnCompareBrowse = new System.Windows.Forms.Button();
            this.lblCompareImage = new System.Windows.Forms.Label();
            this.txtCompare = new System.Windows.Forms.TextBox();
            this.btnCompare = new System.Windows.Forms.Button();
            this.lblReqChecksum = new System.Windows.Forms.Label();
            this.lblRequired = new System.Windows.Forms.Label();
            this.lblSHAChecksum = new System.Windows.Forms.Label();
            this.lblSHA = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblRomImage = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.chkBikeSpeed = new System.Windows.Forms.CheckBox();
            this.chkObstacles = new System.Windows.Forms.CheckBox();
            this.chkVSTracks = new System.Windows.Forms.CheckBox();
            this.chkVSOpponents = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboChallengeLaps = new System.Windows.Forms.ComboBox();
            this.cboExcitebikeLaps = new System.Windows.Forms.ComboBox();
            this.cboBikeSpeed = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdRandomize
            // 
            this.cmdRandomize.Location = new System.Drawing.Point(437, 248);
            this.cmdRandomize.Name = "cmdRandomize";
            this.cmdRandomize.Size = new System.Drawing.Size(96, 23);
            this.cmdRandomize.TabIndex = 154;
            this.cmdRandomize.Text = "Randomize";
            this.cmdRandomize.UseVisualStyleBackColor = true;
            this.cmdRandomize.Click += new System.EventHandler(this.cmdRandomize_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 309);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 153;
            // 
            // chkColors
            // 
            this.chkColors.AutoSize = true;
            this.chkColors.Location = new System.Drawing.Point(15, 173);
            this.chkColors.Name = "chkColors";
            this.chkColors.Size = new System.Drawing.Size(111, 17);
            this.chkColors.TabIndex = 150;
            this.chkColors.Text = "Randomize Colors";
            this.chkColors.UseVisualStyleBackColor = true;
            this.chkColors.CheckedChanged += new System.EventHandler(this.determineFlags);
            // 
            // lblFlags
            // 
            this.lblFlags.AutoSize = true;
            this.lblFlags.Location = new System.Drawing.Point(291, 113);
            this.lblFlags.Name = "lblFlags";
            this.lblFlags.Size = new System.Drawing.Size(32, 13);
            this.lblFlags.TabIndex = 148;
            this.lblFlags.Text = "Flags";
            // 
            // txtFlags
            // 
            this.txtFlags.Location = new System.Drawing.Point(329, 109);
            this.txtFlags.Name = "txtFlags";
            this.txtFlags.Size = new System.Drawing.Size(200, 20);
            this.txtFlags.TabIndex = 147;
            // 
            // btnNewSeed
            // 
            this.btnNewSeed.Location = new System.Drawing.Point(186, 109);
            this.btnNewSeed.Name = "btnNewSeed";
            this.btnNewSeed.Size = new System.Drawing.Size(86, 23);
            this.btnNewSeed.TabIndex = 139;
            this.btnNewSeed.Text = "New Seed";
            this.btnNewSeed.UseVisualStyleBackColor = true;
            this.btnNewSeed.Click += new System.EventHandler(this.btnNewSeed_Click);
            // 
            // lblSeed
            // 
            this.lblSeed.AutoSize = true;
            this.lblSeed.Location = new System.Drawing.Point(12, 113);
            this.lblSeed.Name = "lblSeed";
            this.lblSeed.Size = new System.Drawing.Size(32, 13);
            this.lblSeed.TabIndex = 146;
            this.lblSeed.Text = "Seed";
            // 
            // txtSeed
            // 
            this.txtSeed.Location = new System.Drawing.Point(69, 111);
            this.txtSeed.Name = "txtSeed";
            this.txtSeed.Size = new System.Drawing.Size(100, 20);
            this.txtSeed.TabIndex = 138;
            // 
            // btnCompareBrowse
            // 
            this.btnCompareBrowse.Location = new System.Drawing.Point(458, 33);
            this.btnCompareBrowse.Name = "btnCompareBrowse";
            this.btnCompareBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnCompareBrowse.TabIndex = 136;
            this.btnCompareBrowse.Text = "Browse";
            this.btnCompareBrowse.UseVisualStyleBackColor = true;
            // 
            // lblCompareImage
            // 
            this.lblCompareImage.AutoSize = true;
            this.lblCompareImage.Location = new System.Drawing.Point(12, 35);
            this.lblCompareImage.Name = "lblCompareImage";
            this.lblCompareImage.Size = new System.Drawing.Size(94, 13);
            this.lblCompareImage.TabIndex = 145;
            this.lblCompareImage.Text = "Comparison Image";
            // 
            // txtCompare
            // 
            this.txtCompare.Location = new System.Drawing.Point(132, 35);
            this.txtCompare.Name = "txtCompare";
            this.txtCompare.Size = new System.Drawing.Size(320, 20);
            this.txtCompare.TabIndex = 135;
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(458, 62);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 137;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            // 
            // lblReqChecksum
            // 
            this.lblReqChecksum.AutoSize = true;
            this.lblReqChecksum.Location = new System.Drawing.Point(129, 88);
            this.lblReqChecksum.Name = "lblReqChecksum";
            this.lblReqChecksum.Size = new System.Drawing.Size(241, 13);
            this.lblReqChecksum.TabIndex = 144;
            this.lblReqChecksum.Text = "8d2b8aea636a2239805c99744bf48c0b4df8d96e";
            // 
            // lblRequired
            // 
            this.lblRequired.AutoSize = true;
            this.lblRequired.Location = new System.Drawing.Point(12, 88);
            this.lblRequired.Name = "lblRequired";
            this.lblRequired.Size = new System.Drawing.Size(50, 13);
            this.lblRequired.TabIndex = 143;
            this.lblRequired.Text = "Required";
            // 
            // lblSHAChecksum
            // 
            this.lblSHAChecksum.AutoSize = true;
            this.lblSHAChecksum.Location = new System.Drawing.Point(129, 64);
            this.lblSHAChecksum.Name = "lblSHAChecksum";
            this.lblSHAChecksum.Size = new System.Drawing.Size(247, 13);
            this.lblSHAChecksum.TabIndex = 142;
            this.lblSHAChecksum.Text = "????????????????????????????????????????";
            // 
            // lblSHA
            // 
            this.lblSHA.AutoSize = true;
            this.lblSHA.Location = new System.Drawing.Point(12, 64);
            this.lblSHA.Name = "lblSHA";
            this.lblSHA.Size = new System.Drawing.Size(88, 13);
            this.lblSHA.TabIndex = 141;
            this.lblSHA.Text = "SHA1 Checksum";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(458, 7);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 134;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblRomImage
            // 
            this.lblRomImage.AutoSize = true;
            this.lblRomImage.Location = new System.Drawing.Point(12, 9);
            this.lblRomImage.Name = "lblRomImage";
            this.lblRomImage.Size = new System.Drawing.Size(86, 13);
            this.lblRomImage.TabIndex = 140;
            this.lblRomImage.Text = "Golf ROM Image";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(132, 9);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(320, 20);
            this.txtFileName.TabIndex = 133;
            // 
            // chkBikeSpeed
            // 
            this.chkBikeSpeed.AutoSize = true;
            this.chkBikeSpeed.Location = new System.Drawing.Point(15, 196);
            this.chkBikeSpeed.Name = "chkBikeSpeed";
            this.chkBikeSpeed.Size = new System.Drawing.Size(137, 17);
            this.chkBikeSpeed.TabIndex = 151;
            this.chkBikeSpeed.Text = "Randomize Bike Speed";
            this.chkBikeSpeed.UseVisualStyleBackColor = true;
            this.chkBikeSpeed.CheckedChanged += new System.EventHandler(this.determineFlags);
            // 
            // chkObstacles
            // 
            this.chkObstacles.AutoSize = true;
            this.chkObstacles.Location = new System.Drawing.Point(15, 150);
            this.chkObstacles.Name = "chkObstacles";
            this.chkObstacles.Size = new System.Drawing.Size(129, 17);
            this.chkObstacles.TabIndex = 149;
            this.chkObstacles.Text = "Randomize Obstacles";
            this.chkObstacles.UseVisualStyleBackColor = true;
            this.chkObstacles.CheckedChanged += new System.EventHandler(this.determineFlags);
            // 
            // chkVSTracks
            // 
            this.chkVSTracks.AutoSize = true;
            this.chkVSTracks.Location = new System.Drawing.Point(253, 172);
            this.chkVSTracks.Name = "chkVSTracks";
            this.chkVSTracks.Size = new System.Drawing.Size(141, 17);
            this.chkVSTracks.TabIndex = 155;
            this.chkVSTracks.Text = "VS format for track order";
            this.chkVSTracks.UseVisualStyleBackColor = true;
            this.chkVSTracks.CheckedChanged += new System.EventHandler(this.determineFlags);
            // 
            // chkVSOpponents
            // 
            this.chkVSOpponents.AutoSize = true;
            this.chkVSOpponents.Location = new System.Drawing.Point(253, 150);
            this.chkVSOpponents.Name = "chkVSOpponents";
            this.chkVSOpponents.Size = new System.Drawing.Size(182, 17);
            this.chkVSOpponents.TabIndex = 156;
            this.chkVSOpponents.Text = "VS format for opponents on track";
            this.chkVSOpponents.UseVisualStyleBackColor = true;
            this.chkVSOpponents.CheckedChanged += new System.EventHandler(this.determineFlags);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 157;
            this.label1.Text = "Challenge laps";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 158;
            this.label2.Text = "Excitebike laps";
            // 
            // cboChallengeLaps
            // 
            this.cboChallengeLaps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChallengeLaps.FormattingEnabled = true;
            this.cboChallengeLaps.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "Random",
            "Random Low (1-5)",
            "Random High (5-9)"});
            this.cboChallengeLaps.Location = new System.Drawing.Point(342, 195);
            this.cboChallengeLaps.Name = "cboChallengeLaps";
            this.cboChallengeLaps.Size = new System.Drawing.Size(121, 21);
            this.cboChallengeLaps.TabIndex = 159;
            this.cboChallengeLaps.SelectedIndexChanged += new System.EventHandler(this.determineFlags);
            // 
            // cboExcitebikeLaps
            // 
            this.cboExcitebikeLaps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExcitebikeLaps.FormattingEnabled = true;
            this.cboExcitebikeLaps.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "Random",
            "Random Low (1-5)",
            "Random High (5-9)"});
            this.cboExcitebikeLaps.Location = new System.Drawing.Point(342, 218);
            this.cboExcitebikeLaps.Name = "cboExcitebikeLaps";
            this.cboExcitebikeLaps.Size = new System.Drawing.Size(121, 21);
            this.cboExcitebikeLaps.TabIndex = 160;
            this.cboExcitebikeLaps.SelectedIndexChanged += new System.EventHandler(this.determineFlags);
            // 
            // cboBikeSpeed
            // 
            this.cboBikeSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBikeSpeed.FormattingEnabled = true;
            this.cboBikeSpeed.Items.AddRange(new object[] {
            "Very Slow",
            "Slow",
            "Normal",
            "Fast",
            "Very Fast",
            "Random",
            "Random Slow",
            "Random Fast"});
            this.cboBikeSpeed.Location = new System.Drawing.Point(104, 217);
            this.cboBikeSpeed.Name = "cboBikeSpeed";
            this.cboBikeSpeed.Size = new System.Drawing.Size(121, 21);
            this.cboBikeSpeed.TabIndex = 163;
            this.cboBikeSpeed.SelectedIndexChanged += new System.EventHandler(this.determineFlags);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 161;
            this.label4.Text = "Bike Speed";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 345);
            this.Controls.Add(this.cboBikeSpeed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboExcitebikeLaps);
            this.Controls.Add(this.cboChallengeLaps);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkVSOpponents);
            this.Controls.Add(this.chkVSTracks);
            this.Controls.Add(this.cmdRandomize);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.chkBikeSpeed);
            this.Controls.Add(this.chkColors);
            this.Controls.Add(this.chkObstacles);
            this.Controls.Add(this.lblFlags);
            this.Controls.Add(this.txtFlags);
            this.Controls.Add(this.btnNewSeed);
            this.Controls.Add(this.lblSeed);
            this.Controls.Add(this.txtSeed);
            this.Controls.Add(this.btnCompareBrowse);
            this.Controls.Add(this.lblCompareImage);
            this.Controls.Add(this.txtCompare);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.lblReqChecksum);
            this.Controls.Add(this.lblRequired);
            this.Controls.Add(this.lblSHAChecksum);
            this.Controls.Add(this.lblSHA);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblRomImage);
            this.Controls.Add(this.txtFileName);
            this.Name = "Form1";
            this.Text = "Excitebike Randomizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdRandomize;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox chkColors;
        private System.Windows.Forms.Label lblFlags;
        private System.Windows.Forms.TextBox txtFlags;
        private System.Windows.Forms.Button btnNewSeed;
        private System.Windows.Forms.Label lblSeed;
        private System.Windows.Forms.TextBox txtSeed;
        private System.Windows.Forms.Button btnCompareBrowse;
        private System.Windows.Forms.Label lblCompareImage;
        private System.Windows.Forms.TextBox txtCompare;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Label lblReqChecksum;
        private System.Windows.Forms.Label lblRequired;
        private System.Windows.Forms.Label lblSHAChecksum;
        private System.Windows.Forms.Label lblSHA;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblRomImage;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.CheckBox chkBikeSpeed;
        private System.Windows.Forms.CheckBox chkObstacles;
        private System.Windows.Forms.CheckBox chkVSTracks;
        private System.Windows.Forms.CheckBox chkVSOpponents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboChallengeLaps;
        private System.Windows.Forms.ComboBox cboExcitebikeLaps;
        private System.Windows.Forms.ComboBox cboBikeSpeed;
        private System.Windows.Forms.Label label4;
    }
}

