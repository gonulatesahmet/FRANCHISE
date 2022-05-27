using Business.Concrete;
using Business.Constants;
using Core.Tools.DataGrivView;
using Core.Tools.MyMessageBox;
using DataAccess.Concrete.Mssql;
using Entities.DTOs;
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
    public partial class FormEmployee : Form
    {
        #region Entity
        DeviceDto _deviceDto;
        public int EmployeeID;
        public bool EmployeeState;
        #endregion
        #region Manager
        EmployeeManager employeeManager = new EmployeeManager(new MsEmployeeDal());
        BranchManager branchManager = new BranchManager(new MsBranchDal());
        AppellationManager appellationManager = new AppellationManager(new MsAppellationDal());
        #endregion
        public FormEmployee(DeviceDto deviceDto)
        {
            _deviceDto = deviceDto;
            InitializeComponent();
        }
        private void ButtonStatus()
        {
            if (EmployeeID == 0)
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnChangeState.Enabled = false;
            }
            else
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnChangeState.Enabled = true;
            }
        }
        private void Clear()
        {
            EmployeeID = 0;
            EmployeeState = false;
            ButtonStatus();
            txtName.Text = null;
            txtSurName.Text = null;
            txtCode.Text = null;
            txtIdNumber.Text = null;
            txtPhone.Text = null;
            txtAddress.Text = null;
            txtMail.Text = null;
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
        private void EmployeeDtoGetByBranch(int branchId)
        {
            var result = employeeManager.EmployeeDtoGetByBranch(branchId);
            if (result.Success)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.Data;
                string[] headers = { "", "Personel Ad", "Personel Soyad", "Personel Kimlik No", "Personel Doğum Tarih", "Personel Kod", "", "Şube Ad","","Unvan Ad", "Personel Telefon","Personel Mail", "Personel Adres", "Personel Durum" };
                int[] visible = { 0, 6, 8 };
                MyDataGridView.createDataGridView(dataGridView1, headers, visible);
            }
        }
        private void FormEmployee_Load(object sender, EventArgs e)
        {
            ButtonStatus();
            CbbAppellationGetAll();
            CbbBranchList(_deviceDto.InstitutionId);
            EmployeeDtoGetByBranch(Convert.ToInt32(cbbBranch.SelectedValue));
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EmployeeID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["EmployeeId"].Value);
            EmployeeState = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["EmployeeState"].Value);
            ButtonStatus();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = employeeManager.Add(new Entities.Concrete.Employee
            {
                EmployeeName = txtName.Text,
                EmployeeSurname = txtSurName.Text,
                EmployeeIdNumber = txtIdNumber.Text,
                EmployeeBirthDate = Convert.ToDateTime(dtpBirthDate.Text),
                EmployeeCode = txtCode.Text,
                BranchId = Convert.ToInt32(cbbBranch.SelectedValue),
                EmployeePhone = txtPhone.Text,
                EmployeeMail = txtMail.Text,
                EmployeeAddress = txtAddress.Text,
                AppellationId = Convert.ToInt32(cbbAppellation.SelectedValue),
                EmployeeState = true
            });
            if (result.Success)
            {
                Clear();
                EmployeeDtoGetByBranch(Convert.ToInt32(cbbBranch.SelectedValue));
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = employeeManager.Delete(EmployeeID);
            if (result.Success)
            {
                Clear();
                EmployeeDtoGetByBranch(Convert.ToInt32(cbbBranch.SelectedValue));
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FormUpdate frm = new FormUpdate(new Entities.Concrete.Employee
            {
                EmployeeId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["EmployeeId"].Value),
                EmployeeName = Convert.ToString(dataGridView1.CurrentRow.Cells["EmployeeName"].Value),
                EmployeeSurname = Convert.ToString(dataGridView1.CurrentRow.Cells["EmployeeSurname"].Value),
                EmployeeIdNumber = Convert.ToString(dataGridView1.CurrentRow.Cells["EmployeeIdNumber"].Value),
                EmployeeBirthDate = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["EmployeeBirthDate"].Value),
                EmployeeCode = Convert.ToString(dataGridView1.CurrentRow.Cells["EmployeeCode"].Value),
                BranchId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["BranchId"].Value),
                AppellationId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AppellationId"].Value),
                EmployeePhone = Convert.ToString(dataGridView1.CurrentRow.Cells["EmployeePhone"].Value),
                EmployeeMail = Convert.ToString(dataGridView1.CurrentRow.Cells["EmployeeMail"].Value),
                EmployeeAddress = Convert.ToString(dataGridView1.CurrentRow.Cells["EmployeeAddress"].Value)
            });
            frm.InstitutionId = _deviceDto.InstitutionId;
            frm.ShowDialog();
            Clear();
            EmployeeDtoGetByBranch(Convert.ToInt32(cbbBranch.SelectedValue));
        }
        private void btnChangeState_Click(object sender, EventArgs e)
        {
            var result = employeeManager.ChangeState(EmployeeID, EmployeeState);
            if (result.Success)
            {
                Clear();
                EmployeeDtoGetByBranch(Convert.ToInt32(cbbBranch.SelectedValue));
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployeeDtoGetByBranch(Convert.ToInt32(cbbBranch.SelectedValue));
        }
    }
}
