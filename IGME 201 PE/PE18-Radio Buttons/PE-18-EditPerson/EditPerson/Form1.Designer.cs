namespace EditPerson
{
    partial class PersonEditForm
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
            this.components = new System.ComponentModel.Container();
            this.typeLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailText = new System.Windows.Forms.TextBox();
            this.ageLabel = new System.Windows.Forms.Label();
            this.ageText = new System.Windows.Forms.TextBox();
            this.licLabel = new System.Windows.Forms.Label();
            this.licText = new System.Windows.Forms.TextBox();
            this.specialtyLabel = new System.Windows.Forms.Label();
            this.specText = new System.Windows.Forms.TextBox();
            this.gpaLabel = new System.Windows.Forms.Label();
            this.gpaText = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.classGroupBox = new System.Windows.Forms.GroupBox();
            this.classLabel = new System.Windows.Forms.Label();
            this.freshmanRadioButton = new System.Windows.Forms.RadioButton();
            this.sophomoreRadioButton = new System.Windows.Forms.RadioButton();
            this.juniorRadioButton = new System.Windows.Forms.RadioButton();
            this.seniorRadioButton = new System.Windows.Forms.RadioButton();
            this.genderGroupBox = new System.Windows.Forms.GroupBox();
            this.themRadioButton = new System.Windows.Forms.RadioButton();
            this.herRadioButton = new System.Windows.Forms.RadioButton();
            this.himRadioButton = new System.Windows.Forms.RadioButton();
            this.photoGroupBox = new System.Windows.Forms.GroupBox();
            this.photoPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.classGroupBox.SuspendLayout();
            this.genderGroupBox.SuspendLayout();
            this.photoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // typeLabel
            // 
            this.typeLabel.BackColor = System.Drawing.Color.Transparent;
            this.typeLabel.Font = new System.Drawing.Font("MS Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.typeLabel.Location = new System.Drawing.Point(15, 26);
            this.typeLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(116, 17);
            this.typeLabel.TabIndex = 0;
            this.typeLabel.Text = "Person type:";
            // 
            // typeComboBox
            // 
            this.typeComboBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Student",
            "Teacher"});
            this.typeComboBox.Location = new System.Drawing.Point(134, 24);
            this.typeComboBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.typeComboBox.MaxDropDownItems = 2;
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(195, 25);
            this.typeComboBox.TabIndex = 0;
            // 
            // nameLabel
            // 
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Font = new System.Drawing.Font("MS Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.nameLabel.Location = new System.Drawing.Point(15, 72);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(116, 17);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name:";
            // 
            // nameText
            // 
            this.nameText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.nameText.Location = new System.Drawing.Point(134, 70);
            this.nameText.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(343, 24);
            this.nameText.TabIndex = 1;
            // 
            // emailLabel
            // 
            this.emailLabel.BackColor = System.Drawing.Color.Transparent;
            this.emailLabel.Font = new System.Drawing.Font("MS Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.emailLabel.Location = new System.Drawing.Point(15, 121);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(116, 17);
            this.emailLabel.TabIndex = 2;
            this.emailLabel.Text = "Email:";
            // 
            // emailText
            // 
            this.emailText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.emailText.Location = new System.Drawing.Point(134, 116);
            this.emailText.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(343, 24);
            this.emailText.TabIndex = 2;
            // 
            // ageLabel
            // 
            this.ageLabel.BackColor = System.Drawing.Color.Transparent;
            this.ageLabel.Font = new System.Drawing.Font("MS Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ageLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ageLabel.Location = new System.Drawing.Point(15, 172);
            this.ageLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(116, 17);
            this.ageLabel.TabIndex = 3;
            this.ageLabel.Text = "Age:";
            // 
            // ageText
            // 
            this.ageText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ageText.Location = new System.Drawing.Point(134, 167);
            this.ageText.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ageText.Name = "ageText";
            this.ageText.Size = new System.Drawing.Size(98, 24);
            this.ageText.TabIndex = 3;
            // 
            // licLabel
            // 
            this.licLabel.BackColor = System.Drawing.Color.Transparent;
            this.licLabel.Font = new System.Drawing.Font("MS Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.licLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.licLabel.Location = new System.Drawing.Point(15, 224);
            this.licLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.licLabel.Name = "licLabel";
            this.licLabel.Size = new System.Drawing.Size(116, 17);
            this.licLabel.TabIndex = 4;
            this.licLabel.Text = "License Id:";
            // 
            // licText
            // 
            this.licText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.licText.Location = new System.Drawing.Point(134, 221);
            this.licText.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.licText.Name = "licText";
            this.licText.Size = new System.Drawing.Size(195, 24);
            this.licText.TabIndex = 4;
            // 
            // specialtyLabel
            // 
            this.specialtyLabel.BackColor = System.Drawing.Color.Transparent;
            this.specialtyLabel.Location = new System.Drawing.Point(15, 275);
            this.specialtyLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.specialtyLabel.Name = "specialtyLabel";
            this.specialtyLabel.Size = new System.Drawing.Size(116, 17);
            this.specialtyLabel.TabIndex = 5;
            this.specialtyLabel.Text = "Specialty:";
            // 
            // specText
            // 
            this.specText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.specText.Location = new System.Drawing.Point(134, 270);
            this.specText.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.specText.Name = "specText";
            this.specText.Size = new System.Drawing.Size(439, 24);
            this.specText.TabIndex = 5;
            // 
            // gpaLabel
            // 
            this.gpaLabel.BackColor = System.Drawing.Color.Transparent;
            this.gpaLabel.Font = new System.Drawing.Font("MS Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpaLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpaLabel.Location = new System.Drawing.Point(15, 275);
            this.gpaLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.gpaLabel.Name = "gpaLabel";
            this.gpaLabel.Size = new System.Drawing.Size(100, 17);
            this.gpaLabel.TabIndex = 6;
            this.gpaLabel.Text = "GPA:";
            // 
            // gpaText
            // 
            this.gpaText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gpaText.Location = new System.Drawing.Point(134, 270);
            this.gpaText.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gpaText.Name = "gpaText";
            this.gpaText.Size = new System.Drawing.Size(98, 24);
            this.gpaText.TabIndex = 5;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(944, 457);
            this.okButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(94, 31);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(1091, 457);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 31);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // classGroupBox
            // 
            this.classGroupBox.Controls.Add(this.classLabel);
            this.classGroupBox.Controls.Add(this.freshmanRadioButton);
            this.classGroupBox.Controls.Add(this.sophomoreRadioButton);
            this.classGroupBox.Controls.Add(this.juniorRadioButton);
            this.classGroupBox.Controls.Add(this.seniorRadioButton);
            this.classGroupBox.Location = new System.Drawing.Point(652, 12);
            this.classGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.classGroupBox.Name = "classGroupBox";
            this.classGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.classGroupBox.Size = new System.Drawing.Size(155, 136);
            this.classGroupBox.TabIndex = 7;
            this.classGroupBox.TabStop = false;
            this.classGroupBox.Text = "Class";
            // 
            // classLabel
            // 
            this.classLabel.Location = new System.Drawing.Point(8, 110);
            this.classLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.classLabel.Name = "classLabel";
            this.classLabel.Size = new System.Drawing.Size(143, 23);
            this.classLabel.TabIndex = 7;
            this.classLabel.Text = "Class of 9999";
            this.classLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // freshmanRadioButton
            // 
            this.freshmanRadioButton.AutoSize = true;
            this.freshmanRadioButton.Location = new System.Drawing.Point(7, 19);
            this.freshmanRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.freshmanRadioButton.Name = "freshmanRadioButton";
            this.freshmanRadioButton.Size = new System.Drawing.Size(109, 21);
            this.freshmanRadioButton.TabIndex = 3;
            this.freshmanRadioButton.TabStop = true;
            this.freshmanRadioButton.Text = "Freshman";
            this.freshmanRadioButton.UseVisualStyleBackColor = true;
            // 
            // sophomoreRadioButton
            // 
            this.sophomoreRadioButton.AutoSize = true;
            this.sophomoreRadioButton.Location = new System.Drawing.Point(7, 41);
            this.sophomoreRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sophomoreRadioButton.Name = "sophomoreRadioButton";
            this.sophomoreRadioButton.Size = new System.Drawing.Size(119, 21);
            this.sophomoreRadioButton.TabIndex = 4;
            this.sophomoreRadioButton.TabStop = true;
            this.sophomoreRadioButton.Text = "Sophomore";
            this.sophomoreRadioButton.UseVisualStyleBackColor = true;
            // 
            // juniorRadioButton
            // 
            this.juniorRadioButton.AutoSize = true;
            this.juniorRadioButton.Location = new System.Drawing.Point(7, 61);
            this.juniorRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.juniorRadioButton.Name = "juniorRadioButton";
            this.juniorRadioButton.Size = new System.Drawing.Size(89, 21);
            this.juniorRadioButton.TabIndex = 5;
            this.juniorRadioButton.TabStop = true;
            this.juniorRadioButton.Text = "Junior";
            this.juniorRadioButton.UseVisualStyleBackColor = true;
            // 
            // seniorRadioButton
            // 
            this.seniorRadioButton.AutoSize = true;
            this.seniorRadioButton.Location = new System.Drawing.Point(7, 88);
            this.seniorRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.seniorRadioButton.Name = "seniorRadioButton";
            this.seniorRadioButton.Size = new System.Drawing.Size(89, 21);
            this.seniorRadioButton.TabIndex = 6;
            this.seniorRadioButton.TabStop = true;
            this.seniorRadioButton.Text = "Senior";
            this.seniorRadioButton.UseVisualStyleBackColor = true;
            // 
            // genderGroupBox
            // 
            this.genderGroupBox.Controls.Add(this.themRadioButton);
            this.genderGroupBox.Controls.Add(this.herRadioButton);
            this.genderGroupBox.Controls.Add(this.himRadioButton);
            this.genderGroupBox.Location = new System.Drawing.Point(507, 12);
            this.genderGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.genderGroupBox.Name = "genderGroupBox";
            this.genderGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.genderGroupBox.Size = new System.Drawing.Size(123, 126);
            this.genderGroupBox.TabIndex = 6;
            this.genderGroupBox.TabStop = false;
            this.genderGroupBox.Text = "Gender";
            // 
            // themRadioButton
            // 
            this.themRadioButton.AutoSize = true;
            this.themRadioButton.Location = new System.Drawing.Point(9, 94);
            this.themRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.themRadioButton.Name = "themRadioButton";
            this.themRadioButton.Size = new System.Drawing.Size(69, 21);
            this.themRadioButton.TabIndex = 2;
            this.themRadioButton.TabStop = true;
            this.themRadioButton.Text = "Them";
            this.themRadioButton.UseVisualStyleBackColor = true;
            // 
            // herRadioButton
            // 
            this.herRadioButton.AutoSize = true;
            this.herRadioButton.Location = new System.Drawing.Point(7, 59);
            this.herRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.herRadioButton.Name = "herRadioButton";
            this.herRadioButton.Size = new System.Drawing.Size(59, 21);
            this.herRadioButton.TabIndex = 1;
            this.herRadioButton.TabStop = true;
            this.herRadioButton.Text = "Her";
            this.herRadioButton.UseVisualStyleBackColor = true;
            // 
            // himRadioButton
            // 
            this.himRadioButton.AutoSize = true;
            this.himRadioButton.Location = new System.Drawing.Point(7, 26);
            this.himRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.himRadioButton.Name = "himRadioButton";
            this.himRadioButton.Size = new System.Drawing.Size(59, 21);
            this.himRadioButton.TabIndex = 0;
            this.himRadioButton.TabStop = true;
            this.himRadioButton.Text = "Him";
            this.himRadioButton.UseVisualStyleBackColor = true;
            // 
            // photoGroupBox
            // 
            this.photoGroupBox.Controls.Add(this.photoPictureBox);
            this.photoGroupBox.Location = new System.Drawing.Point(856, 206);
            this.photoGroupBox.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.photoGroupBox.Name = "photoGroupBox";
            this.photoGroupBox.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.photoGroupBox.Size = new System.Drawing.Size(334, 202);
            this.photoGroupBox.TabIndex = 44;
            this.photoGroupBox.TabStop = false;
            this.photoGroupBox.Text = "Photo";
            // 
            // photoPictureBox
            // 
            this.photoPictureBox.BackColor = System.Drawing.Color.LightGray;
            this.photoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoPictureBox.Location = new System.Drawing.Point(5, 20);
            this.photoPictureBox.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.photoPictureBox.Name = "photoPictureBox";
            this.photoPictureBox.Size = new System.Drawing.Size(324, 179);
            this.photoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.photoPictureBox.TabIndex = 9;
            this.photoPictureBox.TabStop = false;
            // 
            // PersonEditForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(820, 427);
            this.Controls.Add(this.photoGroupBox);
            this.Controls.Add(this.classGroupBox);
            this.Controls.Add(this.genderGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.gpaText);
            this.Controls.Add(this.specText);
            this.Controls.Add(this.specialtyLabel);
            this.Controls.Add(this.licText);
            this.Controls.Add(this.licLabel);
            this.Controls.Add(this.ageText);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.emailText);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.gpaLabel);
            this.Font = new System.Drawing.Font("MS Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(842, 478);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(756, 401);
            this.Name = "PersonEditForm";
            this.Text = "Edit Person";
            this.Load += new System.EventHandler(this.PersonEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.classGroupBox.ResumeLayout(false);
            this.classGroupBox.PerformLayout();
            this.genderGroupBox.ResumeLayout(false);
            this.genderGroupBox.PerformLayout();
            this.photoGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailText;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.TextBox ageText;
        private System.Windows.Forms.Label licLabel;
        private System.Windows.Forms.TextBox licText;
        private System.Windows.Forms.Label specialtyLabel;
        private System.Windows.Forms.TextBox specText;
        private System.Windows.Forms.Label gpaLabel;
        private System.Windows.Forms.TextBox gpaText;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox classGroupBox;
        private System.Windows.Forms.Label classLabel;
        private System.Windows.Forms.RadioButton freshmanRadioButton;
        private System.Windows.Forms.RadioButton sophomoreRadioButton;
        private System.Windows.Forms.RadioButton juniorRadioButton;
        private System.Windows.Forms.RadioButton seniorRadioButton;
        private System.Windows.Forms.GroupBox genderGroupBox;
        private System.Windows.Forms.RadioButton themRadioButton;
        private System.Windows.Forms.RadioButton herRadioButton;
        private System.Windows.Forms.RadioButton himRadioButton;
        private System.Windows.Forms.GroupBox photoGroupBox;
        private System.Windows.Forms.PictureBox photoPictureBox;
    }
}

