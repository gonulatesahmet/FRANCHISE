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

namespace WinForms_UI.Device1.BranchDiscountContent
{
    public partial class FormBranchDiscountContent : Form
    {
        #region Entities
        DeviceDto _deviceDto;
        public int BranchDiscountContentId;
        public bool BranchDiscountContentState;
        #endregion
        #region Manager
        BranchManager branchManager = new BranchManager(new MsBranchDal());
        BranchDiscountManager branchDiscountManager = new BranchDiscountManager(new MsBranchDiscountDal());
        BranchDiscountContentManager branchDiscountContentManager = new BranchDiscountContentManager(new MsBranchDiscountContentDal());
        #endregion
        public FormBranchDiscountContent(DeviceDto deviceDto)
        {
            _deviceDto = deviceDto;
            InitializeComponent();
        }
        private void ButtonStatus()
        {
            if (BranchDiscountContentId == 0)
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
            BranchDiscountContentId = 0;
            BranchDiscountContentState = false;
            txtName.Text = null;
            txtCode.Text = null;
            txtDescription.Text = null;
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
        private void CbbBranchDiscountList(int branchId)
        {
            cbbBranchDiscount.DataSource = null;
            var result = branchDiscountManager.CbbBranchDiscountGetByBranch(branchId, true);
            if (result.Success)
            {
                cbbBranchDiscount.ValueMember = "BranchDiscountId";
                cbbBranchDiscount.DisplayMember = "BranchDiscountName";
                cbbBranchDiscount.DataSource = result.Data;
            }
        }
        private void BranchDiscountContentList(int branchId)
        {
            var result = branchDiscountContentManager.BranchDiscountContentDtoGetByBranch(branchId);
            if (result.Success)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.Data;
                string[] headers = { "", "İndirim İçerik Ad", "İndirim İçerik Kod", "İndirim İçerik Açıklama", "", "İndirim Ad", "İndirim İçerik Durum" };
                int[] visible = { 0, 4 };
                MyDataGridView.createDataGridView(dataGridView1, headers, visible);
            }
        }

        private void FormBranchDiscountContent_Load(object sender, EventArgs e)
        {
            CbbBranchList(_deviceDto.InstitutionId);
            ButtonStatus();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BranchDiscountContentId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["BranchDiscountContentId"].Value);
            BranchDiscountContentState = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["BranchDiscountContentState"].Value);
            ButtonStatus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = branchDiscountContentManager.Add(new Entities.Concrete.BranchDiscountContent
            {
                BranchDiscountContentName = txtName.Text,
                BranchDiscountContentCode = txtCode.Text,
                BranchDiscountContentDescription = txtDescription.Text,
                BranchDiscountId = Convert.ToInt32(cbbBranchDiscount.SelectedValue),
                BranchDiscountContentState = true
            });
            if (result.Success)
            {
                BranchDiscountContentList(Convert.ToInt32(cbbBranch.SelectedValue));
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
            var result = branchDiscountContentManager.Delete(BranchDiscountContentId);
            if (result.Success)
            {
                BranchDiscountContentList(Convert.ToInt32(cbbBranch.SelectedValue));
                Clear();
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FormUpdate frm = new FormUpdate(new Entities.Concrete.BranchDiscountContent
            {
                BranchDiscountContentName = Convert.ToString(dataGridView1.CurrentRow.Cells["BranchDiscountContentName"].Value),
                BranchDiscountContentCode = Convert.ToString(dataGridView1.CurrentRow.Cells["BranchDiscountContentCode"].Value),
                BranchDiscountContentDescription = Convert.ToString(dataGridView1.CurrentRow.Cells["BranchDiscountContentDescription"].Value),
                BranchDiscountId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["BranchDiscountId"].Value),
                BranchDiscountContentId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["BranchDiscountContentId"].Value)
            })
            {
                BranchId = Convert.ToInt32(cbbBranch.SelectedValue)
            };
            frm.ShowDialog();
            BranchDiscountContentList(Convert.ToInt32(cbbBranch.SelectedValue));
            Clear();
        }

        private void btnChangeState_Click(object sender, EventArgs e)
        {
            var result = branchDiscountContentManager.ChangeState(BranchDiscountContentId, BranchDiscountContentState);
            if (result.Success)
            {
                BranchDiscountContentList(Convert.ToInt32(cbbBranch.SelectedValue));
                Clear();
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }

        private void cbbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbbBranchDiscountList(Convert.ToInt32(cbbBranch.SelectedValue));
            BranchDiscountContentList(Convert.ToInt32(cbbBranch.SelectedValue));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
