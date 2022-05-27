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

namespace WinForms_UI.Device1.BranchDiscountContentBranchProduct
{
    public partial class FormBranchDiscountContentBranchProduct : Form
    {
        #region Entity
        DeviceDto _deviceDto;
        public int BranchDiscountContentBranchProductId;
        public bool BranchDiscountContentBranchProductState;
        #endregion
        #region Manager
        BranchManager branchManager = new BranchManager(new MsBranchDal());
        BranchDiscountContentManager branchDiscountContentManager = new BranchDiscountContentManager(new MsBranchDiscountContentDal());
        BranchProductManager branchProductManager = new BranchProductManager(new MsBranchProductDal());
        BranchDiscountContentBranchProductManager branchDiscountContentBranchProductManager = new BranchDiscountContentBranchProductManager(new MsBranchDiscountContentBranchProductDal());
        #endregion
        public FormBranchDiscountContentBranchProduct(DeviceDto deviceDto)
        {
            _deviceDto = deviceDto;
            InitializeComponent();
        }
        private void ButtonStatus()
        {
            if (BranchDiscountContentBranchProductId == 0)
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
            BranchDiscountContentBranchProductId = 0;
            BranchDiscountContentBranchProductState = false;
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
        private void BranchDiscountContentList(int branchId)
        {
            CbbBranchDiscountContent.DataSource = null;
            var result = branchDiscountContentManager.CbbBranchDiscountContentGetByBranch(branchId, true);
            if (result.Success)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.Data;
                string[] headers = { "", "İndirim İçerik Ad"};
                int[] visible = { 0 };
                MyDataGridView.createDataGridView(dataGridView1, headers, visible);
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.ColumnHeadersVisible = false;


                CbbBranchDiscountContent.ValueMember = "BranchDiscountContentId";
                CbbBranchDiscountContent.DisplayMember = "BranchDiscountContentName";
                CbbBranchDiscountContent.DataSource = result.Data;
            }
        }
        private void BranchProductList(int branchId)
        {
            cbbBranchProduct.DataSource = null;
            var result = branchProductManager.CbbBranchProductGetByBranch(branchId, true);
            if (result.Success)
            {
                cbbBranchProduct.ValueMember = "BranchProductId";
                cbbBranchProduct.DisplayMember = "ProductName";
                cbbBranchProduct.DataSource = result.Data;
            }
            
        }
        private void BranchDiscountContentBranchProductDtoGetByBranchDiscountContent(int branchDiscountContentId)
        {
            var result = branchDiscountContentBranchProductManager.BranchDiscountContentBranchProductDtoGetByBranchDiscountContent(branchDiscountContentId);
            if (result.Success)
            {
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = result.Data;
                string[] headers = { "", "", "İndirim İçerik Ad", "", "Ürün Ad", "Ürün Fiyat", "İndirim İçerik Ürün Durum" };
                int[] visible = { 0, 1, 3 };
                MyDataGridView.createDataGridView(dataGridView2, headers, visible);
            }
        }
        private void FormBranchDiscountContentBranchProduct_Load(object sender, EventArgs e)
        {
            CbbBranchList(_deviceDto.InstitutionId);
            Clear();
        }

        private void CbbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            BranchDiscountContentList(Convert.ToInt32(cbbBranch.SelectedValue));
            BranchProductList(Convert.ToInt32(cbbBranch.SelectedValue));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = branchDiscountContentBranchProductManager.Add(new Entities.Concrete.BranchDiscountContentBranchProduct
            {
                BranchDiscountContentId = Convert.ToInt32(CbbBranchDiscountContent.SelectedValue),
                BranchProductId = Convert.ToInt32(cbbBranchProduct.SelectedValue),
                BranchDiscountContentBranchProductState = true
            });
            if (result.Success)
            {
                BranchDiscountContentBranchProductDtoGetByBranchDiscountContent(Convert.ToInt32(CbbBranchDiscountContent.SelectedValue));
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = branchDiscountContentBranchProductManager.Delete(BranchDiscountContentBranchProductId);
            if (result.Success)
            {
                BranchDiscountContentBranchProductDtoGetByBranchDiscountContent(Convert.ToInt32(dataGridView1.CurrentRow.Cells["BranchDiscountContentId"].Value));
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
            FormUpdate frm = new FormUpdate(new Entities.Concrete.BranchDiscountContentBranchProduct
            {
                BranchDiscountContentBranchProductId = Convert.ToInt32(dataGridView2.CurrentRow.Cells["BranchDiscountContentBranchProductId"].Value),
                BranchDiscountContentId = Convert.ToInt32(dataGridView2.CurrentRow.Cells["BranchDiscountContentId"].Value),
                BranchProductId = Convert.ToInt32(dataGridView2.CurrentRow.Cells["BranchProductId"].Value)
            });
            frm.BranchId = _deviceDto.BranchId;
            frm.ShowDialog();
            Clear();
            BranchDiscountContentBranchProductDtoGetByBranchDiscountContent(Convert.ToInt32(dataGridView1.CurrentRow.Cells["BranchDiscountContentId"].Value));
        }

        private void btnChangeState_Click(object sender, EventArgs e)
        {
            var result = branchDiscountContentBranchProductManager.ChangeState(BranchDiscountContentBranchProductId, BranchDiscountContentBranchProductState);
            if (result.Success)
            {
                BranchDiscountContentBranchProductDtoGetByBranchDiscountContent(Convert.ToInt32(dataGridView1.CurrentRow.Cells["BranchDiscountContentId"].Value));
                Clear();
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BranchDiscountContentBranchProductDtoGetByBranchDiscountContent(Convert.ToInt32(dataGridView1.CurrentRow.Cells["BranchDiscountContentId"].Value));
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BranchDiscountContentBranchProductId = Convert.ToInt32(dataGridView2.CurrentRow.Cells["BranchDiscountContentBranchProductId"].Value);
            BranchDiscountContentBranchProductState = Convert.ToBoolean(dataGridView2.CurrentRow.Cells["BranchDiscountContentBranchProductState"].Value);
            ButtonStatus();
        }
    }
}
