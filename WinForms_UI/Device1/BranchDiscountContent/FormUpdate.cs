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

namespace WinForms_UI.Device1.BranchDiscountContent
{
    public partial class FormUpdate : Form
    {
        public int BranchId;
        Entities.Concrete.BranchDiscountContent _branchDiscountContent;
        BranchDiscountManager branchDiscountManager = new BranchDiscountManager(new MsBranchDiscountDal());
        BranchDiscountContentManager branchDiscountContentManager = new BranchDiscountContentManager(new MsBranchDiscountContentDal());
        public FormUpdate(Entities.Concrete.BranchDiscountContent branchDiscountContent)
        {
            _branchDiscountContent = branchDiscountContent;
            InitializeComponent();
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

        private void FormUpdate_Load(object sender, EventArgs e)
        {
            CbbBranchDiscountList(BranchId);
            txtName.Text = _branchDiscountContent.BranchDiscountContentName;
            txtCode.Text = _branchDiscountContent.BranchDiscountContentCode;
            txtDescription.Text = _branchDiscountContent.BranchDiscountContentDescription;
            cbbBranchDiscount.SelectedValue = _branchDiscountContent.BranchDiscountId;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = branchDiscountContentManager.Update(new Entities.Concrete.BranchDiscountContent
            {
                BranchDiscountContentName = txtName.Text,
                BranchDiscountContentCode = txtCode.Text,
                BranchDiscountContentDescription = txtDescription.Text,
                BranchDiscountId = Convert.ToInt32(cbbBranchDiscount.SelectedValue),
                BranchDiscountContentId = _branchDiscountContent.BranchDiscountContentId
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
