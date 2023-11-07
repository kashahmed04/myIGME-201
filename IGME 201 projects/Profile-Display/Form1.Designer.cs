namespace Profile_Display
{
    partial class DisplayProfile
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
            this.photoGroupBox = new System.Windows.Forms.GroupBox();
            this.photoPictureBox = new System.Windows.Forms.PictureBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.bioLabel = new System.Windows.Forms.Label();
            this.dmButton = new System.Windows.Forms.Button();
            this.statsListView = new System.Windows.Forms.ListView();
            this.gameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rankHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.matchupHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gpa_specHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.photoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // photoGroupBox
            // 
            this.photoGroupBox.Controls.Add(this.photoPictureBox);
            this.photoGroupBox.Location = new System.Drawing.Point(13, 13);
            this.photoGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.photoGroupBox.Name = "photoGroupBox";
            this.photoGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.photoGroupBox.Size = new System.Drawing.Size(388, 319);
            this.photoGroupBox.TabIndex = 53;
            this.photoGroupBox.TabStop = false;
            this.photoGroupBox.Enter += new System.EventHandler(this.photoGroupBox_Enter);
            // 
            // photoPictureBox
            // 
            this.photoPictureBox.BackColor = System.Drawing.Color.LightGray;
            this.photoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoPictureBox.Location = new System.Drawing.Point(4, 19);
            this.photoPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.photoPictureBox.Name = "photoPictureBox";
            this.photoPictureBox.Size = new System.Drawing.Size(380, 296);
            this.photoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.photoPictureBox.TabIndex = 0;
            this.photoPictureBox.TabStop = false;
            // 
            // usernameLabel
            // 
            this.usernameLabel.Location = new System.Drawing.Point(424, 66);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(236, 41);
            this.usernameLabel.TabIndex = 54;
            this.usernameLabel.Text = "usernameLabel";
            this.usernameLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // bioLabel
            // 
            this.bioLabel.Location = new System.Drawing.Point(424, 146);
            this.bioLabel.Name = "bioLabel";
            this.bioLabel.Size = new System.Drawing.Size(475, 126);
            this.bioLabel.TabIndex = 55;
            this.bioLabel.Text = "bioLabel";
            // 
            // dmButton
            // 
            this.dmButton.Location = new System.Drawing.Point(17, 416);
            this.dmButton.Name = "dmButton";
            this.dmButton.Size = new System.Drawing.Size(380, 70);
            this.dmButton.TabIndex = 56;
            this.dmButton.Text = "Message";
            this.dmButton.UseVisualStyleBackColor = true;
            this.dmButton.Click += new System.EventHandler(this.dmButton_Click);
            // 
            // statsListView
            // 
            this.statsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.gameHeader,
            this.timeHeader,
            this.rankHeader,
            this.matchupHeader,
            this.gpa_specHeader});
            this.statsListView.FullRowSelect = true;
            this.statsListView.GridLines = true;
            this.statsListView.HideSelection = false;
            this.statsListView.Location = new System.Drawing.Point(450, 297);
            this.statsListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statsListView.MultiSelect = false;
            this.statsListView.Name = "statsListView";
            this.statsListView.Size = new System.Drawing.Size(399, 226);
            this.statsListView.TabIndex = 57;
            this.statsListView.UseCompatibleStateImageBehavior = false;
            this.statsListView.View = System.Windows.Forms.View.Details;
            this.statsListView.SelectedIndexChanged += new System.EventHandler(this.statsListView_SelectedIndexChanged);
            // 
            // gameHeader
            // 
            this.gameHeader.Text = "Games";
            this.gameHeader.Width = 185;
            // 
            // timeHeader
            // 
            this.timeHeader.Text = "Time";
            this.timeHeader.Width = 100;
            // 
            // rankHeader
            // 
            this.rankHeader.Text = "Rank";
            this.rankHeader.Width = 110;
            // 
            // matchupHeader
            // 
            this.matchupHeader.Text = "Matchup %";
            this.matchupHeader.Width = 107;
            // 
            // gpa_specHeader
            // 
            this.gpa_specHeader.Text = "get rid";
            this.gpa_specHeader.Width = 440;
            // 
            // DisplayProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 588);
            this.Controls.Add(this.statsListView);
            this.Controls.Add(this.dmButton);
            this.Controls.Add(this.bioLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.photoGroupBox);
            this.Name = "DisplayProfile";
            this.Text = "DisplayProfile";
            this.photoGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox photoGroupBox;
        private System.Windows.Forms.PictureBox photoPictureBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label bioLabel;
        private System.Windows.Forms.Button dmButton;
        private System.Windows.Forms.ListView statsListView;
        private System.Windows.Forms.ColumnHeader gameHeader;
        private System.Windows.Forms.ColumnHeader timeHeader;
        private System.Windows.Forms.ColumnHeader rankHeader;
        private System.Windows.Forms.ColumnHeader matchupHeader;
        private System.Windows.Forms.ColumnHeader gpa_specHeader;
    }
}

