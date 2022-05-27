using Business.Concrete;
using Business.Constants;
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
    public partial class FormUpdate : Form
    {
        BranchProductDto _branchProductDto;
        BranchProductManager branchProductManager = new BranchProductManager(new MsBranchProductDal());
        public FormUpdate(BranchProductDto branchProductDto)
        {
            _branchProductDto = branchProductDto;
            InitializeComponent();
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
        private void FormUpdate_Load(object sender, EventArgs e)
        {
            cbbStockStatusList();
            lblProductName.Text = _branchProductDto.ProductName;
            txtProductPrice.Text = _branchProductDto.BranchProductPrice.ToString();
            cbbStockStatus.SelectedValue = _branchProductDto.StockStatus;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = branchProductManager.Update(new Entities.Concrete.BranchProduct
            {
                BranchProductId = _branchProductDto.BranchProductId,
                ProductId = _branchProductDto.ProductId,
                BranchProductPrice = Convert.ToDecimal(txtProductPrice.Text),
                StockStatus = Convert.ToBoolean(cbbStockStatus.SelectedValue)
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
