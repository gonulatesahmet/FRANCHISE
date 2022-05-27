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

namespace WinForms_UI.Product
{
    public partial class FormProduct : Form
    {
        #region Entity
        public int ProductId;
        public bool ProductState;
        DeviceDto _deviceDto;
        #endregion
        #region Manager
        ProductManager productManager = new ProductManager(new MsProductDal());
        CategoryManager categoryManager = new CategoryManager(new MsCategoryDal());
        TypeOfProductManager typeOfProductManager = new TypeOfProductManager(new MsTypeOfProductDal());
        #endregion
        public FormProduct(DeviceDto deviceDto)
        {
            _deviceDto = deviceDto;
            InitializeComponent();
        }
        private void ButtonStatus()
        {
            if (ProductId == 0)
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
            ProductId = 0;
            ProductState = false;
            ButtonStatus();
            txtName.Text = null;
            txtCode.Text = null;
            txtDescription.Text = null;
            txtPrice.Text = null;
            cbbCategory.SelectedIndex = 0;
            cbbStockStatus.SelectedIndex = 0;
            cbbTypeOfProduct.SelectedIndex = 0;
        }
        public class CbbStockStatus
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
        private void cbbTypeOfProductGetAll()
        {
            cbbTypeOfProduct.DataSource = null;
            var result = typeOfProductManager.CbbTypeOfProductGetAll(true);
            if (result.Success)
            {
                cbbTypeOfProduct.ValueMember = "TypeOfProductId";
                cbbTypeOfProduct.DisplayMember = "TypeOfProductName";
                cbbTypeOfProduct.DataSource = result.Data;
            }
        }
        private void cbbCategoryGetAll()
        {
            var result = categoryManager.CbbCategoryGetAll(true);
            if (result.Success)
            {
                cbbCategory.ValueMember = "CategoryId";
                cbbCategory.DisplayMember = "CategoryName";
                cbbCategory.DataSource = result.Data;
            }
        }
        private void ProductDtoGetAll()
        {
            var result = productManager.ProductDtoGetAll();
            if (result.Success)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.Data;
                string[] headers = { "", "Ürün Ad", "Ürün Kod", "Ürün Açıklama", "Ürün Fiyat", "", "Kategori Ad","","Ürün Tür", "Stok Durum", "Ürün Durum" };
                int[] visible = { 0, 5, 7 };
                MyDataGridView.createDataGridView(dataGridView1, headers, visible);
            }
        }
        private void FormProduct_Load(object sender, EventArgs e)
        {
            cbbTypeOfProductGetAll();
            cbbStockStatusList();
            cbbCategoryGetAll();
            ButtonStatus();
            ProductDtoGetAll();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = productManager.Add(new Entities.Concrete.Product
            {
                ProductName = txtName.Text,
                ProductCode = txtCode.Text,
                ProductDescription = txtDescription.Text,
                ProductPrice = Convert.ToDecimal(txtPrice.Text),
                StockStatus = Convert.ToBoolean(cbbStockStatus.SelectedValue),
                CategoryId = Convert.ToInt32(cbbCategory.SelectedValue),
                TypeOfProductId = Convert.ToInt32(cbbTypeOfProduct.SelectedValue),
                ProductState = true
            });
            if (result.Success)
            {
                Clear();
                ProductDtoGetAll();
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = productManager.Delete(ProductId);
            if (result.Success)
            {
                Clear();
                ProductDtoGetAll();
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FormUpdate frm = new FormUpdate(new Entities.Concrete.Product
            {
                ProductId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ProductId"].Value),
                ProductName = Convert.ToString(dataGridView1.CurrentRow.Cells["ProductName"].Value),
                ProductCode = Convert.ToString(dataGridView1.CurrentRow.Cells["ProductCode"].Value),
                ProductDescription = Convert.ToString(dataGridView1.CurrentRow.Cells["ProductDescription"].Value),
                ProductPrice = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["ProductPrice"].Value),
                CategoryId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CategoryId"].Value),
                StockStatus =Convert.ToBoolean(dataGridView1.CurrentRow.Cells["StockStatus"].Value),
                TypeOfProductId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TypeOfProductId"].Value)
            });
            frm.ShowDialog();
            Clear();
            ProductDtoGetAll();
        }

        private void btnChangeState_Click(object sender, EventArgs e)
        {
            var result = productManager.ChangeState(ProductId, ProductState);
            if (result.Success)
            {
                Clear();
                ProductDtoGetAll();
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ProductId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ProductId"].Value);
            ProductState = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["ProductState"].Value);
            ButtonStatus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
