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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.editPersonTabControl = new System.Windows.Forms.TabControl();
            this.detailsTabPage = new System.Windows.Forms.TabPage();
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
            this.label1 = new System.Windows.Forms.Label();
            this.homepageTextBox = new System.Windows.Forms.TextBox();
            this.birthdateLabel = new System.Windows.Forms.Label();
            this.birthDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.photoGroupBox = new System.Windows.Forms.GroupBox();
            this.photoPictureBox = new System.Windows.Forms.PictureBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.gpaTextBox = new System.Windows.Forms.TextBox();
            this.gpaLabel = new System.Windows.Forms.Label();
            this.specTextBox = new System.Windows.Forms.TextBox();
            this.specialtyLabel = new System.Windows.Forms.Label();
            this.licTextBox = new System.Windows.Forms.TextBox();
            this.licLabel = new System.Windows.Forms.Label();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.ageLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.typeVal = new System.Windows.Forms.Label();
            this.homePageTabPage = new System.Windows.Forms.TabPage();
            this.homepageWebBrowser = new System.Windows.Forms.WebBrowser();
            this.coursesTabPage = new System.Windows.Forms.TabPage();
            this.allCoursesGroupBox = new System.Windows.Forms.GroupBox();
            this.courseSearchLabel = new System.Windows.Forms.Label();
            this.courseSearchTextBox = new System.Windows.Forms.TextBox();
            this.allCoursesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.selectedCoursesGroupBox = new System.Windows.Forms.GroupBox();
            this.selectedCoursesListView = new System.Windows.Forms.ListView();
            this.codeHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.instructorName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dowHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scheduleTabPage = new System.Windows.Forms.TabPage();
            this.scheduleWebBrowser = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.editPersonTabControl.SuspendLayout();
            this.detailsTabPage.SuspendLayout();
            this.classGroupBox.SuspendLayout();
            this.genderGroupBox.SuspendLayout();
            this.photoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).BeginInit();
            this.homePageTabPage.SuspendLayout();
            this.coursesTabPage.SuspendLayout();
            this.allCoursesGroupBox.SuspendLayout();
            this.selectedCoursesGroupBox.SuspendLayout();
            this.scheduleTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // editPersonTabControl
            // 
            this.editPersonTabControl.Controls.Add(this.detailsTabPage);
            this.editPersonTabControl.Controls.Add(this.homePageTabPage);
            this.editPersonTabControl.Controls.Add(this.coursesTabPage);
            this.editPersonTabControl.Controls.Add(this.scheduleTabPage);
            this.editPersonTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editPersonTabControl.Location = new System.Drawing.Point(0, 0);
            this.editPersonTabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.editPersonTabControl.Name = "editPersonTabControl";
            this.editPersonTabControl.SelectedIndex = 0;
            this.editPersonTabControl.Size = new System.Drawing.Size(1137, 439);
            this.editPersonTabControl.TabIndex = 1;
            // 
            // detailsTabPage
            // 
            this.detailsTabPage.Controls.Add(this.classGroupBox);
            this.detailsTabPage.Controls.Add(this.genderGroupBox);
            this.detailsTabPage.Controls.Add(this.label1);
            this.detailsTabPage.Controls.Add(this.homepageTextBox);
            this.detailsTabPage.Controls.Add(this.birthdateLabel);
            this.detailsTabPage.Controls.Add(this.birthDateTimePicker);
            this.detailsTabPage.Controls.Add(this.photoGroupBox);
            this.detailsTabPage.Controls.Add(this.cancelButton);
            this.detailsTabPage.Controls.Add(this.okButton);
            this.detailsTabPage.Controls.Add(this.gpaTextBox);
            this.detailsTabPage.Controls.Add(this.gpaLabel);
            this.detailsTabPage.Controls.Add(this.specTextBox);
            this.detailsTabPage.Controls.Add(this.specialtyLabel);
            this.detailsTabPage.Controls.Add(this.licTextBox);
            this.detailsTabPage.Controls.Add(this.licLabel);
            this.detailsTabPage.Controls.Add(this.ageTextBox);
            this.detailsTabPage.Controls.Add(this.ageLabel);
            this.detailsTabPage.Controls.Add(this.emailTextBox);
            this.detailsTabPage.Controls.Add(this.emailLabel);
            this.detailsTabPage.Controls.Add(this.nameTextBox);
            this.detailsTabPage.Controls.Add(this.nameLabel);
            this.detailsTabPage.Controls.Add(this.typeComboBox);
            this.detailsTabPage.Controls.Add(this.typeVal);
            this.detailsTabPage.Location = new System.Drawing.Point(4, 23);
            this.detailsTabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.detailsTabPage.Name = "detailsTabPage";
            this.detailsTabPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.detailsTabPage.Size = new System.Drawing.Size(1129, 412);
            this.detailsTabPage.TabIndex = 0;
            this.detailsTabPage.Text = "Details";
            this.detailsTabPage.UseVisualStyleBackColor = true;
            // 
            // classGroupBox
            // 
            this.classGroupBox.Controls.Add(this.classLabel);
            this.classGroupBox.Controls.Add(this.freshmanRadioButton);
            this.classGroupBox.Controls.Add(this.sophomoreRadioButton);
            this.classGroupBox.Controls.Add(this.juniorRadioButton);
            this.classGroupBox.Controls.Add(this.seniorRadioButton);
            this.classGroupBox.Location = new System.Drawing.Point(812, 15);
            this.classGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.classGroupBox.Name = "classGroupBox";
            this.classGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.classGroupBox.Size = new System.Drawing.Size(203, 126);
            this.classGroupBox.TabIndex = 41;
            this.classGroupBox.TabStop = false;
            this.classGroupBox.Text = "Class";
            // 
            // classLabel
            // 
            this.classLabel.AutoSize = true;
            this.classLabel.Location = new System.Drawing.Point(80, 102);
            this.classLabel.Name = "classLabel";
            this.classLabel.Size = new System.Drawing.Size(45, 13);
            this.classLabel.TabIndex = 7;
            this.classLabel.Text = "label2";
            // 
            // freshmanRadioButton
            // 
            this.freshmanRadioButton.AutoSize = true;
            this.freshmanRadioButton.Location = new System.Drawing.Point(6, 17);
            this.freshmanRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.freshmanRadioButton.Name = "freshmanRadioButton";
            this.freshmanRadioButton.Size = new System.Drawing.Size(91, 17);
            this.freshmanRadioButton.TabIndex = 3;
            this.freshmanRadioButton.TabStop = true;
            this.freshmanRadioButton.Text = "Freshman";
            this.freshmanRadioButton.UseVisualStyleBackColor = true;
            // 
            // sophomoreRadioButton
            // 
            this.sophomoreRadioButton.AutoSize = true;
            this.sophomoreRadioButton.Location = new System.Drawing.Point(6, 38);
            this.sophomoreRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sophomoreRadioButton.Name = "sophomoreRadioButton";
            this.sophomoreRadioButton.Size = new System.Drawing.Size(101, 17);
            this.sophomoreRadioButton.TabIndex = 4;
            this.sophomoreRadioButton.TabStop = true;
            this.sophomoreRadioButton.Text = "Sophomore";
            this.sophomoreRadioButton.UseVisualStyleBackColor = true;
            // 
            // juniorRadioButton
            // 
            this.juniorRadioButton.AutoSize = true;
            this.juniorRadioButton.Location = new System.Drawing.Point(6, 58);
            this.juniorRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.juniorRadioButton.Name = "juniorRadioButton";
            this.juniorRadioButton.Size = new System.Drawing.Size(70, 17);
            this.juniorRadioButton.TabIndex = 5;
            this.juniorRadioButton.TabStop = true;
            this.juniorRadioButton.Text = "Junior";
            this.juniorRadioButton.UseVisualStyleBackColor = true;
            // 
            // seniorRadioButton
            // 
            this.seniorRadioButton.AutoSize = true;
            this.seniorRadioButton.Location = new System.Drawing.Point(6, 82);
            this.seniorRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.seniorRadioButton.Name = "seniorRadioButton";
            this.seniorRadioButton.Size = new System.Drawing.Size(71, 17);
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
            this.genderGroupBox.Location = new System.Drawing.Point(642, 15);
            this.genderGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.genderGroupBox.Name = "genderGroupBox";
            this.genderGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.genderGroupBox.Size = new System.Drawing.Size(138, 127);
            this.genderGroupBox.TabIndex = 40;
            this.genderGroupBox.TabStop = false;
            this.genderGroupBox.Text = "Gender";
            // 
            // themRadioButton
            // 
            this.themRadioButton.AutoSize = true;
            this.themRadioButton.Location = new System.Drawing.Point(7, 89);
            this.themRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.themRadioButton.Name = "themRadioButton";
            this.themRadioButton.Size = new System.Drawing.Size(64, 17);
            this.themRadioButton.TabIndex = 2;
            this.themRadioButton.TabStop = true;
            this.themRadioButton.Text = "Them";
            this.themRadioButton.UseVisualStyleBackColor = true;
            // 
            // herRadioButton
            // 
            this.herRadioButton.AutoSize = true;
            this.herRadioButton.Location = new System.Drawing.Point(6, 55);
            this.herRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.herRadioButton.Name = "herRadioButton";
            this.herRadioButton.Size = new System.Drawing.Size(51, 17);
            this.herRadioButton.TabIndex = 1;
            this.herRadioButton.TabStop = true;
            this.herRadioButton.Text = "Her";
            this.herRadioButton.UseVisualStyleBackColor = true;
            // 
            // himRadioButton
            // 
            this.himRadioButton.AutoSize = true;
            this.himRadioButton.Location = new System.Drawing.Point(6, 24);
            this.himRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.himRadioButton.Name = "himRadioButton";
            this.himRadioButton.Size = new System.Drawing.Size(52, 17);
            this.himRadioButton.TabIndex = 0;
            this.himRadioButton.TabStop = true;
            this.himRadioButton.Text = "Him";
            this.himRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 278);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Homepage:";
            // 
            // homepageTextBox
            // 
            this.homepageTextBox.Location = new System.Drawing.Point(104, 275);
            this.homepageTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.homepageTextBox.Name = "homepageTextBox";
            this.homepageTextBox.Size = new System.Drawing.Size(468, 20);
            this.homepageTextBox.TabIndex = 38;
            // 
            // birthdateLabel
            // 
            this.birthdateLabel.AutoSize = true;
            this.birthdateLabel.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.birthdateLabel.Location = new System.Drawing.Point(11, 238);
            this.birthdateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.birthdateLabel.Name = "birthdateLabel";
            this.birthdateLabel.Size = new System.Drawing.Size(72, 13);
            this.birthdateLabel.TabIndex = 37;
            this.birthdateLabel.Text = "Birthdate:";
            // 
            // birthDateTimePicker
            // 
            this.birthDateTimePicker.CustomFormat = "MMM d, yyyy";
            this.birthDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.birthDateTimePicker.Location = new System.Drawing.Point(104, 232);
            this.birthDateTimePicker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.birthDateTimePicker.Name = "birthDateTimePicker";
            this.birthDateTimePicker.Size = new System.Drawing.Size(157, 20);
            this.birthDateTimePicker.TabIndex = 36;
            // 
            // photoGroupBox
            // 
            this.photoGroupBox.Controls.Add(this.photoPictureBox);
            this.photoGroupBox.Location = new System.Drawing.Point(807, 153);
            this.photoGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.photoGroupBox.Name = "photoGroupBox";
            this.photoGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.photoGroupBox.Size = new System.Drawing.Size(267, 191);
            this.photoGroupBox.TabIndex = 35;
            this.photoGroupBox.TabStop = false;
            this.photoGroupBox.Text = "Photo";
            // 
            // photoPictureBox
            // 
            this.photoPictureBox.BackColor = System.Drawing.Color.LightGray;
            this.photoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoPictureBox.Location = new System.Drawing.Point(4, 16);
            this.photoPictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.photoPictureBox.Name = "photoPictureBox";
            this.photoPictureBox.Size = new System.Drawing.Size(259, 172);
            this.photoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.photoPictureBox.TabIndex = 9;
            this.photoPictureBox.TabStop = false;
            // 
            // cancelButton
            // 
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(999, 375);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 24);
            this.cancelButton.TabIndex = 32;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(895, 375);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 24);
            this.okButton.TabIndex = 31;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // gpaTextBox
            // 
            this.gpaTextBox.Location = new System.Drawing.Point(104, 191);
            this.gpaTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gpaTextBox.Name = "gpaTextBox";
            this.gpaTextBox.Size = new System.Drawing.Size(79, 20);
            this.gpaTextBox.TabIndex = 28;
            // 
            // gpaLabel
            // 
            this.gpaLabel.Location = new System.Drawing.Point(11, 194);
            this.gpaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gpaLabel.Name = "gpaLabel";
            this.gpaLabel.Size = new System.Drawing.Size(80, 13);
            this.gpaLabel.TabIndex = 30;
            this.gpaLabel.Text = "GPA:";
            // 
            // specTextBox
            // 
            this.specTextBox.Location = new System.Drawing.Point(104, 191);
            this.specTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.specTextBox.Name = "specTextBox";
            this.specTextBox.Size = new System.Drawing.Size(468, 20);
            this.specTextBox.TabIndex = 29;
            // 
            // specialtyLabel
            // 
            this.specialtyLabel.Location = new System.Drawing.Point(9, 194);
            this.specialtyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.specialtyLabel.Name = "specialtyLabel";
            this.specialtyLabel.Size = new System.Drawing.Size(93, 13);
            this.specialtyLabel.TabIndex = 27;
            this.specialtyLabel.Text = "Specialty:";
            // 
            // licTextBox
            // 
            this.licTextBox.Location = new System.Drawing.Point(104, 153);
            this.licTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.licTextBox.Name = "licTextBox";
            this.licTextBox.Size = new System.Drawing.Size(157, 20);
            this.licTextBox.TabIndex = 26;
            // 
            // licLabel
            // 
            this.licLabel.Location = new System.Drawing.Point(9, 155);
            this.licLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.licLabel.Name = "licLabel";
            this.licLabel.Size = new System.Drawing.Size(93, 13);
            this.licLabel.TabIndex = 25;
            this.licLabel.Text = "License Id:";
            // 
            // ageTextBox
            // 
            this.ageTextBox.Location = new System.Drawing.Point(104, 112);
            this.ageTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(79, 20);
            this.ageTextBox.TabIndex = 24;
            // 
            // ageLabel
            // 
            this.ageLabel.Location = new System.Drawing.Point(9, 115);
            this.ageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(93, 13);
            this.ageLabel.TabIndex = 23;
            this.ageLabel.Text = "Age:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(104, 73);
            this.emailTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(468, 20);
            this.emailTextBox.TabIndex = 22;
            // 
            // emailLabel
            // 
            this.emailLabel.Location = new System.Drawing.Point(9, 76);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(93, 13);
            this.emailLabel.TabIndex = 21;
            this.emailLabel.Text = "Email:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(104, 37);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(275, 20);
            this.nameTextBox.TabIndex = 20;
            // 
            // nameLabel
            // 
            this.nameLabel.Location = new System.Drawing.Point(9, 39);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(93, 13);
            this.nameLabel.TabIndex = 19;
            this.nameLabel.Text = "Name:";
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Student",
            "Teacher"});
            this.typeComboBox.Location = new System.Drawing.Point(104, 2);
            this.typeComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.typeComboBox.MaxDropDownItems = 2;
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(157, 21);
            this.typeComboBox.TabIndex = 18;
            // 
            // typeVal
            // 
            this.typeVal.Location = new System.Drawing.Point(9, 4);
            this.typeVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.typeVal.Name = "typeVal";
            this.typeVal.Size = new System.Drawing.Size(93, 13);
            this.typeVal.TabIndex = 17;
            this.typeVal.Text = "Person type:";
            // 
            // homePageTabPage
            // 
            this.homePageTabPage.Controls.Add(this.homepageWebBrowser);
            this.homePageTabPage.Location = new System.Drawing.Point(4, 25);
            this.homePageTabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.homePageTabPage.Name = "homePageTabPage";
            this.homePageTabPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.homePageTabPage.Size = new System.Drawing.Size(1129, 410);
            this.homePageTabPage.TabIndex = 1;
            this.homePageTabPage.Text = "Homepage";
            this.homePageTabPage.UseVisualStyleBackColor = true;
            // 
            // homepageWebBrowser
            // 
            this.homepageWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.homepageWebBrowser.Location = new System.Drawing.Point(4, 3);
            this.homepageWebBrowser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.homepageWebBrowser.MinimumSize = new System.Drawing.Size(27, 20);
            this.homepageWebBrowser.Name = "homepageWebBrowser";
            this.homepageWebBrowser.ScriptErrorsSuppressed = true;
            this.homepageWebBrowser.Size = new System.Drawing.Size(1121, 404);
            this.homepageWebBrowser.TabIndex = 0;
            // 
            // coursesTabPage
            // 
            this.coursesTabPage.Controls.Add(this.allCoursesGroupBox);
            this.coursesTabPage.Controls.Add(this.selectedCoursesGroupBox);
            this.coursesTabPage.Location = new System.Drawing.Point(4, 25);
            this.coursesTabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.coursesTabPage.Name = "coursesTabPage";
            this.coursesTabPage.Size = new System.Drawing.Size(1129, 410);
            this.coursesTabPage.TabIndex = 2;
            this.coursesTabPage.Text = "Courses";
            this.coursesTabPage.UseVisualStyleBackColor = true;
            // 
            // allCoursesGroupBox
            // 
            this.allCoursesGroupBox.Controls.Add(this.courseSearchLabel);
            this.allCoursesGroupBox.Controls.Add(this.courseSearchTextBox);
            this.allCoursesGroupBox.Controls.Add(this.allCoursesListView);
            this.allCoursesGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.allCoursesGroupBox.Location = new System.Drawing.Point(0, 162);
            this.allCoursesGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.allCoursesGroupBox.Name = "allCoursesGroupBox";
            this.allCoursesGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.allCoursesGroupBox.Size = new System.Drawing.Size(1129, 248);
            this.allCoursesGroupBox.TabIndex = 2;
            this.allCoursesGroupBox.TabStop = false;
            this.allCoursesGroupBox.Text = "All Courses";
            // 
            // courseSearchLabel
            // 
            this.courseSearchLabel.AutoSize = true;
            this.courseSearchLabel.Location = new System.Drawing.Point(179, 23);
            this.courseSearchLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.courseSearchLabel.Name = "courseSearchLabel";
            this.courseSearchLabel.Size = new System.Drawing.Size(57, 13);
            this.courseSearchLabel.TabIndex = 14;
            this.courseSearchLabel.Text = "Search:";
            // 
            // courseSearchTextBox
            // 
            this.courseSearchTextBox.Location = new System.Drawing.Point(245, 20);
            this.courseSearchTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.courseSearchTextBox.Name = "courseSearchTextBox";
            this.courseSearchTextBox.Size = new System.Drawing.Size(600, 20);
            this.courseSearchTextBox.TabIndex = 13;
            // 
            // allCoursesListView
            // 
            this.allCoursesListView.BackColor = System.Drawing.SystemColors.Window;
            this.allCoursesListView.BackgroundImageTiled = true;
            this.allCoursesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.allCoursesListView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.allCoursesListView.FullRowSelect = true;
            this.allCoursesListView.HideSelection = false;
            this.allCoursesListView.Location = new System.Drawing.Point(4, 44);
            this.allCoursesListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.allCoursesListView.Name = "allCoursesListView";
            this.allCoursesListView.Size = new System.Drawing.Size(1121, 201);
            this.allCoursesListView.TabIndex = 12;
            this.allCoursesListView.UseCompatibleStateImageBehavior = false;
            this.allCoursesListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Code";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Instructor";
            this.columnHeader3.Width = 175;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Days";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Time";
            this.columnHeader5.Width = 300;
            // 
            // selectedCoursesGroupBox
            // 
            this.selectedCoursesGroupBox.Controls.Add(this.selectedCoursesListView);
            this.selectedCoursesGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectedCoursesGroupBox.Location = new System.Drawing.Point(0, 0);
            this.selectedCoursesGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.selectedCoursesGroupBox.Name = "selectedCoursesGroupBox";
            this.selectedCoursesGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.selectedCoursesGroupBox.Size = new System.Drawing.Size(1129, 152);
            this.selectedCoursesGroupBox.TabIndex = 1;
            this.selectedCoursesGroupBox.TabStop = false;
            this.selectedCoursesGroupBox.Text = "Selected Courses";
            // 
            // selectedCoursesListView
            // 
            this.selectedCoursesListView.BackColor = System.Drawing.SystemColors.Window;
            this.selectedCoursesListView.BackgroundImageTiled = true;
            this.selectedCoursesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.codeHdr,
            this.descHdr,
            this.instructorName,
            this.dowHdr,
            this.timeHdr});
            this.selectedCoursesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedCoursesListView.FullRowSelect = true;
            this.selectedCoursesListView.HideSelection = false;
            this.selectedCoursesListView.Location = new System.Drawing.Point(4, 16);
            this.selectedCoursesListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectedCoursesListView.Name = "selectedCoursesListView";
            this.selectedCoursesListView.Size = new System.Drawing.Size(1121, 133);
            this.selectedCoursesListView.TabIndex = 11;
            this.selectedCoursesListView.UseCompatibleStateImageBehavior = false;
            this.selectedCoursesListView.View = System.Windows.Forms.View.Details;
            // 
            // codeHdr
            // 
            this.codeHdr.Text = "Code";
            this.codeHdr.Width = 180;
            // 
            // descHdr
            // 
            this.descHdr.Text = "Description";
            this.descHdr.Width = 250;
            // 
            // instructorName
            // 
            this.instructorName.Text = "Instructor";
            this.instructorName.Width = 175;
            // 
            // dowHdr
            // 
            this.dowHdr.Text = "Days";
            this.dowHdr.Width = 100;
            // 
            // timeHdr
            // 
            this.timeHdr.Text = "Time";
            this.timeHdr.Width = 300;
            // 
            // scheduleTabPage
            // 
            this.scheduleTabPage.Controls.Add(this.scheduleWebBrowser);
            this.scheduleTabPage.Location = new System.Drawing.Point(4, 25);
            this.scheduleTabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.scheduleTabPage.Name = "scheduleTabPage";
            this.scheduleTabPage.Size = new System.Drawing.Size(1129, 410);
            this.scheduleTabPage.TabIndex = 3;
            this.scheduleTabPage.Text = "Schedule";
            this.scheduleTabPage.UseVisualStyleBackColor = true;
            // 
            // scheduleWebBrowser
            // 
            this.scheduleWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduleWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.scheduleWebBrowser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.scheduleWebBrowser.MinimumSize = new System.Drawing.Size(27, 20);
            this.scheduleWebBrowser.Name = "scheduleWebBrowser";
            this.scheduleWebBrowser.ScriptErrorsSuppressed = true;
            this.scheduleWebBrowser.Size = new System.Drawing.Size(1129, 410);
            this.scheduleWebBrowser.TabIndex = 0;
            // 
            // PersonEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 439);
            this.Controls.Add(this.editPersonTabControl);
            this.Font = new System.Drawing.Font("MS PGothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "PersonEditForm";
            this.Text = "Person Edit Form";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.editPersonTabControl.ResumeLayout(false);
            this.detailsTabPage.ResumeLayout(false);
            this.detailsTabPage.PerformLayout();
            this.classGroupBox.ResumeLayout(false);
            this.classGroupBox.PerformLayout();
            this.genderGroupBox.ResumeLayout(false);
            this.genderGroupBox.PerformLayout();
            this.photoGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).EndInit();
            this.homePageTabPage.ResumeLayout(false);
            this.coursesTabPage.ResumeLayout(false);
            this.allCoursesGroupBox.ResumeLayout(false);
            this.allCoursesGroupBox.PerformLayout();
            this.selectedCoursesGroupBox.ResumeLayout(false);
            this.scheduleTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabControl editPersonTabControl;
        private System.Windows.Forms.TabPage detailsTabPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox homepageTextBox;
        private System.Windows.Forms.Label birthdateLabel;
        private System.Windows.Forms.DateTimePicker birthDateTimePicker;
        private System.Windows.Forms.GroupBox photoGroupBox;
        private System.Windows.Forms.PictureBox photoPictureBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox gpaTextBox;
        private System.Windows.Forms.Label gpaLabel;
        private System.Windows.Forms.TextBox specTextBox;
        private System.Windows.Forms.Label specialtyLabel;
        private System.Windows.Forms.TextBox licTextBox;
        private System.Windows.Forms.Label licLabel;
        private System.Windows.Forms.TextBox ageTextBox;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label typeVal;
        private System.Windows.Forms.TabPage homePageTabPage;
        private System.Windows.Forms.WebBrowser homepageWebBrowser;
        private System.Windows.Forms.TabPage coursesTabPage;
        private System.Windows.Forms.GroupBox allCoursesGroupBox;
        private System.Windows.Forms.Label courseSearchLabel;
        private System.Windows.Forms.TextBox courseSearchTextBox;
        private System.Windows.Forms.ListView allCoursesListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.GroupBox selectedCoursesGroupBox;
        private System.Windows.Forms.ListView selectedCoursesListView;
        private System.Windows.Forms.ColumnHeader codeHdr;
        private System.Windows.Forms.ColumnHeader descHdr;
        private System.Windows.Forms.ColumnHeader instructorName;
        private System.Windows.Forms.ColumnHeader dowHdr;
        private System.Windows.Forms.ColumnHeader timeHdr;
        private System.Windows.Forms.TabPage scheduleTabPage;
        private System.Windows.Forms.WebBrowser scheduleWebBrowser;
        private System.Windows.Forms.GroupBox classGroupBox;
        private System.Windows.Forms.RadioButton freshmanRadioButton;
        private System.Windows.Forms.RadioButton sophomoreRadioButton;
        private System.Windows.Forms.RadioButton juniorRadioButton;
        private System.Windows.Forms.RadioButton seniorRadioButton;
        private System.Windows.Forms.GroupBox genderGroupBox;
        private System.Windows.Forms.RadioButton themRadioButton;
        private System.Windows.Forms.RadioButton herRadioButton;
        private System.Windows.Forms.RadioButton himRadioButton;
        private System.Windows.Forms.Label classLabel;
    }
}

