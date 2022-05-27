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

namespace WinForms_UI.Device1.BranchProduct
{
    public partial class FormBranchProduct : Form
    {
        #region Entities
        DeviceDto _deviceDto;
        public int BranchProductId;
        public bool BranchProductState;
        #endregion
        #region Manager
        BranchProductManager branchProductManager = new BranchProductManager(new MsBranchProductDal());
        BranchManager branchManager = new BranchManager(new MsBranchDal());
        ProductManager productManager = new ProductManager(new MsProductDal());
        #endregion


        public FormBranchProduct(DeviceDto deviceDto)
        {
            _deviceDto = deviceDto;
            InitializeComponent();
        }
        private void ButtonStatus()
        {
            if (BranchProductId == 0)
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
            BranchProductId = 0;
            BranchProductState = false;
            ButtonStatus();
        }
        private class CbbStockStatus
        {
            public bool Value { get; set; }
            public string Key { get; set; }
        }
        private void cbbStockStatusList()
        {
            List<CbbStockStatus> cbbStockStatusList = new List<CbbStockStatus>()
            {
                new CbbStockStatus { Value = false, Key = "Sayılamaz" },
                new CbbStockStatus { Value = true, Key = "Sayılabilir" }
            };
            cbbStockStatus.DataSource = cbbStockStatusList;
            cbbStockStatus.DisplayMember = "Key";
            cbbStockStatus.ValueMember = "Value";
        }
        private void CbbBranchList(int institutionId)
        {
            var result = branchManager.CbbBranchGetAll(institutionId, true);
            if (result.Success)
            {
                cbbBranch.ValueMember = "BranchId";
                cbbBranch.DisplayMember = "BranchName";
                cbbBranch.DataSource = result.Data;
            }
        }
        private void BranchProductDtoList(int branchId)
        {
            var result = branchProductManager.BranchProductDtoGetByBranch(branchId, true);
            if (result.Success)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.Data;
                string[] headers = { "", "", "", "", "Ürün Ad", "Şube Ürün Fiyat", "Ürün Fiyat","","Kategori Ad","","Ürün Tür", "Stok Durum", "Şube Ürün Durum" };
                int[] visible = { 0, 1, 2, 3, 7, 9 };
                MyDataGridView.createDataGridView(dataGridView1, headers, visible);
            }
        }
        private void ProductGetNotAvailableInBranchProduct(int branchId)
        {
            cbbBranchProduct.DataSource = null;
            var result = productManager.CbbProductGetNotAvailableInBranchProduct(branchId, true);
            if (result.Success)
            {
                cbbBranchProduct.ValueMember = "ProductId";
                cbbBranchProduct.DisplayMember = "ProductName";
                cbbBranchProduct.DataSource = result.Data;
            }
        }
        private void FormBranchProduct_Load(object sender, EventArgs e)
        {
            ButtonStatus();
            CbbBranchList(_deviceDto.InstitutionId);
            cbbStockStatusList();
        }
        private void cbbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            BranchProductDtoList(Convert.ToInt32(cbbBranch.SelectedValue));
            ProductGetNotAvailableInBranchProduct(Convert.ToInt32(cbbBranch.SelectedValue));
            if (cbbBranchProduct.Items.Count <= 0)
            {
                btnAdd.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = branchProductManager.Add(new Entities.Concrete.BranchProduct
            {
                BranchId = Convert.ToInt32(cbbBranch.SelectedValue),
                ProductId = Convert.ToInt32(cbbBranchProduct.SelectedValue),
                BranchProductPrice = Convert.ToDecimal(txtProductPrice.Text),
                StockStatus = Convert.ToBoolean(cbbStockStatus.SelectedValue),
                BranchProductState = true
            });
            if (result.Success)
            {
                BranchProductDtoList(Convert.ToInt32(cbbBranch.SelectedValue));
                ProductGetNotAvailableInBranchProduct(Convert.ToInt32(cbbBranch.SelectedValue));
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = branchProductManager.Delete(BranchProductId);
            if (result.Success)
            {
                BranchProductDtoList(Convert.ToInt32(cbbBranch.SelectedValue));
                ProductGetNotAvailableInBranchProduct(Convert.ToInt32(cbbBranch.SelectedValue));
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
            FormUpdate frm = new FormUpdate(new BranchProductDto
            {
                BranchProductId = BranchProductId,
                ProductId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ProductId"].Value),
                ProductName = Convert.ToString(dataGridView1.CurrentRow.Cells["ProductName"].Value),
                BranchProductPrice = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["BranchProductPrice"].Value),
                StockStatus = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["StockStatus"].Value)
            });
            frm.ShowDialog();
            Clear();
            BranchProductDtoList(Convert.ToInt32(cbbBranch.SelectedValue));
            ProductGetNotAvailableInBranchProduct(Convert.ToInt32(cbbBranch.SelectedValue));
        }
        private void btnChangeState_Click(object sender, EventArgs e)
        {
            var result = branchProductManager.ChangeState(BranchProductId, BranchProductState);
            if (result.Success)
            {
                BranchProductDtoList(Convert.ToInt32(cbbBranch.SelectedValue));
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
            BranchProductId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["BranchProductId"].Value);
            BranchProductState = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["BranchProductState"].Value);
            ButtonStatus();
        }


    }
}
