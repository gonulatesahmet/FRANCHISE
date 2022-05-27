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

namespace WinForms_UI.Device1.BranchDiscount
{
    public partial class FormBranchDiscount : Form
    {
        #region Entities
        DeviceDto _deviceDto;
        public int BranchDiscountId;
        public bool BranchDiscountState;
        #endregion
        #region Manager
        BranchManager branchManager = new BranchManager(new MsBranchDal());
        TypeOfDiscountManager typeOfDiscountManager = new TypeOfDiscountManager(new MsTypeOfDiscountDal());
        DiscountManager discountManager = new DiscountManager(new MsDiscountDal());
        BranchDiscountManager branchDiscountManager = new BranchDiscountManager(new MsBranchDiscountDal());
        #endregion
        public FormBranchDiscount(DeviceDto deviceDto)
        {
            _deviceDto = deviceDto;
            InitializeComponent();
        }
        private void ButtonStatus()
        {
            if (BranchDiscountId == 0)
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
            BranchDiscountId = 0;
            BranchDiscountState = false;
            ButtonStatus();
        }
        private void CbbBranchList(int institutionId)
        {
            cbbBranch.DataSource = null;
            var result = branchManager.CbbBranchGetAll(institutionId, true);
            if (result.Success)
            {
                cbbBranch.ValueMember = "BranchId";
                cbbBranch.DisplayMember = "BranchName";
                cbbBranch.DataSource = result.Data;
            }
        }
        private void CbbDiscountList(int branchId)
        {
            cbbDiscount.DataSource = null;
            var result = discountManager.DiscountGetNotAvailebleInBranchDiscount(branchId, true);
            if (result.Success)
            {
                cbbDiscount.ValueMember = "DiscountId";
                cbbDiscount.DisplayMember = "DiscountName";
                cbbDiscount.DataSource = result.Data;
            }
        }
        private void CbbTypeOfDiscountList()
        {
            cbbTypeOfDiscount.DataSource = null;
            var result = typeOfDiscountManager.CbbTypeOfDiscountGetAll(true);
            if (result.Success)
            {
                cbbTypeOfDiscount.ValueMember = "TypeOfDiscountId";
                cbbTypeOfDiscount.DisplayMember = "TypeOfDiscountName";
                cbbTypeOfDiscount.DataSource = result.Data;
            }
        }
        private void BranchDiscountList(int branchId)
        {
            var result = branchDiscountManager.BranchDiscountDtoGetByBranch(branchId);
            if (result.Success)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.Data;
                string[] headers = { "", "", "", "", "İndirim Ad", "", "İndirim Tür Ad", "İndirim Miktar", "Şube İndirim Durum" };
                int[] visible = { 0, 1, 2, 3, 5 };
                MyDataGridView.createDataGridView(dataGridView1, headers, visible);
            }
        }
        private void FormBranchDiscount_Load(object sender, EventArgs e)
        {
            CbbBranchList(_deviceDto.InstitutionId);
            CbbTypeOfDiscountList();
            ButtonStatus();
        }
        private void cbbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            BranchDiscountList(Convert.ToInt32(cbbBranch.SelectedValue));
            CbbDiscountList(Convert.ToInt32(cbbBranch.SelectedValue));
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BranchDiscountId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["BranchDiscountId"].Value);
            BranchDiscountState = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["BranchDiscountState"].Value);
            ButtonStatus();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = branchDiscountManager.Add(new Entities.Concrete.BranchDiscount
            {
                BranchId = Convert.ToInt32(cbbBranch.SelectedValue),
                DiscountId = Convert.ToInt32(cbbDiscount.SelectedValue),
                TypeOfDiscountId = Convert.ToInt32(cbbTypeOfDiscount.SelectedValue),
                BranchDiscountAmount = Convert.ToDecimal(txtAmount.Text),
                BranchDiscountState = true
            });
            if (result.Success)
            {
                BranchDiscountList(Convert.ToInt32(cbbBranch.SelectedValue));
                CbbDiscountList(Convert.ToInt32(cbbBranch.SelectedValue));
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = branchDiscountManager.Delete(BranchDiscountId);
            if (result.Success)
            {
                BranchDiscountList(Convert.ToInt32(cbbBranch.SelectedValue));
                CbbDiscountList(Convert.ToInt32(cbbBranch.SelectedValue));
                MyMessageBox.InfoMessageBox(result.Message);
                Clear();
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FormUpdate frm = new FormUpdate(new BranchDiscountDto
            {
                BranchDiscountId=BranchDiscountId,
                DiscountName = dataGridView1.CurrentRow.Cells["DiscountName"].Value.ToString(),
                TypeOfDiscountId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TypeOfDiscountId"].Value),
                BranchDiscountAmount = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["BranchDiscountAmount"].Value),
                DiscountId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["DiscountId"].Value)
            });
            frm.ShowDialog();
            BranchDiscountList(Convert.ToInt32(cbbBranch.SelectedValue));
        }
        private void btnChangeState_Click(object sender, EventArgs e)
        {
            var result = branchDiscountManager.ChangeState(BranchDiscountId, BranchDiscountState);
            if (result.Success)
            {
                BranchDiscountList(Convert.ToInt32(cbbBranch.SelectedValue));
                CbbDiscountList(Convert.ToInt32(cbbBranch.SelectedValue));
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
    }
}
