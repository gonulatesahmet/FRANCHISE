using Business.Concrete;
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

namespace WinForms_UI.Device1.BranchDiscountContentBranchProduct
{
    public partial class FormUpdate : Form
    {
        public int BranchId;
        Entities.Concrete.BranchDiscountContentBranchProduct _branchDiscountContentBranchProduct;
        BranchProductManager branchProductManager = new BranchProductManager(new MsBranchProductDal());
        BranchDiscountContentBranchProductManager branchDiscountContentBranchProductManager = new BranchDiscountContentBranchProductManager(new MsBranchDiscountContentBranchProductDal());
        public FormUpdate(Entities.Concrete.BranchDiscountContentBranchProduct branchDiscountContentBranchProduct)
        {
            _branchDiscountContentBranchProduct = branchDiscountContentBranchProduct;
            InitializeComponent();
        }
        private void CbbBranchProductList(int branchId)
        {
            cbbBranchProduct.DataSource = null;
            var result = branchProductManager.CbbBranchProductGetByBranch(branchId, true);
            if (result.Success)
            {
                cbbBranchProduct.ValueMember = "BranchProductId";
                cbbBranchProduct.DisplayMember = "ProductName";
                cbbBranchProduct.DataSource = result.Data;
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
                this.Close();
            }
        }

        private void FormUpdate_Load(object sender, EventArgs e)
        {
            CbbBranchProductList(BranchId);
            cbbBranchProduct.SelectedValue = _branchDiscountContentBranchProduct.BranchProductId;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = branchDiscountContentBranchProductManager.Update(new Entities.Concrete.BranchDiscountContentBranchProduct
            {
                BranchDiscountContentBranchProductId = _branchDiscountContentBranchProduct.BranchDiscountContentBranchProductId,
                BranchDiscountContentId = _branchDiscountContentBranchProduct.BranchDiscountContentId,
                BranchProductId = Convert.ToInt32(cbbBranchProduct.SelectedValue)
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
