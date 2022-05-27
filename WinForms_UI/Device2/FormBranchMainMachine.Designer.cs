namespace WinForms_UI.Device2
{
    partial class FormBranchMainMachine
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
            this.btnSession = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnBranchGeneralReport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDeviceMac = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblBranch = new System.Windows.Forms.Label();
            this.lblInstitution = new System.Windows.Forms.Label();
            this.lblTypeOfDevice = new System.Windows.Forms.Label();
            this.lblDeviceCode = new System.Windows.Forms.Label();
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSession
            // 
            this.btnSession.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(64)))), ((int)(((byte)(139)))));
            this.btnSession.FlatAppearance.BorderSize = 0;
            this.btnSession.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSession.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.btnSession.Location = new System.Drawing.Point(408, 360);
            this.btnSession.Name = "btnSession";
            this.btnSession.Size = new System.Drawing.Size(273, 168);
            this.btnSession.TabIndex = 41;
            this.btnSession.Text = "Salonlar";
            this.btnSession.UseVisualStyleBackColor = false;
            this.btnSession.Click += new System.EventHandler(this.btnSession_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(64)))), ((int)(((byte)(139)))));
            this.btnEmployee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEmployee.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(157)))), ((int)(((byte)(81)))));
            this.btnEmployee.FlatAppearance.BorderSize = 0;
            this.btnEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.btnEmployee.Location = new System.Drawing.Point(966, 360);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(273, 168);
            this.btnEmployee.TabIndex = 45;
            this.btnEmployee.Text = "Personel";
            this.btnEmployee.UseVisualStyleBackColor = false;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(64)))), ((int)(((byte)(139)))));
            this.btnPayment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPayment.FlatAppearance.BorderSize = 0;
            this.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.btnPayment.Location = new System.Drawing.Point(687, 360);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(273, 168);
            this.btnPayment.TabIndex = 46;
            this.btnPayment.Text = "Odeme";
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnBranchGeneralReport
            // 
            this.btnBranchGeneralReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(64)))), ((int)(((byte)(139)))));
            this.btnBranchGeneralReport.FlatAppearance.BorderSize = 0;
            this.btnBranchGeneralReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBranchGeneralReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBranchGeneralReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.btnBranchGeneralReport.Location = new System.Drawing.Point(1245, 360);
            this.btnBranchGeneralReport.Name = "btnBranchGeneralReport";
            this.btnBranchGeneralReport.Size = new System.Drawing.Size(273, 168);
            this.btnBranchGeneralReport.TabIndex = 47;
            this.btnBranchGeneralReport.Text = "Şube Genel Rapor";
            this.btnBranchGeneralReport.UseVisualStyleBackColor = false;
            this.btnBranchGeneralReport.Click += new System.EventHandler(this.btnBranchGeneralReport_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(64)))), ((int)(((byte)(139)))));
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblDeviceMac);
            this.panel1.Controls.Add(this.lblArea);
            this.panel1.Controls.Add(this.lblBranch);
            this.panel1.Controls.Add(this.lblInstitution);
            this.panel1.Controls.Add(this.lblTypeOfDevice);
            this.panel1.Controls.Add(this.lblDeviceCode);
            this.panel1.Controls.Add(this.lblDeviceName);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 304);
            this.panel1.TabIndex = 48;
            // 
            // lblDeviceMac
            // 
            this.lblDeviceMac.AutoSize = true;
            this.lblDeviceMac.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.lblDeviceMac.Location = new System.Drawing.Point(88, 261);
            this.lblDeviceMac.Name = "lblDeviceMac";
            this.lblDeviceMac.Size = new System.Drawing.Size(11, 13);
            this.lblDeviceMac.TabIndex = 27;
            this.lblDeviceMac.Text = "*";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.lblArea.Location = new System.Drawing.Point(88, 231);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(11, 13);
            this.lblArea.TabIndex = 26;
            this.lblArea.Text = "*";
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.lblBranch.Location = new System.Drawing.Point(88, 201);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(11, 13);
            this.lblBranch.TabIndex = 25;
            this.lblBranch.Text = "*";
            // 
            // lblInstitution
            // 
            this.lblInstitution.AutoSize = true;
            this.lblInstitution.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.lblInstitution.Location = new System.Drawing.Point(88, 171);
            this.lblInstitution.Name = "lblInstitution";
            this.lblInstitution.Size = new System.Drawing.Size(11, 13);
            this.lblInstitution.TabIndex = 24;
            this.lblInstitution.Text = "*";
            // 
            // lblTypeOfDevice
            // 
            this.lblTypeOfDevice.AutoSize = true;
            this.lblTypeOfDevice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.lblTypeOfDevice.Location = new System.Drawing.Point(88, 141);
            this.lblTypeOfDevice.Name = "lblTypeOfDevice";
            this.lblTypeOfDevice.Size = new System.Drawing.Size(11, 13);
            this.lblTypeOfDevice.TabIndex = 23;
            this.lblTypeOfDevice.Text = "*";
            // 
            // lblDeviceCode
            // 
            this.lblDeviceCode.AutoSize = true;
            this.lblDeviceCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.lblDeviceCode.Location = new System.Drawing.Point(88, 111);
            this.lblDeviceCode.Name = "lblDeviceCode";
            this.lblDeviceCode.Size = new System.Drawing.Size(11, 13);
            this.lblDeviceCode.TabIndex = 22;
            this.lblDeviceCode.Text = "*";
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.AutoSize = true;
            this.lblDeviceName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.lblDeviceName.Location = new System.Drawing.Point(88, 81);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(11, 13);
            this.lblDeviceName.TabIndex = 21;
            this.lblDeviceName.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.label7.Location = new System.Drawing.Point(42, 231);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Salon :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.label6.Location = new System.Drawing.Point(17, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Cihaz MAC :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.label5.Location = new System.Drawing.Point(24, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Cihaz Tür :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.label4.Location = new System.Drawing.Point(44, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Şube :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.label3.Location = new System.Drawing.Point(39, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Kurum :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.label2.Location = new System.Drawing.Point(21, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Cihaz Kod :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.label1.Location = new System.Drawing.Point(27, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Cihaz Ad :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.label8.Location = new System.Drawing.Point(3, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 25);
            this.label8.TabIndex = 28;
            this.label8.Text = "Cihaz Bilgileri";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(64)))), ((int)(((byte)(139)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.btnExit.Location = new System.Drawing.Point(1635, 900);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(273, 168);
            this.btnExit.TabIndex = 49;
            this.btnExit.Text = "Çıkış";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormBranchMainMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBranchGeneralReport);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.btnEmployee);
            this.Controls.Add(this.btnSession);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormBranchMainMachine";
            this.Text = "FormBranchMainMachine";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSession;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnBranchGeneralReport;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lblDeviceMac;
        public System.Windows.Forms.Label lblArea;
        public System.Windows.Forms.Label lblBranch;
        public System.Windows.Forms.Label lblInstitution;
        public System.Windows.Forms.Label lblTypeOfDevice;
        public System.Windows.Forms.Label lblDeviceCode;
        public System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
    }
}