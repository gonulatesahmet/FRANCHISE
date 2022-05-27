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

namespace WinForms_UI.Branch
{
    public partial class FormBranch : Form
    {
        #region Entity
        public int InstitutionId;
        public int BranchId;
        public bool BranchState;
        DeviceDto _deviceDto;
        #endregion
        #region Manager
        BranchManager branchManager = new BranchManager(new MsBranchDal());
        #endregion

        public FormBranch(DeviceDto deviceDto)
        {
            _deviceDto = deviceDto;
            InitializeComponent();
        }
        private void ButtonStatus()
        {
            if (BranchId == 0)
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
            BranchId = 0;
            BranchState = false;
            ButtonStatus();
            txtName.Text = null;
            txtCode.Text = null;
            txtDescription.Text = null;
            txtAuthorizedName.Text = null;
            txtPhone.Text = null;
            txtMail.Text = null;
            txtAddress.Text= null;
            txtCity.Text = null;
            txtDistrict.Text= null;
            txtBranchRegion.Text = null;
        }
        private void BranchList(int institutionId)
        {
            var result = branchManager.GetAll(institutionId);
            if (result.Success)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.Data;
                string[] headers = { "", "", "Şube Ad", "Şube Kod", "Şube Açıklama", "Yetkili Kişi", "Şube Telefon", "Şube Mail","Bölge", "Şehir", "İlçe", "Şube Adres", "Durum" };
                int[] visible = { 0, 1 };
                MyDataGridView.createDataGridView(dataGridView1, headers, visible);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }
        private void FormBranch_Load(object sender, EventArgs e)
        {
            BranchList(_deviceDto.InstitutionId);
            Clear();
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BranchId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["BranchId"].Value);
            BranchState = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["BranchState"].Value);
            ButtonStatus();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = branchManager.Add(new Entities.Concrete.Branch
            {
                BranchName = txtName.Text,
                BranchCode= txtCode.Text,
                BranchDescription = txtDescription.Text,
                AuthorizedPerson = txtAuthorizedName.Text,
                BranchPhone = txtPhone.Text,
                BranchMail = txtMail.Text,
                BranchAddress = txtAddress.Text,
                BranchRegion = txtBranchRegion.Text,
                BranchCity = txtCity.Text,
                BranchDistrict = txtDistrict.Text,
                InstitutionId = _deviceDto.InstitutionId,
                BranchState = true
            });
            if (result.Success)
            {
                BranchList(_deviceDto.InstitutionId);
                Clear();
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = branchManager.Delete(BranchId);
            if (result.Success)
            {
                Clear();
                BranchList(_deviceDto.InstitutionId);
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                Clear();
                MyMessageBox.ErrorMessageBox(Messages.DeletedFailed);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FormUpdate frm = new FormUpdate(new Entities.Concrete.Branch
            {
                BranchId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["BranchId"].Value),
                BranchName = Convert.ToString(dataGridView1.CurrentRow.Cells["BranchName"].Value),
                BranchCode = Convert.ToString(dataGridView1.CurrentRow.Cells["BranchCode"].Value),
                BranchDescription = Convert.ToString(dataGridView1.CurrentRow.Cells["BranchDescription"].Value),
                AuthorizedPerson = Convert.ToString(dataGridView1.CurrentRow.Cells["AuthorizedPerson"].Value),
                BranchPhone = Convert.ToString(dataGridView1.CurrentRow.Cells["BranchPhone"].Value),
                BranchMail = Convert.ToString(dataGridView1.CurrentRow.Cells["BranchMail"].Value),
                BranchRegion = Convert.ToString(dataGridView1.CurrentRow.Cells["BranchRegion"].Value),
                BranchCity = Convert.ToString(dataGridView1.CurrentRow.Cells["BranchCity"].Value),
                BranchDistrict = Convert.ToString(dataGridView1.CurrentRow.Cells["BranchDistrict"].Value),
                BranchAddress = Convert.ToString(dataGridView1.CurrentRow.Cells["BranchAddress"].Value)
            });
            frm.ShowDialog();
            Clear();
            BranchList(_deviceDto.InstitutionId);
        }
        private void btnChangeState_Click(object sender, EventArgs e)
        {
            var result = branchManager.ChangeState(BranchId, BranchState);
            if (result.Success)
            {
                BranchList(_deviceDto.InstitutionId);
                Clear();
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                Clear();
                MyMessageBox.ErrorMessageBox(Messages.ChangeStatedFailed);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
