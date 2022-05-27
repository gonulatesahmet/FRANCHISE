using Business.Concrete;
using Core.Tools.MyMessageBox;
using DataAccess.Concrete.Mssql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_UI.Device2
{
    public partial class FormEmployeeControl : Form
    {
        public int BranchId;
        public int AreaId;
        public string Namespace;
        public string FormName;
        public bool FormResult;
        public int EmployeeId;
        EmployeeManager employeeManager = new EmployeeManager(new MsEmployeeDal());
        public FormEmployeeControl()
        {
            InitializeComponent();
        }
        private void WriteTextBox(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "btn1":
                    txtEmployeeCode.Text += (1).ToString();
                    break;
                case "btn2":
                    txtEmployeeCode.Text += (2).ToString();
                    break;
                case "btn3":
                    txtEmployeeCode.Text += (3).ToString();
                    break;
                case "btn4":
                    txtEmployeeCode.Text += (4).ToString();
                    break;
                case "btn5":
                    txtEmployeeCode.Text += (5).ToString();
                    break;
                case "btn6":
                    txtEmployeeCode.Text += (6).ToString();
                    break;
                case "btn7":
                    txtEmployeeCode.Text += (7).ToString();
                    break;
                case "btn8":
                    txtEmployeeCode.Text += (8).ToString();
                    break;
                case "btn9":
                    txtEmployeeCode.Text += (9).ToString();
                    break;
                case "btn0":
                    txtEmployeeCode.Text += (0).ToString();
                    break;
                case "btnx":
                    if(txtEmployeeCode.Text.Length == 0)
                    {
                        MyMessageBox.ErrorMessageBox("Kutu Zaten Boş");
                    }
                    else
                    {
                        txtEmployeeCode.Text = txtEmployeeCode.Text.Remove(txtEmployeeCode.Text.Length - 1, 1);
                    }
                    break;
                default:
                    MyMessageBox.ErrorMessageBox("Sayı Giriniz.");
                    break;
            }
        }
        private void FormEmployeeControl_Load(object sender, EventArgs e)
        {
            btn1.Click += new EventHandler(WriteTextBox);
            btn2.Click += new EventHandler(WriteTextBox);
            btn3.Click += new EventHandler(WriteTextBox);
            btn4.Click += new EventHandler(WriteTextBox);
            btn5.Click += new EventHandler(WriteTextBox);
            btn6.Click += new EventHandler(WriteTextBox);
            btn7.Click += new EventHandler(WriteTextBox);
            btn8.Click += new EventHandler(WriteTextBox);
            btn9.Click += new EventHandler(WriteTextBox);
            btn0.Click += new EventHandler(WriteTextBox);
            btnx.Click += new EventHandler(WriteTextBox);
        }
        //FormBranchMainMachine abc = (FormBranchMainMachine)Application.OpenForms["FormBranchMainMachine"];
        public void txtEmployeeCode_TextChanged(object sender, EventArgs e)
        {
            if(txtEmployeeCode.Text.Length == 6)
            {
                var result = employeeManager.EmployeeCodeControl(txtEmployeeCode.Text, BranchId);
                if (result.Success)
                {
                    this.FormResult = true;
                    this.DialogResult = DialogResult.OK;
                    this.EmployeeId = result.Data.EmployeeId;
                    this.Close();
                }
                else
                {
                    MyMessageBox.InfoMessageBox(result.Message);
                }

            }
        }
    }
}
