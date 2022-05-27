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

namespace WinForms_UI.Product
{
    public partial class FormUpdate : Form
    {
        Entities.Concrete.Product _product;
        ProductManager productManager = new ProductManager(new MsProductDal());
        CategoryManager categoryManager = new CategoryManager(new MsCategoryDal());
        TypeOfProductManager typeOfProductManager = new TypeOfProductManager(new MsTypeOfProductDal());
        public FormUpdate(Entities.Concrete.Product product)
        {
            _product = product;
            InitializeComponent();
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
        private void FormUpdate_Load(object sender, EventArgs e)
        {
            cbbTypeOfProductGetAll();
            cbbCategoryGetAll();
            cbbStockStatusList();
            txtName.Text = _product.ProductName;
            txtCode.Text = _product.ProductCode;
            txtDescription.Text = _product.ProductDescription;
            txtPrice.Text = _product.ProductPrice.ToString();
            cbbCategory.SelectedValue = _product.CategoryId;
            cbbStockStatus.SelectedValue = _product.StockStatus;
            cbbTypeOfProduct.SelectedValue = _product.TypeOfProductId;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = productManager.Update(new Entities.Concrete.Product
            {
                ProductId = _product.ProductId,
                ProductName = txtName.Text,
                ProductCode = txtCode.Text,
                ProductDescription = txtDescription.Text,
                ProductPrice = Convert.ToDecimal(txtPrice.Text),
                CategoryId = Convert.ToInt32(cbbCategory.SelectedValue),
                StockStatus = Convert.ToBoolean(cbbStockStatus.SelectedValue),
                TypeOfProductId = Convert.ToInt32(cbbTypeOfProduct.SelectedValue)
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
