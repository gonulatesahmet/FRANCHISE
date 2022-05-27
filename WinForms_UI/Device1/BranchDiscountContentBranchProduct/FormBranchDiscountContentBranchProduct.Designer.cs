namespace WinForms_UI.Device1.BranchDiscountContentBranchProduct
{
    partial class FormBranchDiscountContentBranchProduct
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
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbbBranch = new System.Windows.Forms.ComboBox();
            this.btnOnly0 = new System.Windows.Forms.Button();
            this.btnOnly1 = new System.Windows.Forms.Button();
            this.btnChangeState = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbbBranchProduct = new System.Windows.Forms.ComboBox();
            this.CbbBranchDiscountContent = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(302, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Şube Ürün :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbbBranch);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(671, 78);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Şube Seçiniz";
            // 
            // cbbBranch
            // 
            this.cbbBranch.FormattingEnabled = true;
            this.cbbBranch.Location = new System.Drawing.Point(9, 30);
            this.cbbBranch.Name = "cbbBranch";
            this.cbbBranch.Size = new System.Drawing.Size(180, 21);
            this.cbbBranch.TabIndex = 1;
            this.cbbBranch.SelectedIndexChanged += new System.EventHandler(this.CbbBranch_SelectedIndexChanged);
            // 
            // btnOnly0
            // 
            this.btnOnly0.Location = new System.Drawing.Point(689, 349);
            this.btnOnly0.Name = "btnOnly0";
            this.btnOnly0.Size = new System.Drawing.Size(224, 78);
            this.btnOnly0.TabIndex = 55;
            this.btnOnly0.Text = "Sadece Pasifleri Listele";
            this.btnOnly0.UseVisualStyleBackColor = true;
            // 
            // btnOnly1
            // 
            this.btnOnly1.Location = new System.Drawing.Point(689, 265);
            this.btnOnly1.Name = "btnOnly1";
            this.btnOnly1.Size = new System.Drawing.Size(224, 78);
            this.btnOnly1.TabIndex = 54;
            this.btnOnly1.Text = "Sadece Aktifleri Listele";
            this.btnOnly1.UseVisualStyleBackColor = true;
            // 
            // btnChangeState
            // 
            this.btnChangeState.Location = new System.Drawing.Point(689, 181);
            this.btnChangeState.Name = "btnChangeState";
            this.btnChangeState.Size = new System.Drawing.Size(224, 78);
            this.btnChangeState.TabIndex = 53;
            this.btnChangeState.Text = "Seçili Kategori Durumunu Değiştir";
            this.btnChangeState.UseVisualStyleBackColor = true;
            this.btnChangeState.Click += new System.EventHandler(this.btnChangeState_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(689, 97);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(224, 78);
            this.btnUpdate.TabIndex = 52;
            this.btnUpdate.Text = "Seçili Kategoriyi Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(689, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(224, 78);
            this.btnDelete.TabIndex = 51;
            this.btnDelete.Text = "Seçili Kategoriyi Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(919, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 50;
            this.dataGridView1.Size = new System.Drawing.Size(260, 1056);
            this.dataGridView1.TabIndex = 50;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbbBranchProduct);
            this.groupBox3.Controls.Add(this.CbbBranchDiscountContent);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(671, 162);
            this.groupBox3.TabIndex = 58;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Unvan";
            // 
            // cbbBranchProduct
            // 
            this.cbbBranchProduct.FormattingEnabled = true;
            this.cbbBranchProduct.Location = new System.Drawing.Point(372, 30);
            this.cbbBranchProduct.Name = "cbbBranchProduct";
            this.cbbBranchProduct.Size = new System.Drawing.Size(138, 21);
            this.cbbBranchProduct.TabIndex = 6;
            // 
            // CbbBranchDiscountContent
            // 
            this.CbbBranchDiscountContent.FormattingEnabled = true;
            this.CbbBranchDiscountContent.Location = new System.Drawing.Point(124, 30);
            this.CbbBranchDiscountContent.Name = "CbbBranchDiscountContent";
            this.CbbBranchDiscountContent.Size = new System.Drawing.Size(162, 21);
            this.CbbBranchDiscountContent.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(336, 104);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(174, 38);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Şube İndirim İçeriğe Ürün Ekle";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Şube İndirim İçerik :";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(689, 990);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(224, 78);
            this.btnExit.TabIndex = 56;
            this.btnExit.Text = "Çıkış";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(1185, 12);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 50;
            this.dataGridView2.Size = new System.Drawing.Size(735, 1056);
            this.dataGridView2.TabIndex = 59;
            this.dataGridView2.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseClick);
            // 
            // FormBranchDiscountContentBranchProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnOnly0);
            this.Controls.Add(this.btnOnly1);
            this.Controls.Add(this.btnChangeState);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormBranchDiscountContentBranchProduct";
            this.Text = "FormBranchDiscountContentBranchProduct";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormBranchDiscountContentBranchProduct_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbbBranch;
        private System.Windows.Forms.Button btnOnly0;
        private System.Windows.Forms.Button btnOnly1;
        private System.Windows.Forms.Button btnChangeState;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox cbbBranchProduct;
        private System.Windows.Forms.ComboBox CbbBranchDiscountContent;
    }
}