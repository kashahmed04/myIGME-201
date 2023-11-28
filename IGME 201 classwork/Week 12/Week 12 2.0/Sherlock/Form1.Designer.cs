namespace Sherlock
{
    partial class Sherlock
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
            this.refLabel = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.countdownLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.exitButton = new System.Windows.Forms.Button();
            this.happyPictureBox = new System.Windows.Forms.PictureBox();
            this.sadPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.happyPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sadPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // refLabel
            // 
            this.refLabel.AutoSize = true;
            this.refLabel.Location = new System.Drawing.Point(17, 19);
            this.refLabel.Name = "refLabel";
            this.refLabel.Size = new System.Drawing.Size(56, 16);
            this.refLabel.TabIndex = 0;
            this.refLabel.Text = "refLabel";
            this.refLabel.Click += new System.EventHandler(this.refLabel_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 49);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(100, 22);
            this.textBox.TabIndex = 1;
            // 
            // countdownLabel
            // 
            this.countdownLabel.AutoSize = true;
            this.countdownLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countdownLabel.ForeColor = System.Drawing.Color.Red;
            this.countdownLabel.Location = new System.Drawing.Point(12, 101);
            this.countdownLabel.Name = "countdownLabel";
            this.countdownLabel.Size = new System.Drawing.Size(126, 46);
            this.countdownLabel.TabIndex = 2;
            this.countdownLabel.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.webBrowser1);
            this.groupBox1.Location = new System.Drawing.Point(376, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 377);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 18);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(380, 356);
            this.webBrowser1.TabIndex = 0;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(684, 415);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // happyPictureBox
            // 
            this.happyPictureBox.Image = global::Sherlock.Properties.Resources.happy;
            this.happyPictureBox.Location = new System.Drawing.Point(20, 171);
            this.happyPictureBox.Name = "happyPictureBox";
            this.happyPictureBox.Size = new System.Drawing.Size(118, 112);
            this.happyPictureBox.TabIndex = 5;
            this.happyPictureBox.TabStop = false;
            // 
            // sadPictureBox
            // 
            this.sadPictureBox.Image = global::Sherlock.Properties.Resources.sad;
            this.sadPictureBox.Location = new System.Drawing.Point(20, 171);
            this.sadPictureBox.Name = "sadPictureBox";
            this.sadPictureBox.Size = new System.Drawing.Size(118, 112);
            this.sadPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sadPictureBox.TabIndex = 3;
            this.sadPictureBox.TabStop = false;
            // 
            // Sherlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.happyPictureBox);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sadPictureBox);
            this.Controls.Add(this.countdownLabel);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.refLabel);
            this.Name = "Sherlock";
            this.Text = "Sherlock";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.happyPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sadPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label refLabel;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label countdownLabel;
        private System.Windows.Forms.PictureBox sadPictureBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.PictureBox happyPictureBox;
    }
}

