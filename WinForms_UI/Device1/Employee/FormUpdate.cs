using Business.Concrete;
using Business.Constants;
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

namespace WinForms_UI.Employee
{
    public partial class FormUpdate : Form
    {
        public int InstitutionId;
        Entities.Concrete.Employee _employee;
        EmployeeManager employeeManager = new EmployeeManager(new MsEmployeeDal());
        BranchManager branchManager = new BranchManager(new MsBranchDal());
        AppellationManager appellationManager = new AppellationManager(new MsAppellationDal());
        public FormUpdate(Entities.Concrete.Employee employee)
        {
            _employee = employee;
            InitializeComponent();
        }
        private void CbbAppellationGetAll()
        {
            cbbAppellation.DataSource = null;
            var result = appellationManager.CbbAppellationGetAll(true);
            if (result.Success)
            {
                cbbAppellation.ValueMember = "AppellationId";
                cbbAppellation.DisplayMember = "AppellationName";
                cbbAppellation.DataSource = result.Data;
            }
        }
        private void CbbBranchList(int InstitutionId)
        {
            var result = branchManager.CbbBranchGetAll(InstitutionId, true);
            if (result.Success)
            {
                cbbBranch.ValueMember = "BranchId";
                cbbBranch.DisplayMember = "BranchName";
                cbbBranch.DataSource = result.Data;
            }
        }
        private void FormUpdate_Load(object sender, EventArgs e)
        {
            CbbBranchList(InstitutionId);
            CbbAppellationGetAll();
            txtName.Text = _employee.EmployeeName;
            txtSurName.Text = _employee.EmployeeSurname;
            txtIdNumber.Text = _employee.EmployeeIdNumber;
            dtpBirthDate.Text = _employee.EmployeeBirthDate.ToString();
            txtCode.Text = _employee.EmployeeCode;
            txtPhone.Text = _employee.EmployeePhone;
            txtMail.Text = _employee.EmployeeMail;
            txtAddress.Text = _employee.EmployeeAddress;
            cbbBranch.SelectedValue = _employee.BranchId;
            cbbAppellation.SelectedValue = _employee.AppellationId;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = employeeManager.Update(new Entities.Concrete.Employee
            {
                EmployeeId = _employee.EmployeeId,
                EmployeeName = txtName.Text,
                EmployeeSurname = txtSurName.Text,
                EmployeeIdNumber = txtIdNumber.Text,
                EmployeeBirthDate = Convert.ToDateTime(dtpBirthDate.Value),
                EmployeePhone = txtPhone.Text,
                EmployeeCode = txtCode.Text,
                EmployeeAddress = txtAddress.Text,
                BranchId = Convert.ToInt32(cbbBranch.SelectedValue),
                AppellationId = Convert.ToInt32(cbbAppellation.SelectedValue),
                EmployeeMail = txtMail.Text
            });
            if (result.Success)
            {
                MyMessageBox.InfoMessageBox(result.Message);
                this.Close();
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }
    }
}
