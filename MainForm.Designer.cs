namespace MedicalGasPlantAutomation
{
    partial class MainForm
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
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCOM = new System.Windows.Forms.ComboBox();
            this.CONNECTButton = new System.Windows.Forms.Button();
            this.logoMiniPictureBox = new System.Windows.Forms.PictureBox();
            this.mainFormMuteButton = new System.Windows.Forms.Button();
            this.mainFormMinimizeButton = new System.Windows.Forms.Button();
            this.mainFormExitButton = new System.Windows.Forms.Button();
            this.plantTabControl = new DevExpress.XtraTab.XtraTabControl();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.timerCOM = new System.Windows.Forms.Timer(this.components);
            this.timerGIF = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoMiniPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plantTabControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(88)))), ((int)(((byte)(145)))));
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBoxCOM);
            this.panel1.Controls.Add(this.CONNECTButton);
            this.panel1.Controls.Add(this.logoMiniPictureBox);
            this.panel1.Controls.Add(this.mainFormMuteButton);
            this.panel1.Controls.Add(this.mainFormMinimizeButton);
            this.panel1.Controls.Add(this.mainFormExitButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2560, 216);
            this.panel1.TabIndex = 1;
            // 
            // button6
            // 
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.Location = new System.Drawing.Point(2180, 17);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 66);
            this.button6.TabIndex = 11;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1307, 12);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 3;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(1549, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = " ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button4
            // 
            this.button4.Image = global::MedicalGasPlantAutomation.Properties.Resources.deButton;
            this.button4.Location = new System.Drawing.Point(2029, 25);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 57);
            this.button4.TabIndex = 9;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button3
            // 
            this.button3.Image = global::MedicalGasPlantAutomation.Properties.Resources.enButton1;
            this.button3.Location = new System.Drawing.Point(1909, 25);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 57);
            this.button3.TabIndex = 8;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Image = global::MedicalGasPlantAutomation.Properties.Resources.Fransa;
            this.button2.Location = new System.Drawing.Point(1789, 25);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 57);
            this.button2.TabIndex = 7;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(195, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 41);
            this.label2.TabIndex = 6;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(132, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(663, 41);
            this.label1.TabIndex = 6;
            this.label1.Text = "MEDICAL GAS PLANT MANAGEMENT SYSTEM";
            // 
            // comboBoxCOM
            // 
            this.comboBoxCOM.FormattingEnabled = true;
            this.comboBoxCOM.Location = new System.Drawing.Point(1776, 69);
            this.comboBoxCOM.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCOM.Name = "comboBoxCOM";
            this.comboBoxCOM.Size = new System.Drawing.Size(160, 24);
            this.comboBoxCOM.TabIndex = 2;
            this.comboBoxCOM.Visible = false;
            // 
            // CONNECTButton
            // 
            this.CONNECTButton.Location = new System.Drawing.Point(1773, 7);
            this.CONNECTButton.Margin = new System.Windows.Forms.Padding(4);
            this.CONNECTButton.Name = "CONNECTButton";
            this.CONNECTButton.Size = new System.Drawing.Size(169, 54);
            this.CONNECTButton.TabIndex = 4;
            this.CONNECTButton.Text = "CONNECT";
            this.CONNECTButton.UseVisualStyleBackColor = true;
            this.CONNECTButton.Visible = false;
            this.CONNECTButton.Click += new System.EventHandler(this.CONNECTButton_Click);
            // 
            // logoMiniPictureBox
            // 
            this.logoMiniPictureBox.Image = global::MedicalGasPlantAutomation.Properties.Resources.SchoennLogo58x58;
            this.logoMiniPictureBox.Location = new System.Drawing.Point(5, 4);
            this.logoMiniPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.logoMiniPictureBox.Name = "logoMiniPictureBox";
            this.logoMiniPictureBox.Size = new System.Drawing.Size(113, 105);
            this.logoMiniPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoMiniPictureBox.TabIndex = 1;
            this.logoMiniPictureBox.TabStop = false;
            this.logoMiniPictureBox.Click += new System.EventHandler(this.logoMiniPictureBox_Click);
            // 
            // mainFormMuteButton
            // 
            this.mainFormMuteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(88)))), ((int)(((byte)(145)))));
            this.mainFormMuteButton.BackgroundImage = global::MedicalGasPlantAutomation.Properties.Resources.muteGreen;
            this.mainFormMuteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.mainFormMuteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainFormMuteButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(88)))), ((int)(((byte)(145)))));
            this.mainFormMuteButton.Location = new System.Drawing.Point(2288, 17);
            this.mainFormMuteButton.Margin = new System.Windows.Forms.Padding(4);
            this.mainFormMuteButton.Name = "mainFormMuteButton";
            this.mainFormMuteButton.Size = new System.Drawing.Size(67, 62);
            this.mainFormMuteButton.TabIndex = 0;
            this.mainFormMuteButton.UseVisualStyleBackColor = false;
            this.mainFormMuteButton.Click += new System.EventHandler(this.mainFormMuteButton_Click);
            // 
            // mainFormMinimizeButton
            // 
            this.mainFormMinimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(88)))), ((int)(((byte)(145)))));
            this.mainFormMinimizeButton.BackgroundImage = global::MedicalGasPlantAutomation.Properties.Resources.minimize;
            this.mainFormMinimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.mainFormMinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainFormMinimizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(88)))), ((int)(((byte)(145)))));
            this.mainFormMinimizeButton.Location = new System.Drawing.Point(2384, 17);
            this.mainFormMinimizeButton.Margin = new System.Windows.Forms.Padding(4);
            this.mainFormMinimizeButton.Name = "mainFormMinimizeButton";
            this.mainFormMinimizeButton.Size = new System.Drawing.Size(67, 62);
            this.mainFormMinimizeButton.TabIndex = 0;
            this.mainFormMinimizeButton.UseVisualStyleBackColor = false;
            this.mainFormMinimizeButton.Click += new System.EventHandler(this.mainFormMinimizeButton_Click);
            // 
            // mainFormExitButton
            // 
            this.mainFormExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(88)))), ((int)(((byte)(145)))));
            this.mainFormExitButton.BackgroundImage = global::MedicalGasPlantAutomation.Properties.Resources.exit;
            this.mainFormExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.mainFormExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainFormExitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(88)))), ((int)(((byte)(145)))));
            this.mainFormExitButton.Location = new System.Drawing.Point(2476, 17);
            this.mainFormExitButton.Margin = new System.Windows.Forms.Padding(4);
            this.mainFormExitButton.Name = "mainFormExitButton";
            this.mainFormExitButton.Size = new System.Drawing.Size(67, 62);
            this.mainFormExitButton.TabIndex = 0;
            this.mainFormExitButton.UseVisualStyleBackColor = false;
            this.mainFormExitButton.Click += new System.EventHandler(this.mainFormExitButton_Click);
            // 
            // plantTabControl
            // 
            this.plantTabControl.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.plantTabControl.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.plantTabControl.Appearance.Options.UseBackColor = true;
            this.plantTabControl.AppearancePage.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(88)))), ((int)(((byte)(145)))));
            this.plantTabControl.AppearancePage.Header.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plantTabControl.AppearancePage.Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.plantTabControl.AppearancePage.Header.Options.UseBackColor = true;
            this.plantTabControl.AppearancePage.Header.Options.UseFont = true;
            this.plantTabControl.AppearancePage.Header.Options.UseForeColor = true;
            this.plantTabControl.AppearancePage.HeaderActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.plantTabControl.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.White;
            this.plantTabControl.AppearancePage.HeaderActive.Options.UseBackColor = true;
            this.plantTabControl.AppearancePage.HeaderActive.Options.UseForeColor = true;
            this.plantTabControl.AppearancePage.PageClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.plantTabControl.AppearancePage.PageClient.Options.UseBackColor = true;
            this.plantTabControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.plantTabControl.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.plantTabControl.Location = new System.Drawing.Point(0, 108);
            this.plantTabControl.Margin = new System.Windows.Forms.Padding(4);
            this.plantTabControl.Name = "plantTabControl";
            this.plantTabControl.Size = new System.Drawing.Size(2611, 1222);
            this.plantTabControl.TabIndex = 2;
            this.plantTabControl.Click += new System.EventHandler(this.plantTabControl_Click);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.defaultLookAndFeel1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            // 
            // timerCOM
            // 
            this.timerCOM.Interval = 50;
            this.timerCOM.Tick += new System.EventHandler(this.timerCOM_Tick);
            // 
            // timerGIF
            // 
            this.timerGIF.Enabled = true;
            this.timerGIF.Interval = 1000;
            this.timerGIF.Tick += new System.EventHandler(this.timerGIF_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MedicalGasPlantAutomation.Properties.Resources.InDuty;
            this.pictureBox1.Location = new System.Drawing.Point(1437, 102);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 256);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1631, 67);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(244, 183);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(1564, 675);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(343, 300);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1769, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 81);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1788, 47);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 25);
            this.comboBox1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1940, 1100);
            this.Controls.Add(this.plantTabControl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(2560, 1329);
            this.MinimumSize = new System.Drawing.Size(1819, 943);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_reload);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoMiniPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plantTabControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button mainFormExitButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button mainFormMinimizeButton;
        private System.Windows.Forms.PictureBox logoMiniPictureBox;
        private System.Windows.Forms.ComboBox comboBoxCOM;
        private DevExpress.XtraTab.XtraTabControl plantTabControl;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.Button mainFormMuteButton;
        private System.Windows.Forms.Button CONNECTButton;
        private System.Windows.Forms.Timer timerCOM;
        private System.Windows.Forms.Timer timerGIF;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}

